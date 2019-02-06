using System;
using FuzjaApi.Domain.UnitOfWork;

namespace FuzjaApi.Infrastructure.Domain
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly FuzjaApiDbContext _context;

        public UnitOfWork(FuzjaApiDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception exceptionEF)
            {
                throw new Exception(exceptionEF.Message);
            }
        }
    }
}
