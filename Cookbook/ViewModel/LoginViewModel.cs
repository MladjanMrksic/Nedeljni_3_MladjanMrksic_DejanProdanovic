using Cookbook.Command;
using Cookbook.DataAccess;
using Cookbook.Model;
using Cookbook.Validation;
using Cookbook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cookbook.ViewModel
{
    class LoginViewModel:ViewModelBase
    {
        LoginView view;

        IPersonService personService;


        public LoginViewModel(LoginView loginView)
        {
            view = loginView;

            personService = new PersonService();


        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string someProperty]
        {
            get
            {

                return string.Empty;
            }
        }



        private ICommand submitCommand;
        public ICommand SubmitCommand
        {
            get
            {
                if (submitCommand == null)
                {
                    submitCommand = new RelayCommand(Submit);
                    return submitCommand;
                }
                return submitCommand;
            }
        }

        void Submit(object obj)
        {

            string encryptedString = (obj as PasswordBox).Password;

            string password = EncryptionHelper.Encrypt(encryptedString);

            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(encryptedString))
            {
                MessageBox.Show("Wrong user name or password");
                return;
            }
            if (UserName.Equals("Admin") && !encryptedString.Equals("Admin123"))
            {
                MessageBox.Show("Wrong password for Admin");
                return;
            }

            if (UserName.Equals("Admin") && encryptedString.Equals("Admin123"))
            {
                tblPerson adminInDb =
                    personService.GetUserByUserNameAndPass(UserName, password);

                if (adminInDb == null)
                {
                    tblPerson admin = new tblPerson();
                    admin.Username = UserName;
                    admin.Password = password;
                    adminInDb = personService.AddUser(admin);
                    AdminMainView adminMain = new AdminMainView(adminInDb);
                    adminMain.Show();
                    view.Close();
                    return;
                }
                else
                {
                    AdminMainView adminMain = new AdminMainView(adminInDb);
                    adminMain.Show();
                    view.Close();
                    return;
                }

            }
            tblPerson userInDb = personService.GetUserByUserName(UserName);


            if (userInDb == null)
            {
                FirstLogin firstLogin = new FirstLogin(UserName, password);
                firstLogin.Show();
                view.Close();
                return;
            }
            else
            {
                if (!userInDb.Password.Equals(password))
                {
                    MessageBox.Show("Wrong password for this user");
                    return;
                }
                tblPerson p;
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {
                    p = (from x in context.tblPersons where x.Username == UserName select x).First();
                }
                UserMain main = new UserMain(p);
                main.Show();

                view.Close();
                return;
            }

        }
    }
}
