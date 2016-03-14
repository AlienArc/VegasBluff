using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Bluff.Views
{
    /// <summary>
    /// Interaction logic for AboutBluff.xaml
    /// </summary>
    public partial class AboutBluff : Window
    {
        
        public string Version
        {
            get { return (string)GetValue(VersionProperty); }
            set { SetValue(VersionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Version.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VersionProperty =
            DependencyProperty.Register("Version", typeof(string), typeof(AboutBluff), new PropertyMetadata(string.Empty));


        public AboutBluff()
        {
            InitializeComponent();
            var assembly = Assembly.GetExecutingAssembly();
            Version = assembly.GetName().Version.ToString();

        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
