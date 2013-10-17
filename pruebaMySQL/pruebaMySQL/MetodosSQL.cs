using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms; // Borrar libreria
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace pruebaMySQL
{
    class MetodosSQL
    {

        private String parametrosSql = "Server=localhost;Port=3306;Database=beamdb;Uid=root;Pwd=Nexus4";
        MySqlConnection cnx;
        MySqlCommand cmd;



        public MetodosSQL()
        {
            cnx = new MySqlConnection(parametrosSql);
        }

        ~MetodosSQL()
        {
            cnx.Close();
            cnx.Dispose();
        }

        /* Metodo privado para abrir la conexion con la base de datos */

        private void abrirConexion()
        {
            cnx.Open();
            cmd = cnx.CreateCommand();
        }

        /* Metodo privado para cerrar la conexion con la base de datos */

        private void cerrarConexion()
        {
            cnx.Close();
            cnx.Dispose();
        }

        /* Metodo para introducir un mensajero en el sistema */

        public int nuevoMensajero(int tarifa, string nombre, string apellidos, string dni, string direccion, string fijo, string movil, string empresa, string banco, string email)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Insert INTO Mensajero (idTarifa_Mensajero,Nombre,Apellidos,DNI,Direccion,TelefonoFijo,TelefonoMovil,TelefonoEmpresa,NumCuentaBancaria,Email) VALUES (@tarifa,@nombre,@apellidos,@dni,@direccion,@fijo,@movil,@empresa,@banco,@email)";
                cmd.Parameters.AddWithValue("@tarifa", tarifa);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellidos", apellidos);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@fijo", fijo);
                cmd.Parameters.AddWithValue("@movil", movil);
                cmd.Parameters.AddWithValue("@empresa", empresa);
                cmd.Parameters.AddWithValue("@banco", banco);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);    // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }

        /* Metodo para borrar un mensajero del sistema */

        public int borrarMensajero(int idMensajero)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Delete FROM Mensajero WHERE idMensajero = @id";
                cmd.Parameters.AddWithValue("@id", idMensajero);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);  // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }

        /* Metodo para introducir un nuevo cliente en el sistema */

        public int nuevoCliente(int tarifa, string nombre, string delegacion, string direccion, string cif, string email, string fijo, string fax)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Insert INTO cliente (idTarifa_Cliente,NombreFiscal,Delegacion,DireccionFiscal,CIF,Email,Telefono,Fax) VALUES (@tarifa,@nombre,@delegacion,@direccion,@cif,@email,@fijo,@fax)";
                cmd.Parameters.AddWithValue("@tarifa", tarifa);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@delegacion", delegacion);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@cif", cif);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@fijo", fijo);
                cmd.Parameters.AddWithValue("@fax", fax);          
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);    // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }

        /* Metodo para borrar un cliente del sistema */

        public int borrarCliente(int idCliente)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Delete FROM cliente WHERE idCliente = @id";
                cmd.Parameters.AddWithValue("@id", idCliente);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);  // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }


         public int nuevaTarifaCliente(double direccionL,double tesperaL,double kmL,double dirlluviaL,double kmlluviaL,double direccionC,double kmC,double tesperaC, double direccionF,double kmNacF,double kmIntF,double mozo,double tesperaF,double nacCap14,double nacCap10,double valija,double excesos)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "INSERT INTO tarifa_cliente (DireccionesL,TEsperaL,KilometroL,DireccionLluviaL,KilometroLluviaL,DireccionC,KilometroC,TEsperaC,DireccionF,KilometroNacionalF,KilometroIntF,Mozo,TiempoEsperaF,NacionalCapital14,NacionalCapital10,Valija,Excesos) VALUES 
                    (@direccionL,tesperaL,@kmL,@dirlluviaL,@)";
                cmd.Parameters.AddWithValue("@direccionL", direccionL);
                cmd.Parameters.AddWithValue("@tesperaL", tesperaL);
                cmd.Parameters.AddWithValue("@kmL",kmL);
                cmd.Parameters.AddWithValue("@dirlluviaL",dirlluviaL);
                cmd.Parameters.AddWithValue("@kmlluvia", kmlluviaL);
                cmd.Parameters.AddWithValue("@direccionC", direccionC);
                cmd.Parameters.AddWithValue("@kmc",kmC);
                cmd.Parameters.AddWithValue("@tesperaC",tesperaC);
                cmd.Parameters.AddWithValue("@direccionF",direccionF);
                cmd.Parameters.AddWithValue("@kmNacF", kmNacF);
                cmd.Parameters.AddWithValue("@kmIntF", kmIntF);
                cmd.Parameters.AddWithValue("@mozo", mozo);
                cmd.Parameters.AddWithValue("@tesperaF", tesperaF);
                cmd.Parameters.AddWithValue("@nacCap14", nacCap14);
                cmd.Parameters.AddWithValue("@nacCap10", nacCap10);
                cmd.Parameters.AddWithValue("@valija", valija);
                cmd.Parameters.AddWithValue("@excesos", excesos);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);    // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }



        public int borrarTarifaCliente(int idTarifa)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Delete FROM tarifa_cliente WHERE idTarifa_Cliente = @id";
                cmd.Parameters.AddWithValue("@id", idTarifa);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);  // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }



        /****************************/

        public int nuevaTarifaMensajero(double direccionL, double kmL, double tesperaL, double dirlluviaL, double kmlluviaL, double direccionC, double kmC, double tesperaC, double excesos)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Insert INTO tarifa_mensajero (DireccionL,KilometrosL,TEsperaL,DireccionLLuviaL,KilometrosLLuviaL,DireccionC,KilometrosC,TEsperaC,Excesos) VALUES (@direccionL, @kmL, @tesperaL, @dirlluvial, @kmlluvial, @direccionC, @kmC, @tesperaC, @excesos)";                
                cmd.Parameters.AddWithValue("@direccionL", direccionL);
                cmd.Parameters.AddWithValue("@kmL", kmL);
                cmd.Parameters.AddWithValue("@tesperaL", tesperaL);                
                cmd.Parameters.AddWithValue("@dirlluviaL", dirlluviaL);
                cmd.Parameters.AddWithValue("@kmlluviaL", kmlluviaL);
                cmd.Parameters.AddWithValue("@direccionC", direccionC);
                cmd.Parameters.AddWithValue("@kmC", kmC);
                cmd.Parameters.AddWithValue("@tesperaC", tesperaC);
                cmd.Parameters.AddWithValue("@excesos", excesos);

            //    MessageBox.Show(cmd.CommandText);

                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);    // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }



        public int borrarTarifaMensajero(int idTarifa)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Delete FROM tarifa_mensajero WHERE idTarifa_Mensajero = @id";
                cmd.Parameters.AddWithValue("@id", idTarifa);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);  // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }

        public int insertarTipoServicio(char letra, string nombre)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Insert INTO tipo_servicio (Letra_Servicio, Nombre_Servicio) VALUES (@letra,@nombre)";
                cmd.Parameters.AddWithValue("@letra", letra);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);  // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }


        public int borrarTipoServicio(int idServicio)
        {
            abrirConexion();
            try
            {
                cmd.CommandText = "Delete FROM  tipo_servicio WHERE idTipo_Servicio = @id";
                cmd.Parameters.AddWithValue("@id", idServicio);
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);  // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }


        public int insertarServicioL(string fecha, int numAlbaran, double direcciones, double tEspera, double km,double direccionesL, double kmL, double variosServicio,double variosMensajero, double excesos, int mensajero, int cliente)
        {
             abrirConexion();
            try
            {
                cmd.CommandTimeout = 0;
                cmd.CommandText = "Insert INTO servicio (idTipo_Servicio,Fecha,NumAlbaran,DireccionesL,TEsperaL,KilometroL,DireccionLluviaL,KilometroLLuviaL,Excesos,VariosServicio,VariosMensajero,idMensajero,idCliente) VALUES (1,'2013-02-02',259,2.0,3.0,4.0,5.0, 2.0,2.0,5.0,0.0,1,1)";
                cmd.Parameters.AddWithValue("@tipo", 1);
                cmd.Parameters.AddWithValue("@fecha", fecha);
            //    cmd.Parameters.AddWithValue("@
               
                cmd.ExecuteNonQuery();
                cerrarConexion();
                return 0;

            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);  // NO! hacer Throw y mostrar mensaje en clase interfaz              
            }
            finally
            {
                cerrarConexion();
            }
            return 1;
        }



    }
}
