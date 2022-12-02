using AutoMapper;

namespace Application.Common.Mappings
{
    public interface IMapFrom<Source,Destination>
    {   
        void Mapping(Profile profile) => profile.CreateMap(typeof(Source),typeof(Destination));
    }
}
