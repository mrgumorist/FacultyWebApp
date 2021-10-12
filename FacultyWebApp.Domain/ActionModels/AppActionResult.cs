using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Domain.ActionModels
{
    public class AppActionResult
    {
        public bool IsSuccessful { get; set; } = false;
        public string Message { get; set; }
        public object ResObj { get; set; }

        public int StatusCode { get; set; }

        public AppActionResult()
        {

        }

        public AppActionResult(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }

        public AppActionResult(bool isSuccessful, string message, object resObj)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            ResObj = resObj;
        }

        public AppActionResult(bool isSuccessful, string message, object resObj, int statusCode)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            ResObj = resObj;
            StatusCode = statusCode;
        }
    }
}
