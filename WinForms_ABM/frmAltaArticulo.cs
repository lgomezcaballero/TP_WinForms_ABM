using System;
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
    public partial class frmAltaArticulo : Form
    {
        //private Articulo articulo = null;
       /* public frmAltaArticulo()
        {
            InitializeComponent();
        }

        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            //this.articulo = articulo;
            //Text = "Modificar Artículo";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Articulo articulo = new Articulo();
            ArticuloNegocio datos = new ArticuloNegocio();
            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = tbxCodigo.Text;
                articulo.Nombre = tbxNombre.Text;
                articulo.Descripcion = tbxDescripcion.Text;
                articulo.ImagenUrl = tbxImagenUrl.Text;
                articulo.Marca = (Marca)cbxMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;
                articulo.Precio = Convert.ToDecimal(tbxPrecio.Text);

                if (articulo.ID == 0)
                {
                    datos.agregarArticulo(articulo);
                    MessageBox.Show("El artículo se ha agregado exitosamente");

                }
                else
                {
                    datos.modificarArticulo(articulo);
                    MessageBox.Show("El articulo se ha modificado exitosamente");

                }
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marca = new MarcaNegocio();

            CategoriaNegocio categoria = new CategoriaNegocio();
            try
            {
                cbxMarca.DataSource = marca.listar();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "Descripcion";
                cbxCategoria.DataSource = categoria.listar();
                cbxCategoria.ValueMember = "Id";
                cbxCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    tbxCodigo.Text = articulo.Codigo;
                    tbxNombre.Text = articulo.Nombre;
                    tbxDescripcion.Text = articulo.Descripcion;
                    tbxImagenUrl.Text = articulo.ImagenUrl;
                    cbxMarca.SelectedValue = articulo.Marca.ID;
                    cbxCategoria.SelectedValue = articulo.Categoria.ID;
                    tbxPrecio.Text = articulo.Precio.ToString();
                    cargarImagen(articulo.ImagenUrl);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txbImagenUrl_Leave(object sender, EventArgs e)
        {
            cargarImagen(tbxImagenUrl.Text);
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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivo = new OpenFileDialog();
            archivo.Filter = "jpg|*.jpg";
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                tbxImagenUrl.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }
    */}
}
