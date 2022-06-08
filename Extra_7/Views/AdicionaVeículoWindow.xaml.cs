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

namespace Extra_7.Views
{
    /// <summary>
    /// Interaction logic for AdicionaVeículoWindow.xaml
    /// </summary>
    public partial class AdicionaVeículoWindow : Window
    {
        public AdicionaVeículoWindow()
        {
            InitializeComponent();

            cbTipo.Items.Add("Ligeiro");
            cbTipo.Items.Add("Pesado");
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
    }
}
