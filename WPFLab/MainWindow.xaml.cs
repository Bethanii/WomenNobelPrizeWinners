using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ClassLibraryWPFLab;

namespace WPFLab
{
    public partial class MainWindow : Window
    {
        static string filePath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\WomenNobelPrizes.csv";
        static int countLines = GetCount(filePath); 
        WomenClass[] w = GetWinner(filePath, countLines);
        public MainWindow()
        {
            InitializeComponent();
        }
        static WomenClass[] GetWinner(string filePath, int count)
        {
            string strRead;
            System.IO.FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader readerW = new StreamReader(fs);
            strRead = readerW.ReadLine();  
            WomenClass[] wo = new WomenClass[count];

            for (int counter = 1; counter < count; ++counter) 
            {
                strRead = readerW.ReadLine(); 
                string[] Parts = strRead.Split(',');
                wo[counter] = new WomenClass();
                wo[counter].Number = Convert.ToInt32(Parts[0]);
                wo[counter].FullName = Parts[1];
                wo[counter].Country = Parts[2];
                wo[counter].Category = Parts[3];
                wo[counter].Description = Parts[4];
            } 
            readerW.Close();
            fs.Close();
            return wo;
        }
        private void btnCategory_Click(object sender, RoutedEventArgs e)
        {
            ClearGrid(WinnerList);
            MakeVisible(WinnerList);
            string chosen = "";
            try
            {
                ComboBoxItem chosenItem = (ComboBoxItem)categoryBox.SelectedItem;
                chosen = chosenItem.Content.ToString();
            }
            catch
            {
                MessageBox.Show("Choose a category");
                return;
            }
            string display = "Nobel prize winners of the " + chosen + " category:\n";
            var queryResults = from p in w
                               where p?.Country == chosen 
                               select p; 
            foreach (var Name in queryResults)
            {
                WinnerList.Items.Add(new WomenClass()
                {
                    FullName = Name.FullName,
                    Country = Name.Country,
                    Category = Name.Category,
                    Description = Name.Description
                });
            }
        }
        static int GetCount(string file)
        {
            int count = 0;
            string strRead;
            FileStream sr = new FileStream(file, FileMode.Open, FileAccess.Read);
            StreamReader readerCount = new StreamReader(sr);
            strRead = readerCount.ReadLine();  
            while (strRead != null)
            {
                ++count;
                strRead = readerCount.ReadLine(); 
            }
            readerCount.Close();
            sr.Close();
            return count;
        }
        private void btnCountry_Click(object sender, RoutedEventArgs e)
        { 
            ClearGrid(WinnerList);
            MakeVisible(WinnerList);
            string chosen = "";
            try
            {
                ComboBoxItem chosenItem = (ComboBoxItem)countryBox.SelectedItem;
                chosen = chosenItem.Content.ToString();
            }
            catch
            {
                MessageBox.Show("Choose a category", "Category");
                return;
            }
            string display = "Nobel prize winners from " + chosen + "\n";
            var queryResults = from p in w
                               where p?.Category == chosen
                               select p; 
            foreach (var Name in queryResults)
            {
                WinnerList.Items.Add(new WomenClass()
                {
                    FullName = Name.FullName,
                    Country = Name.Country,
                    Category = Name.Category,
                    Description = Name.Description
                });
            }
        }
        static void ClearGrid(ListView WinnerList)
        {
            int rows = WinnerList.Items.Count;
            for(int counter = rows - 1; counter >= 0; --counter)
            {
                WinnerList.Items.RemoveAt(counter);
            }
        }

        static void MakeVisible(ListView WinnerList)
        {
            if(WinnerList.Visibility == Visibility.Hidden)
            {
                WinnerList.Visibility = Visibility.Visible;
            }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            WinnerList.Visibility = Visibility.Hidden;
        }
        }
    }