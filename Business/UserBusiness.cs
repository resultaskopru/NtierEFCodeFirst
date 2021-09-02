using Data.Models;
using DataAccess.Auth;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        public User Authentication(StringValues values)
        {
            User user = null;
            UserDataAccess userDataAccess = new();
            user = userDataAccess.Authentication(values, user);
            return user;
        }
    }
}
