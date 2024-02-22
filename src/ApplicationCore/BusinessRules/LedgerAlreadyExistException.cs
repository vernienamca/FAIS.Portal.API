using System.Net;

namespace FAIS.ApplicationCore.BusinessRules
{
    public class LedgerAlreadyExistException : BusinessRulesException
    {
        private const string message = "Ledger already exists.";
        private const bool isSucess = false;

        public LedgerAlreadyExistException() : base(HttpStatusCode.BadRequest, isSucess, message) { }
    }
}
