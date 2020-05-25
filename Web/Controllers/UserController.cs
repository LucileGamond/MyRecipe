using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service;
using Web.Models;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;



namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            this.userService = userService;
            this.userProfileService = userProfileService;
        }



        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();
            var users = userService.GetUsers().ToList();
                
            users.ForEach(u =>
            {
                UserProfileEntity userProfile = userProfileService.GetUserProfile(u.Id);
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                };
                model.Add(user);
            });

            return View(model);
        }




        [HttpGet]
        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();

            return PartialView("_AddUser", model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            UserEntity userEntity = new UserEntity
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = model.Password,
                UserProfile = new UserProfileEntity
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName             
                }
            };
            userService.InsertUser(userEntity);
            if (userEntity.Id != Guid.Empty)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }



        public ActionResult EditUser(Guid id)
        {
            UserViewModel model = new UserViewModel();
            if (id != Guid.Empty)
            {
                UserEntity userEntity = userService.GetUser(id);
                UserProfileEntity userProfileEntity = userProfileService.GetUserProfile(id);
                model.FirstName = userProfileEntity.FirstName;
                model.LastName = userProfileEntity.LastName;
                model.Email = userEntity.Email;
            }
            return PartialView("_EditUser", model);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel model)
        {
            UserEntity userEntity = userService.GetUser(model.Id);
            userEntity.Email = model.Email;
            UserProfileEntity userProfileEntity = userProfileService.GetUserProfile(model.Id);
            userProfileEntity.FirstName = model.FirstName;
            userProfileEntity.LastName = model.LastName;
            userEntity.UserProfile = userProfileEntity;
            userService.UpdateUser(userEntity);
            if (userEntity.Id != Guid.Empty)
            {
                return RedirectToAction("index");
            }
            return View(model);
        }



        [HttpGet]
        public PartialViewResult DeleteUser(Guid id)
        {
            UserEntity user = userService.GetUser(id);
            UserViewModel uservm = new UserViewModel();
            uservm.UserName = user.UserName;
            uservm.Id = user.Id ;
            return PartialView("_DeleteUser", uservm);
        }

        [HttpPost]
        public ActionResult DoDeleteUser(Guid id)
        {
            userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}