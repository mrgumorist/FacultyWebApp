using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.Domain.ActionModels
{
    public class AppActionResult
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public object ResObj { get; set; }

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
    }
}
