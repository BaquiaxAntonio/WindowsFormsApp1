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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Persona> personas = new List<Persona>();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {

            //intaciar clase
            Persona persona = new Persona();

            //guarda los datos de un persona
            persona.Dpi = textBoxDpi.Text;
            persona.Nombre=textBoxNombre.Text;
            persona.Apellido=textBoxApellido.Text;
            persona.FechaNacimiento = monthCalendar1.SelectionStart;

            textBoxDpi.Text = "";
            textBoxApellido.Text = "";
            textBoxNombre.Text = "";
            textBoxDpi.Select();

            //manda a guardar a la persona a la lesda de personas
            personas.Add(persona);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = personas;
            dataGridView1.Refresh();
        }
        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void buttonOrdenarApeliido_Click(object sender, EventArgs e)
        {
            personas=personas.OrderBy(p => p.Apellido).ToList();
            mostrar();
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            string dpi = textBoxDpi.Text;
            personas.RemoveAll(p => p.Dpi == dpi);
            mostrar();
        }

        private void buttonOrdenarDescendente_Click(object sender, EventArgs e)
        {
            personas.OrderByDescending(p => p.Apellido);
            mostrar();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {;
            FileStream  stream= new FileStream("personas.txt", FileMode.OpenOrCreate,FileAccess.Write);
            StreamWriter writer= new StreamWriter(stream);

            for(int i = 0; i < personas.Count; i++)
            {
                writer.WriteLine(personas[i].Dpi);
                writer.WriteLine(personas[i].Nombre);
                writer.WriteLine(personas[i].Apellido);
                writer.WriteLine(personas[i].FechaNacimiento);
            }
            writer.Close();
        }

        private void buttonLeer_Click(object sender, EventArgs e)
        {
            string fileName = "personas.txt";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek()>-1)
            {
                Persona persona = new Persona();
                persona.Dpi=reader.ReadLine();
                persona.Nombre=reader.ReadLine();
                persona.Apellido=reader.ReadLine();
                persona.FechaNacimiento=Convert.ToDateTime(reader.ReadLine());

                personas.Add(persona);
            }
            mostrar();
        }
    }
}
