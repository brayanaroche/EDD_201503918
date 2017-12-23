using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbolBinarioBusqueda
{
    public partial class Form1 : Form
    {
        ArbolBB arbol = new ArbolBB();

        public Form1()
        {
            InitializeComponent();
            arbol.inicializarArbol();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arbol.retorno = "";
            arbol.retornoIn = "";
            arbol.retornoPost = "";
            arbol.insertarArbol(textBox1.Text);
            
            textBox2.Text = arbol.PreOrden(arbol.raiz);
            textBox3.Text = arbol.InOrden(arbol.raiz);
            textBox4.Text = arbol.PostOrden(arbol.raiz);
            textBox1.Clear();
        }
    }
}
