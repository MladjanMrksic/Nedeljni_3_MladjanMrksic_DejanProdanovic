﻿using Cookbook.Model;
using Cookbook.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cookbook.View
{
    /// <summary>
    /// Interaction logic for AdminMainView.xaml
    /// </summary>
    public partial class AdminMainView : Window
    {
        public AdminMainView()
        {
            InitializeComponent();
        }
        public AdminMainView(tblPerson person)
        {
            InitializeComponent();
            DataContext = new AdminMainViewModel(this, person);
        }

        private void TextBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView((DataContext as AdminMainViewModel).RecipeList);
            view.Filter = o => (o as vwRecipe).RecipeName.Contains((sender as TextBox).Text);
        }

        private void TextBoxType_TextChanged(object sender, TextChangedEventArgs e)
        {
            var view = CollectionViewSource.GetDefaultView((DataContext as AdminMainViewModel).RecipeList);
            view.Filter = o => (o as vwRecipe).RecipeType.Contains((sender as TextBox).Text);
        }
    }
}
