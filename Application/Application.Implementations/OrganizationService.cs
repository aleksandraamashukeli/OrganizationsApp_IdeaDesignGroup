using Application.Common.Models.Organization;
using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Domain.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        public IMapper Mapper { get; }
        public IUnitOfWork UnitOfWork { get; }

        public OrganizationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }


        public IEnumerable<GetOrganizationDTO> Get(int pageNumber,string searchText)
        {
            var pageSize = 3;
            try
            {
                using (UnitOfWork)
                {
                    var organizations = UnitOfWork.OrganizationRepository.Get();


                    if (!String.IsNullOrWhiteSpace(searchText))
                    {
                        organizations = organizations.Where(o =>
                         o.Name.ToLower().Contains(searchText.ToLower()) ||
                         o.Address.ToLower().Contains(searchText.ToLower()) ||
                         o.Activitie.ToLower().Contains(searchText.ToLower())
                         );
                    }
                 

                    if (pageNumber !=0 )
                    {
                        organizations = organizations
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize);
                        return Mapper.Map<IEnumerable<GetOrganizationDTO>>(organizations);
                    }
                    else
                    {
                        return Mapper.Map<IEnumerable<GetOrganizationDTO>>(organizations);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GetOrganizationDTO> GetById(int id)
        {
            try
            {
                using (UnitOfWork)
                {
                    var organization = await UnitOfWork.OrganizationRepository.Get(id);
                    return Mapper.Map<GetOrganizationDTO>(organization);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Create(CreateOrganizationDTO dto)
        {
            try
            {
                using (UnitOfWork)
                {
                    var organization = Mapper.Map<Organization>(dto);
                    await UnitOfWork.OrganizationRepository.Insert(organization);
                    UnitOfWork.Save();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(UpdateOrganizationDTO dto)
        {
            try
            {
                using (UnitOfWork)
                {
                    var organization = Mapper.Map<Organization>(dto);
                    UnitOfWork.OrganizationRepository.Update(organization);
                    UnitOfWork.Save();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  async Task Delete(int id)
        {
            try
            {
                using (UnitOfWork)
                {
                    await UnitOfWork.OrganizationRepository.Delete(id);
                    UnitOfWork.Save();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task AddPersonToOrganization(int organizationId, int personId)
        {
            try
            {

                using (UnitOfWork)
                {
                    var organizationPerson = new OrganizationPerson() { OrganizationId = organizationId, PersonId = personId };
                    await UnitOfWork.OrganizationPersonRepository.Insert(organizationPerson);

                    UnitOfWork.Save();

                }
           
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetOrganizationDTO> GetPersonOrganizations(int personid)
        {
            try
            {
                using (UnitOfWork)
                {
                    var organizationpeople = UnitOfWork.OrganizationPersonRepository.Get().Where(o => o.PersonId == personid);
                    var organizations = UnitOfWork.OrganizationRepository.Get().Where(o => organizationpeople.Any(op => op.OrganizationId.Equals(o.Id)));
                    return Mapper.Map<IEnumerable<GetOrganizationDTO>>(organizations);
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
                    return UnitOfWork.OrganizationRepository.GetCount();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


