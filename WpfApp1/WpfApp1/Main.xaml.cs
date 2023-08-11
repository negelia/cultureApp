using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Data.SqlClient;
using WpfApp1.DataSet1TableAdapters;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.DevTools.V96.Network;
using System.Data.OleDb;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : System.Windows.Window
    {
        DataSet1 datasetNEW;
        ActorsTableAdapter actors;
        ManagersTableAdapter managers;
        ConcertsTableAdapter concerts;
        RewardsTableAdapter rewards;
        AwardTableAdapter awardView;
        AfishaTableAdapter afishaView;
        TheatresTableAdapter theatres;
        //ActorConcertTableAdapter actorConcert;

        System.Data.DataTable dataTable = new System.Data.DataTable("dataBase");
        System.Data.DataTable afisha = new System.Data.DataTable("dataBase");
        System.Data.DataTable afisha1 = new System.Data.DataTable("dataBase");
        System.Data.DataTable afisha2 = new System.Data.DataTable("dataBase");
        System.Data.DataTable afishaSearch = new System.Data.DataTable("dataBase");
        System.Data.DataTable awards = new System.Data.DataTable("dataBase");
        System.Data.DataTable awards1 = new System.Data.DataTable("dataBase");
        System.Data.DataTable awards2 = new System.Data.DataTable("dataBase");
        System.Data.DataTable awards3 = new System.Data.DataTable("dataBase");
        System.Data.DataTable awardsSearch = new System.Data.DataTable("dataBase");

        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-3CDDHCO8\\SQLEXPRESS; Database=Culture_ProjectDB; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False");

        int ID_Actor;
        int ID_Manager;
        int ID_Concert;
        int ID_Reward;
        int ID_Theatre;
        public Main()
        {
            InitializeComponent();

            datasetNEW = new DataSet1();

            //actors
            actors = new ActorsTableAdapter();

            actors.Fill(datasetNEW.Actors);

            data.ItemsSource = datasetNEW.Actors.DefaultView;
            data.SelectionMode = DataGridSelectionMode.Single;
            data.SelectedValuePath = "ID_Actor";
            data.CanUserAddRows = false;
            data.CanUserDeleteRows = false;
            data.IsReadOnly = true;

            //managers
            managers = new ManagersTableAdapter();

            data1.SelectionMode = DataGridSelectionMode.Single;
            data1.CanUserAddRows = false;
            data1.CanUserDeleteRows = false;
            data1.IsReadOnly = true;

            //concerts
            concerts = new ConcertsTableAdapter();
            rewards = new RewardsTableAdapter();
            theatres = new TheatresTableAdapter();
            actors = new ActorsTableAdapter();

            //PlaceCB.DisplayMemberPath = "Title";
            //PlaceCB.SelectedItem = 0;

            //RewardCB.DisplayMemberPath = "Title";
            //RewardCB.SelectedItem = 0;

            //ActorCB.DisplayMemberPath = "Surname";
            //ActorCB.SelectedItem = 0;

            data2.SelectionMode = DataGridSelectionMode.Single;
            data2.CanUserAddRows = false;
            data2.CanUserDeleteRows = false;
            data2.IsReadOnly = true;



            //afisha
            concerts = new ConcertsTableAdapter();
            theatres = new TheatresTableAdapter();
            afishaView = new AfishaTableAdapter();

            data3.SelectionMode = DataGridSelectionMode.Single;
            data3.CanUserAddRows = false;
            data3.CanUserDeleteRows = false;
            data3.IsReadOnly = true;

            //award
            concerts = new ConcertsTableAdapter();
            actors = new ActorsTableAdapter();
            rewards = new RewardsTableAdapter();
            //actorConcert = new ActorConcertTableAdapter();
            awardView = new AwardTableAdapter();

            data4.SelectionMode = DataGridSelectionMode.Single;
            data4.CanUserAddRows = false;
            data4.CanUserDeleteRows = false;
            data4.IsReadOnly = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            data.Columns[0].Visibility = Visibility.Hidden;
            data.Columns[5].Visibility = Visibility.Hidden;

            data.Columns[1].Header = "Фамилия";
            data.Columns[2].Header = "Имя";
            data.Columns[3].Header = "Отчество";
            data.Columns[4].Header = "Дата рождения";

            
        }
        private void tab2_Click(object sender, MouseButtonEventArgs e)
        {
            managers.Fill(datasetNEW.Managers);

            data1.ItemsSource = datasetNEW.Managers.DefaultView;
            data1.SelectedValuePath = "ID_Manager";

            data1.Columns[0].Visibility = Visibility.Hidden;
            //data1.Columns[6].Visibility = Visibility.Hidden;

            data1.Columns[1].Header = "Фамилия";
            data1.Columns[2].Header = "Имя";
            data1.Columns[3].Header = "Отчество";
            data1.Columns[4].Header = "Логин";
            data1.Columns[5].Header = "Пароль";

        }
        private void tab3_Click(object sender, MouseButtonEventArgs e)
        {
            concerts.Fill(datasetNEW.Concerts);
            rewards.Fill(datasetNEW.Rewards);
            theatres.Fill(datasetNEW.Theatres);

            PlaceCB.ItemsSource = datasetNEW.Theatres.DefaultView;
            PlaceCB.DisplayMemberPath = "Title";
            PlaceCB.SelectedValuePath = "ID_Theatre";
            PlaceCB.SelectedItem = 0;

            RewardCB.ItemsSource = datasetNEW.Rewards.DefaultView;
            RewardCB.DisplayMemberPath = "Title";
            RewardCB.SelectedValuePath = "ID_Reward";
            RewardCB.SelectedItem = 0;

            ActorCB.ItemsSource = datasetNEW.Actors.DefaultView;
            ActorCB.DisplayMemberPath = "Surname";
            ActorCB.SelectedValuePath = "ID_Actor";
            ActorCB.SelectedItem = 0;

            data2.ItemsSource = datasetNEW.Concerts.DefaultView;
            data2.SelectedValuePath = "ID_Concert";
            //data2.SelectedValuePath = "ID_Reward";
            //data2.SelectedValuePath = "ID_Theatre";

            data2.Columns[0].Visibility = Visibility.Hidden;
            data2.Columns[5].Visibility = Visibility.Hidden;
            data2.Columns[6].Visibility = Visibility.Hidden;
            data2.Columns[7].Visibility = Visibility.Hidden;

            data2.Columns[1].Header = "Название";
            data2.Columns[2].Header = "Жанр";
            data2.Columns[3].Header = "Дата";
            data2.Columns[4].Header = "Стоимость";

        }

        private void tab4_Click(object sender, MouseButtonEventArgs e)
        {
            concerts.Fill(datasetNEW.Concerts);
            theatres.Fill(datasetNEW.Theatres);
            afishaView.Fill(datasetNEW.Afisha);

            data3.ItemsSource = datasetNEW.Afisha.DefaultView;
            data3.SelectedValuePath = "ID_Theatre";
            data3.SelectedValuePath = "ID_Concert";

            data3.Columns[0].Visibility = Visibility.Hidden;
            data3.Columns[1].Visibility = Visibility.Hidden;

        }

        private void tab5_Click(object sender, MouseButtonEventArgs e)
        {
            concerts.Fill(datasetNEW.Concerts);
            actors.Fill(datasetNEW.Actors);
            rewards.Fill(datasetNEW.Rewards);
            //actorConcert.Fill(datasetNEW.ActorConcert);
            awardView.Fill(datasetNEW.Award);

            data4.ItemsSource = datasetNEW.Award.DefaultView;
            //data4.SelectedValuePath = "ID_Actor";
            //data4.SelectedValuePath = "ID_ActorConcert";
            //data4.SelectedValuePath = "ID_Concert";
            data4.SelectedValuePath = "ID_Reward";

            data4.Columns[0].Visibility = Visibility.Hidden;
            data4.Columns[1].Visibility = Visibility.Hidden;
            data4.Columns[2].Visibility = Visibility.Hidden;

        }


        //actors
        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkA() == true)
            {
                actors.Insert(famTB.Text,
                    imTB.Text,
                    otchTB.Text,
                    date.DisplayDate
                    );
                actors.Fill(datasetNEW.Actors);

                errorFam.Content = " ";
                errorName_Copy.Content = " ";
                errorOtch_Copy1.Content = " ";
                errorDate_Copy.Content = " ";
            }
        }
        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkA() == true)
            {
                actors.UpdateQuery(famTB.Text,
                    imTB.Text,
                    otchTB.Text,
                    date.SelectedDate.ToString(),
                    ID_Actor
                    );
                actors.Fill(datasetNEW.Actors);

                errorFam.Content = " ";
                errorName_Copy.Content = " ";
                errorOtch_Copy1.Content = " ";
                errorDate_Copy.Content = " ";
            }
        }
        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (data.SelectedItem != null)
            {
                actors.DeleteQuery(ID_Actor);
                actors.Fill(datasetNEW.Actors);

                errorFam.Content = " ";
                errorName_Copy.Content = " ";
                errorOtch_Copy1.Content = " ";
                errorDate_Copy.Content = " ";
            }
        }
        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)data.SelectedItem;
            if (dataRowView != null)
            {
                famTB.Text = dataRowView.Row.Field<String>("Surname");
                imTB.Text = dataRowView.Row.Field<String>("Name");
                otchTB.Text = dataRowView.Row.Field<String>("Middle_Name");
                //date.SelectedDate = Convert.ToDateTime(dataRowView.Row.Field<String>("Birthday"));

                ID_Actor = dataRowView.Row.Field<int>("ID_Actor");
            }
        }

        //managers
        private void insertManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkM() == true)
            {
                managers.Insert(famManagerTB.Text,
                    imManagerTB.Text,
                    otchManagerTB.Text,
                    loginManagerTB.Text,
                    passManagerTB.Text
                    );
                managers.Fill(datasetNEW.Managers);

                errorManPass_Copy3.Content = " ";
                errorManlogin_Copy2.Content = " ";
                errorManFam.Content = " ";
                errorManName_Copy.Content = " ";
                errorManOtch_Copy1.Content = " ";
            }
        }
        private void updateManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkM() == true)
            {
                managers.UpdateQuery(famManagerTB.Text,
                    imManagerTB.Text,
                    otchManagerTB.Text,
                    loginManagerTB.Text,
                    passManagerTB.Text,
                    ID_Manager
                    );
                managers.Fill(datasetNEW.Managers);

                errorManPass_Copy3.Content = " ";
                errorManlogin_Copy2.Content = " ";
                errorManFam.Content = " ";
                errorManName_Copy.Content = " ";
                errorManOtch_Copy1.Content = " ";
            }
        }
        private void deleteManagerBtn_Click(object sender, RoutedEventArgs e)
        {
            if (data1.SelectedItem != null)
            {
                managers.DeleteQuery(ID_Manager);
                managers.Fill(datasetNEW.Managers);

                errorManPass_Copy3.Content = " ";
                errorManlogin_Copy2.Content = " ";
                errorManFam.Content = " ";
                errorManName_Copy.Content = " ";
                errorManOtch_Copy1.Content = " ";
            }
        }
        private void data1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)data1.SelectedItem;
            if (dataRowView != null)
            {
                famManagerTB.Text = dataRowView.Row.Field<String>("Surname");
                imManagerTB.Text = dataRowView.Row.Field<String>("Name");
                otchManagerTB.Text = dataRowView.Row.Field<String>("Middle_Name");
                loginManagerTB.Text = dataRowView.Row.Field<String>("Login");
                passManagerTB.Text = dataRowView.Row.Field<String>("Password");

                ID_Manager = dataRowView.Row.Field<int>("ID_Manager");
            }
        }


        //concerts
        private void insertConcertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkC() == true)
            {
                concerts.Insert(
                    titleTB.Text,
                    GenreTB.Text,
                    dateConcert.DisplayDate,
                    Convert.ToDecimal(priceTB.Text),
                    (int)PlaceCB.SelectedValue,
                    (int)ActorCB.SelectedValue,
                    (int)RewardCB.SelectedValue
                    );

                concerts.Fill(datasetNEW.Concerts);

                errorTitle.Content = " ";
                errorGenre.Content = " ";
                placeCBerror.Content = " ";
                rewardCBerror.Content = " ";
                errorPrice.Content = " ";
                Dateerror_Copy.Content = " ";
            }
        }
        private void updateConcertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (checkC() == true)
            {
                concerts.UpdateQuery(
                    titleTB.Text,
                    GenreTB.Text,
                    dateConcert.SelectedDate.ToString(),
                    Convert.ToDecimal(priceTB.Text),
                    (int)PlaceCB.SelectedValue,
                    (int)ActorCB.SelectedValue,
                    (int)RewardCB.SelectedValue,
                    ID_Concert
                    );

                concerts.Fill(datasetNEW.Concerts);

                errorTitle.Content = " ";
                errorGenre.Content = " ";
                placeCBerror.Content = " ";
                rewardCBerror.Content = " ";
                errorPrice.Content = " ";
                Dateerror_Copy.Content = " ";
            }
        }
        private void deleteConcertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (data2.SelectedItem != null)
            {
                concerts.DeleteQuery(ID_Concert);
                theatres.DeleteQuery(ID_Theatre);
                rewards.DeleteQuery(ID_Reward);
                actors.DeleteQuery(ID_Actor);
                concerts.Fill(datasetNEW.Concerts);

                errorTitle.Content = " ";
                errorGenre.Content = " ";
                placeCBerror.Content = " ";
                rewardCBerror.Content = " ";
                errorPrice.Content = " ";
                Dateerror_Copy.Content = " ";
                ActorError.Content = " ";
            }
        }
        private void data2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)data2.SelectedItem;
            if (dataRowView != null)
            {
                titleTB.Text = dataRowView.Row.Field<String>("Title");
                GenreTB.Text = dataRowView.Row.Field<String>("Genre");
                PlaceCB.SelectedValue = dataRowView.Row.Field<int>("ID_Theatre");
                RewardCB.SelectedValue = dataRowView.Row.Field<int>("ID_Reward");

                ID_Concert = dataRowView.Row.Field<int>("ID_Concert");

            }
        }

        //afisha
        private void data3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)data3.SelectedItem;
            if (dataRowView != null)
            {
                ID_Concert = dataRowView.Row.Field<int>("ID_Concert");
                ID_Theatre = dataRowView.Row.Field<int>("ID_Theatre");
            }
        }

        private void exportBtn1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                Workbook xlWorkbook = ExcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                DataTableCollection collection = datasetNEW.Tables;
                for (int i = collection.Count; i > 0; i--)
                {
                    Sheets xlSheets = null;
                    Worksheet xlWorksheet = null;
                    xlSheets = ExcelApp.Sheets;
                    xlWorksheet = (Worksheet)xlSheets.Add(xlSheets[1],Type.Missing, Type.Missing, Type.Missing);
                    System.Data.DataTable table = collection[i - 1];
                    xlWorksheet.Name = table.TableName;
                    for (int j = 1; j < table.Columns.Count + 1; j++)
                    {

                        ExcelApp.Cells[1, j] = table.Columns[j - 1].ColumnName;

                    }

                    for (int k = 0; k < table.Rows.Count; k++)
                    {
                        for (int l = 0; l < table.Columns.Count; l++)
                        {
                            ExcelApp.Cells[k + 2, l + 1] = table.Rows[k].ItemArray[l].ToString();
                        }
                    }
                    ExcelApp.Columns.AutoFit();
                }
                ((Worksheet)ExcelApp.ActiveWorkbook.Sheets[ExcelApp.ActiveWorkbook.Sheets.Count]).Delete();
                ExcelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public System.Data.DataTable afishaFill (string afishaSQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = afishaSQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(afisha);
            connection.Close();
            return afisha;
        }

        public System.Data.DataTable afisha1Fill(string afisha1SQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = afisha1SQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(afisha1);
            connection.Close();
            return afisha1;
        }

        public System.Data.DataTable afisha2Fill(string afisha2SQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = afisha2SQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(afisha2);
            connection.Close();
            return afisha2;
        }

        //afisha
        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            afisha = afishaFill("SELECT * FROM [dbo].[Afisha] WHERE [Жанр] = '" + TextBox_SearchLine.Text + "'");
            afisha1 = afisha1Fill("SELECT * FROM [dbo].[Afisha] WHERE [Место] = '" + TextBox_SearchLine.Text + "'");
            afisha2 = afisha2Fill("SELECT * FROM [dbo].[Afisha] WHERE [Название] = '" + TextBox_SearchLine.Text + "'");

            if (afisha.Rows.Count > 0)
            {
                data3.ItemsSource = afisha.DefaultView;
            }
            else if (afisha1.Rows.Count > 0)
            {
                data3.ItemsSource = afisha1.DefaultView;
            }
            else if (afisha2.Rows.Count > 0)
            {
                data3.ItemsSource = afisha2.DefaultView;
            }

            data3.Columns[0].Visibility = Visibility.Hidden;
            data3.Columns[1].Visibility = Visibility.Hidden;


            //var rows = dataTable.GetChanges(DataRowState.Modified);

            //if (rows != null)
            //{
            //    adapter.Update(rows);
            //}

            //dataTable.AcceptChanges();

        }

        public System.Data.DataTable afishaSearchFill(string afishaSearchSQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = afishaSearchSQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(afishaSearch);
            connection.Close();
            return afishaSearch;
        }

        private void checkTB_Checked(object sender, RoutedEventArgs e)
        {
            afishaSearch = afishaSearchFill("SELECT * FROM [dbo].[Afisha] WHERE [Стоимость] = 0");
            if (afishaSearch.Rows.Count > 0)
            {
                data3.ItemsSource = afishaSearch.DefaultView;
            }

            data3.Columns[0].Visibility = Visibility.Hidden;
            data3.Columns[1].Visibility = Visibility.Hidden;

        }

        private void checkTB_Unchecked_1(object sender, RoutedEventArgs e)
        {
            afishaSearch = afishaSearchFill("SELECT * FROM [dbo].[Afisha] WHERE [Стоимость] = 0");
            if (afishaSearch.Rows.Count > 0)
            {
                data3.ItemsSource = afishaSearch.DefaultView;
            }
            afishaSearch.Clear();
            data3.ItemsSource = datasetNEW.Afisha;
            data3.Columns[0].Visibility = Visibility.Hidden;
            data3.Columns[1].Visibility = Visibility.Hidden;
        }

        public System.Data.DataTable awardFill(string awardsSQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = awardsSQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(awards);
            connection.Close();
            return awards;
        }

        public System.Data.DataTable award1Fill(string awards1SQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = awards1SQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(awards1);
            connection.Close();
            return awards1;
        }

        public System.Data.DataTable award2Fill(string awards2SQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = awards2SQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(awards2);
            connection.Close();
            return awards2;
        }

        public System.Data.DataTable award3Fill(string awards3SQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = awards3SQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(awards3);
            connection.Close();
            return awards3;
        }

        //awards
        private void searchBtn1_Click(object sender, RoutedEventArgs e)
        {
            awards = awardFill("SELECT * FROM [dbo].[Award] WHERE [Концерт] = '" + TextBox1_SearchLine.Text + "'");
            awards1 = award1Fill("SELECT * FROM [dbo].[Award] WHERE [Фамилия] = '" + TextBox1_SearchLine.Text + "'");
            awards2 = award2Fill("SELECT * FROM [dbo].[Award] WHERE [Имя] = '" + TextBox1_SearchLine.Text + "'");
            awards3 = award3Fill("SELECT * FROM [dbo].[Award] WHERE [Отчество] = '" + TextBox1_SearchLine.Text + "'");

            if (awards.Rows.Count > 0)
            {
                data4.ItemsSource = awards.DefaultView;
            }
            else if (awards1.Rows.Count > 0)
            {
                data4.ItemsSource = awards1.DefaultView;
            }
            else if (awards2.Rows.Count > 0)
            {
                data4.ItemsSource = awards2.DefaultView;
            }
            else if (awards3.Rows.Count > 0)
            {
                data4.ItemsSource = awards3.DefaultView;
            }

            data4.Columns[0].Visibility = Visibility.Hidden;
            data4.Columns[1].Visibility = Visibility.Hidden;
            data4.Columns[2].Visibility = Visibility.Hidden;
        }

        public System.Data.DataTable awardsSearchFill(string awardsSearchSQL)
        {
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = awardsSearchSQL;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(awardsSearch);
            connection.Close();
            return awardsSearch;
        }

        private void checkAwardTB_Checked(object sender, RoutedEventArgs e)
        {
            awardsSearch = awardsSearchFill("SELECT * FROM [dbo].[Award] WHERE [Награда] = 'лучшая драматическая роль'");
            if (awardsSearch.Rows.Count > 0)
            {
                data4.ItemsSource = awardsSearch.DefaultView;

                data4.Columns[0].Visibility = Visibility.Hidden;
                data4.Columns[1].Visibility = Visibility.Hidden;
                data4.Columns[2].Visibility = Visibility.Hidden;
            }
        }

        private void checkAwardTB_Unchecked_1(object sender, RoutedEventArgs e)
        {
            awardsSearch = awardsSearchFill("SELECT * FROM [dbo].[Award] WHERE [Награда] = 'лучшая драматическая роль'");
            if (awardsSearch.Rows.Count > 0)
            {
                data4.ItemsSource = awardsSearch.DefaultView;
            }
            awardsSearch.Clear();
            data4.ItemsSource = datasetNEW.Award;
            data4.Columns[0].Visibility = Visibility.Hidden;
            data4.Columns[1].Visibility = Visibility.Hidden;
            data4.Columns[2].Visibility = Visibility.Hidden;

        }

        private void TextBox1_SearchLine_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void exportBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.ApplicationClass ExcelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                Workbook xlWorkbook = ExcelApp.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

                DataTableCollection collection = datasetNEW.Tables;
                for (int i = collection.Count; i > 0; i--)
                {
                    Sheets xlSheets = null;
                    Worksheet xlWorksheet = null;
                    xlSheets = ExcelApp.Sheets;
                    xlWorksheet = (Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
                    System.Data.DataTable table = collection[i - 1];
                    xlWorksheet.Name = table.TableName;
                    for (int j = 1; j < table.Columns.Count + 1; j++)
                    {

                        ExcelApp.Cells[1, j] = table.Columns[j - 1].ColumnName;

                    }

                    for (int k = 0; k < table.Rows.Count; k++)
                    {
                        for (int l = 0; l < table.Columns.Count; l++)
                        {
                            ExcelApp.Cells[k + 2, l + 1] = table.Rows[k].ItemArray[l].ToString();
                        }
                    }
                    ExcelApp.Columns.AutoFit();
                }
                ((Worksheet)ExcelApp.ActiveWorkbook.Sheets[ExcelApp.ActiveWorkbook.Sheets.Count]).Delete();
                ExcelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_SearchLine_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void concertCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AwardCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void GenreCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void checkAwardTB_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void checkTB_Unchecked(object sender, RoutedEventArgs e)
        {
            
        }


        public bool checkA() 
        {
            //actors
            if (famTB.Text.Length < 2) { errorFam.Content = "Фамилия должна содержать два символа, как минимум"; return false; }
            if (Regex.Match(famTB.Text, "[!@#&%*_\\-.]").Length != 0) { errorFam.Content = "Фамилия не может содержать спецсимволы"; return false; }
            if (Regex.Match(famTB.Text, "\\d").Length != 0) { errorFam.Content = "Фамилия не может содержать цифры"; return false; }
            if (Regex.Match(famTB.Text, "[A-Za-z]").Length != 0) { errorFam.Content = "Фамилия не может содержать латинские символы"; return false; }
            if (Regex.Match(famTB.Text, "[А-Яа-я]").Length == 0) { errorFam.Content = "Фамилия должна содержать буквы кириллицы"; return false; }

            if (imTB.Text.Length < 2) { errorName_Copy.Content = "Имя должно содержать два символа, как минимум"; return false; }
            if (Regex.Match(imTB.Text, "[!@#&%*_\\-.]").Length != 0) { errorName_Copy.Content = "Имя не может содержать спецсимволы"; return false; }
            if (Regex.Match(imTB.Text, "\\d").Length != 0) { errorName_Copy.Content = "Имя не может содержать цифры"; return false; }
            if (Regex.Match(imTB.Text, "[A-Za-z]").Length != 0) { errorName_Copy.Content = "Имя не может содержать латинские символы"; return false; }

            if (Regex.Match(otchTB.Text, "[!@#&%*_\\-.]").Length != 0) { errorOtch_Copy1.Content = "Отчество не может содержать спецсимволы"; return false; }
            if (Regex.Match(otchTB.Text, "\\d").Length != 0) { errorOtch_Copy1.Content = "Отчество не может содержать цифры"; return false; }
            if (Regex.Match(otchTB.Text, "[A-Za-z]").Length != 0) { errorOtch_Copy1.Content = "Отчество не может содержать латинские символы"; return false; }

            if (date.GetValue(DatePicker.SelectedDateProperty) == null) { errorDate_Copy.Content = "Выберете дату"; return false; }

            return true;
        }

        public bool checkC()
        {
            //concerts
            if (titleTB.Text.Length == 0) { errorTitle.Content = "Введите название"; return false; }
            if (GenreTB.Text.Length == 0) { errorGenre.Content = "Введите жанр"; return false; }
            if (priceTB.Text.Length == 0) { errorPrice.Content = "Введите стоимость"; return false; }

            if (PlaceCB.SelectedItem == null) { placeCBerror.Content = "Выберете место"; return false; }
            if (RewardCB.SelectedItem == null) { rewardCBerror.Content = "Выберете награду"; return false; }
            if (ActorCB.SelectedItem == null) { ActorError.Content = "Выберете актёра"; return false; }

            if (Regex.Match(priceTB.Text, "^[.][0-9]+$|^[0-9]*[,]{0,1}[0-9]*$").Length == 0) { errorPrice.Content = "Введите стоимость в формате : xx,xx"; return false; }

            if (dateConcert.GetValue(DatePicker.SelectedDateProperty) == null) { Dateerror_Copy.Content = "Выберете дату"; return false; }

            return true;
        }

        public bool checkM()
        {
            //managers
            if (passManagerTB.Text.Length == 0 || passManagerTB.Text.Length < 6) { errorManPass_Copy3.Content = "Пароль должен содержать шесть символов"; return false; }
            if (loginManagerTB.Text.Length == 0 || loginManagerTB.Text.Length < 5) { errorManlogin_Copy2.Content = "Логин должен содержать пять символов"; return false; }

            if (Regex.Match(passManagerTB.Text, "[!@#&%*_\\-.]").Length == 0) { errorManPass_Copy3.Content = "Пароль должен содержать спецсимволы"; return false; }
            if (Regex.Match(loginManagerTB.Text, "[!@#&%*_\\-.]").Length == 0) { errorManlogin_Copy2.Content = "Логин должен содержать спецсимволы"; return false; }

            if (Regex.Match(passManagerTB.Text, "\\d").Length == 0) { errorManPass_Copy3.Content = "Пароль должен содержать цифры"; return false; }
            if (Regex.Match(loginManagerTB.Text, "\\d").Length == 0) { errorManlogin_Copy2.Content = "Логин должен содержать цифры"; return false; }

            if (Regex.Match(passManagerTB.Text, "[A-Za-z]").Length == 0) { errorManPass_Copy3.Content = "Пароль должен содержать латинские символы"; return false; }
            if (Regex.Match(loginManagerTB.Text, "[A-Za-z]").Length == 0) { errorManlogin_Copy2.Content = "Логин должен содержать латинские символы"; return false; }

            if (Regex.Match(passManagerTB.Text, "[А-Яа-я]").Length != 0) { errorManPass_Copy3.Content = "Пароль не должен содержать буквы кириллицы"; return false; }
            if (Regex.Match(loginManagerTB.Text, "[А-Яа-я]").Length != 0) { errorManlogin_Copy2.Content = "Логин не должен содержать буквы кириллицы"; return false; }

            if (famManagerTB.Text.Length < 2) { errorManFam.Content = "Фамилия должна содержать два символа, как минимум"; return false; }
            if (Regex.Match(famManagerTB.Text, "[!@#&%*_\\-.]").Length != 0) { errorManFam.Content = "Фамилия не может содержать спецсимволы"; return false; }
            if (Regex.Match(famManagerTB.Text, "\\d").Length != 0) { errorManFam.Content = "Фамилия не может содержать цифры"; return false; }
            if (Regex.Match(famManagerTB.Text, "[A-Za-z]").Length != 0) { errorManFam.Content = "Фамилия не может содержать латинские символы"; return false; }
            if (Regex.Match(famManagerTB.Text, "[А-Яа-я]").Length == 0) { errorManFam.Content = "Фамилия должна содержать буквы кириллицы"; return false; }

            if (imManagerTB.Text.Length < 2) { errorManName_Copy.Content = "Имя должно содержать два символа, как минимум"; return false; }
            if (Regex.Match(imManagerTB.Text, "[!@#&%*_\\-.]").Length != 0) { errorManName_Copy.Content = "Имя не может содержать спецсимволы"; return false; }
            if (Regex.Match(imManagerTB.Text, "\\d").Length != 0) { errorManName_Copy.Content = "Имя не может содержать цифры"; return false; }
            if (Regex.Match(imManagerTB.Text, "[A-Za-z]").Length != 0) { errorManName_Copy.Content = "Имя не может содержать латинские символы"; return false; }

            if (Regex.Match(otchManagerTB.Text, "[!@#&%*_\\-.]").Length != 0) { errorManOtch_Copy1.Content = "Отчество не может содержать спецсимволы"; return false; }
            if (Regex.Match(otchManagerTB.Text, "\\d").Length != 0) { errorManOtch_Copy1.Content = "Отчество не может содержать цифры"; return false; }
            if (Regex.Match(otchManagerTB.Text, "[A-Za-z]").Length != 0) { errorManOtch_Copy1.Content = "Отчество не может содержать латинские символы"; return false; }


            return true;
        }

    }
}
