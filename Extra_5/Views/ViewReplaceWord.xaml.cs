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

namespace Extra_5.Views
{
    public partial class ViewReplaceWord : Window
    {
        private App app { get; set; }
        public ViewReplaceWord()
        {
            InitializeComponent();

            app = App.Current as App;

            app.Model_File.WordReplaced += Model_File_Word_Replaced;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Tem a certeza que deseja cancelar?", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                this.Hide();
        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Tem a certeza que deseja substituir todas as entradas?", "Substituir", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                if(!app.Model_File.ReplaceWord(app.Model_File.text, tbOldWord.Text.ToString(), tbNewWord.Text.ToString()))
                    MessageBox.Show("Não foram efetuadas nenhumas mudanças!", "Notificação", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }
        private void Model_File_Word_Replaced()
        {
            // Notifica que a substituição foi um sucesso

            MessageBoxResult result = MessageBox.Show("Todas as entradas foram substituídas!", "Notificação", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
                this.Close();
        }
    }
}
