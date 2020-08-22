using Cookbook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.DataAccess
{
    interface IPersonService
    {
        tblPerson GetUserByUserNameAndPass(string userName, string password);
        tblPerson GetUserByUserName(string userName);
        tblPerson AddUser(tblPerson user);
    }
}
