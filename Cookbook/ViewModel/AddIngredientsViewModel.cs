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
    class AddIngredientsViewModel : ViewModelBase
    {
        AddIngredientsView view;
        IngredientService ingredientService = new IngredientService();
        public AddIngredientsViewModel(AddIngredientsView aiv, tblRecipe rec)
        {
            view = aiv;
            Recipe = rec;
            IngredientsList = ingredientService.GetAllIngredients();
            newIngredient = new tblIngredient();
            Ingredient = new tblIngredient();
        }

        private tblRecipe recipe;
        public tblRecipe Recipe
        {
            get { return recipe; }
            set { recipe = value; OnPropertyChanged("Recipe"); }
        }

        private List<tblIngredient> ingredientsList;
        public List<tblIngredient> IngredientsList
        {
            get { return ingredientsList; }
            set { ingredientsList = value; OnPropertyChanged("IngredientsList"); }
        }

        private tblIngredient ingredient;
        public tblIngredient Ingredient
        {
            get { return ingredient; }
            set { ingredient = value; OnPropertyChanged("Ingredient"); }
        }

        private tblIngredient newIngredient;
        public tblIngredient NewIngredient
        {
            get { return newIngredient; }
            set { newIngredient = value; OnPropertyChanged("NewIngredient"); }
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

        private ICommand add;
        public ICommand Add
        {
            get
            {
                if (add == null)
                {
                    add = new RelayCommand(param => AddExecute(), param => CanAddExecute());
                }
                return add;
            }
        }
        private void AddExecute()
        {
            try
            {
                NewIngredient = Ingredient;
                //NewIngredient.tblRecipe = Recipe;
                //ingredientService.AddIngredient(newIngredient);
                IngredientsList = ingredientService.GetAllIngredients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message.ToString());
            }
        }
        private bool CanAddExecute()
        {
            //if ((from x in IngredientsList where x.IngredientName == Ingredient.IngredientName && x.tblRecipe == Recipe select x).FirstOrDefault() == null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return true;
        }
    }



}
