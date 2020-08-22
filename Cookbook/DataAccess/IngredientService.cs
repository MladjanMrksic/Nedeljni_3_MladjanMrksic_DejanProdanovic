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

        public List<tblIngredient> GetAllIngredients()
        {
            try
            {
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
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
        public tblIngredient GetIngredientByName(string name)
        {
            try
            {
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {
                    return (from x in context.tblIngredients
                            where x.IngredientName.Equals(name)
                            select x).First();
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