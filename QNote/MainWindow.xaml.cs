using QNote.Classes;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace QNote
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Information> information;
        public MainWindow()
        {
            InitializeComponent();
            information = new List<Information>();
            ReadDatabase();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewTodoList newTodoList = new NewTodoList();
            newTodoList.ShowDialog();

            ReadDatabase();
        }

        private void ExistButton_Click(object sender, RoutedEventArgs e)
        {
            ReadDatabase();
            this.Close();
        }

        void ReadDatabase()
        {
            // SQL Connection.
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Information>();
                information = (connection.Table<Information>().ToList()).OrderBy(c => c.CreatedDate).ToList();

            }
            if (information != null)
            {
                informationListView.ItemsSource = information;
            }
        }
    }
}
