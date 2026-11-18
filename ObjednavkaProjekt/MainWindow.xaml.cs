using ObjednavkaProjekt.Třídy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ObjednavkaProjekt
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

        private void btnVypocitat_Click(
            object sender, RoutedEventArgs e)
        {
            txtVysledek.Text = "";

            // Kontrola číselného vstupu
            if (!decimal.TryParse(txtCena.Text, out decimal cena))
            {
                MessageBox.Show("Zadejte platnou cenu.");
                return;
            }

            // Kontrola záporné ceny
            if (cena < 0)
            {
                MessageBox.Show("Cena nesmí být záporná.");
                return;
            }

            // Výběr dopravy
            int doprava = cmbDoprava.SelectedIndex;

            // Vytvoření objektu
            Objednavka objednavka =
                new Objednavka(cena, doprava);

            // Výpočet celkové ceny
            decimal celkem = objednavka.VypocitejCelkem();

            // Zobrazení výsledku
            txtVysledek.Text = $"Celkem: {celkem:N2} Kč";
        }
    }
}