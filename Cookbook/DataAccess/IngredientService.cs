using Cookbook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cookbook.DataAccess
{
    class IngredientService
    {
        public tblIngredient AddIngredient(tblIngredient ingredient)
        {
            try
            {
                using (CookbookDatabaseEntities context = new CookbookDatabaseEntities())
                {

                    tblIngredient newIngredient = new tblIngredient();
                    newIngredient.IngredientName = ingredient.IngredientName;
                    newIngredient.tblRecipe = ingredient.tblRecipe;

                    context.tblIngredients.Add(newIngredient);
                    context.SaveChanges();
                    MessageBox.Show("Ingredient successfully added to recipe!", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
                    return newIngredient;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblIngredient> GetAllIngredients()
        {
            try
            {
                using (CookbookDatabaseEntities context = new CookbookDatabaseEntities())
                {
                    return (from x in context.tblIngredients
                            select x).ToList();
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
