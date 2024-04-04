using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassKortLagning
{
    public class cSkjalamyndarar
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = kortlagning; allow user variables = True; character set = utf8";
       // private string m_strTenging = "server = srv-rafraenskil-1.edge.is; user id = brjann; Password = 100%gledi; persist security info = True; database = kortlagning; allow user variables = True; character set = utf8";

        public int ID { get; set; }
        public string Heiti {  get; set; }
        public string Sveitarfelag { get; set; }
        public string Tengilidur {  get; set; } 
        public string Starfsheiti { get; set; } 
        public string Heimilisfang {  get; set; }
        public string Tolvupostfang { get; set; }
        public string Simi {  get; set; }

        public DataTable geSkjalamyndara(string strVarsla)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string strSQL = string.Format("SELECT distinct s.id, s.heiti, s.sveitarfelag, s.tengilidur, s.starfsheiti, s.heimilisfang, s.tolvupostfang, s.simi  FROM skjalamyndari s, kortlagning k where k.skjalid=s.id and  k.heraudkenni = '{0}';", strVarsla);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable geSkjalamyndara(int ID)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string strSQL = string.Format ("SELECT * FROM skjalamyndari s WHERE id = {0};", ID);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public int Vista()
        {
            int iRet = 0;

            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  id, karfa, md5, Vörlsuutgafa, Skrar, slod
            command.Parameters.AddWithValue("@ID", this.ID);
            command.Parameters.AddWithValue("@heiti", this.Heiti);
            command.Parameters.AddWithValue("@sveitarfelag", this.Sveitarfelag);
            command.Parameters.AddWithValue("@tengilidur", this.Tengilidur);
            command.Parameters.AddWithValue("@starfsheiti", this.Starfsheiti);
            command.Parameters.AddWithValue("@heimilisfang", this.Heimilisfang);
            command.Parameters.AddWithValue("@tolvupostfang", this.Tolvupostfang);
            command.Parameters.AddWithValue("@simi", this.Simi);
            //id, heiti, sveitarfelag, tengilidur, starfsheiti, heimilisfang, tolvupostfang, simi
          
            if (this.ID == 0)
            {
                command.CommandText = string.Format("INSERT INTO `skjalamyndari` SET  `heiti`=@heiti, `sveitarfelag`=@sveitarfelag, `tengilidur`=@tengilidur, `starfsheiti`=@starfsheiti, `heimilisfang`=@heimilisfang, `tolvupostfang`=@tolvupostfang, `simi`=@simi ;");
            }
            else
            {
                command.CommandText = string.Format("UPDATE `skjalamyndari` SET  `heiti`=@heiti, `sveitarfelag`=@sveitarfelag, `tengilidur`=@tengilidur, `starfsheiti`=@starfsheiti, `heimilisfang`=@heimilisfang, `tolvupostfang`=@tolvupostfang, `simi`=@simi WHERE ID = {0} ;", this.ID);
            }
     
            command.ExecuteNonQuery();

            command.CommandText = "SELECT max(id) FROM skjalamyndari s";
            iRet = Convert.ToInt32(command.ExecuteScalar());
            conn.Dispose();
            command.Dispose();

            return iRet;

        }
    }
}
