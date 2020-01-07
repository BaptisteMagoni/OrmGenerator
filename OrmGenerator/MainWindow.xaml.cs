using ModuleOrmGenerator.dal;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrmGenerator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DAOFactory dao = new DAOFactory();
            Object connection = dao.GetConnection(SqlconnectorType.MYSQL);

            if (connection != null)
            {

                InitializeComponent();
                var test = dao.GetDAOTable().ShowColumnsByTableName(SqlconnectorType.MYSQL, connection);

            }
            else
            {
                MessageBox.Show("Problème de connection à la base de données vérifier votre connexion !");
            }
        }
    }
}
