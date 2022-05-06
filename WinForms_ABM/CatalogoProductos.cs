﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WinForms_ABM
{
    public partial class FormInicio : Form
    {
        private List<Articulo> listaArticulos;
        public FormInicio()
        {
            InitializeComponent();
        }

        

        private void FormInicio_Load(object sender, EventArgs e)
        {
            actualizar();

        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo articuloSeleccionado = (Articulo)dgvDatos.CurrentRow.DataBoundItem;
            cargarImagen(articuloSeleccionado.ImagenUrl);
        }

        private void cargarImagen(string url)
        {
            try
            {
                pbImagen.Load(url);

            }
            catch (Exception)
            {
                
                pbImagen.Load("https://www.agora-gallery.com/advice/wp-content/uploads/2015/10/image-placeholder.png");
            }
        }

        private void actualizar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
                dgvDatos.DataSource = listaArticulos;
                OcultarColumnas();
                //dgvDatos.Columns["ImagenUrl"].Visible = false;
                //dgvDatos.Columns["Codigo"].Width = 40;
                //cargarImagen(listaArticulos[0].ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void OcultarColumnas()
        {
            dgvDatos.Columns ["ImagenUrl"].Visible = false;
            //dgvDatos.Columns["Codigo"].Width = 40;
            cargarImagen(listaArticulos[0].ImagenUrl);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            actualizar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Selecciona el articulo actual
            Articulo selecionado;
            selecionado = (Articulo)dgvDatos.CurrentRow.DataBoundItem;
            
            
            frmAltaArticulo modoficar = new frmAltaArticulo(selecionado);  
            modoficar.ShowDialog(); 
            //Cargar();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            ArticuloNegocio articulo = new ArticuloNegocio();
            Articulo seleccionado = new Articulo();


            try
            {

                DialogResult Respuesta = MessageBox.Show("¿Esta seguro que quiere eliminar ese articulo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvDatos.CurrentRow.DataBoundItem;
                    articulo.EliminarArticulo(seleccionado.ID);
                    actualizar();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());

            }
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> ArticulosFiltrados;
            string filtro = Filtro.Text;

            if(filtro != "")
            {
                //Aca filtra por Nombre del articulo o por su codigo, se puede hacer que filtre por otro atributos del articulo
             ArticulosFiltrados = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Codigo.ToUpper().Contains(filtro.ToUpper()));      
            }

            else
            {
                ArticulosFiltrados = listaArticulos;
            }


            dgvDatos.DataSource = null;
            dgvDatos.DataSource = ArticulosFiltrados;
            OcultarColumnas();

        }
    }
}
