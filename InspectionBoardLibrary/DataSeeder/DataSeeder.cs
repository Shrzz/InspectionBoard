using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Extensions;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.DataSeeder
{
    public class DataSeeder
    {
        public async Task AddAdminUser()
        {
            UserService service = new UserService();
            if (service.TableIsEmpty())
            {
                User u = new User();
                u.Username = "admin";
                u.Password = "admin";
                await service.AddAsync(u);
            }
        }

        public async Task AddStudent()
        {
            StudentService service = new StudentService();
            if (service.TableIsEmpty())
            {
                Student s = new Student();
                s.Id = 0;
                s.Surname = "Качалов";
                s.Name = "Дмитрий";
                s.Patronymic = "Геннадьевич";
                s.Group = service.SelectGroups().FirstOrDefault();
                await service.AddAsync(s);
            }
        }

        public async Task AddFaculties()
        {
            var service = new GroupService();
            if (service.TableIsEmpty())
            {
                var group = new Group();
                group.Id = 0;
                group.Name = "72491";
                group.Faculty = "ПОИТ";
                await service.AddAsync(group);

                group = new Group();
                group.Id = 1;
                group.Name = "72492";
                group.Faculty = "ПОИТ";
                await service.AddAsync(group);

                group = new Group();
                group.Id = 2;
                group.Name = "71691";
                group.Faculty = "КСИС";
                await service.AddAsync(group);

                group = new Group();
                group.Id = 3;
                group.Name = "73213";
                group.Faculty = "РИЭ";
                await service.AddAsync(group);
            }
        }  
    }
}
