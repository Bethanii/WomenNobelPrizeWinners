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

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFruit_Click(object sender, RoutedEventArgs e)
        {
           ComboBoxItem chosenFruit = (ComboBoxItem)Fruit.SelectedItem;
           string chosen = chosenFruit.Content.ToString();
         //   MessageBox.Show("You picked " + chosen);

            if (Fruit.SelectedIndex == 0)
            {
                MessageBox.Show("You chose the first fruit " + chosenFruit);
            }
            if (Fruit.SelectedIndex == 1)
            {
                MessageBox.Show("You chose the second fruit, orange");
            }
            if (Fruit.SelectedIndex == 2)
            {
                MessageBox.Show("You chose the third fruit, banana");
            }
            if (Fruit.SelectedIndex == 3)
            {
                MessageBox.Show("You chose the fourth fruit, cherry");
            }
            if (Fruit.SelectedIndex == 4)
            {
                MessageBox.Show("You chose the fifth fruit, strawberry");
            }
            if (Fruit.SelectedIndex == 5)
            {
                MessageBox.Show("You chose the sixth fruit, blueberry");
            }
        }

        private void btnEducation_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem chosenItem = (ComboBoxItem)Vegtable.SelectedItem;
            string chosen = chosenItem.Content.ToString();
             MessageBox.Show("You picked " + chosen);
            }
        }
    }
