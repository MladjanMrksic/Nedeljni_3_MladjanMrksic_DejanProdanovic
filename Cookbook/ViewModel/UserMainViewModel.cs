using Cookbook.Command;
using Cookbook.DataAccess;
using Cookbook.Model;
using Cookbook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cookbook.ViewModel
{
    class UserMainViewModel : ViewModelBase
    {
        UserMain view;
        RecipeService recipeService = new RecipeService();
        public UserMainViewModel(UserMain um, tblPerson p)
        {
            view = um;
            User = p;
            RecipeList = recipeService.GetAllvwRecipes();
            Recipe = new vwRecipe();
        }

        //private List<tblRecipe> recipeList;

        //public List<tblRecipe> RecipeList
        //{
        //    get { return recipeList; }
        //    set { recipeList = value; OnPropertyChanged("RecipeList"); }
        //}

        private List<vwRecipe> recipeList;

        public List<vwRecipe> RecipeList
        {
            get { return recipeList; }
            set { recipeList = value; OnPropertyChanged("RecipeList"); }
        }

        private vwRecipe recipe;

        public vwRecipe Recipe
        {
            get { return recipe; }
            set { recipe = value; OnPropertyChanged("Recipe"); }
        }




        private tblPerson user;
        public tblPerson User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }

        private ICommand deleteRecipe;
        public ICommand DeleteRecipe
        {
            get
            {
                if (deleteRecipe == null)
                {
                    deleteRecipe = new RelayCommand(param => DeleteRecipeExecute(), param => CanDeleteRecipeExecute());
                }
                return deleteRecipe;
            }
        }
        private void DeleteRecipeExecute()
        {
            try
            {
                if (Recipe != null)
                {
                    int recipeID = Recipe.RecipeID;
                    recipeService.DeleteRecipe(recipeID);
                    RecipeList = recipeService.GetAllvwRecipes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanDeleteRecipeExecute()
        {
            if (Recipe == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand updateRecipe;
        public ICommand UpdateRecipe
        {
            get
            {
                if (updateRecipe == null)
                {
                    updateRecipe = new RelayCommand(param => UpdateRecipeExecute(), param => CanUpdateRecipeExecute());
                }
                return updateRecipe;
            }
        }
        private void UpdateRecipeExecute()
        {
            try
            {
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {
                    tblRecipe recipeToUpdate = ConvertTotblRepcipe(Recipe);
                    UpdateRecipeView recipeView = new UpdateRecipeView(recipeToUpdate,User);
                    recipeView.ShowDialog();
                    RecipeList = recipeService.GetAllvwRecipes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanUpdateRecipeExecute()
        {
            if (Recipe == null)
            {
                return false;
            }
            else if (Recipe.PersonID == User.PersonID || User.Username.Equals("Admin"))
            {
                return true;
            }

            else
                return false;
        }

        private ICommand addRecipe;
        public ICommand AddRecipe
        {
            get
            {
                if (addRecipe == null)
                {
                    addRecipe = new RelayCommand(param => AddRecipeExecute(), param => CanAddRecipeExecute());
                }
                return addRecipe;
            }
        }
        private void AddRecipeExecute()
        {
            try
            {
                AddRecipeView addView = new AddRecipeView(User);
                addView.ShowDialog();
                RecipeList = recipeService.GetAllvwRecipes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanAddRecipeExecute()
        {
            return true;
        }

        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            try
            {
                LoginView login = new LoginView();
                login.Show();
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanLogoutExecute()
        {
            return true;
        }

        private tblRecipe ConvertTotblRepcipe(vwRecipe vwRecipe)
        {
            tblRecipe tblRecipe = new tblRecipe();
            tblRecipe.RecipeID = vwRecipe.RecipeID;
            tblRecipe.RecipeName = vwRecipe.RecipeName;
            tblRecipe.RecipeType = vwRecipe.RecipeType;
            tblRecipe.RecipeType = vwRecipe.RecipeType;
            tblRecipe.IntendedFor = vwRecipe.IntendedFor;
            tblRecipe.Author = vwRecipe.PersonID;
            tblRecipe.Description = vwRecipe.Description;
            tblRecipe.DateCreated = vwRecipe.DateCreated;

            return tblRecipe;


        }
    }
}
