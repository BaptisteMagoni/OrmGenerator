using ModuleOrmGenerator.Class;
using ModuleOrmGenerator.Class.Model;
using ModuleOrmGenerator.ConfigurationLangue;
using ModuleOrmGenerator.dal;
using ModuleOrmGenerator.dal.constant;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OrmGenerator.Entities;
using OrmGenerator.Views;
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

        #region Attributs

        private Langue langue { get; set; }
        public SqlconnectorType CurrentConnectorType { get; set; }
        public List<TableModel> TableModels { get; set; }
        public ConnectionString ConnectionString { get; set; }
        public string Path { get; set; }
        public List<SaveConfigModel> Saves { get; set; }

        #endregion

        #region Constructor

        public Configuration()
        {
            InitializeComponent();
            TableModels = new List<TableModel>();
            langue = new Langue();
            LoadComboBoxSqlType();
            LoadSaveConfiguration();
        }

        #endregion

        #region Methods

        #region TextBox

        private void TextBox_Database_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool state = TextBox_IP.Text.Length > 0;
            ComboBox_SqlType.IsEnabled = state;
            Label_TypeBDD.IsEnabled = state;
            CheckBox_Authentification.IsEnabled = state;

            if (!state)
                LoadComboBoxSqlType();

            EnableButton(!string.IsNullOrEmpty(TextBox_IP.Text));
        }

        private void TextBox_Username_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButton(!string.IsNullOrEmpty(TextBox_Username.Text));
        }

        private void TextBox_Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableButton(!string.IsNullOrEmpty(TextBox_Password.Text));
        }

        #endregion

        #region ComboBox

        private void ComboBox_SqlType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_SqlType.SelectedItem != null)
            {
                CheckBox_Authentification.IsEnabled = !string.IsNullOrEmpty(ComboBox_SqlType.SelectedItem.ToString());
                CurrentConnectorType = (SqlconnectorType)ComboBox_SqlType.SelectedItem;

                Label_Username.IsEnabled = true;
                Label_Password.IsEnabled = true;
                TextBox_Username.IsEnabled = true;
                TextBox_Password.IsEnabled = true;
            }

            EnableButton();
        }

        private void ComboBox_Connection_Save_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string saveName = ComboBox_Connection_Save.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(saveName))
                {

                    SaveConfigModel config = JsonMethod<SaveConfigModel>.ReadAllDataJson(Path).Where(x => x.Name == saveName).FirstOrDefault();

                    if (config != null)
                    {

                        TextBox_IP.Text = config.Address;
                        TextBox_Password.Text = config.Password;
                        TextBox_Username.Text = config.Username;
                        ComboBox_SqlType.Text = config.CurrentConnectorType;

                    }

                    EnableButton();

                }
            }
            catch { }
        }

        #endregion

        #region CheckBox

        private void CheckBox_Authentification_Checked(object sender, RoutedEventArgs e)
        {
            bool state = CheckBox_Authentification.IsChecked.Value;
            TextBox_Username.IsEnabled = !state;
            TextBox_Password.IsEnabled = !state;
            Label_Username.IsEnabled = !state;
            Label_Password.IsEnabled = !state;
            CheckBox_Authentification.Content = state ? langue.Authentification_CheckBox_Enable : langue.Authentification_CheckBox_Disable;

            EnableButton();
        }

        #endregion

        #region Button

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

        private void Button_Save_Configuration_Click(object sender, RoutedEventArgs e)
        {
            SaveDialog dialog = new SaveDialog();
            dialog.ShowDialog();
            string SaveName = dialog.TextBox_Save_Name.Text;
            if (!string.IsNullOrEmpty(SaveName))
            {
                SaveConfigModel model = new SaveConfigModel()
                {
                    Name = SaveName,
                    Address = TextBox_IP.Text,
                    Username = TextBox_Username.Text,
                    Password = TextBox_Password.Text,
                    CurrentConnectorType = ComboBox_SqlType.SelectedItem.ToString(),
                };

                Saves.Add(model);

                var result = JsonMethod<SaveConfigModel>.AddData(Saves);
                JsonMethod<SaveConfigModel>.WriteDataJson(Path, result);
                UpdateComboBox_Saves(Saves);

            }

        }

        private void Button_Delete_Configuration_Click(object sender, RoutedEventArgs e)
        {
            TrashDialog dialog = new TrashDialog(Path);
            dialog.Path = Path;
            dialog.ShowDialog();
            Saves = dialog.NewSaveConfig;
            if(Saves != null)
                UpdateComboBox_Saves(Saves);
        }

        #endregion

        #region Other Method

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

            Path += Constant.FILE_NAME_SAVE_CONFIGURATION;

            if (!File.Exists(Constant.FILE_NAME_SAVE_CONFIGURATION))
            {
                File.Create(Path);
            }

            Saves = JsonMethod<SaveConfigModel>.ReadAllDataJson(Path);

            if (Saves != null)
            {
                foreach (var item in Saves)
                {
                    ComboBox_Connection_Save.HorizontalContentAlignment = HorizontalAlignment.Left;
                    ComboBox_Connection_Save.Items.Add(item.Name);
                }
            }
            else
            {
                Saves = new List<SaveConfigModel>();
                ComboBox_Connection_Save.HorizontalContentAlignment = HorizontalAlignment.Center;
                ComboBox_Connection_Save.Items.Add(langue.ComboBox_Saves_Empty);
            }
        }

        private void EnableButton(bool state = true)
        {
            EnableButtonFinish(state);
            EnableButtonSave(state);
        }

        private void EnableButtonFinish(bool state)
        {
            if (CheckIfHaveAlreadyInformation() || !state)
                Button_Finish.IsEnabled = state;
        }

        private void EnableButtonSave(bool state)
        {
            if (CheckIfHaveAlreadyInformation() || !state)
                Button_Save_Configuration.IsEnabled = state;
        }

        private bool CheckIfHaveAlreadyInformation()
        {
            bool state = false;
            try
            {
                state = !string.IsNullOrEmpty(TextBox_IP.Text);
                state = !string.IsNullOrEmpty(ComboBox_SqlType.SelectedItem.ToString());
                if (!CheckBox_Authentification.IsChecked.Value)
                    state = !string.IsNullOrEmpty(TextBox_Username.Text);
            }
            catch
            {
                return false;
            }
            return state;
        }

        private void UpdateComboBox_Saves(List<SaveConfigModel> saves)
        {
            ComboBox_Connection_Save.Items.Clear();
            foreach(var item in saves)
            {
                ComboBox_Connection_Save.Items.Add(item.Name);
            }
        }

        #endregion

        #endregion
    }
}
