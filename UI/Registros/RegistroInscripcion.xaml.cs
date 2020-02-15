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
    /// Interaction logic for Registro_Inscripcion.xaml
    /// </summary>
    public partial class RegistroInscripcion : Window
    {
        public RegistroInscripcion()
        {
            InitializeComponent();
        }

    

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            FechaDatePicker.Text = string.Empty;
            IdPersonaTextBox.Text = string.Empty;
            ComentariosTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            BalanceTextBox.Text = "0";

        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Inscripcion LlenaClase()
        {
            int id;
            int.TryParse(IdPersonaTextBox.Text, out id);

            Personas persona = new Personas();
            Inscripcion inscripcion = new Inscripcion();

             persona = PersonasBll.Buscar(id);

            int a = Convert.ToInt32(MontoTextBox.Text);

            if(persona != null){
                
                inscripcion.InscripcionId = Convert.ToInt32(IdTextBox.Text);
                inscripcion.Fecha = FechaDatePicker.DisplayDate;
                inscripcion.PersonaId = Convert.ToInt32(IdPersonaTextBox.Text);
                inscripcion.Comentarios = ComentariosTextBox.Text;
                inscripcion.Monto += a;
                inscripcion.Balance = a + inscripcion.Balance;
                persona.Balance = a + persona.Balance;
                
            }
            else
            {
                MessageBox.Show("Esta persona no existe");
            }
                return inscripcion;
        }


        private void LlenaCampo(Inscripcion inscripcion)
        {
            IdTextBox.Text = Convert.ToString(inscripcion.InscripcionId);
            FechaDatePicker.SelectedDate = inscripcion.Fecha;
            IdPersonaTextBox.Text = Convert.ToString(inscripcion.PersonaId);
            ComentariosTextBox.Text = inscripcion.Comentarios;
            MontoTextBox.Text =Convert.ToString(inscripcion.Monto);
            BalanceTextBox.Text = Convert.ToString(inscripcion.Balance);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Inscripcion inscripcion = InscripcionBll.Buscar((int)Convert.ToInt32(IdTextBox.Text));
            return (inscripcion != null);
        }


        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Inscripcion inscripcion;
            
            bool paso = false;

            if (!Validar())
                return;
            
            inscripcion = LlenaClase();
            if ((Convert.ToInt32(IdTextBox.Text)) == 0)
            {
                
                paso = InscripcionBll.Guardar(inscripcion);
            }
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede Modificar la persona que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = InscripcionBll.Modificar(inscripcion);

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


            if (IdPersonaTextBox.Text == string.Empty)
            {
                MessageBox.Show(IdPersonaTextBox.Text, "El campo no puede estar vacio");
                IdPersonaTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ComentariosTextBox.Text))
            {
                MessageBox.Show(ComentariosTextBox.Text, "El campo Comentario no puede estar vacio");
                ComentariosTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(FechaDatePicker.Text))
            {
                MessageBox.Show("Este campo no puede estar vacio", "Error");
                FechaDatePicker.Focus();
                paso = false;

            }



            return paso;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Inscripcion inscripcion = new Inscripcion();
            int.TryParse(IdTextBox.Text, out id);

            Limpiar();

            inscripcion = InscripcionBll.Buscar(id);

            if (inscripcion != null)
            {
                
                MessageBox.Show("Inscripcion Encontrada");
                LlenaCampo(inscripcion);
            }
            else
            {
                MessageBox.Show("Inscripcion no Encontrada");
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);
            Inscripcion inscripcion = new Inscripcion();
            Limpiar();

            if (InscripcionBll.Eliminar(id))

                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                
            else
                MessageBox.Show(IdTextBox.Text, "No se puede eliminar una persona que no existe");
        }

       
    }
}
