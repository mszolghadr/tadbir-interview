using System;
using Microsoft.EntityFrameworkCore;
using tadbir.Data;
using tadbir.Entities;
using tadbir.Repository;
using Xunit;
namespace tadbir.Tests
{
    public static class TestSeed
    {
        private static TadbirDbContext _context;
        public static TadbirDbContext Context
        {
            get
            {
                var options = new DbContextOptionsBuilder<TadbirDbContext>()
                 .UseInMemoryDatabase(databaseName: "InterviewDataBase")
                 .Options;
                return _context ??= new TadbirDbContext(options);
            }
        }
    }
}
