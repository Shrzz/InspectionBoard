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
                s.Faculty = service.SelectFaculties().FirstOrDefault();
                s.EducationForm = service.SelectEducationForms().FirstOrDefault();
                await service.AddAsync(s);
            }
        }

        public async Task AddEducationForms()
        {
            var service = new EducationFormService();
            if (service.TableIsEmpty())
            {
                var educationForm = new EducationForm();
                educationForm.Id = 0;
                educationForm.Form = "Бюджетная";
                await service.AddAsync(educationForm);

                educationForm = new EducationForm();
                educationForm.Id = 1;
                educationForm.Form = "Платная";
                await service.AddAsync(educationForm);
            }

        }

        public async Task AddExamTypes()
        {
            var service = new ExamTypeService();
            if (service.TableIsEmpty())
            {
                ExamType type = new ExamType();
                type.Id = 0;
                type.Type = "Вступительный";
                await service.AddAsync(type);

                type = new ExamType();
                type.Id = 1;
                type.Type = "Промежуточный";
                await service.AddAsync(type);

                type = new ExamType();
                type.Id = 2;
                type.Type = "Итоговый";
                await service.AddAsync(type);
            }

        }

        public async Task AddExamForms()
        {
            var service = new ExamFormService();
            if (service.TableIsEmpty())
            {
                var form = new ExamForm();
                form.Id = 0;
                form.Form = "Письменный";
                await service.AddAsync(form);

                form = new ExamForm();
                form.Id = 1;
                form.Form = "Устный";
                await service.AddAsync(form);
            }
        }

        public async Task AddFaculties()
        {
            var service = new FacultyService();
            if (service.TableIsEmpty())
            {
                var faculty = new Faculty();
                faculty.Id = 0;
                faculty.Name = "ПОИТ";
                await service.AddAsync(faculty);

                faculty = new Faculty();
                faculty.Id = 1;
                faculty.Name = "КСИС";
                await service.AddAsync(faculty);

                faculty = new Faculty();
                faculty.Id = 2;
                faculty.Name = "РИЭ";
                await service.AddAsync(faculty);

                faculty = new Faculty();
                faculty.Id = 3;
                faculty.Name = "ИЭФ";
                await service.AddAsync(faculty);
            }
        }

        public async Task AddCategories()
        {
            var service = new CategoryService();
            if (service.TableIsEmpty())
            {
                var category = new Category();
                category.Id = 0;
                category.Name = "Без категории";
                category.Multiplier = "1";
                await service.AddAsync(category);

                category = new Category();
                category.Id = 1;
                category.Name = "Первая";
                category.Multiplier = "1.10";
                await service.AddAsync(category);

                category = new Category();
                category.Id = 2;
                category.Name = "Вторая";
                category.Multiplier = "1.25";
                await service.AddAsync(category);

                category = new Category();
                category.Id = 3;
                category.Name = "Высшая";
                category.Multiplier = "1.5";
                await service.AddAsync(category);
            }
        }
    }
}
