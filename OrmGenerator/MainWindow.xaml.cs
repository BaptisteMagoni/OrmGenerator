using Microsoft.Win32;
using ModuleOrmGenerator.Class;
using ModuleOrmGenerator.Class.Model;
using ModuleOrmGenerator.ConfigurationLangue;
using ModuleOrmGenerator.dal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinForm = System.Windows.Forms;

namespace OrmGenerator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<TableModel> TableModels { get; set; }
        public SqlconnectorType CurrentConenctorType { get; set; }
        public ConnectionString ConnectionString { get; set; }
        public Boolean AuthentificationWindows { get; set; }
        public Langue langue { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            langue = new Langue();
        }

        private void Button_Depos_Click(object sender, RoutedEventArgs e)
        {
            WinForm.FolderBrowserDialog dialog = new WinForm.FolderBrowserDialog();
            WinForm.DialogResult result = dialog.ShowDialog();

            if (result == WinForm.DialogResult.OK)
            {
                TextBox_Depos.Text = dialog.SelectedPath;
            }
        }

        private void Button_Configuration_Click(object sender, RoutedEventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.ShowDialog();

            TableModels = configuration.TableModels;
            CurrentConenctorType = configuration.CurrentConnectorType;
            ConnectionString = configuration.ConnectionString;

            if (TableModels.Count > 0)
            {
                ComboBox_Database.IsEnabled = true;

                foreach (TableModel item in TableModels)
                    ComboBox_Database.Items.Add(item.Name);
            }
        }

        private void ComboBox_Database_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox_Tables.Items.Clear();
            string databaseName = ComboBox_Database.SelectedItem.ToString();
            
            if (!string.IsNullOrEmpty(databaseName))
            {
                ComboBox_Tables.IsEnabled = true;

                DAOFactory dao = new DAOFactory
                {
                    DataConnection = ConnectionString,
                };

                Object connection = dao.GetConnection(CurrentConenctorType);

                if(connection != null)
                {
                    List<string> tables = dao.GetDAOTable().GetTableOfDatabase(CurrentConenctorType, connection, databaseName);

                    if (tables.Count > 0)
                    {
                        ComboBox_Tables.HorizontalContentAlignment = HorizontalAlignment.Left;
                        
                        foreach (string item in tables)
                        {
                            ComboBox_Tables.Items.Add(item);
                        }
                    }
                    else
                    {
                        ComboBox_Tables.Items.Add(langue.ComboBox_Table_Empty);
                        ComboBox_Tables.HorizontalContentAlignment = HorizontalAlignment.Center;
                    }

                }

            }
        }

        private void ComboBox_Tables_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DAOFactory dao = new DAOFactory()
            {
                DataConnection = ConnectionString
            };

            Object connection = dao.GetConnection(CurrentConenctorType);

            if(connection != null)
            {
                try
                {
                    Grid_Table.Visibility = Visibility.Visible;
                    CreateTable(dao.GetDAOTable().GetColumnsByTableName(CurrentConenctorType, connection, ComboBox_Database.SelectedItem.ToString(), ComboBox_Tables.SelectedItem.ToString()));
                }
                catch
                {
                    Grid_Table.Visibility = Visibility.Hidden;
                }
            }

        }

        private void CreateTable(List<ColumnModel> columnModels)
        {
            var list = new ObservableCollection<ColumnModel>();

            foreach(var item in columnModels)
            {
                list.Add(item);   
            }
            Table.ItemsSource = list;
        }

    }
}
