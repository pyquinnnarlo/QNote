using QNote.Classes;
using SQLite;
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

namespace QNote
{
    /// <summary>
    /// Interaction logic for NewTodoList.xaml
    /// </summary>
    public partial class NewTodoList : Window
    {
        public NewTodoList()
        {
            InitializeComponent();
        }

        private void CloseTapButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string richText = new TextRange(DescrptionBox.Document.ContentStart, DescrptionBox.Document.ContentEnd).Text;

            // Get Information Class
            Information information = new Information()
            {
                Title = Title.Text,
                Description = richText,
                CreatedDate = DateTime.Now,
            };

            SQLiteConnection connection = new SQLiteConnection(App.databasePath);
            connection.CreateTable<Information>();
            if (information.Title == "" || information.Description == "" || information.CreatedDate == null)
            {
                MessageBox.Show("Please check the Values!");

            }
            else
            {
                connection.Insert(information);
            }

            this.Close();
            
        }
    }
}
