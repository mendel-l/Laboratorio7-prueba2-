using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio7_prueba2_
{
    public partial class Form1 : Form
    {
        List<Propietario> propietarios = new List<Propietario>();
        List<Propiedad> propiedades = new List<Propiedad>();
        List<Total> total = new List<Total>();
        public Form1()
        {
            InitializeComponent();
        }
        private void SaveTxtPropietario()
        {
            FileStream stream = new FileStream(@"Propietario.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var propietario in propietarios)
            {
                writer.WriteLine(propietario.Dpi);
                writer.WriteLine(propietario.Nombre);
                writer.WriteLine(propietario.Apellido);
            }
            writer.Close();
        }
        private void ReadTxtPropietario()
        {
            FileStream stream = new FileStream("Propietario.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1) 
            {
                Propietario persona = new Propietario();
                persona.Dpi = reader.ReadLine();
                persona.Nombre = reader.ReadLine();
                persona.Apellido = reader.ReadLine();
                propietarios.Add(persona);
            }
            reader.Close();
        }

        private void SaveTxtPropiedad()
        {
            FileStream stream = new FileStream(@"Propiedad.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var propiedad in propiedades)
            {
                writer.WriteLine(propiedad.NoCasa);
                writer.WriteLine(propiedad.DpiOwner);
                writer.WriteLine(propiedad.CuotaMantenimiento);
            }
            writer.Close();
        }
        private void ReadTxtPropiedad()
        {
            FileStream stream = new FileStream("Propiedad.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Propiedad BienInmueble = new Propiedad();
                BienInmueble.NoCasa = reader.ReadLine();
                BienInmueble.DpiOwner = reader.ReadLine();
                BienInmueble.CuotaMantenimiento = reader.ReadLine();
                propiedades.Add(BienInmueble);
            }
            reader.Close();
        }
        private void ActualizarGridPropietarios()
        {
            dataGridViewTotal.DataSource = null;
            dataGridViewTotal.Refresh();
            dataGridViewTotal.DataSource = propietarios;
            dataGridViewTotal.Refresh();

            dataGridViewTotal.DataSource = null;
            dataGridViewTotal.Refresh();
            dataGridViewTotal.DataSource = propiedades;
            dataGridViewTotal.Refresh();
        }

        private void buttonIngresarPropietarios_Click(object sender, EventArgs e)
        {
            Propietario prop = new Propietario();
            prop.Dpi = textBoxDPI.Text;
            prop.Nombre = textBoxName.Text;
            prop.Apellido = textBoxLastName.Text;

            propietarios.Add(prop);

            SaveTxtPropietario();
            ReadTxtPropietario();
        }

        private void buttonIngresarPropiedades_Click(object sender, EventArgs e)
        {
            Propiedad prop = new Propiedad();
            prop.NoCasa = textBoxNoHouse.Text;
            prop.DpiOwner = comboBoxDPIOwner.Text;
            prop.CuotaMantenimiento = Convert.ToString(numericUpDownCuotaMantenimiento.Value);

            propiedades.Add(prop);

            SaveTxtPropiedad();
            ReadTxtPropiedad();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < propietarios.Count; ++i)
            {
                Total registro = new Total();

                for (int j = 0; j < propiedades.Count; j++)
                {
                    if (propietarios[i].Dpi == propiedades[j].DpiOwner)
                    {
                        registro.Name = propietarios[i].Nombre;
                        registro.LastName = propietarios[i].Apellido;
                        registro.NoHouse = propiedades[j].NoCasa;
                        registro.PaySuport = propiedades[j].CuotaMantenimiento;
                    }
                }
                total.Add(registro);
                dataGridViewTotal.DataSource = null;
                dataGridViewTotal.Refresh();

                dataGridViewTotal.DataSource = total;
                dataGridViewTotal.Refresh();
            
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            total = total.OrderByDescending(n => n.PaySuport).ToList();
            dataGridViewTotal.DataSource = null;
            dataGridViewTotal.Refresh();
            dataGridViewTotal.DataSource = total;
            dataGridViewTotal.Refresh();
        }
    }
}
