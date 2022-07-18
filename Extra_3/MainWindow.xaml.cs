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
using Extra_3.Models;

namespace Extra_3
{
    public partial class MainWindow : Window
    {
        private App app;
        public MainWindow()
        {
            InitializeComponent();

            // Ligação à App.

            app = App.Current as App;

            // Subscrição dos métodos no evento do Model.

            app._ModelMovimento.movimentoInserido += Model_Registar_RegistoInserido;
            app._ModelMovimento.movimentoInserido += Model_Registar_SaldoBaixo;

            RefreshLV();
        }

        private void registarButton_Click(object sender, RoutedEventArgs e)
        {
            // Ver App.xaml.cs para localização da instância.
            // Uma vez que estamos ligados à App (l.28) podemos chamar esta instância.

            app._AdicionarMovimento.ShowDialog();

            // Atualiza a textblock que contém o saldo.
            this.tbSaldoDisponível.Text = "Saldo Disponível: " + app._ModelMovimento.saldo + "€";

            RefreshLV();
        }
        public void RefreshLV()
        {
            // Função chamada após inserir um novo registo na View AdicionarMovimento.
            lvMovimentos.ItemsSource = null;
            lvMovimentos.ItemsSource = app._ModelMovimento.Movimentos;
        }
        private void sairButton_Click(object sender, RoutedEventArgs e)
        {
            // Força o programa a fechar.

            System.Windows.Application.Current.Shutdown();
        }
        private void Model_Registar_RegistoInserido(Movimento M)
        {
            MessageBox.Show("Movimento inserido com sucesso!", "Notificação", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void Model_Registar_SaldoBaixo(Movimento M)
        {
            if (app._ModelMovimento.saldo < 5)
                MessageBox.Show("O seu saldo é inferior a 5€.", "Alerta de saldo - Nível 2", MessageBoxButton.OK, MessageBoxImage.Information);
            else if (app._ModelMovimento.saldo < 20)
                MessageBox.Show("O seu saldo é inferior a 20€.", "Alerta de saldo - Nível 1", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void lvMovimentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                MessageBox.Show("Data: " + app._ModelMovimento.Movimentos[lvMovimentos.SelectedIndex].getData() + "\nDescrição: " + app._ModelMovimento.Movimentos[lvMovimentos.SelectedIndex].getDescrição() + "\nQuantia: " + app._ModelMovimento.Movimentos[lvMovimentos.SelectedIndex].getQuantia() + "€", "Detalhes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Escolha Inválida!", "Alerta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
