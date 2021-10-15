using FacultyWebApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace FacultyWebApp.DAL.Seeder
{
    public class MainPropsSeeder
    {
        public static void SeedStudents(ApplicationDbContext context)
        {
            if (context.Students.SingleOrDefault(c => c.Name== "Viktor" && c.PhoneNum=="+380631199999") == null)
            {
                context.Students.Add(new Entities.Student
                {
                    Name = "Viktor",
                    Surname = "Crook",
                    EducationTypeId = context.EducationTypes.Single(x => x.Id ==1).Id,
                    GroupId = context.Groups.Single(x => x.Id == 1).Id,
                    EntryYear = 2020,
                    IsDeducted = false,
                    PhoneNum = "+380631199999"
                });
                context.SaveChanges();
            }

            if (context.Students.SingleOrDefault(c => c.Name == "Michel" && c.PhoneNum == "+380531111111") == null)
            {
                context.Students.Add(new Entities.Student
                {
                    Name = "Michel",
                    Surname = "Crook",
                    EducationTypeId = context.EducationTypes.Single(x => x.Id == 2).Id,
                    GroupId = context.Groups.Single(x => x.Id == 2).Id,
                    EntryYear = 2019,
                    IsDeducted = false,
                    PhoneNum = "+380531111111"
                });
                context.SaveChanges();
            }
        }

        /*public static void SeedParsingUserSettings(AppDbContext context)
        {
            if (context.SettingsProps.SingleOrDefault(c => c.Name == "ParserUserName") == null)
            {
                context.SettingsProps.Add(new Entities.SettingsProp
                {
                    Name = "ParserUserName",
                    Value = "mrgumor@gmail.com"
                });
                context.SaveChanges();
            }

            if (context.SettingsProps.SingleOrDefault(c => c.Name == "ParserUserPassword") == null)
            {
                context.SettingsProps.Add(new Entities.SettingsProp
                {
                    Name = "ParserUserPassword",
                    Value = "r!4vcBzVy8"
                });
                context.SaveChanges();
            }

            if (context.SettingsProps.SingleOrDefault(c => c.Name == "UserToken") == null)
            {
                context.SettingsProps.Add(new Entities.SettingsProp
                {
                    Name = "UserToken",
                    Value = ""
                });
                context.SaveChanges();
            }

            if (context.SettingsProps.SingleOrDefault(c => c.Name == "LastParseDate") == null)
            {
                context.SettingsProps.Add(new Entities.SettingsProp
                {
                    Name = "LastParseDate",
                    Value = ""
                });
                context.SaveChanges();
            }
        }*/
    }
}
