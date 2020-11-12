using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.WebModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IUserService
    {
        //TODO: Change all the User domain models with appropriate ViewModel!!!

        void Register(RegisterViewModel registerModel);
        void Login(LoginViewModel loginModel, out bool isAdmin);
        void Logout();
        UserViewModel GetCurrentUser(string username);
    }
}
