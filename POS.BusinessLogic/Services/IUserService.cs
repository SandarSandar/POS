using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BusinessLogic.Services
{
    public interface IUserService
    {
        List<UserModel> GetUserList();
        bool SaveUser(UserModel userModel);

        bool UpdateUser(UserModel UserModel);

        bool DeleteUserById(string Id);

        UserModel GetUserById(string userId);

        UserModel LoginUser(UserModel userModel);
    }
}
