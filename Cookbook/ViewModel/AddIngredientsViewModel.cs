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
                if (view.Salt.IsChecked == true)
                {
                    tblIngredient Salt = new tblIngredient();
                    Salt.IngredientName = "Salt";
                    Recipe.tblIngredients1.Add(Salt);
                }
                if (view.Milk.IsChecked == true)
                {
                    tblIngredient Milk = new tblIngredient();
                    Milk.IngredientName = "Milk";
                    Recipe.tblIngredients1.Add(Milk);
                }
                if (view.Sugar.IsChecked == true)
                {
                    tblIngredient Sugar = new tblIngredient();
                    Sugar.IngredientName = "Sugar";
                    Recipe.tblIngredients1.Add(Sugar);
                }
                if (view.Tomato.IsChecked == true)
                {
                    tblIngredient Tomato = new tblIngredient();
                    Tomato.IngredientName = "Tomato";
                    Recipe.tblIngredients1.Add(Tomato);
                }
                if (view.Mayonnaise.IsChecked == true)
                {
                    tblIngredient Mayonnaise = new tblIngredient();
                    Mayonnaise.IngredientName = "Mayonnaise";
                    Recipe.tblIngredients1.Add(Mayonnaise);
                }
                if (view.Ketchup.IsChecked == true)
                {
                    tblIngredient Ketchup = new tblIngredient();
                    Ketchup.IngredientName = "Ketchup";
                    Recipe.tblIngredients1.Add(Ketchup);
                }
                if (view.Cheese.IsChecked == true)
                {
                    tblIngredient Cheese = new tblIngredient();
                    Cheese.IngredientName = "Cheese";
                    Recipe.tblIngredients1.Add(Cheese);
                }
                if (view.Egg.IsChecked == true)
                {
                    tblIngredient Egg = new tblIngredient();
                    Egg.IngredientName = "Egg";
                    Recipe.tblIngredients1.Add(Egg);
                }
                if (view.Ham.IsChecked == true)
                {
                    tblIngredient Ham = new tblIngredient();
                    Ham.IngredientName = "Ham";
                    Recipe.tblIngredients1.Add(Ham);
                }
                if (view.Flour.IsChecked == true)
                {
                    tblIngredient Flour = new tblIngredient();
                    Flour.IngredientName = "Flour";
                    Recipe.tblIngredients1.Add(Flour);
                }

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
