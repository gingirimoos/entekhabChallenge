using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Application.UseCases.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace WebApi.Utilities
{
    public class RawRequestBodyFormatter : InputFormatter
    {
        public RawRequestBodyFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            var dataContentType = context.HttpContext.GetRouteValue("datatype")?.ToString();
            if (dataContentType == null)
            {
                return await InputFormatterResult.SuccessAsync(request);
            }
            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();
                var payload = JsonConvert.DeserializeObject<Payload>(content);
                var overTimeCalculator = payload.OverTimeCalculator;
                switch (dataContentType)
                {
                    case "json":
                        payload = JsonConvert.DeserializeObject<Payload>(payload.Data);
                        break;
                    case "xml":
                    {
                        var xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(payload.Data);
                        var json = JsonConvert.SerializeXmlNode(xmlDocument);
                        var purifiedJson = json.Substring(json.IndexOf(':') + 1, json.Length - (json.IndexOf(':') + 2));
                        payload = JsonConvert.DeserializeObject<Payload>(purifiedJson);
                        break;
                    }
                    case "cs":
                    {
                        payload = JsonConvert.DeserializeObject<Payload>(Converter.ConvertCsvToJsonObject(payload.Data));
                        break;
                    }
                    case "custom":
                    {
                        payload = JsonConvert.DeserializeObject<Payload>(Converter.ConvertCustomToJsonObject(payload.Data));
                        break;
                    }
                }

                payload.OverTimeCalculator = overTimeCalculator;
                return await InputFormatterResult.SuccessAsync(payload);
            }
        }
    }
}
