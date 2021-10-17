using Application.Common.Models.Person;
using Application.Interfaces;
using AutoMapper;
using Domain.Persistance;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Application.Implementations
{
    public class PersonService : IPersonService
    {
        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }

        public PersonService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }


        public async Task Create(CreatePersonDTO dto)
        {
            try
            {
                using (UnitOfWork)
                {
                    var person = Mapper.Map<Person>(dto);
                    await UnitOfWork.PersonRepository.Insert(person);
                    UnitOfWork.Save();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                using (UnitOfWork)
                {
                    await UnitOfWork.PersonRepository.Delete(id);
                    UnitOfWork.Save();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetPersonDTO> Get(int pageNumber, string searchText)
        {
            var pageSize = 3;

            try
            {
                using (UnitOfWork)
                {
                    var people = UnitOfWork.PersonRepository.Get();

                    if (!String.IsNullOrWhiteSpace(searchText))
                    {
                        people = people.Where(p =>
                           p.FirstName.ToLower().Contains(searchText.ToLower()) ||
                           p.LastName.ToLower().Contains(searchText.ToLower()) ||
                           p.PersonalId.ToLower().Contains(searchText.ToLower())
                           );
                    }
               


                    if (pageNumber != 0)
                    {
                       people = people
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
                        return Mapper.Map<IEnumerable<GetPersonDTO>>(people);
                    }
                    else
                    {
                        return Mapper.Map<IEnumerable<GetPersonDTO>>(people);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCount()
        {
            try
            {
                using (UnitOfWork)
                {
                    return UnitOfWork.PersonRepository.GetCount();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public async Task<GetPersonDTO> GetById(int id)
        {
            try
            {
                using (UnitOfWork)
                {
                    var person = await UnitOfWork.PersonRepository.Get(id);
                    var personDTO = Mapper.Map<GetPersonDTO>(person);
                    return personDTO;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(UpdatePersonDTO dto)
        {
            try
            {
                using (UnitOfWork)
                {
                    var person = Mapper.Map<Person>(dto);
                    UnitOfWork.PersonRepository.Update(person);
                    UnitOfWork.Save();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetPersonDTO> GetForOrganization(int organizationId)
        {
            try
            {
                using (UnitOfWork)
                {
                    var organizationpeople = UnitOfWork.OrganizationPersonRepository.Get().Where(o => o.OrganizationId == organizationId);


                    var people = UnitOfWork.PersonRepository.Get().Where(p => organizationpeople.All(p2 => p2.PersonId != p.Id));
                    return Mapper.Map<IEnumerable<GetPersonDTO>>(people);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
