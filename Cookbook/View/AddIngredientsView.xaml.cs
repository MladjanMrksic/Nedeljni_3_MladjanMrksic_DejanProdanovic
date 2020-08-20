using Cookbook.Model;
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
    /// Interaction logic for AddIngredientsView.xaml
    /// </summary>
    public partial class AddIngredientsView : Window
    {
        public AddIngredientsView(tblRecipe recipe)
        {
            DataContext = new AddIngredientsViewModel(this, recipe);
            InitializeComponent();
        }
    }
}
