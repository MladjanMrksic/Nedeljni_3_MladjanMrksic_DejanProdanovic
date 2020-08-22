using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cookbook.Model;

namespace Cookbook.DataAccess
{
    class RecipeService : IRecipeService
    {
        public tblRecipe AddNewRecipe(tblRecipe recipe)
        {
            try
            {
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {

                    tblRecipe newRecipe = new tblRecipe
                    {
                        RecipeName = recipe.RecipeName,
                        RecipeType = recipe.RecipeType,
                        IntendedFor = recipe.IntendedFor,
                        Author = recipe.Author,
                        Description = recipe.Description,
                        DateCreated = recipe.DateCreated,



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
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {
                    
                    context.tblRecipes.Remove((from x in context.tblRecipes
                                               where x.RecipeID == ID
                                               select x).FirstOrDefault());
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
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
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

        public List<vwRecipe> GetAllvwRecipes()
        {
            try
            {
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {
                    return (from x in context.vwRecipes
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
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
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
                using (CookbookDatabaseEntities1 context = new CookbookDatabaseEntities1())
                {
                    tblRecipe recipe = (from x in context.tblRecipes
                                        where x.RecipeID == Updated.RecipeID
                                        select x).First();
                    recipe.RecipeName = Updated.RecipeName;
                    recipe.DateCreated = Updated.DateCreated;
                    recipe.IntendedFor = Updated.IntendedFor;
                    recipe.Description = Updated.Description;
                    recipe.RecipeType = Updated.RecipeType;
                    recipe.tblIngredients = Updated.tblIngredients;
                    context.SaveChanges();
                    MessageBox.Show("Recipe successfully updated!", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
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
