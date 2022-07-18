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
using System.Windows.Shapes;
using Extra_3.Models;

namespace Extra_3.Views
{
    public partial class AdicionarMovimento : Window
    {
        private App app;
        public AdicionarMovimento()
        {
            InitializeComponent();

            // Ligação à App

            app = App.Current as App;

            cbTipo.Items.Add("Depósito");
            cbTipo.Items.Add("Levantamento");
        }

        private void registarButton_Click(object sender, RoutedEventArgs e)
        {
            double quantia = 0;
            // Verifica se o tipo é válido
            if (cbTipo.SelectedItem == null)
            {
                MessageBox.Show("ERRO! Tipo inválido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Tenta converter a quantia inserida.
            else if (!(double.TryParse(tbQuantia.Text.ToString(), out quantia)))
            {
                MessageBox.Show("ERRO! Quantia inválida!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Verifica se os outros valores são válidos.
            else if (tbDescrição.Text == "" || tbDescrição.Text == null || tbData.Text == "" || tbData.Text == null)
            {
                MessageBox.Show("ERRO! Valores inválidos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // Passou nas verificações:
            else
            {
                Movimento newMovimento = new Movimento(quantia, tbDescrição.Text.ToString(), tbData.Text.ToString());
                // Chama o método do model para inserir na lista de movimentos.
                if (!app._ModelMovimento.inserir(newMovimento, cbTipo.SelectedItem.ToString()))
                {
                    MessageBox.Show("A operação não pode ser registada por falta de saldo.\nDispõe apenas de " + app._ModelMovimento.saldo + "€ e tentou registar uma operação de " + newMovimento.getQuantia() + "€");
                }
            }
        }

        private void voltarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
