using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace HW_05
{
    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS; Initial Catalog=America; Integrated Security=True";
        DataSet ds = new DataSet();
        public MainWindow()
        {
            InitializeComponent();


            string sqlAllTable = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            string sqlCitizen = "SELECT * FROM Citizen";
            string sqlShowName = "SELECT surname, name FROM Citizen";
            string sqlShowAge = "SELECT surname, age FROM Citizen";
            string sqlShowCharacter = "SELECT surname, character FROM Citizen";
            string sqlShowState = "SELECT c.surname, s.name AS state FROM Citizen c, States s WHERE c.states_id = s.id";
            string sqlStates = "SELECT * FROM States";
            string sqlCities = "SELECT * FROM Cities";
            string sqlOldestCities = "SELECT TOP 3 name Название, year_foundation Год_основания, population Население FROM Cities ORDER BY year_foundation";


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var adapterAllTable = new SqlDataAdapter(sqlAllTable, connection);
                var adapterCitizen = new SqlDataAdapter(sqlCitizen, connection);
                var adapterNameCitizen = new SqlDataAdapter(sqlShowName, connection);
                var adapterAgeCitizen = new SqlDataAdapter(sqlShowAge, connection);
                var adapterCharacterCitizen = new SqlDataAdapter(sqlShowCharacter, connection);
                var adapterStatesCitizen = new SqlDataAdapter(sqlShowState, connection);
                var adapterStates = new SqlDataAdapter(sqlStates, connection);
                var adapterCities = new SqlDataAdapter(sqlCities, connection);
                var adapterOldestCities = new SqlDataAdapter(sqlOldestCities, connection);

                adapterAllTable.Fill(ds, "AllTable");
                adapterCitizen.Fill(ds, "Citizen");
                adapterNameCitizen.Fill(ds, "Name");
                adapterAgeCitizen.Fill(ds, "Age");
                adapterCharacterCitizen.Fill(ds, "Character");
                adapterStatesCitizen.Fill(ds, "States");
                adapterStates.Fill(ds, "States");
                adapterCities.Fill(ds, "Cities");
                adapterOldestCities.Fill(ds, "OldestCities");

                dgMain.ItemsSource = ds.Tables["AllTable"].DefaultView;
            }
        }

        private void ShowName(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ds.Tables["Name"].DefaultView;
        }

        private void ShowAge(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ds.Tables["Age"].DefaultView;
        }

        private void ShowCharacter(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ds.Tables["Character"].DefaultView;
        }

        private void ShowState(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ds.Tables["States"].DefaultView;
        }

        private void ShowCities(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ds.Tables["Cities"].DefaultView;
        }

        private void ShowOldestCities(object sender, RoutedEventArgs e)
        {
            dgMain.ItemsSource = ds.Tables["OldestCities"].DefaultView;
        }
    }
}
