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
    public class ApplicationSettings
    {
        private readonly ExamContext context;
        public User CurrentUser { get; set; }
        public string settingsFileDefaultPath;


        public ApplicationSettings(User user, ExamContext context)
        {
            CurrentUser = user;
            this.context = context;
        }
            
        public async void SetUsername(string newUsername)
        {
            UserRepository repository = new UserRepository(this.context);
            CurrentUser.Username = newUsername;
            await repository.Update(CurrentUser);
        }

        public async void SetPassword(string newPassword)
        {
            UserRepository repository = new UserRepository(this.context);
            CurrentUser.Password = newPassword;
            await repository.Update(CurrentUser);
        }
    }
}
