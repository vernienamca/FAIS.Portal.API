using Microsoft.VisualStudio.TestTools.UnitTesting;
using FAIS.ApplicationCore.Entities.Security;

namespace FAIS.ApplicationCoreTests.Entities
{
    [TestClass]
    public class TokenOptionsTests
    {
        [TestMethod]
        public void CreateEntity()
        {
            var entity = new TokenKeys()
            {
                Issuer = "http://localhost:55653",
                Audience = "http://localhost:55653",
                ExpiresInMinutes = 30
            };

            Assert.IsNotNull(entity);
            Assert.AreEqual("http://localhost:55653", entity.Issuer);
            Assert.AreEqual("http://localhost:55653", entity.Audience);
            Assert.AreEqual(30, entity.ExpiresInMinutes);

        }
    }
}
