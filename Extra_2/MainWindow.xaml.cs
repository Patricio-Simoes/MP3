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

namespace Extra_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Variável que guarda o clube vencedor
        private string clube = "Clube 2";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btClube1_MouseEnter(object sender, MouseEventArgs e)
        {
            // Faz as trocas necessárias no botão 1
            btClube1.Content = clube;
            if (clube == "Clube 2")
                btClube2.Content = "Clube 1";
            else if (clube == "Clube 3")
                btClube3.Content = "Clube 1";
        }
        private void btClube2_MouseEnter(object sender, MouseEventArgs e)
        {
            // Faz as trocas necessárias no botão 2
            btClube2.Content = clube;
            if (clube == "Clube 1")
                btClube1.Content = "Clube 2";
            else if (clube == "Clube 3")
                btClube3.Content = "Clube 2";
        }
        private void btClube3_MouseEnter(object sender, MouseEventArgs e)
        {
            // Faz as trocas necessárias no botão 3
            btClube3.Content = clube;
            if (clube == "Clube 2")
                btClube2.Content = "Clube 3";
            else if (clube == "Clube 1")
                btClube1.Content = "Clube 3";
        }

        private void btClube_MouseLeave(object sender, MouseEventArgs e)
        {
            // Reseta os botões ao sair de qualquer um deles

            btClube1.Content = "Clube 1";
            btClube2.Content = "Clube 2";
            btClube3.Content = "Clube 3";
        }

        private void btClube_Click(object sender, RoutedEventArgs e)
        {
            // Converte o object sender para um botão de modo a que possamos aceder ao seu conteúdo.
            // Desta forma, em vez de termos 3 métodos, 1 para cada botão, temos apenas 1 método ligado aos 3 botões.
            Button bt = (Button)sender;
            // Mostra a mensagem de texto.
            MessageBox.Show("Escolheu o " + bt.Content.ToString() + " !","Votação", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
