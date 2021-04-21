using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
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
            UserRepository repository = new UserRepository(new UserContext());
            if (repository.TableIsEmpty())
            {
                User u = new User();
                u.Username = "admin";
                u.Password = "admin";
                await repository.Add(u);
            }
        }

        public async Task AddGroups()
        {
            GroupRepository repository = new GroupRepository(new ExamContext());
            if (repository.TableIsEmpty())
            {
                var group = new Group();
                group.Id = 0;
                group.Name = "72491";
                group.Faculty = "ПОИТ";
                await repository.Add(group);

                group = new Group();
                group.Id = 1;
                group.Name = "72492";
                group.Faculty = "ПОИТ";
                await repository.Add(group);

                group = new Group();
                group.Id = 2;
                group.Name = "71691";
                group.Faculty = "КСИС";
                await repository.Add(group);

                group = new Group();
                group.Id = 3;
                group.Name = "73213";
                group.Faculty = "РИЭ";
                await repository.Add(group);
            }
        }

        public async Task AddStudent()
        {
            StudentRepository repository = new StudentRepository(new ExamContext());
            if (repository.TableIsEmpty())
            {
                Student s = new Student();
                s.Id = 0;
                s.Surname = "Качалов";
                s.Name = "Дмитрий";
                s.Patronymic = "Геннадьевич";
                var groups = await repository.SelectGroups();
                s.Group = groups.FirstOrDefault();
                await repository.Add(s);
            }
        }

 
    }
}
