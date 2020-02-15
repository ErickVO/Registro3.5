using Registro.BLL;
using Registro.Entidades;
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
using Registro.UI.Registros;
using Registro.UI.Consultas;

namespace Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuRePersona_Click(object sender, RoutedEventArgs e)
        {
            RegistroPersona persona = new RegistroPersona();
            persona.ShowDialog();
        }

        private void MenuReInscripcion_Click(object sender, RoutedEventArgs e)
        {
            RegistroInscripcion inscripcion = new RegistroInscripcion();
            inscripcion.ShowDialog();
        }

        private void MenuRePago_Click(object sender, RoutedEventArgs e)
        {
            RegistroPago pago = new RegistroPago();
            pago.ShowDialog();
        }

        private void ConsultaPersona_Click(object sender,RoutedEventArgs e)
        {
            cPersonas cp = new cPersonas();
            cp.ShowDialog();

        }

        private void ConsultaInscripcion_Click(object sender, RoutedEventArgs e)
        {
            cInscripcion ci = new cInscripcion();
            ci.ShowDialog();

        }

    }
}