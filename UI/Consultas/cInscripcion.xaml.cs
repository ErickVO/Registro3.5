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

namespace Registro.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cInscripcion.xaml
    /// </summary>
    public partial class cInscripcion : Window
    {
        public cInscripcion()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Inscripcion>();

            if (CriterioTexBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0:
                        listado = InscripcionBll.GetList(p => true);
                        break;

                    case 1:
                        int id = Convert.ToInt32(CriterioTexBox.Text);
                        listado = InscripcionBll.GetList(i => i.InscripcionId == id);
                        break;

                    case 2:
                        int monto = Convert.ToInt32(CriterioTexBox.Text);
                        listado = InscripcionBll.GetList(i => i.Monto == monto);
                        break;

                    case 3:
                        listado = InscripcionBll.GetList(i => i.Comentarios.Contains(CriterioTexBox.Text));
                        break;

                    

                }
                DateTime a = DesdeDatePicker.DisplayDate;
                DateTime b = HastaDatePicker.DisplayDate;

                //    listado = listado.Where(c => c.FechaNacimiento.Date >= a.Date. && c.FechaNacimiento.Date <= b.Date);
            }
            else
            {
                listado = InscripcionBll.GetList(i => true);
            }
        }
    }
}


