using FacultyWebApp.BLL.DTOs;
using FacultyWebApp.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacultyWebApp.BLL.Interfaces
{
    public interface ISheduleService
    {
        void AddToShudule(SheduleDTO sheduleItemDTO);
        List<SheduleItemResponseModel> GetShedule(int groupId);
        List<SheduleItemResponseModel> GetShedule();
    }
}
