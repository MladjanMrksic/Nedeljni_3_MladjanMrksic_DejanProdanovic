using Cookbook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.DataAccess
{
    class PersonService:IPersonService
    {
        public tblPerson AddUser(tblPerson user)
        {
            try
            {
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {

                    tblPerson newUser = new tblPerson();
                    newUser.Username = user.Username;
                    newUser.Password = user.Password;
                    newUser.FirstName = user.FirstName;
                    newUser.LastName = user.LastName;

                    context.tblPersons.Add(newUser);
                    context.SaveChanges();

                    return newUser;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPerson GetUserByUserName(string userName)
        {
            try
            {
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {


                    tblPerson user = (from x in context.tblPersons
                                      where x.Username == userName 
                                      
                                      select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPerson GetUserByUserNameAndPass(string userName, string password)
        {
            try
            {
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {


                    tblPerson user = (from x in context.tblPersons
                                      where x.Username == userName &&
                                      x.Password == password
                                      select x).First();

                    return user;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
