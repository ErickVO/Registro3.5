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
        
            int idP;
            int.TryParse(InscripcionIdTextBox.Text, out idP);
            Inscripcion inscripcion = new Inscripcion();
            Personas persona = new Personas();

            inscripcion = InscripcionBll.Buscar(idP);
            persona = PersonasBll.Buscar(inscripcion.PersonaId);

            if (!Validar())
                return;

            int a = Convert.ToInt32(MontoPagarTextBox.Text);

            if(a > 0 )
            {
                if(inscripcion != null)
                {
                    inscripcion.Balance = inscripcion.Balance - a;
                    persona.Balance = persona.Balance - a;
                }
                    
            }
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
