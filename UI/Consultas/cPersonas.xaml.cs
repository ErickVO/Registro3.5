using Registro.BLL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Registro.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cPersonas.xaml
    /// </summary>
    public partial class cPersonas : Window
    {
        public cPersonas()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = PersonasBll.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = PersonasBll.GetList(p => p.Id == id);
                        break;

                    case 2:
                        listado = PersonasBll.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;

                    case 3:
                        listado = PersonasBll.GetList(p => p.Cedula.Contains(CriterioTextBox.Text));
                        break;

                    case 4:
                        listado = PersonasBll.GetList(p => p.Direccion.Contains(CriterioTextBox.Text));
                        break;

                }
                

              listado = listado.Where(c => c.FechaNacimiento.Date >= DesdeDatePicker.SelectedDate && c.FechaNacimiento.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = PersonasBll.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}


