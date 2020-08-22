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
    class AddRecipeViewModel : ViewModelBase
    {
        AddRecipeView view;
        RecipeService recipeService = new RecipeService();
        public AddRecipeViewModel(AddRecipeView arv, tblPerson p)
        {
            view = arv;
            User = p;
            Recipe = new tblRecipe();
        }

        private tblPerson user;
        public tblPerson User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }

        private tblRecipe recipe;
        public tblRecipe Recipe
        {
            get { return recipe; }
            set { recipe = value; OnPropertyChanged("Recipe"); }
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
                Recipe.DateCreated = DateTime.Now;
                Recipe.tblPerson = User;
                recipeService.AddNewRecipe(Recipe);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanSaveExecute()
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
