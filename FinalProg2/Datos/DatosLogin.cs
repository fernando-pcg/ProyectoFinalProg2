using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Logica;
using System.Windows;


namespace Datos
{
    public class DatosLogin
    {
        SqlConnection cnn;
        SqlCommand comando;
        SqlDataReader dr;
        Login Logic = new Login();
        Cliente clt = new Cliente();
        public void Conexion()
        {
            cnn = new SqlConnection("Data Source=FERNANDORFR;Initial Catalog=FinalProg2;Integrated Security=True");
            cnn.Open();
        }

        public string LoginRequest(string Correo)
        {
            Conexion();
            string ClaveR = "Correo";
            string lineaComando = $"Select Clave, IdCliente from Usuarios where Correo = '{Correo}'";
            comando = new SqlCommand(lineaComando, cnn);
            dr = comando.ExecuteReader();


            if (dr.Read())
            {

                ClaveR = dr["Clave"].ToString();
            }
            dr.Close();
            return ClaveR;


        }
       

        public int RolRequest(string Correo)
        {
            Conexion();
            int RolR;
            string lineaComando = $"Select Rol from Usuarios where Correo = '{Correo}'";
            comando = new SqlCommand(lineaComando, cnn);
            dr = comando.ExecuteReader();
            dr.Read();
            RolR = int.Parse(dr["Rol"].ToString());
            dr.Close();
            return RolR;


        }
        public List<string> GetDataClient(int id)
        {
            
            Conexion();
            string lineaComando = $"Select * from Cliente where IdCliente = {id}";
            comando = new SqlCommand(lineaComando, cnn);
            dr = comando.ExecuteReader();
            dr.Read();
            List<string> ClientesArray = new List<string>();
            ClientesArray.Add(dr["Nombre"].ToString());
            ClientesArray.Add(dr["Apellido"].ToString());
            ClientesArray.Add(dr["CedulaPasaporte"].ToString());
            ClientesArray.Add(dr["FechaNacimiento"].ToString());
            ClientesArray.Add(dr["Edad"].ToString());
            ClientesArray.Add(dr["Direccion"].ToString());
            ClientesArray.Add(dr["Telefono"].ToString());
            ClientesArray.Add(dr["Celular"].ToString());
            ClientesArray.Add(dr["PrestamoA"].ToString());
            dr.Close();
                return ClientesArray;
            
            

        }
        public List<string> GetDataMoney(int id)
        {

            Conexion();
            string lineaComando = $"Select * from Prestamos where IdCliente = {id}";
            comando = new SqlCommand(lineaComando, cnn);
            dr = comando.ExecuteReader();
            dr.Read();
            List<string> ClientesArray = new List<string>();
            ClientesArray.Add(dr["Nombre"].ToString());
            ClientesArray.Add(dr["Apellido"].ToString());
            ClientesArray.Add(dr["CedulaPasaporte"].ToString());
            ClientesArray.Add(dr["FechaNacimiento"].ToString());
            ClientesArray.Add(dr["Edad"].ToString());
            ClientesArray.Add(dr["Direccion"].ToString());
            ClientesArray.Add(dr["Telefono"].ToString());
            ClientesArray.Add(dr["Celular"].ToString());
            ClientesArray.Add(dr["PrestamoA"].ToString());
            dr.Close();
            return ClientesArray;

        }
        public List<string> GetDataUser(int id)
        {

            Conexion();
            string lineaComando = $"select idusuario, Nombre,Correo,Clave,Estado from Usuarios where IdCliente = {id}";
            comando = new SqlCommand(lineaComando, cnn);
            dr = comando.ExecuteReader();
            dr.Read();
            List<string> ClientesArray = new List<string>();
            ClientesArray.Add(dr["Nombre"].ToString());
            ClientesArray.Add(dr["Correo"].ToString());
            ClientesArray.Add(dr["Clave"].ToString());
            ClientesArray.Add(dr["Estado"].ToString());
            dr.Close();
            return ClientesArray;



        }

        public void Guardar(string Nombre, string Apellido, string Cedula, string Fecha, int Edad, string Direccion, Int64 Telefono, Int64 Celular)
        {
            Conexion();
            string lineacomando = $"insert into Cliente (Nombre,Apellido,CedulaPasaporte,FechaNacimiento,Edad,Direccion,Telefono,Celular)values ('{Nombre}','{Apellido}','{Cedula}','{Fecha}',{Edad},'{Direccion}',{Telefono},{Celular})";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }

