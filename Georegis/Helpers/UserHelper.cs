using Context;
using Georegis.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Entities;
using Common;
namespace Georegis.Helpers
{

    public class UserHelper
    {

        [Authorize]
        static public CurrentUserViewModel GetCurrentUser(string login)
        {
            NpgsqlContext dbContext = new NpgsqlContext();
            CurrentUserViewModel userVM = new CurrentUserViewModel();
            User user = new User();
            try 
            {
                if (string.IsNullOrEmpty(login))
                    throw new ValidateException("Не указан логин", "");
                user = dbContext.Users.FirstOrDefault(x => x.Login.Equals(login));
                if (user == null)
                    throw new ValidateException("Пользователь не найден", "");
            }
            catch
            {
                userVM.FullName = "Пользоваель не найден";
                userVM.Id = -1;
            }
            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, CurrentUserViewModel>()
            .ForMember(dest => dest.Department, opt => opt.Ignore()));
            var mapper = config.CreateMapper();
            userVM = mapper.Map<User, CurrentUserViewModel>(user);
            userVM.Department = new DepartmentViewModel();
            if (user.Department != null)
            {
                userVM.Department.Id = user.Department.Id;
                userVM.Department.CodeId = user.Department.CodeId;
                userVM.Department.DepartmentCode = user.Department.DepartmentCode;
                userVM.Department.DepartmentPrefix = user.Department.DepartmentPrefix;
                userVM.Department.Description = user.Department.Description;
                userVM.Department.Title = user.Department.Title;
            }
            return userVM;
        }

    }
}