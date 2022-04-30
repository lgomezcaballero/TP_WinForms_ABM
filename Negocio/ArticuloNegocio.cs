using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            //SqlConnection conexion = new SqlConnection();
            //SqlCommand comando = new SqlCommand();
            //SqlDataReader lector;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                //comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "Select a.ID, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion Marca," +
                //    " c.Descripcion Categoria, a.ImagenUrl, a.Precio From ARTICULOS a Inner Join MARCAS m on a.IdMarca = m.Id" +
                //    " Inner Join CATEGORIAS c on a.IdCategoria = c.Id";
                datos.setConsulta("Select a.ID, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion Marca," +
                    " c.Descripcion Categoria, a.ImagenUrl, a.Precio From ARTICULOS a Inner Join MARCAS m on a.IdMarca = m.Id" +
                    " Inner Join CATEGORIAS c on a.IdCategoria = c.Id");
                datos.ejecutarLectura();
                //comando.Connection = conexion;
                
                //conexion.Open();
                //lector = comando.ExecuteReader();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.Lector["ID"];
                    if(!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if(!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if(!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion= (string)datos.Lector["Descripcion"];
                    if(!(datos.Lector["Marca"] is DBNull))
                        aux.Marca = new Marca();
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    if(!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion= (string)datos.Lector["Categoria"];
                    if(!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if(!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);

                }

                //conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                //Prueba
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("Insert Into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio)" +
                    " Values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");
                datos.setParametros("@Codigo", articulo.Codigo);
                datos.setParametros("@Nombre", articulo.Nombre);
                datos.setParametros("@Descripcion", articulo.Descripcion);
                datos.setParametros("@IdMarca", articulo.Marca.ID);
                datos.setParametros("@IdCategoria", articulo.Categoria.ID);
                datos.setParametros("@Precio", articulo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