        public void Borrar(int idCliente)
        {
            Conexion();
            string lineacomando = $"delete from Cliente where idCliente = ({idCliente})";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }

        public void Actualizar(string Nombre, string Apellido, string Cedula, string Fecha, int Edad, string Direccion, Int64 Telefono, Int64 Celular, int idCliente)
        {
            Conexion();
            string lineacomando = $"update Cliente set nombre ='{Nombre}', Apellido='{Apellido}',Cedula='{Cedula}', Fecha ='{Fecha}', Edad = {Edad},Direccion='{Direccion}',Telefono= '{Telefono}', Celular='{Celular}' where idCliente = '{idCliente }";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable Buscar(int idCliente)
        {
            Conexion();
            string lineacomando = $"select * from Cliente where idCliente ={idCliente}";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable table = new DataTable();
            data.Fill(table);
            cnn.Close();
            return table;

        }
        public void GuardarP(decimal interes, decimal capital, string tiempo, string fecha, int cuotas, decimal pagos, decimal deudas)
        {
            Conexion();
            string lineacomando = $"insert into Prestamos values ({interes},{capital},'{tiempo}','{fecha}',{cuotas},{pagos},{deudas})";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }

        public void BorrarP(int IdPrestamo)
        {
            Conexion();
            string lineacomando = $"delete from Prestamos where IdPrestamo = (IdPrestamo)";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }

        public void ActualizarP(decimal interes, decimal capital, string tiempo, string fecha, int cuotas, decimal pagos, decimal deudas, int IdPrestamo)
        {
            Conexion();
            string lineacomando = $"update Prestamos set Interes ={interes}, Capital ={capital},Tiempo='{tiempo}', Cuotas={cuotas}, Pagos={pagos}, Deudas={deudas} where IdPrestamo = {IdPrestamo}";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable BuscarP(int IdPrestamo)
        {
            Conexion();
            string lineacomando = $"select * from Prestamos where IdPrestamo ={IdPrestamo}";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable table = new DataTable();
            data.Fill(table);
            cnn.Close();
            return table;

        }


        public void GuardarU(string nombre, string correo, string clave, string estado)
        {
            Conexion();
            string lineacomando = $"insert into Usuarios(Nombre,Correo,Clave,Estado) values ('{nombre}','{correo}','{clave}','{estado}')";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }

        public void BorrarU(int idusuario)
        {
            Conexion();
            string lineacomando = $"delete from Usuarios where idusuario = ({idusuario})";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }

        public void ActualizarU(string nombre, string correo, string clave, string estado, int idusuario)
        {
            Conexion();
            string lineacomando = $"update Usuarios set Nombre ='{nombre}', Correo='{correo}',Estado='{estado}', Rol ={rol}  where idusuario = {idusuario}";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            cnn.Close();
        }
        public DataTable BuscarU(int idusuario)
        {
            Conexion();
            string lineacomando = $"select * from Usuarios  where idusuario ={idusuario}";
            comando = new SqlCommand(lineacomando, cnn);
            comando.ExecuteNonQuery();
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable table = new DataTable();
            data.Fill(table);
            cnn.Close();
            return table;

        }

        public DataTable LlenarGrid()
        {
            Conexion();
            string lineaComando = $"select idCliente,Nombre,Apellido,CedulaPasaporte,FechaNacimiento,Edad,Direccion,Telefono,Celular,PrestamoA from Cliente";
            comando = new SqlCommand(lineaComando, cnn);
            comando.ExecuteNonQuery();
            //Comando para adaptar la vista de la tabla al datagridview
            SqlDataAdapter data = new SqlDataAdapter(comando);
            //instanciando la tabla como nueva tabla de datos
            DataTable table = new DataTable();
            //Llenar el grid con la tabla adaptada
            data.Fill(table);
            cnn.Close();
            //Retorna la tabla
            return table;

        }
        public DataTable LlenarGridU()
        {
            Conexion();
            string lineaComando = $"select idusuario, Nombre,Correo,Clave,Estado from Usuarios" +
                $"";
            comando = new SqlCommand(lineaComando, cnn);
            comando.ExecuteNonQuery();
            //Comando para adaptar la vista de la tabla al datagridview
            SqlDataAdapter data = new SqlDataAdapter(comando);
            //instanciando la tabla como nueva tabla de datos
            DataTable table = new DataTable();
            //Llenar el grid con la tabla adaptada
            data.Fill(table);
            cnn.Close();
            //Retorna la tabla
            return table;

        }
    }
}
