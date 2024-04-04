using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cClassKortLagning
{
    public class cVorslustofnanir
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = kortlagning; allow user variables = True; character set = utf8";
        //private string m_strTenging = "server = srv-rafraenskil-1.edge.is; user id = brjann; Password = 100%gledi; persist security info = True; database = kortlagning; allow user variables = True; character set = utf8";


        public int ID { get; set; }
        public string Heiti { get; set; }

        public string Audkenni { get; set; }

        public string Lykilord { get; set; }    

        public DataTable getVorslustofnanir()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string strSQL = "SELECT * FROM vorslustofnun v; ";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public string getLogin(string strUser, string strPassword)
        {
            string strRet = null;
            string strSQL = string.Format("SELECT audkenni FROM vorslustofnun v where audkenni = '{0}' and lykilord = '{1}';", strUser, strPassword);
            var login = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
            if (login != null)
            {
                strRet = login.ToString();
            }
            return strRet;
        }

        public void vistaVorslustofnun()
        {

            //vista stöff
            MySqlConnection conn = new MySqlConnection(m_strTenging);
            conn.Open();
            MySqlCommand command = new MySqlCommand("", conn);
            //  id, karfa, md5, Vörlsuutgafa, Skrar, slod
            command.Parameters.AddWithValue("@ID", this.ID);
            command.Parameters.AddWithValue("@Heiti", this.Heiti);
            command.Parameters.AddWithValue("@Audkenni", this.Audkenni);

            if (this.ID == 0)
            {
                command.CommandText = string.Format("INSERT INTO `vorslustofnun` SET  `Heiti`=@heiti,  `Audkenni`=@Audkenni ;");
            }
            else
            {
                command.CommandText = string.Format("UPDATE `vorslustofnun` SET  `Heiti`=@heiti WHERE id = {0};", this.ID);
            }
            command.ExecuteNonQuery();
            conn.Dispose();
            command.Dispose();

        }
    }
}
