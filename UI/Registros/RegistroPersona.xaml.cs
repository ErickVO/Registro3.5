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
    /// Interaction logic for Registro_de_Persona.xaml
    /// </summary>
    public partial class RegistroPersona : Window
    {
        public RegistroPersona()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDateTimePicker.Text = string.Empty;
            BalanceTextBox.Text = "0";
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private Personas LlenaClase()
        {
    
            Personas persona = new Personas();
            persona.Id = Convert.ToInt32(IdTextBox.Text);
            persona.Nombre = NombreTextBox.Text;
            persona.Telefono = TelefonoTextBox.Text;
            persona.Cedula = CedulaTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;
            persona.FechaNacimiento = FechaNacimientoDateTimePicker.DisplayDate;
            persona.Balance = persona.Balance;
            return persona;
        }

        private void LlenaCampo(Personas persona)
        {
            IdTextBox.Text = Convert.ToString(persona.Id);
            NombreTextBox.Text = persona.Nombre;
            TelefonoTextBox.Text = persona.Telefono;
            CedulaTextBox.Text = persona.Cedula;
            DireccionTextBox.Text = persona.Direccion;
            FechaNacimientoDateTimePicker.SelectedDate = persona.FechaNacimiento;
            BalanceTextBox.Text = Convert.ToString(persona.Balance);
        }

         private bool ExisteEnLaBaseDeDatos()
        {
            Personas persona = PersonasBll.Buscar((int)Convert.ToInt32(IdTextBox.Text));
            return (persona != null);
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Personas persona;
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenaClase();

            if ((Convert.ToInt32(IdTextBox.Text)) == 0)
            {
                paso = PersonasBll.Guardar(persona);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar la persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonasBll.Modificar(persona);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private bool Validar()
        {
            bool paso = true;


            if (NombreTextBox.Text == string.Empty)
            {
                MessageBox.Show(NombreTextBox.Text, "El campo no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MessageBox.Show(DireccionTextBox.Text, "El campo Direccion no puede estar vacio");
                DireccionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text.Replace("-", "")))
            {
                MessageBox.Show(CedulaTextBox.Text, "El campo Cedula no puede estar vacio");
                CedulaTextBox.Focus();
                paso = false;

            }
            return paso;
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

            if (PersonasBll.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show(IdTextBox.Text, "No se puede eliminar una persona que no existe");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

            persona = PersonasBll.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");
            }
        }
    }
}
