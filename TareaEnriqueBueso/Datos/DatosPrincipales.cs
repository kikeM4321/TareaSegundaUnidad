using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosPrincipales
    {
       public async Task<bool> LoginAsync(string correo, string clave)
        {
            bool valido = false;
            try
            {
                string sql = "SELECT 1 FROM usuario WHERE Correo=@Correo AND Contraseña=@Contraseña;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexión.cadena))
                {
                  await _conexion.OpenAsync();
                    using(MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Correo", MySqlDbType.VarChar, 45).Value=correo;
                        comando.Parameters.Add("@Contraseña", MySqlDbType.VarChar, 45).Value = clave;

                        valido = Convert.ToBoolean(await comando.ExecuteScalarAsync());
                    }
                }
                
            }
            catch (Exception ex)
            {
            }
            return valido;
        }







    }
}
