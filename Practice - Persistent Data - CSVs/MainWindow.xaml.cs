using System;
using System.Collections.Generic;
using System.Globalization;
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
using CsvHelper;

namespace Practice___Persistent_Data___CSVs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> _cars = new List<Car>();
        const string filePath = "cars.csv";
        public MainWindow()
        {
            Preload();
            InitializeComponent();

            lvCarInfo.ItemsSource = _cars;

        }

        public void Preload()
        {
            _cars.Add(new Car("Toyota", "Rav4", "2020", 25000));
            _cars.Add(new Car("Hyundia", "Sonata", "2018", 90000));
            _cars.Add(new Car("Lexus", "Rx300", "2016", 150000));
            _cars.Add(new Car("Honda", "Civic", "2017", 110000));
            _cars.Add(new Car("Kia", "Sorento", "2022", 50000));

        }

        public void SaveCSVfile<T>(string filePath, List<T> list)
        { 
             CultureInfo ci = CultureInfo.InvariantCulture;

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            { 
                csvWriter.WriteRecords(list);
                writer.Flush();
            }

        }

        public List<T> LoadCSVfile<T>(string filePath)
        {
            List<T> tempList = new List<T>();

            using (StreamReader sr = new StreamReader(filePath))
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
               
                tempList = csv.GetRecords<T>().ToList();
            }

            return tempList;
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            string make = txtMake.Text;
            string model = txtModel.Text;
            string year = txtYear.Text;
            int mileage = int.Parse(txtMileage.Text);
            

            _cars.Add(new Car(make, model, year, mileage));

            lvCarInfo.Items.Refresh();

        }

        private void btnSavingCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveCSVfile(filePath, _cars);

        }

        private void btnLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            _cars = LoadCSVfile<Car>(filePath);

            lvCarInfo.ItemsSource = _cars;

        }
    }
}
