using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Model;

namespace Cookbook.DataAccess
{
    class RecipeService : IRecipeService
    {
        public tblRecipe AddNewRecipe(tblRecipe recipe)
        {
            try
            {
                using (CookbookDatabaseEntities context = new CookbookDatabaseEntities())
                {
                    tblRecipe newRecipe = new tblRecipe
                    {
                        RecipeName = recipe.RecipeName,
                        RecipeType = recipe.RecipeType,
                        IntendedFor = recipe.IntendedFor,
                        Author = recipe.Author,
                        Description = recipe.Description,
                        DateCreated = recipe.DateCreated,
                        tblIngredients = recipe.tblIngredients,
                        tblPerson = recipe.tblPerson,
                        tblShoppingLists = recipe.tblShoppingLists
                    };
                    context.tblRecipes.Add(newRecipe);
                    context.SaveChanges();

                    return newRecipe;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteRecipe(int ID)
        {
            try
            {
                using (CookbookDatabaseEntities context = new CookbookDatabaseEntities())
                {
                    context.tblRecipes.Remove((from x in context.tblRecipes
                                               where x.RecipeID == ID
                                               select x).First());
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());               
            }
        }

        public List<tblRecipe> GetAllRecipes()
        {
            try
            {
                using (CookbookDatabaseEntities context = new CookbookDatabaseEntities())
                {
                    return (from x in context.tblRecipes
                            select x).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblRecipe GetRecipeByID(int ID)
        {
            try
            {
                using (CookbookDatabaseEntities context = new CookbookDatabaseEntities())
                {
                    return (from x in context.tblRecipes
                            where x.RecipeID == ID
                            select x).First();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblRecipe UpdateRecipe(tblRecipe Updated)
        {
            try
            {
                using (CookbookDatabaseEntities context = new CookbookDatabaseEntities())
                {
                    tblRecipe recipe = (from x in context.tblRecipes
                                        where x.RecipeID == Updated.RecipeID
                                        select x).First();
                    recipe = Updated;
                    context.SaveChanges();
                    return recipe;
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
