using Application.Common.Models.Organization;
using Application.Common.Models.Person;
using AutoMapper;
using OrganizationsApp.Models.Organization;
using OrganizationsApp.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationsApp
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            ///OrganizationViewModel -> OrganizationDTO
            ///
            CreateMap<GetOrganizationDTO, GetOrganizationViewModel>();

            CreateMap<GetOrganizationViewModel, GetOrganizationDTO>();
            CreateMap<CreateOrganizationViewModel, CreateOrganizationDTO>();
            CreateMap<UpdateOrganizationViewModel, UpdateOrganizationDTO>();
            CreateMap<DeleteOrganizationViewModel, DeleteOrganizationDTO>();

            ///PersonViewModel -> PersonDTO
            ///

            CreateMap<GetPersonDTO, GetPersonViewModel>();


            CreateMap<GetPersonViewModel, GetPersonDTO>();
            CreateMap<CreatePersonViewModel, CreatePersonDTO>();
            CreateMap<UpdatePersonViewModel, UpdatePersonDTO>();
            CreateMap<DeletePersonViewModel, DeletePersonDTO>();
        }
        

    }
}
