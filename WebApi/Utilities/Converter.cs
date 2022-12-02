using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WebApi.Utilities
{
    public static class Converter
    {
        public static string ConvertCsvToJsonObject(string data)
        {
            var lines = data.Split('\n');
            var csv = lines.Select(line => line.Split(',')).ToList();
            var properties = lines[0].Split(',');
            var listObjResult = new List<Dictionary<string, string>>();
            for (var i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (var j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);
                listObjResult.Add(objResult);
            }
            return JsonConvert.SerializeObject(listObjResult.First());
        }

        public static string ConvertCustomToJsonObject(string data)
        {
            var lines = data.Split('\n');
            var csv = lines.Select(line => line.Split('/')).ToList();
            var properties = lines[0].Split('/');
            var listObjResult = new List<Dictionary<string, string>>();
            for (var i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (var j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);
                listObjResult.Add(objResult);
            }
            return JsonConvert.SerializeObject(listObjResult.First());
        }
    }
}