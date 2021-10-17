using Application.Common.Models.Organization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrganizationService
    {
        public IEnumerable<GetOrganizationDTO> Get(int pageNumber,string SearchText);
        public Task<GetOrganizationDTO> GetById(int id);

        public int GetCount();
        public Task Create(CreateOrganizationDTO dto);

        public Task Update(UpdateOrganizationDTO dto);

        public Task Delete(int id);

        public Task AddPersonToOrganization(int organizationId, int personId);

        public IEnumerable<GetOrganizationDTO> GetPersonOrganizations(int personid);


    }
}
