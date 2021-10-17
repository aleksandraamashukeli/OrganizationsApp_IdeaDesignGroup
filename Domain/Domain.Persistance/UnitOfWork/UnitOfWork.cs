using Domain.Models;
using Infrastructure.EF;
using System;

namespace Domain.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {

        private bool disposed;
        private IRepository<Person> personRepository;
        private IRepository<Organization> organizationRepository;
        private IRepository<OrganizationPerson> organizationPersonRepository;
        public DBContext DBContext { get; set; }



        public UnitOfWork(DBContext dBContext)
        {
            disposed = false;
            DBContext = dBContext;
        }


        public IRepository<Person> PersonRepository
        {
            get
            {

                if (personRepository == null)
                {
                    personRepository = new Repository<Person>(DBContext);
                }
                return personRepository;
            }
        }

        public IRepository<Organization> OrganizationRepository
        {
            get
            {
                if (organizationRepository == null)
                {
                    organizationRepository = new Repository<Organization>(DBContext);
                }
                return organizationRepository;

            }
        }

        public IRepository<OrganizationPerson> OrganizationPersonRepository
        {
            get
            {
                if (organizationPersonRepository == null)
                {
                    organizationPersonRepository = new Repository<OrganizationPerson>(DBContext);
                }
                return organizationPersonRepository;

            }
        }



        public void Save()
        {
            DBContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DBContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
