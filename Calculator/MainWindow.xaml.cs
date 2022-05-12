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

namespace Calculator
{
    public partial class MainWindow : Window
    {
        double lastNumber = 0;
        double currentNumber = 0;
        double result = 0;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            int inputValue = 0;

            // Como todos os botões numéricos estão associados a este evento, filtramos o object sender para saber qual foi o botão que deu trigger neste evento
            // e por consequência, qual o valor numérico a ser introduzido na resultLabel.

            if (sender == zeroButton)
                inputValue = 0;
            else if (sender == oneButton)
                inputValue = 1;
            else if (sender == twoButton)
                inputValue = 2;
            else if (sender == threeButton)
                inputValue = 3;
            else if (sender == fourButton)
                inputValue = 4;
            else if (sender == fiveButton)
                inputValue = 5;
            else if (sender == sixButton)
                inputValue = 6;
            else if (sender == sevenButton)
                inputValue = 7;
            else if (sender == eightButton)
                inputValue = 8;
            else if (sender == nineButton)
                inputValue = 9;

            // Dois casos diferentes:
            // 1º - A label está vazia (0) -> É só alterar o texto da label;
            // 2º - A label não está vazia <=> Estamos a escrever um número de 2+ dígitos -> Temos de dar append para não perder o conteúdo que lá está.

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = inputValue.ToString();
            else
                resultLabel.Content += inputValue.ToString();
        } 
        private void operationButton_Click (object sender, RoutedEventArgs e)
        {
            // Tenta converter a string que está na resultLabel para um valor double(lastNumber), se não conseguir apresenta mensagem de erro

            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
                if (sender == addButton)
                {
                    selectedOperator = SelectedOperator.Addition;
                    operationLabel.Content += lastNumber.ToString() + " + ";
                }
                else if (sender == subtractButton)
                {
                    selectedOperator = SelectedOperator.Subtraction;
                    operationLabel.Content += lastNumber.ToString() + " - ";
                }
                else if (sender == multiplyButton)
                {
                    selectedOperator = SelectedOperator.Multiplication;
                    operationLabel.Content += lastNumber.ToString() + " * ";
                }
                else if (sender == divideButton)
                {
                    selectedOperator = SelectedOperator.Division;
                    operationLabel.Content += lastNumber.ToString() + " / ";
                }
            }
            else
                MessageBox.Show("Verifique se o número é valido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        // Guarda a lista de operadores possíveis para mais tarde fazer a comparação no equalButton_Click
        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        private void dotButton_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se a label já contém uma vírgula, se contiver e adicionar outro, o número fica inválido
            resultLabel.Content += ",";
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            operationLabel.Content = "";
            lastNumber = 0;
            currentNumber = 0;
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            // Verifica se algum operador está ativo antes de igualar

            if (operationLabel.Content.ToString().Contains("+") || operationLabel.Content.ToString().Contains("-") || operationLabel.Content.ToString().Contains("*") || operationLabel.Content.ToString().Contains("/"))
            {

                // Tenta converter a string que está na resultLabel para um valor double(currentNumber), se não conseguir apresenta mensagem de erro

                if (double.TryParse(resultLabel.Content.ToString(), out currentNumber))
                {
                    switch (selectedOperator)
                    {
                        case SelectedOperator.Addition:
                            result = Math.Add(lastNumber, currentNumber);
                            break;
                        case SelectedOperator.Subtraction:
                            result = Math.Subtract(lastNumber, currentNumber);
                            break;
                        case SelectedOperator.Multiplication:
                            result = Math.Multiply(lastNumber, currentNumber);
                            break;
                        case SelectedOperator.Division:
                            result = Math.Divide(lastNumber, currentNumber);
                            break;
                    }
                    resultLabel.Content = result.ToString();
                    operationLabel.Content = "";
                }
                else
                    MessageBox.Show("Verifique se o número é valido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Verifique se a operação é valida!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void percentageButton_Click(object sender, RoutedEventArgs e)
        {
            double temp = 0;

            // Tenta converter a string que está na resultLabel para um valor double(temp), se não conseguir apresenta mensagem de erro

            if (double.TryParse(resultLabel.Content.ToString(), out temp))
            {
                resultLabel.Content = (temp/100).ToString();
            }
            else
                MessageBox.Show("Verifique se o número é valido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void simetricButton_Click(object sender, RoutedEventArgs e)
        {
            double temp = 0;

            // Tenta converter a string que está na resultLabel para um valor double(temp), se não conseguir apresenta mensagem de erro

            if (double.TryParse(resultLabel.Content.ToString(), out temp))
            {
                resultLabel.Content = (temp * -1).ToString();
            }
            else
                MessageBox.Show("Verifique se o número é valido!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // Class que vai lidar com as 4 operações básicas
    // Necessário usar uma class? Não

    public class Math
    {
        public static double Add(double a, double b) { return a + b; }
        public static double Subtract(double a, double b) { return a - b; }
        public static double Multiply(double a, double b) { return a * b; }
        public static double Divide(double a, double b)
        {
            // Divisão por 0
            if (b == 0)
            {
                MessageBox.Show("Impossível dividir por 0!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            else
                return a / b; 
        }
    }
}