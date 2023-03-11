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

namespace karacsonyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
           int keszlet = 0;

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 1; i <= 40; i++)
            {
                cboNapSzama.Items.Add(i);
            }
        }

        
        private void btnHozzaad_Click(object sender, RoutedEventArgs e) // Ez valamiért nem működik megfelelően!!!!!!!
        {

            if(int.Parse(txtElkeszitett.Text) < 0 || int.Parse(txtEladott.Text) < 0)
            {
                lblHiba.Content = "Negatív számot nem adhat meg!";
            }

            if (keszlet + int.Parse(txtElkeszitett.Text) <  int.Parse(txtEladott.Text))
            {
                lblHiba.Content = "Túl sok az eladott angyalka";
            }

            lblHiba.Content = "";   // hibaüzenet törlése
            keszlet += int.Parse(txtElkeszitett.Text);
            keszlet-= int.Parse(txtEladott.Text);

            string sor = string.Format($"{cboNapSzama.SelectedItem.ToString()}.nap\t+{txtElkeszitett.Text}\t-{txtEladott.Text}\t=\t{keszlet}");

            lbLista.Items.Add(sor);
        }
    }
}
