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

namespace Extra_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculaButton_Click(object sender, RoutedEventArgs e)
        {
            double a = 0, b = 0, res = 0;
            // Verifica se os valores inseridos são válidos ao tentar converter para double
            if (double.TryParse(tbValor1.Text.ToString(),out a) && double.TryParse(tbValor2.Text.ToString(), out b))
            {
                // Verifica se o operador é válido
                if (tbOperação.Text.ToString() != "/" && tbOperação.Text.ToString() != "*" && tbOperação.Text.ToString() != "-" && tbOperação.Text.ToString() != "+")
                {
                    MessageBox.Show("ERRO! O operador inserido não é valido!", "Mensagem de Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; 
                }
                // Verifica se estamos a dividir por 0
                if (tbOperação.Text.ToString() == "/" && b == 0)
                {
                    MessageBox.Show("ERRO! Impossível dividir por 0!", "Mensagem de Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                // Efetua o cálculo
                switch (tbOperação.Text.ToString())
                {
                    case "+" :
                        res = a + b;
                        break;
                    case "-" :
                        res = a - b;
                        break;
                    case "*" :
                        res = a * b;
                        break;
                    case "/" :
                        res = a / b;
                        break;
                    default: 
                        break;
                }
                // Coloca o resultado na textbox
                tbResultado.Text = res.ToString();
            }
        }
    }
}