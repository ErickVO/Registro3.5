using Registro.BLL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro.UI.Registros
{
    /// <summary>
    /// Interaction logic for Registro_Pago.xaml
    /// </summary>
    public partial class RegistroPago : Window
    {
        public RegistroPago()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdPagoTextBox.Text = string.Empty;
            InscripcionIdTextBox.Text = string.Empty;
            MontoPagarTextBox.Text = string.Empty;
        }



        private void BtnPagar_Click(object sender, RoutedEventArgs e)
        {
            int Id = Convert.ToInt32(InscripcionIdTextBox.Text);
            int Monto = Convert.ToInt32(MontoPagarTextBox.Text);

            if (!Validar())
                return;

            InscripcionBll.Pago(Id, Monto);

            
            Limpiar();

        }

        

        private bool Validar()
        {
            bool paso = true;


            if (IdPagoTextBox.Text == string.Empty)
            {
                MessageBox.Show(IdPagoTextBox.Text, "El campo no puede estar vacio");
                IdPagoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(InscripcionIdTextBox.Text))
            {
                MessageBox.Show(InscripcionIdTextBox.Text, "El campo Comentario no puede estar vacio");
                InscripcionIdTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MontoPagarTextBox.Text))
            {
                MessageBox.Show(MontoPagarTextBox.Text, "El campo Monto no puede estar vacio");
                MontoPagarTextBox.Focus();
                paso = false;

            }
            return paso;
        }
    }
}
