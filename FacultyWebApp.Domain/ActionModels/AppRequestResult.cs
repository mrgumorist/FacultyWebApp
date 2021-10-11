using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Domain.ActionModels
{
    public class AppRequestResult: AppActionResult
    {
        public int StatusCode { get; set; }

        public AppRequestResult(bool isSuccessful, string message, int statusCode)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            StatusCode = statusCode;
        }

        public AppRequestResult(bool isSuccessful, string message, object resObj, int statusCode)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            ResObj = resObj;
            StatusCode = statusCode;
        }
    }
}
