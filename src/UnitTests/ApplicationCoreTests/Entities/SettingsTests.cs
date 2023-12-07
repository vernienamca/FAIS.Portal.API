using System;
using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FAIS.ApplicationCoreTests.Entities
{
    [TestClass]
    public class SettingsTests
    {
        [TestMethod]
        public void CreateEntity()
        {
            var entity = new Settings()
            {
                Id = 1,
                FromEmail = "donotreply-pvao@gmail.com",
                FromName = "Philippine Veterans Affairs Office (PVAO)",
                ServerName = "smtp.gmail.com",
                SMTPPort = 587,
                Username = "donotreply-pvao@gmail.com",
                Password = "$P2==YQBY4",
                EnableSSL = true,
                MaxSignOnAttempts = 4,
                ExpiresIn = 45,
                MinPasswordLength = 10,
                MinSpecialCharacters = 2,
                EnforcePasswordHistory = 2,
                CreatedBy = 1,
                DateCreated = DateTime.Parse("2/21/2021 11:30:23 AM"),
                UpdatedBy = 1,
                DateUpdated = DateTime.Parse("2/21/2021 12:34:00 PM"),
            };

            Assert.IsNotNull(entity);
            Assert.AreEqual(1, entity.Id);
            Assert.AreEqual("donotreply-pvao@gmail.com", entity.FromEmail);
            Assert.AreEqual("Philippine Veterans Affairs Office (PVAO)", entity.FromName);
            Assert.AreEqual("smtp.gmail.com", entity.ServerName);
            Assert.AreEqual(587, entity.SMTPPort);
            Assert.AreEqual("donotreply-pvao@gmail.com", entity.Username);
            Assert.AreEqual("$P2==YQBY4", entity.Password);
            Assert.AreEqual(true, entity.EnableSSL);
            Assert.AreEqual(4, entity.MaxSignOnAttempts);
            Assert.AreEqual(45, entity.ExpiresIn);
            Assert.AreEqual(10, entity.MinPasswordLength);
            Assert.AreEqual(2, entity.MinSpecialCharacters);
            Assert.AreEqual(2, entity.EnforcePasswordHistory);
            Assert.AreEqual(1, entity.CreatedBy);
            Assert.AreEqual(DateTime.Parse("2/21/2021 11:30:23 AM"), entity.DateCreated);
            Assert.AreEqual(1, entity.UpdatedBy);
            Assert.AreEqual(DateTime.Parse("2/21/2021 12:34:00 PM"), entity.DateUpdated);
        }
    }
}
