using System.Net;

namespace Clean_Api.Common.Errors
{
    public class DuplicateEmailException : Exception
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Email already exists.";
    }
}

