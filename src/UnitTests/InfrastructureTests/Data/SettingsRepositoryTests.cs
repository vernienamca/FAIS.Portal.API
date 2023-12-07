using FAIS.ApplicationCore.Entities.Structure;
using FAIS.ApplicationCore.Interfaces;
using FAIS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InfrastructureTests.Data
{
    [TestClass]
    public class SettingsRepositoryTests
    {
        private IModuleRepository _repository;
        private FAISContext _context;
        private DbContextOptionsBuilder<FAISContext> _builder;

        [TestInitialize]
        public void Initialize()
        {
            _builder = new DbContextOptionsBuilder<FAISContext>();
            _builder.UseInMemoryDatabase("TestDB" + Guid.NewGuid().ToString());

            _context = new FAISContext(_builder.Options);
            _repository = new ModuleRepository(_context);
        }
    }
}
