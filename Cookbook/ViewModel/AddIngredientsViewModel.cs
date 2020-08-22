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
        public bool IngredientsAdded = false;

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

        private bool milk;

        public bool Milk
        {
            get { return milk; }
            set
            {
                milk = value;
                OnPropertyChanged("Milk");
            }
        }


        private bool sugar;

        public bool Sugar
        {
            get { return sugar; }
            set
            {
                sugar = value;
                OnPropertyChanged("Sugar");
            }
        }

        private bool mayo;

        public bool Mayo
        {
            get { return mayo; }
            set
            {
                mayo = value;
                OnPropertyChanged("Mayo");
            }
        }

        private bool ketchup;

        public bool Ketchup
        {
            get { return ketchup; }
            set
            {
                ketchup = value;
                OnPropertyChanged("Ketchup");
            }
        }

        private bool egg;

        public bool Egg
        {
            get { return egg; }
            set
            {
                egg = value;
                OnPropertyChanged("Egg");
            }
        }

        private bool flour;

        public bool Flour
        {
            get { return flour; }
            set
            {
                flour = value;
                OnPropertyChanged("Flour");
            }
        }

        private bool salt;

        public bool Salt
        {
            get { return salt; }
            set
            {
                salt = value;
                OnPropertyChanged("Salt");
            }
        }

        private bool tomato;

        public bool Tomato
        {
            get { return tomato; }
            set
            {
                tomato = value;
                OnPropertyChanged("Tomato");
            }
        }


        private bool mushrooms;

        public bool Mushrooms
        {
            get { return mushrooms; }
            set
            {
                mushrooms = value;
                OnPropertyChanged("Mushrooms");
            }
        }


        private bool cheese;

        public bool Cheese
        {
            get { return cheese; }
            set
            {
                cheese = value;
                OnPropertyChanged("Cheese");
            }
        }


        private bool ham;

        public bool Ham
        {
            get { return ham; }
            set
            {
                ham = value;
                OnPropertyChanged("Ham");
            }
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

                if (Milk == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Milk");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Sugar == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Sugar");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Mayo == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Mayonnaise");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Ketchup == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Ketchup");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Egg == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Egg");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Flour == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Flour");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Salt == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Salt");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Tomato == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Tomato");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Mushrooms == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Mushroom");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Cheese == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Cheese");
                    Recipe.tblIngredients.Add(ingredient);
                }
                if (Ham == true)
                {
                    tblIngredient ingredient = ingredientService.GetIngredientByName("Ham");
                    Recipe.tblIngredients.Add(ingredient);
                }

                IngredientsAdded = true;
                MessageBox.Show("Intgredients Choosed Successfully!");


                view.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            if (Egg == false && Flour == false && Salt == false && Mayo == false
                 && Sugar == false && Milk == false && Ham == false
                && Ketchup == false && Mushrooms == false &&
                Cheese == false && Tomato == false)
            {
                return false;
            }
            return true;
        }
    }



}
