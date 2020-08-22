using Cookbook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.DataAccess
{
    interface IRecipeService
    {
        List<tblRecipe> GetAllRecipes();
        List<vwRecipe> GetAllvwRecipes();
        tblRecipe GetRecipeByID(int ID);
        tblRecipe AddNewRecipe(tblRecipe recipe);
        tblRecipe UpdateRecipe(tblRecipe recipe);
        void DeleteRecipe(int ID);
    }
}
