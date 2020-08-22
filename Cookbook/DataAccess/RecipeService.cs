﻿using System;
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
                using (CookbookDatabaseEntities context = new CookbookDatabaseEntities())
                {
                    tblRecipe newRecipe = new tblRecipe();
                    newRecipe.RecipeName = recipe.RecipeName;
                    newRecipe.RecipeType = recipe.RecipeType;
                    newRecipe.IntendedFor = recipe.IntendedFor;
                    newRecipe.Description = recipe.Description;
                    newRecipe.DateCreated = DateTime.Now;
                    newRecipe.tblPerson = recipe.tblPerson;
                    newRecipe.Author = recipe.tblPerson.PersonID;
                    //{
                    //    RecipeName = recipe.RecipeName,
                    //    RecipeType = recipe.RecipeType,
                    //    IntendedFor = recipe.IntendedFor,
                    //    Author = recipe.Author,
                    //    Description = recipe.Description,
                    //    DateCreated = recipe.DateCreated,
                    //    //tblIngredients = recipe.tblIngredients,
                    //    tblPerson = recipe.tblPerson,
                    //    //tblShoppingLists = recipe.tblShoppingLists
                    //};
                    context.tblRecipes.Add(newRecipe);
                    context.SaveChanges();
                    MessageBox.Show("Recipe successfully added to recipe!", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    List < tblIngredient > list = (from x in context.tblIngredients where x.tblRecipe.RecipeID == ID select x).ToList();
                    foreach (var i in list)
                    {
                        context.tblIngredients.Remove(i);
                    }
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
