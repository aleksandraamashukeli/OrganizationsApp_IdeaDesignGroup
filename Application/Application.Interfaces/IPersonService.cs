using Application.Common.Models.Person;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPersonService
    {
        public IEnumerable<GetPersonDTO> Get(int pageNumber,string searchText);
        public Task<GetPersonDTO> GetById(int id);

        public IEnumerable<GetPersonDTO> GetForOrganization(int organizationId);

        public int GetCount();
        public Task Create(CreatePersonDTO dto);

        public Task Update(UpdatePersonDTO dto);

        public Task Delete(int Id);
    }
}
