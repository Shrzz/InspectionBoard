using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class ExamService
    {
        private readonly IRepository<Exam> repository;

        public ExamService()
        {
            repository = new ExamRepository(new ExamContext());
        }

        public async Task<bool> HasStudentEntries(int id)
        {
            foreach (var item in await repository.Select())
            {
                if (item.Student.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task RemoveAllStudentEntries(int id)
        {
            foreach (var item in await repository.Select())
            {
                if (item.Student.Id == id)
                {
                    await repository.Remove(item.Id);
                }
            }
        }

        public async Task<bool> HasTeacherEntries(int id)
        {
            foreach (var item in await repository.Select())
            {
                if (item.Teacher.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task RemoveAllTeacherEntries(int id)
        {
            foreach (var item in await repository.Select())
            {
                if (item.Teacher.Id == id)
                {
                    await repository.Remove(id);
                }
            }
        }

        public async Task<bool> HasSubjectEntries(int id)
        {
            foreach (var item in await repository.Select())
            {
                if (item.Subject.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task RemoveAllSubjectEntries(int id)
        {
            foreach (var item in await repository.Select())
            {
                if (item.Subject.Id == id)
                {
                    await repository.Remove(id);
                }
            }
        }

        public async Task<bool> HasTicketEntries(int id)
        {
            foreach (var item in await repository.Select())
            {
                if (item.Ticket.Id == id)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task RemoveAllTicketEntries(int id)
        {
            foreach (var item in await repository.Select())
            {
                if (item.Ticket.Id == id)
                {
                    await repository.Remove(id);
                }
            }
        }

    }
}
