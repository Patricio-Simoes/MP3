using Microsoft.Win32;
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

namespace Extra_5
{
    public partial class MainWindow : Window
    {
        private App app;
        public MainWindow()
        {
            InitializeComponent();

            app = App.Current as App;

            app.Model_File.CloseRead += Model_File_CloseRead;
            app.Model_File.CloseWrite += Model_File_CloseWrite;
        }

        private void replaceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.View_ReplaceWord.Show();
            }
            catch
            {
                MessageBox.Show("Erro, reinicie o programa.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Tem a certeza que eliminar todo o texto entre parênteses?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (app.Model_File.DeleteText(tbFileText.Text.ToString()))
                    MessageBox.Show("Texto entre parênteses apagado com sucesso!", "Notificação", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Não foi detetado nenhum texto entre parênteses!", "Notificação", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void leaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Tem a certeza que deseja sair?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)

                // Força o programa a fechar

                System.Windows.Application.Current.Shutdown();
        }

        private void readButton_Click(object sender, RoutedEventArgs e)
        {
            // Abre uma caixa de diálogo que permite escolher um ficheiro txt

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ficheiros de texto (*.txt)|*.txt|Todos of ficheiros (*.*)|*.*";
            if(dlg.ShowDialog() == true)
                app.Model_File.ReadFile(dlg.FileName);
        }
        private void Model_File_CloseRead()
        {
            tbFileText.Text = app.Model_File.text;

            tbWords.Text = app.Model_File.CountWords(app.Model_File.text).ToString();
            tbCharacters.Text = app.Model_File.CountCharacters(app.Model_File.text).ToString();
            tbAlunos.Text = app.Model_File.CountAlunos(app.Model_File.text).ToString();
            tbParagraphs.Text = app.Model_File.CountParagraphs(app.Model_File.text).ToString();

            MessageBox.Show("Leitura efetuada com sucesso!", "Notificação", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Abre uma caixa de diálogo que permite escolher um ficheiro txt

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ficheiros de texto (*.txt)|*.txt|Todos of ficheiros(*.*)|*.*";
            if (dlg.ShowDialog() == true)
                app.Model_File.WriteFile(dlg.FileName, tbFileText.Text.ToString());
        }
        private void Model_File_CloseWrite()
        {
            MessageBox.Show("Escrita terminada com sucesso!", "Notificação", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (app.Model_File.text != null && app.Model_File.text.Length > 0)
            {
                tbFileText.Text = app.Model_File.text;

                tbWords.Text = app.Model_File.CountWords(app.Model_File.text).ToString();
                tbCharacters.Text = app.Model_File.CountCharacters(app.Model_File.text).ToString();
                tbAlunos.Text = app.Model_File.CountAlunos(app.Model_File.text).ToString();
                tbParagraphs.Text = app.Model_File.CountParagraphs(app.Model_File.text).ToString();

                MessageBox.Show("Atualização efetuada com sucesso!", "Notificação", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Texto Vazio", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
