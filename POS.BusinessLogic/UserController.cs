using POS.BusinessLogic.Services;
using POS.DAL;
using POS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BusinessLogic
{
    public class UserController: IUserService
    {
        UserDataController userDataController;

        public UserController()
        {
            userDataController = new UserDataController();
        }

        public bool CheckUserAlreadyExists(UserModel userModel)
        {
            List<UserModel> userList = userDataController.GetUserList();
            bool userExits = userList.Where(u => u.Email.Equals(userModel.Email)).Any();
            return userExits;
        }

        public bool DeleteUserById(string Id)
        {
            return userDataController.DeleteUserById(Id);
        }

        public UserModel GetUserById(string userId)
        {
            return userDataController.GetUserById(userId);
        }

        public List<UserModel> GetUserList()
        {
            return userDataController.GetUserList();
        }

        public UserModel LoginUser(UserModel userModel)
        {
            return userDataController.GetUserByUserNameAndPassword(userModel.UserName, userModel.Password);
        }

        public bool SaveUser(UserModel userModel)
        {           
            return userDataController.SaveUser(userModel);
        }

        public bool UpdateUser(UserModel userModel)
        {
            return userDataController.UpdateUser(userModel);
        }

    }
}
