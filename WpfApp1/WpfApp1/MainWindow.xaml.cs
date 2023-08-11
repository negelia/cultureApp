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
using System.Data;
using System.Data.SqlClient;
using WpfApp1.DataSet1TableAdapters;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        public DataTable Select(string selectSQL) 
        {
            DataTable dataTable = new DataTable("dataBase");
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-3CDDHCO8\\SQLEXPRESS; Database=Culture_ProjectDB; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False");
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = selectSQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
        private void signIn(object sender, RoutedEventArgs e)
        {
            if (check() == true) 
            {
                DataTable dt_user = Select("SELECT * FROM [dbo].[Managers] WHERE [login] = '" + login.Text + "' AND [password] = '" + password.Password + "'");
                if (dt_user.Rows.Count > 0)
                {
                    Main Main = new Main();
                    Main.Show();
                    this.Close();
                }
                else MessageBox.Show("Пользователь не найден");
            }
        }

        private void insertBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            Register Register = new Register();
            Register.Show();
            this.Close();
        }

        public bool check()
        {
            if (password.Password.Length == 0 || password.Password.Length < 6) { errorPass.Content = "Пароль должен содержать шесть символов"; return false; }
            if (login.Text.Length == 0 || login.Text.Length < 5) { errorLogin.Content = "Логин должен содержать пять символов"; return false; }

            if (Regex.Match(password.Password, "[!@#&%*_\\-.]").Length == 0) { errorPass.Content = "Пароль должен содержать спецсимволы"; return false; }
            if (Regex.Match(login.Text, "[!@#&%*_\\-.]").Length == 0) { errorLogin.Content = "Логин должен содержать спецсимволы"; return false; }

            if (Regex.Match(password.Password, "\\d").Length == 0) { errorPass.Content = "Пароль должен содержать цифры"; return false; }
            if (Regex.Match(login.Text, "\\d").Length == 0) { errorLogin.Content = "Логин должен содержать цифры"; return false; }

            if (Regex.Match(password.Password, "[A-Za-z]").Length == 0) { errorPass.Content = "Пароль должен содержать латинские символы"; return false; }
            if (Regex.Match(login.Text, "[A-Za-z]").Length == 0) { errorLogin.Content = "Логин должен содержать латинские символы"; return false; }

            if (Regex.Match(password.Password, "[А-Яа-я]").Length != 0) { errorPass.Content = "Пароль не должен содержать буквы кириллицы"; return false; }
            if (Regex.Match(login.Text, "[А-Яа-я]").Length != 0) { errorLogin.Content = "Логин не должен содержать буквы кириллицы"; return false; }

            return true;
        }
    }
}
