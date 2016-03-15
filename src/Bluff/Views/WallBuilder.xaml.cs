using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bluff.Bezier;
using Bluff.VideoWall;

namespace Bluff.Views
{
    /// <summary>
    /// Interaction logic for WallBuilder.xaml
    /// </summary>
    public partial class WallBuilder : Window
    {
        public WallBuilder(WallBuilderConfiguration configuration)
        {
            InitializeComponent();
            DataContext = Configuration = configuration;            
        }
        
        public WallBuilderConfiguration Configuration { get; }

        private void DecimalOnlyPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var val = 0m;
            var testText = e.Text;
            var sourceText = ((TextBox)sender).Text;

            if (string.IsNullOrEmpty(testText))
            {
                e.Handled = true;
            }

            if (testText == ".")
            {
                testText += "0";
            }

            if (decimal.TryParse(sourceText + testText, out val))
                return;

            e.Handled = true;

        }
        private void IntegerOnlyPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var val = 0;
            var testText = e.Text;
            var sourceText = ((TextBox)sender).Text;

            if (string.IsNullOrEmpty(testText))
            {
                e.Handled = true;
            }

            if (testText == ".")
            {
                testText += "0";
            }

            if (int.TryParse(sourceText + testText, out val))
                return;

            e.Handled = true;

        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Ok_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
