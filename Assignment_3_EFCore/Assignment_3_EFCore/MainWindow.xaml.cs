using BaseballLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
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

namespace Assignment_3_EFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        BaseballLibrary.Player player = new Player();

        public MainWindow()
        {
            InitializeComponent();
        }//end of MainWindow

        public static string GetConnectionString()
        {
            string connectionString;

            //Insert Baseball.mdf directory after AttachDbFile=
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= [insert Baseball.mdf directory here] ;Initial Catalog=Assignment_3_BaseballDB;Integrated Security=True;Connect Timeout=30";

            return connectionString;
        }//end of GetConnectionString

        public List<BaseballLibrary.Player> SearchPlayerByLastName(string parameter)
        {
            List<BaseballLibrary.Player> players = new List<BaseballLibrary.Player>();

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {

                string sqlCommandString = @"SELECT [PlayerID], [FirstName], [LastName], [BattingAverage] FROM [Players] WHERE [LastName] = @lastname";
                SqlCommand sqlCommand = new SqlCommand(sqlCommandString, connection);

                sqlCommand.Parameters.AddWithValue("@lastname", parameter);

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    players.Add(new BaseballLibrary.Player
                    {
                        PlayerID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        BattingAverage = reader.GetDecimal(3)
                });
                }//end while

                connection.Close();

            }//end of using

            return players;

        }//end of SearchPlayerByLastName

        private void btn_Add_Player_Click(object sender, RoutedEventArgs e)
        {
            bool textbox_check_pass = false;
            while (textbox_check_pass == false)
            {

                if (String.IsNullOrEmpty(txbx_FirstName.Text) == true)
                {
                    textbox_check_pass = false;
                    break;
                }
                else
                {
                    player.FirstName = txbx_FirstName.Text;
                }

                if (String.IsNullOrEmpty(txbx_LastName.Text) == true)
                {
                    textbox_check_pass = false;
                    break;
                }
                else
                {
                    player.LastName = txbx_LastName.Text;
                }

                //if (String.IsNullOrEmpty(txbx_PlayerID.Text) == true)
                //{
                //    textbox_check_pass = false;
                //    break;
                //}
                //else
                //{
                //    int result;
                //    if (int.TryParse(txbx_PlayerID.Text, out result) == false)
                //    {
                //        textbox_check_pass = false;
                //        break;
                //    }
                //    Trace.WriteLine(result);
                //    player.PlayerID = result;
                //}

                if (String.IsNullOrEmpty(txbx_BattingAverage.Text) == true)
                {
                    textbox_check_pass = false;
                    Trace.WriteLine("ERROR: Batting Average is NULL or empty.");
                    break;
                }
                else
                {
                    decimal result;
                    if (decimal.TryParse(txbx_BattingAverage.Text, out result) == false)
                    {
                        textbox_check_pass = false;
                        Trace.WriteLine("ERROR: Batting Average is not convertable to decimal.");
                        break;
                    }
                    if (CheckScaleAndPrecision(result) == false)
                    {
                        textbox_check_pass = false;
                        break;
                    }
                    else
                    {
                        Trace.WriteLine(result);
                        player.BattingAverage = result;
                    }
                    
                }

                textbox_check_pass = true;
                
            }//end of while

            if (textbox_check_pass == true) //if all the checks are passed = true
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {

                    string sqlQuery = "INSERT INTO [Players] ([FirstName], [LastName], [BattingAverage]) VALUES (@fname, @lname, @bataverage)";
                    SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);

                    //SqlParameter playerID_parameter = new SqlParameter("@playerID", System.Data.SqlDbType.Int);
                    //playerID_parameter.Value = player.PlayerID;

                    sqlCommand.Parameters.AddWithValue("@fname", player.FirstName);
                    sqlCommand.Parameters.AddWithValue("@lname", player.LastName);

                    SqlParameter battingAverage_parameter = new SqlParameter("@bataverage", System.Data.SqlDbType.Decimal);
                    battingAverage_parameter.Value = ((decimal)player.BattingAverage);
                    battingAverage_parameter.Precision = 3;
                    battingAverage_parameter.Scale = 3;

                    //sqlCommand.Parameters.Add(playerID_parameter);
                    sqlCommand.Parameters.Add(battingAverage_parameter);

                    connection.Open();

                    sqlCommand.ExecuteNonQuery();

                    connection.Close();
                }//end of using
            }//end of if
            else //if checks fail
            {

            }

        }//end of btn_Add_Player_Click

        public bool CheckScaleAndPrecision(decimal number)
        {
            int precision = 3;
            int scale = 3;

            SqlDecimal sqlDecimal = new SqlDecimal(number);
            if (sqlDecimal.Precision > precision || sqlDecimal.Scale > scale)
            {
                Trace.WriteLine("Invalid precision and scale.");
                return false;
            }
            else
            {
                return true;
            }
        }//end of ConvertScaleAndPrecision

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            datagrid_Baseball.ItemsSource = SearchPlayerByLastName(txbx_LastName.Text);
        }//end of btn_Search_Click

        private void btn_ViewAllPlayers_Click(object sender, RoutedEventArgs e)
        {
            List<BaseballLibrary.Player> players = new List<BaseballLibrary.Player>();

            using (var connection = new SqlConnection(GetConnectionString()))
            {

                string sqlQuery = "SELECT [PlayerID], [FirstName], [LastName], [BattingAverage] FROM [Players]";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);

                connection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();


                while (reader.Read())
                {
                    players.Add(new BaseballLibrary.Player
                    {
                        PlayerID = reader.GetInt32(0),
                        FirstName = reader.GetString(1).ToString(),
                        LastName = reader.GetString(2).ToString(),
                        BattingAverage = reader.GetDecimal(3)
                    });
                }//end of while

                datagrid_Baseball.ItemsSource = players;

                connection.Close();

            }//end of using

        }//end of btn_ViewAllPlayers_Click
    }//end of MainWindow : Window partial class

}//end of namespace
