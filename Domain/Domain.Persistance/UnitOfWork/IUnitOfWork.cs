using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Organization> OrganizationRepository { get; }
        public IRepository<OrganizationPerson> OrganizationPersonRepository { get; }
        public IRepository<Person> PersonRepository { get; }
        void Save();
    }
}
