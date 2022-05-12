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

namespace Extra_4
{
    public partial class MainWindow : Window
    {
        private App app;
        public string fileName = "Sample_File.txt";
        public MainWindow()
        {
            InitializeComponent();

            app = App.Current as App;

            app.Model_File.CloseRead += Model_File_CloseRead;
            app.Model_File.CloseWrite += Model_File_CloseWrite;

            // Tenta abrir o ficheiro

            try
            {
                app.Model_File.ReadFile(fileName);
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao tentar abrir o ficheiro!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Model_File_CloseRead()
        {
            tbNumero.Text = app.Model_File.numero;
            tbNome.Text = app.Model_File.nome;
            tbCurso.Text = app.Model_File.curso;
        }
        public void Model_File_CloseWrite()
        {
            MessageBox.Show("Dados guardados com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.None);
        }

        private void leaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Vai abandonar o programa.\nTem a certeza?", "Abandonar o Programa", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
                
                // Força o programa a fechar

                System.Windows.Application.Current.Shutdown();
        }

        private void modifyButton_Click(object sender, RoutedEventArgs e)
        {
            // Ativar textBoxes

            tbNumero.IsEnabled = true;
            tbNome.IsEnabled = true;
            tbCurso.IsEnabled = true;

            // Ativar/Desativar Botões

            updateButton.IsEnabled = true;
            updateButton.Visibility = Visibility.Visible;
            cancelButton.IsEnabled = true;
            cancelButton.Visibility = Visibility.Visible;
            modifyButton.IsEnabled = false;
            modifyButton.Visibility = Visibility.Hidden;
            leaveButton.IsEnabled = false;
            leaveButton.Visibility = Visibility.Hidden;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Tem a certeza que deseja reescrever o ficheiro com os novos dados?", "Alterar Ficheiro", MessageBoxButton.OKCancel, MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
                app.Model_File.WriteFile(fileName, tbNumero.Text.ToString(), tbNome.Text.ToString(), tbCurso.Text.ToString());
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Desativar textBoxes

            tbNumero.IsEnabled = false;
            tbNome.IsEnabled = false;
            tbCurso.IsEnabled = false;

            // Ativar/Desativar Botões

            updateButton.IsEnabled = false;
            updateButton.Visibility = Visibility.Hidden;
            cancelButton.IsEnabled = false;
            cancelButton.Visibility = Visibility.Hidden;
            modifyButton.IsEnabled = true;
            modifyButton.Visibility = Visibility.Visible;
            leaveButton.IsEnabled = true;
            leaveButton.Visibility = Visibility.Visible;
        }
    }
}
