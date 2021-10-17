using Application.Common.Models.Person;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrganizationsApp.Models.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public IMapper Mapper { get; }
        public IPersonService PersonService { get; }
        public int PageSize { get; set; }

        public PersonController(IMapper mapper, IPersonService personService)
        {
            Mapper = mapper;
            PersonService = personService;
            PageSize = 3;
        }



        [HttpGet]
        [Route("Count")]
        public int GetCount()
        {
            try
            {
                return (int)Math.Ceiling((double)PersonService.GetCount() / PageSize);
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpGet]
        [Route("GetForOrganization/{id}")]
        public string GetForOrganization(int id)
        {
            try
            {
                var personDTOs = PersonService.GetForOrganization(id);
                var personViewModels = Mapper.Map<IEnumerable<GetPersonViewModel>>(personDTOs);
                var response = JsonConvert.SerializeObject(personViewModels);
                return response;
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
                var personDTOs = PersonService.Get(pageNumber,searchText);
                var personViewModels = Mapper.Map<IEnumerable<GetPersonViewModel>>(personDTOs);
                var response = JsonConvert.SerializeObject(personViewModels);
                return response;
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
                var personDTO = await PersonService.GetById(id);
                var personViewModel = Mapper.Map<GetPersonViewModel>(personDTO);
               
                return JsonConvert.SerializeObject(personViewModel);
            }   
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("Update")]
        public async Task Update([FromBody] UpdatePersonViewModel person)
        {
            try
            {
                var personDTO = Mapper.Map<UpdatePersonDTO>(person);
                await PersonService.Update(personDTO);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        [Route("Delete/{id}")]
        public async Task Delete( int id)
        {
            try
            {
               await PersonService.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        [Route("Create")]
        public async Task Create([FromBody] CreatePersonViewModel person)
        {
            try
            {
                var personDTO = Mapper.Map<CreatePersonDTO>(person);
                await PersonService.Create(personDTO);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
