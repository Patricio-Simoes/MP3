using Extra_7.Models;
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

namespace Extra_7
{
    public partial class MainWindow : Window
    {
        private App app;

        public MainWindow()
        {
            InitializeComponent();

            app = App.Current as App;

            cbSelecao.Items.Add("Ligeiros");
            cbSelecao.Items.Add("Pesados");
        }

        private void adicionaVeiculoButton_Click(object sender, RoutedEventArgs e)
        {
            app._AdicionaVeículoWindow.ShowDialog();
            lvVeiculos.ItemsSource = null;
            lvVeiculos.ItemsSource = app._Garagem.listaVeículos;
        }

        private void cbSelecao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Filtra por veículos ligeiros
            if (cbSelecao.Text.ToString() == "Pesados")
            {
                lvVeiculosEstacionados.ItemsSource = null;
                lvVeiculosEstacionados.ItemsSource = app._Garagem.listaLigeiros;
            }
            // Filtra por veículos Pesados
            else if (cbSelecao.Text.ToString() == "Ligeiros")
            {
                lvVeiculosEstacionados.ItemsSource = null;
                lvVeiculosEstacionados.ItemsSource = app._Garagem.listaPesados;
            }
        }
    }
}
