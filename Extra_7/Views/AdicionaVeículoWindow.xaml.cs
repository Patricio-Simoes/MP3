using Extra_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Extra_7.Views
{
    public partial class AdicionaVeículoWindow : Window
    {
        private App app;
        public AdicionaVeículoWindow()
        {
            InitializeComponent();

            cbTipo.Items.Add("Ligeiro");
            cbTipo.Items.Add("Pesado");

            app = App.Current as App;
        }

        private void cbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipo.SelectedItem.ToString() == "Pesado")
            {
                this.tblEixos.Visibility = Visibility.Visible;
                this.tbEixos.Visibility = Visibility.Visible;
            }
            else
            {
                this.tblEixos.Visibility = Visibility.Hidden;
                this.tbEixos.Visibility = Visibility.Hidden;
            }
        }

        private void adicionaButton_Click(object sender, RoutedEventArgs e)
        {
            // Verifica valores nulos
            if (cbTipo.Text == null || cbTipo.Text == " ")
                MessageBox.Show("Erro! Insira valores válidos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            // Verifica Matrícula válida
            else if (!Regex.IsMatch(tbMatrícula.Text, @"[A-za-z][A-za-z][-][0-9][0-9][-][A-za-z][A-za-z]") && !Regex.IsMatch(tbMatrícula.Text, @"[0-9][0-9][-][A-za-z][A-za-z][-][0-9][0-9]") && !Regex.IsMatch(tbMatrícula.Text, @"[0-9][0-9][-][0-9][0-9][-][A-za-z][A-za-z]") && !Regex.IsMatch(tbMatrícula.Text, @"[A-za-z][A-za-z][-][0-9][0-9][-][0-9][0-9]"))
            {
                MessageBox.Show("Erro! Insira valores válidos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            // Verifica a lotação
            else if (int.Parse(this.tbLotação.Text) < 1)
            {
                MessageBox.Show("Erro! Insira valores válidos!", "Erro", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            // Adiciona um Ligeiro
            else if (cbTipo.Text == "Ligeiro")
            {
                try
                {
                    Veículo newVeículo = new Veículo(int.Parse(this.tbLotação.Text.ToString()), this.tbMatrícula.Text);
                    app._Garagem.Estaciona(newVeículo);
                    MessageBox.Show("Veículo Ligeiro adicionado com sucesso!", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            // Adiciona um Pesado
            else if (cbTipo.Text == "Pesado")
            {
                try
                {
                    Veículo newVeículo = new Veículo(int.Parse(this.tbLotação.Text.ToString()), this.tbMatrícula.Text);
                    app._Garagem.Estaciona(newVeículo, int.Parse(this.tbEixos.Text.ToString()));
                    MessageBox.Show("Veículo Pesado adicionado com sucesso!", "Informação", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            this.Hide();
            // Limpa o conteúdo das textblock
            this.tbEixos.Text = "";
            this.tbLotação.Text = "";
            this.tbMatrícula.Text = "";
        }
    }
}
