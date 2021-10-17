using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Models.Organization;
using OrganizationsApp.Models.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrganizationsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        public IMapper Mapper { get; }
        public IOrganizationService OrganizationService { get; }

        public int PageSize { get; set; }
        public OrganizationController(IMapper mapper,IOrganizationService organizationService)
        {
            Mapper = mapper;
            OrganizationService = organizationService;
            PageSize = 3;
        }


        [HttpGet]
        [Route("Count")]
        public int GetCount()
        {
            try
            {
                return (int)Math.Ceiling((double)OrganizationService.GetCount() / PageSize);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<string> GetById(int id)
        {
            try
            {
                var organizationDTO =await  OrganizationService.GetById(id);
                var organizationViewModel = Mapper.Map<GetOrganizationViewModel>(organizationDTO);
                return JsonConvert.SerializeObject(organizationViewModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("Get/{pageNumber}")]
        public string Get(int pageNumber,[FromQuery] string searchText)
        {
            try
            {
                var organizationDTOs = OrganizationService.Get(pageNumber, searchText);
                var organizationViewModels = Mapper.Map<IEnumerable<GetOrganizationViewModel>>(organizationDTOs);
                return JsonConvert.SerializeObject(organizationViewModels); ;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("GetPersonOrganizations/{id}")]
        public async Task<string> GetPersonOrganizations(int id)
        {
            try
            {
                var organizationDTOs =  OrganizationService.GetPersonOrganizations(id);
                var organizationViewModels = Mapper.Map<IEnumerable<GetOrganizationViewModel>>(organizationDTOs);
                return JsonConvert.SerializeObject(organizationViewModels);
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPost]
        [Route("Update")]
        public async Task Update([FromBody] UpdateOrganizationViewModel organization)
        {
            try
            {
                var organizationDTO = Mapper.Map<UpdateOrganizationDTO>(organization);
                await OrganizationService.Update(organizationDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await OrganizationService.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task Create([FromBody] CreateOrganizationViewModel organization)
        {
            try
            {
                var organizationDTO = Mapper.Map<CreateOrganizationDTO>(organization);
                await OrganizationService.Create(organizationDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("AddPersonToOrganization")]
        public async Task AddPersonToOrganization([FromBody] AddPersonToOrganizationViewModel model)
        {
            try
            {
                await OrganizationService.AddPersonToOrganization(model.OrganizationId, model.PersonId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
