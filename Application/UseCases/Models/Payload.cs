using System;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Aggregates.Person;
using Lib.Swagger;

namespace Application.UseCases.Models
{
    public class Payload: IMapFrom<Payload, Person>, IMapFrom<Payload, PaymentInformation>
    {
        public string Data { get; set; }
        public string OverTimeCalculator { get; set; }


        [SwaggerExclude]
        public string FirstName { get; set; }
        [SwaggerExclude]
        public string LastName { get; set; }
        [SwaggerExclude]
        public double BasicSalary { get; set; }
        [SwaggerExclude]
        public double Allowance { get; set; }
        [SwaggerExclude]
        public double Transportation { get; set; }
        [SwaggerExclude]
        public string Date { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Payload, PaymentInformation>()
                .IgnoreAllNonExisting(); 
            profile.CreateMap<Payload, Person>()
                .IgnoreAllNonExisting();
        }
    }
}