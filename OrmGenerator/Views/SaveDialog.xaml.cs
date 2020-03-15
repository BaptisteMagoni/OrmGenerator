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

namespace OrmGenerator.Views
{
    /// <summary>
    /// Logique d'interaction pour SaveDialog.xaml
    /// </summary>
    public partial class SaveDialog : Window
    {

        public string SaveName { get; set; }

        public SaveDialog()
        {
            InitializeComponent();
        }

        private void TextBox_Save_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Button_Validate.IsEnabled = !string.IsNullOrEmpty(TextBox_Save_Name.Text);
        }

        private void Button_Validate_Click(object sender, RoutedEventArgs e)
        {
            SaveName = TextBox_Save_Name.Text;
            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
