using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace AppNuvem
{
     class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string cidade { get; set; }

        MySqlConnection con = new MySqlConnection("server=sql.freedb.tech;port=3306;database=freedb_testemulti;userid=freedb_abc321973;password=t8PtvCFeR3s?69r;charset=utf8");
        public List<Cliente> listacliente()
        {
            List<Cliente> li = new List<Cliente>();
            string sql = "SELECT * FROM cliente";
            con.Open();
            MySqlCommand cmd = new MySqlCommand (sql,con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Cliente c = new Cliente();
                c.id = (int)dr["id"];
                c.nome = dr["nome"].ToString();
                c.celular = dr["celular"].ToString();
                c.email = dr["email"].ToString();
                c.cidade = dr["cidade"].ToString();
                li.Add(c);

            }
            dr.Close();
            return li;

        }

            public void Inserir(string nome,string celular,string email,string cidade)
            {
                string sql = "INSERT INTO cliente(nome, celular,email,cidade) VALEUS ('"+nome+"','"+celular+"','"+email+"','"+cidade+"')";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }

            public void Atualizar(int id, string nome, string celular, string email, string cidade)
            {
                string sql = "UPDATE cliente Set nome='"+nome+"',celular='"+celular+"',email'"+email+"',cidade='"+cidade+"'WHERE id='"+id+"'";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();        
            }

            public void Excluir(int id)

            {
                string sql = "DELETE FROM cliente WHERE id= '"+id+"'";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }

        public void Localizar(int id)

        {
            string sql = "SELECT * FROM cliente WHERE id='" + id + "'";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                celular = dr["celular"].ToString();
                email = dr["email"].ToString();
                cidade = dr["cidade"].ToString();

                dr.Close();
                con.Close();

            }
        }



            public bool RegistroRepetido (string email)

            {
                string sql = "SELECT * FROM cliente WHERE email='"+email+"'";
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                var result = cmd.ExecuteScalar(); 
                if(result!=null)
                {
                    return (int)result > 0;

                }
                con.Clone();
                return false;


            
            }
            
            



    }
}
