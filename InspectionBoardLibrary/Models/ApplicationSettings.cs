using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models
{
    public static class ApplicationSettings
    {
        public static User CurrentUser { get; set; }
        public static string settingsFileDefaultPath;

        public static async void SetUsername(string newUsername)
        {
            UserRepository repository = new UserRepository(new ExamContext());
            CurrentUser.Username = newUsername;
            await repository.Update(CurrentUser);
        }

        public static async void SetPassword(string newPassword)
        {
            UserRepository repository = new UserRepository(new ExamContext());
            CurrentUser.Password = newPassword;
            await repository.Update(CurrentUser);
        }
    }
}
