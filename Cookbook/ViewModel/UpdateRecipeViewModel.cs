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
    class UpdateRecipeViewModel : ViewModelBase
    {
        UpdateRecipeView view;
        RecipeService recipeService = new RecipeService();

        public UpdateRecipeViewModel(UpdateRecipeView urv, tblRecipe rec,tblPerson personLogedIn)
        {
            view = urv;
            Recipe = rec;
            User = personLogedIn;
        }

        private tblRecipe recipe;
        public tblRecipe Recipe
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

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        private void SaveExecute()
        {
            try
            {
                if (Recipe.IntendedFor == null)
                {
                    MessageBox.Show("IntendedFor must be integer number");
                    return;
                }
                Recipe.DateCreated = DateTime.Now;
                Recipe.Author = User.PersonID;
                recipeService.UpdateRecipe(Recipe);
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanSaveExecute()
        {
            if (string.IsNullOrEmpty(Recipe.RecipeName) ||
               string.IsNullOrEmpty(Recipe.RecipeType) || string.IsNullOrEmpty(Recipe.Description))
            {
                return false;
            }
            return true;
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            try
            {
                view.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }

        private ICommand addIngredients;
        public ICommand AddIngredients
        {
            get
            {
                if (addIngredients == null)
                {
                    addIngredients = new RelayCommand(param => AddIngredientsExecute(), param => CanAddIngredientsExecute());
                }
                return addIngredients;
            }
        }
        private void AddIngredientsExecute()
        {
            try
            {
                AddIngredientsView ingredientsView = new AddIngredientsView(Recipe);
                ingredientsView.ShowDialog();
                //if ((ingredientsView.DataContext as AddIngredientsViewModel).IngredientsAdded == true)
                //{
                //    hasIngredients = true;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanAddIngredientsExecute()
        {
            return true;
        }
    }
}
