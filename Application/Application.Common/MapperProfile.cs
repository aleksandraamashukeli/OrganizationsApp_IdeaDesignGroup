using Application.Common.Models.Organization;
using Application.Common.Models.Person;
using AutoMapper;
using Domain.Models;

namespace Application.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            ///OrganizationDTO -> Organization
            CreateMap<Organization, GetOrganizationDTO>();
            CreateMap<CreateOrganizationDTO, Organization>();
            CreateMap<UpdateOrganizationDTO, Organization>();
            CreateMap<DeleteOrganizationDTO, Organization>();


            ///PersonDTO -> Person
            CreateMap<Person, GetPersonDTO>();
            CreateMap<CreatePersonDTO, Person>();
            CreateMap<UpdatePersonDTO, Person>();
            CreateMap<DeletePersonDTO, Person>();
        }
    }
}
