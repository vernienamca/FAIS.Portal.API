using System;
using System.Globalization;
using System.Net;

namespace FAIS.ApplicationCore.BusinessRules
{
    public abstract class BusinessRulesException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }

        protected BusinessRulesException(HttpStatusCode statusCode) : base() { StatusCode = statusCode; }

        protected BusinessRulesException(HttpStatusCode statusCode, string message) : base(message) { StatusCode = statusCode; }

        protected BusinessRulesException(HttpStatusCode statusCode, bool isSuccess, string message)
            : base(message)
        {
            StatusCode = statusCode;
            IsSuccess = isSuccess;
        }

        public BusinessRulesException(HttpStatusCode statusCode, bool isSuccess, string message, params object[] args)
            :base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
            StatusCode = statusCode;
            IsSuccess = isSuccess;
        }
    }
}
