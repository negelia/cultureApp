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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void signIn(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LAPTOP-3CDDHCO8\\SQLEXPRESS; Database=Culture_ProjectDB; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False");

            string sql = string.Format("SELECT* FROM[dbo].[Managers] WHERE[login] = '" + login.Text + "'");

            string sql1 = string.Format("Insert Into Managers" +
                       "(Surname,Name,Middle_Name,Login,Password) Values(@fam,@name,@otch,@log,@pass)");

            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                connection.Open();
                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    i++;
                }

                if (i == 0)
                {
                    if (check() == true)
                    {
                        using (SqlCommand cmdWrite = new SqlCommand(sql1, connection))
                        {
                            // Добавить параметры
                            cmdWrite.Parameters.AddWithValue("@fam", fam.Text);
                            cmdWrite.Parameters.AddWithValue("@name", name.Text);
                            cmdWrite.Parameters.AddWithValue("@otch", otch.Text);
                            cmdWrite.Parameters.AddWithValue("@log", login.Text);
                            cmdWrite.Parameters.AddWithValue("@pass", password.Password);

                            //connection.Open();
                            cmdWrite.ExecuteNonQuery();
                        }

                        MessageBox.Show("Пользователь добавлен в базу данных");

                        MainWindow Main = new MainWindow();
                        Main.Show();
                        this.Close();
                    }
                }
                else
                {
                    errorLogin.Content = "Введите уникальный логин";
                }
            }
        }
        public bool check()
        {
            if (password.Password.Length == 0 || password.Password.Length < 6) {errorPass.Content = "Пароль должен содержать шесть символов"; return false; }
            if (login.Text.Length == 0 || login.Text.Length < 5) {errorLogin.Content = "Логин должен содержать пять символов"; return false; }

            if (Regex.Match(password.Password, "[!@#&%*_\\-.]").Length == 0) {errorPass.Content = "Пароль должен содержать спецсимволы"; return false; }
            if (Regex.Match(login.Text, "[!@#&%*_\\-.]").Length == 0) {errorLogin.Content = "Логин должен содержать спецсимволы"; return false; }

            if (Regex.Match(password.Password, "\\d").Length == 0) {errorPass.Content = "Пароль должен содержать цифры"; return false; }
            if (Regex.Match(login.Text, "\\d").Length == 0) {errorLogin.Content = "Логин должен содержать цифры"; return false; }

            if (Regex.Match(password.Password, "[A-Za-z]").Length == 0) {errorPass.Content = "Пароль должен содержать латинские символы"; return false; }
            if (Regex.Match(login.Text, "[A-Za-z]").Length == 0) {errorLogin.Content = "Логин должен содержать латинские символы"; return false; }

            if (Regex.Match(password.Password, "[А-Яа-я]").Length != 0) {errorPass.Content = "Пароль не должен содержать буквы кириллицы"; return false; }
            if (Regex.Match(login.Text, "[А-Яа-я]").Length != 0) {errorLogin.Content = "Логин не должен содержать буквы кириллицы"; return false; }

                if (fam.Text.Length < 2) {errorFam_Copy.Content = "Фамилия должна содержать два символа, как минимум"; return false; }
            if (Regex.Match(fam.Text, "[!@#&%*_\\-.]").Length != 0) {errorFam_Copy.Content = "Фамилия не может содержать спецсимволы"; return false; }
            if (Regex.Match(fam.Text, "\\d").Length != 0) {errorFam_Copy.Content = "Фамилия не может содержать цифры"; return false; }
            if (Regex.Match(fam.Text, "[A-Za-z]").Length != 0) {errorFam_Copy.Content = "Фамилия не может содержать латинские символы"; return false; }
            if (Regex.Match(fam.Text, "[А-Яа-я]").Length == 0) {errorFam_Copy.Content = "Фамилия должна содержать буквы кириллицы"; return false; }

            if (name.Text.Length < 2) {errorIm_Copy.Content = "Имя должно содержать два символа, как минимум"; return false; }
            if (Regex.Match(name.Text, "[!@#&%*_\\-.]").Length != 0) {errorIm_Copy.Content = "Имя не может содержать спецсимволы"; return false; }
            if (Regex.Match(name.Text, "\\d").Length != 0) {errorIm_Copy.Content = "Имя не может содержать цифры"; return false; }
            if (Regex.Match(name.Text, "[A-Za-z]").Length != 0) {errorIm_Copy.Content = "Имя не может содержать латинские символы"; return false; }

            if (Regex.Match(otch.Text, "[!@#&%*_\\-.]").Length != 0) {errorOtch_Copy.Content = "Отчество не может содержать спецсимволы"; return false; }
            if (Regex.Match(otch.Text, "\\d").Length != 0) {errorOtch_Copy.Content = "Отчество не может содержать цифры"; return false; }
            if (Regex.Match(otch.Text, "[A-Za-z]").Length != 0) {errorOtch_Copy.Content = "Отчество не может содержать латинские символы"; return false; }

            if (passwordcopy.Password != password.Password) {errorPass_Copy2.Content = "Пароли должны совпадать"; return false; }
            if (passwordcopy.Password.Length == 0) {errorPass_Copy2.Content = "Пройдите проверку пароля"; return false; }


            return true;
        }
    }
}
