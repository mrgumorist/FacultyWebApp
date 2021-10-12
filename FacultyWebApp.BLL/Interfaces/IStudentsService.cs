using FacultyWebApp.Domain.ActionModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FacultyWebApp.BLL.Interfaces
{
    public interface IStudentsService
    {
        public AppActionResult GetUserById(int id);
        public Task<AppActionResult> GetUserByIdAsync(int id);
    }
}
