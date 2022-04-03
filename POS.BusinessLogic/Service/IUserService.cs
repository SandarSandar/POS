using POS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.BusinessLogic.Service
{
    public interface IUserService
    {
        List<UserModel> GetUserList();

        bool SaveUser(UserModel userModel);
    }
}
