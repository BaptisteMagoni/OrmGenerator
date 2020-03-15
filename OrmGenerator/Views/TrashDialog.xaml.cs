using ModuleOrmGenerator.Class;
using ModuleOrmGenerator.Class.Model;
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
    /// Logique d'interaction pour TrashDialog.xaml
    /// </summary>
    public partial class TrashDialog : Window
    {

        public string Path { get; set; }
        public List<SaveConfigModel> NewSaveConfig { get; set; }

        public TrashDialog(string Path)
        {
            InitializeComponent();

            this.Path = Path;

            foreach (var item in JsonMethod<SaveConfigModel>.ReadAllDataJson(this.Path))
            {
                ComboBox_Configuration_Save.Items.Add(item.Name);
            }

        }

        private void ComboBox_Configuration_Save_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Button_Validate.IsEnabled = !string.IsNullOrEmpty(ComboBox_Configuration_Save.SelectedItem.ToString());
        }

        private void Button_Validate_Click(object sender, RoutedEventArgs e)
        {

            List<SaveConfigModel> saves = JsonMethod<SaveConfigModel>.ReadAllDataJson(Path);
            SaveConfigModel save = saves.Where(x => x.Name == ComboBox_Configuration_Save.SelectedItem.ToString()).FirstOrDefault();
            saves.Remove(save);

            JsonMethod<SaveConfigModel>.WriteDataJson(Path, JsonMethod<SaveConfigModel>.AddData(saves));

            NewSaveConfig = saves;

            this.Close();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
