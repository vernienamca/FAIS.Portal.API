using System;
using FAIS.ApplicationCore.Interfaces;
using FAIS.ApplicationCore.Services;
using FAIS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAIS.ApplicationCore.Entities.Structure;

namespace ApplicationCoreTests.Services
{
    [TestClass]
    public class SettingsServiceServiceTests
    {
        private IModuleRepository _repository;
        private IModuleService _service;
        private FAISContext _context;

        private DbContextOptionsBuilder<FAISContext> _builder;

        [TestInitialize]
        public void Initialize()
        {
            _builder = new DbContextOptionsBuilder<FAISContext>();
            _builder.UseInMemoryDatabase("TestDB" + Guid.NewGuid().ToString());

            _context = new FAISContext(_builder.Options);
            _repository = new ModuleRepository(_context);
            _service = new ModuleService(_repository);
        }

        [TestMethod]
        public void CreateRepository()
        {
            Assert.IsNotNull(_service);
            Assert.IsInstanceOfType(_service, typeof(IModuleService));
        }
    }
}
