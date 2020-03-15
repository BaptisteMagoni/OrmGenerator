using ModuleOrmGenerator.Class;
using ModuleOrmGenerator.Class.Model;
using ModuleOrmGenerator.ConfigurationLangue;
using ModuleOrmGenerator.dal;
using ModuleOrmGenerator.dal.constant;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrmGenerator.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace OrmGenerator
{
    /// <summary>
    /// Logique d'interaction pour Configuration.xaml
    /// </summary>
    public partial class Configuration : Window
    {

        private Langue langue { get; set; }
        public SqlconnectorType CurrentConnectorType { get; set; }
        public List<TableModel> TableModels { get; set; }
        public ConnectionString ConnectionString { get; set; }
        public string Path { get; set; }
        public List<dynamic> Saves { get; set; }

        public Configuration()
        {
            InitializeComponent();
            TableModels = new List<TableModel>();
            langue = new Langue();
            LoadComboBoxSqlType();
            LoadSaveConfiguration();
        }

        private void TextBox_Database_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool state = TextBox_IP.Text.Length > 0;
            ComboBox_SqlType.IsEnabled = state;
            Label_TypeBDD.IsEnabled = state;
            CheckBox_Authentification.IsEnabled = state;

            if (!state)
                LoadComboBoxSqlType();
        }

        private void ComboBox_SqlType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_SqlType.SelectedItem != null)
            {
                CheckBox_Authentification.IsEnabled = !string.IsNullOrEmpty(ComboBox_SqlType.SelectedItem.ToString());
                CurrentConnectorType = (SqlconnectorType)ComboBox_SqlType.SelectedItem;
            }

        }

        private void CheckBox_Authentification_Checked(object sender, RoutedEventArgs e)
        {
            bool state = CheckBox_Authentification.IsChecked.Value;
            TextBox_Username.IsEnabled = !state;
            TextBox_Password.IsEnabled = !state;
            Label_Username.IsEnabled = !state;
            Label_Password.IsEnabled = !state;
            CheckBox_Authentification.Content = state ? langue.Authentification_CheckBox_Enable : langue.Authentification_CheckBox_Disable;
        }

        private void LoadComboBoxSqlType()
        {
            ComboBox_SqlType.Items.Clear();
            foreach (SqlconnectorType item in (SqlconnectorType[])Enum.GetValues(typeof(SqlconnectorType)))
                ComboBox_SqlType.Items.Add(item);
        }

        private void LoadSaveConfiguration()
        {

            Path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OrmGenerator\\";

            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            if (!File.Exists(Constant.FILE_NAME_SAVE_CONFIGURATION))
            {
                File.Create(Constant.FILE_NAME_SAVE_CONFIGURATION);
            }

            Path += Constant.FILE_NAME_SAVE_CONFIGURATION;

            foreach(var item in ReadAllDataJson(Path))
            {
                ComboBox_Connection_Save.Items.Add(item.name);
            }

        }

        private void Button_Finish_Click(object sender, RoutedEventArgs e)
        {

            if (CheckIfHaveAlreadyInformation())
            {
                ConnectionString = new ConnectionString()
                {
                    Address = TextBox_IP.Text,
                    Database = string.Empty,
                    Username = TextBox_Username.Text,
                    Password = TextBox_Password.Text,
                };

                DAOFactory dao = new DAOFactory()
                {
                    DataConnection = ConnectionString
                };

                Object connection = dao.GetConnection(CurrentConnectorType);

                if (connection != null)
                {
                    List<string> tables = dao.GetDAOTable().GetAllDataBase(CurrentConnectorType, connection);
                    if (tables.Count > 0)
                    {
                        foreach (string item in tables)
                        {
                            TableModels.Add(new TableModel()
                            {
                                Name = item
                            });
                        }
                    }
                    MessageBox.Show(langue.Authentification_BDD_OK);
                }
                else
                {
                    MessageBox.Show(langue.Authentification_BDD_NOK);
                    Application.Current.Shutdown();
                }
                this.Close();
            }
        }

        private void ComboBox_Connection_Save_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string saveName = ComboBox_Connection_Save.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(saveName))
            {
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private bool CheckIfHaveAlreadyInformation()
        {
            bool state = false;

            state = !string.IsNullOrEmpty(TextBox_IP.Text);
            state = !string.IsNullOrEmpty(ComboBox_SqlType.SelectedItem.ToString());
            state = !string.IsNullOrEmpty(TextBox_Password.Text);
            state = !string.IsNullOrEmpty(TextBox_Username.Text);
            return state;
        }

        private List<dynamic> ReadAllDataJson(string path)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                dynamic array = JArray.Parse(sr.ReadToEnd());
                foreach (var obj in array)
                {
                    Saves.Add(obj);
                }
            }

            return Saves;
        }
    }
}
