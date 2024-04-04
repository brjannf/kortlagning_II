using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;


namespace cClassKortLagning
{
    public class cKortLagningListi
    {
        private string m_strTenging = "server = localhost; user id = root; Password = ivarBjarkLind; persist security info = True; database = kortlagning; allow user variables = True; character set = utf8";
        //private string m_strTenging = "server = srv-rafraenskil-1.edge.is; user id = brjann; Password = 100%gledi; persist security info = True; database = kortlagning; allow user variables = True; character set = utf8";

        public int ID { get; set; }
        public string Heraudkenni { get; set; }
        public string Varsla_heiti { get; set; }
        public string Varsla_audkenni { get; set; }
        public int SkjalID { get; set; }
        public string Skjalm_heiti { get; set; }
        public string Sveitarfelag { get; set; }
        public string Heiti_kerfis { get; set; }
        public string Rafraen_sofn { get; set; }
        public string Hlutverk { get; set; }
        public string Abyrgd_umsjon { get; set; }
        public string Starfseining { get; set; }
        public string Tengilidur_starfseiningar { get; set; }
        public string Birgi { get; set; }
        public string Hysing { get; set; }
        public string Dags_tekid_i_notkun { get; set; }
        public string Dags_tilkynnt { get; set; }
        public string Vardveisla { get; set; }
        public string Staerd { get; set; }
        public string Notkun { get; set; }
        public string Athugasemdir { get; set; }
        public string Aaetlud_skil { get; set; }
        public bool Skilad { get; set; }
        //   id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing,
        //   dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil

        public void hreinsaHlut()
        {
            this.ID = 0;
            this.Heraudkenni = string.Empty;
            this.Varsla_heiti = string.Empty;
            this.Varsla_audkenni = string.Empty;
            this.SkjalID = 0;
            this.Skjalm_heiti = string.Empty;
            this.Sveitarfelag = string.Empty;
            this.Heiti_kerfis = string.Empty;
            this.Rafraen_sofn = string.Empty;
            this.Hlutverk = string.Empty;
            this.Abyrgd_umsjon = string.Empty;
            this.Starfseining = string.Empty;
            this.Tengilidur_starfseiningar = string.Empty;
            this.Birgi = string.Empty;
            this.Hysing = string.Empty;
            this.Dags_tekid_i_notkun = string.Empty;
            this.Dags_tilkynnt = string.Empty;
            this.Vardveisla = string.Empty;
            this.Staerd = string.Empty;
            this.Notkun = string.Empty;
            this.Athugasemdir = string.Empty;
            this.Aaetlud_skil = string.Empty;
            Skilad = false;
    
    }
        public DataTable getKortLagning()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string strSQL = "SELECT v.heiti as varsla_heiti, v.audkenni, s.heiti as skjalm_heiti, s.sveitarfelag, h.hlutverk, k.* FROM kortlagning k, skjalamyndari s, vorslustofnun v, hlutverk h where k.herAudkenni=v.audkenni and k.skjalID=s.id and h.id= k.hlutverk ;";
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getKortLagning(int iID)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //   string strSQL = string.Format("SELECT v.heiti as varsla_heiti, v.audkenni, s.heiti as skjalm_heiti, s.sveitarfelag, h.hlutverk, k.* FROM kortlagning k, skjalamyndari s, vorslustofnun v, hlutverk h where k.herAudkenni=v.audkenni and k.skjalID=s.id and h.id= k.hlutverk AND k.id={0};", iID);
            string strSQL = string.Format("SELECT * FROM kortlagning k where k.id = {0};", iID);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public DataTable getKortLagning(string strVarsla)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string strSQL = string.Format("SELECT v.heiti as varsla_heiti, v.audkenni, s.heiti as skjalm_heiti, s.sveitarfelag, h.hlutverk, k.* FROM kortlagning k, skjalamyndari s, vorslustofnun v, hlutverk h where k.heraudkenni=v.audkenni and k.skjalID=s.id and h.id= k.hlutverk and v.audkenni = '{0}' ;", strVarsla);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        public DataTable getKortLagningLeitVarsla(string strVarsla)
        {
            string strSQL = string.Empty;
            if (!string.IsNullOrEmpty(strVarsla))
            {
                strSQL = string.Format("SELECT v.heiti as varsla_heiti, v.audkenni, s.heiti as skjalm_heiti, s.sveitarfelag, h.hlutverk, k.* FROM kortlagning k, skjalamyndari s, vorslustofnun v, hlutverk h where k.heraudkenni=v.audkenni and k.skjalID=s.id and h.id= k.hlutverk and v.audkenni = '{0}' ", strVarsla);
            }
            else
            {
                strSQL = string.Format("SELECT v.heiti as varsla_heiti, v.audkenni, s.heiti as skjalm_heiti, s.sveitarfelag, h.hlutverk, k.* FROM kortlagning k, skjalamyndari s, vorslustofnun v, hlutverk h where k.heraudkenni=v.audkenni and k.skjalID=s.id and h.id= k.hlutverk ");
            }
            
            if(!string.IsNullOrEmpty(this.Varsla_heiti))
            {
                strSQL += string.Format(" and v.heiti like '%{0}%' ", this.Varsla_heiti);
            }
            if (!string.IsNullOrEmpty(this.Skjalm_heiti))
            {
                strSQL += string.Format(" and s.heiti like '%{0}%' ", this.Skjalm_heiti);
            }
            if (!string.IsNullOrEmpty(this.Sveitarfelag))
            {
                strSQL += string.Format(" and s.sveitarfelag like '%{0}%' ", this.Sveitarfelag);
            }
            if (!string.IsNullOrEmpty(this.Heiti_kerfis))
            {
                strSQL += string.Format(" and k.heiti_kerfis like '%{0}%' ", this.Heiti_kerfis);
            }
            if (!string.IsNullOrEmpty(this.Rafraen_sofn))
            {
                strSQL += string.Format(" and k.rafraen_sofn like '{0}' ", this.Rafraen_sofn);
            }
            if (!string.IsNullOrEmpty(this.Hlutverk))
            {
                strSQL += string.Format(" and h.hlutverk like '{0}' ", this.Hlutverk);
            }
            if (!string.IsNullOrEmpty(this.Abyrgd_umsjon))
            {
                strSQL += string.Format(" and k.abyrgd_umsjon like '%{0}%' ", this.Abyrgd_umsjon);
            }
            if (!string.IsNullOrEmpty(this.Starfseining))
            {
                strSQL += string.Format(" and k.starfseining like '%{0}%' ", this.Starfseining);
            }
            if (!string.IsNullOrEmpty(this.Tengilidur_starfseiningar))
            {
                strSQL += string.Format(" and k.tengilidur_starfseiningar like '%{0}%' ", this.Tengilidur_starfseiningar);
            }
            if (!string.IsNullOrEmpty(this.Birgi))
            {
                strSQL += string.Format(" and k.birgi like '%{0}%' ", this.Birgi);
            }
            if (!string.IsNullOrEmpty(this.Hysing))
            {
                strSQL += string.Format(" and k.hysing like '%{0}%' ", this.Hysing);
            }
           if (!string.IsNullOrEmpty(this.Dags_tekid_i_notkun))
            {
                strSQL += string.Format(" and k.dags_tekid_i_notkun like '%{0}%' ", this.Dags_tekid_i_notkun);
            }
            if (!string.IsNullOrEmpty(this.Dags_tilkynnt))
            {
                strSQL += string.Format(" and k.dags_tilkynnt like '%{0}%' ", this.Dags_tilkynnt);
            }
            if (!string.IsNullOrEmpty(this.Vardveisla))
            {
                strSQL += string.Format(" and k.vardveisla like '{0}' ", this.Vardveisla);
            }
            if (!string.IsNullOrEmpty(this.Staerd))
            {
                strSQL += string.Format(" and k.staerd like '%{0}%' ", this.Staerd);
            }
            if (!string.IsNullOrEmpty(this.Notkun))
            {
                strSQL += string.Format(" and k.notkun like '{0}' ", this.Notkun);
            }
            if (!string.IsNullOrEmpty(this.Athugasemdir))
            {
                strSQL += string.Format(" and k.athugasemdir like '%{0}%' ", this.Athugasemdir);
            }
            if (!string.IsNullOrEmpty(this.Aaetlud_skil))
            {
                strSQL += string.Format(" and k.aaetlud_skil like '%{0}%' ", this.Aaetlud_skil);
            }
            if (this.Skilad)
            {
                strSQL += string.Format(" and k.skilad = '1' ");
            }
            //varsla_heiti, audkenni, skjalm_heiti, sveitarfelag, hlutverk, id, herAudkenni, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil, skilad
            //strSQL = string.Format("SELECT v.heiti as varsla_heiti, v.audkenni, s.heiti as skjalm_heiti, s.sveitarfelag, h.hlutverk, k.* FROM kortlagning k, skjalamyndari s, vorslustofnun v, hlutverk h where k.heraudkenni=v.audkenni and k.skjalID=s.id and h.id= k.hlutverk and v.audkenni = '{0}' and k.heiti_kerfis like '%{1}%' ;", strVarsla);
            DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
            DataTable dt = ds.Tables[0];
            return dt;

        }
            public DataTable getEnumGerd()
            {
                string strSQL = string.Empty;

                strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE,5) as gerd FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='kortlagning' AND TABLE_NAME='kortlagning'AND COLUMN_NAME='rafraen_sofn';");

                var strengur = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
                //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
                DataTable dt = new DataTable();
                dt.Columns.Add("gerd");
                string[] strSplit = strengur.ToString().Split(',');
                foreach (string str in strSplit)
                {
                    DataRow r = dt.NewRow();
                    string strGerð = str.Replace("(", "");
                    strGerð = strGerð.Replace(")", "");
                    strGerð = strGerð.Replace("\'", "");
                    r["gerd"] = strGerð;
                    dt.Rows.Add(r);
                    dt.AcceptChanges();

                }

                return dt;
            }
            public DataTable getEnumNotkun()
            {
                string strSQL = string.Empty;

                strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE,5) as notkun FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='kortlagning' AND TABLE_NAME='kortlagning'AND COLUMN_NAME='notkun';");

                var strengur = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
                //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
                DataTable dt = new DataTable();
                dt.Columns.Add("gerd");
                string[] strSplit = strengur.ToString().Split(',');
                foreach (string str in strSplit)
                {
                    DataRow r = dt.NewRow();
                    string strGerð = str.Replace("(", "");
                    strGerð = strGerð.Replace(")", "");
                    strGerð = strGerð.Replace("\'", "");
                    r["gerd"] = strGerð;
                    dt.Rows.Add(r);
                    dt.AcceptChanges();

                }

                return dt;
            }
            public DataTable getEnumVardveit()
            {
                string strSQL = string.Empty;

                strSQL = string.Format("SELECT SUBSTRING(COLUMN_TYPE,5) as gerd FROM information_schema.COLUMNS WHERE TABLE_SCHEMA='kortlagning' AND TABLE_NAME='kortlagning'AND COLUMN_NAME='vardveisla';");

                var strengur = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
                //  DataSet ds = MySqlHelper.ExecuteDataset(cTenging.sækjaTengiStreng(), string.Format("SELECT `ID`,  `afhendingaar` as afhendingaár, `afhendinganr` as afhendinganr  FROM afhendingaskrá a where ID ={0};", ID));
                DataTable dt = new DataTable();
                dt.Columns.Add("gerd");
                string[] strSplit = strengur.ToString().Split(',');
                foreach (string str in strSplit)
                {
                    DataRow r = dt.NewRow();
                    string strGerð = str.Replace("(", "");
                    strGerð = strGerð.Replace(")", "");
                    strGerð = strGerð.Replace("\'", "");
                    r["gerd"] = strGerð;
                    dt.Rows.Add(r);
                    dt.AcceptChanges();

                }

                return dt;
            }
            public DataTable getHlutverk()
            {
                string strSQL = string.Empty;

                strSQL = string.Format("SELECT * FROM hlutverk h ORDER BY hlutverk desc;");
                DataSet ds = MySqlHelper.ExecuteDataset(m_strTenging, strSQL);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            public void Eyda(int ID)
            {
                string strSQL = string.Empty;

                strSQL = string.Format("Select skjalid from kortlagning where id = {0}", ID);
                var skjalID = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
                strSQL = string.Format("DELETE from kortlagning where id = {0}", ID);
                MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
                //eyða skjalamyndara ef hann er ekki lengur í notkun
                strSQL = string.Format("SELECT count(*) as fjoldi FROM kortlagning k where skjalID = {0};", skjalID);
                var fjoldi = MySqlHelper.ExecuteScalar(m_strTenging, strSQL);
                if (Convert.ToInt32(fjoldi) == 0)
                {
                    strSQL = string.Format("DELETE from skjalamyndari where id = {0}", skjalID);
                    MySqlHelper.ExecuteNonQuery(m_strTenging, strSQL);
                }

            }

            public int vistaHlutVerk(string strHlutverk)
            {
                MySqlConnection conn = new MySqlConnection(m_strTenging);
                conn.Open();
                MySqlCommand command = new MySqlCommand("", conn);
                //  id, karfa, md5, Vörlsuutgafa, Skrar, slod
                command.Parameters.AddWithValue("@hlutverk", strHlutverk);
                command.CommandText = string.Format("INSERT INTO `hlutverk` SET  `hlutverk`=@hlutverk");
                command.ExecuteNonQuery();
                command.CommandText = string.Format("SELECT max(id) as maxID FROM hlutverk h;");
                int iRet = Convert.ToInt32(command.ExecuteScalar());
                return iRet;

            }
            public void Vista()
            {
                MySqlConnection conn = new MySqlConnection(m_strTenging);
                conn.Open();
                MySqlCommand command = new MySqlCommand("", conn);
                //  id, karfa, md5, Vörlsuutgafa, Skrar, slod
                command.Parameters.AddWithValue("@ID", this.ID);
                command.Parameters.AddWithValue("@herAudkenni", this.Heraudkenni);
                command.Parameters.AddWithValue("@skjalID", this.SkjalID);
                command.Parameters.AddWithValue("@heiti_kerfis", this.Heiti_kerfis);
                command.Parameters.AddWithValue("@rafraen_sofn", this.Rafraen_sofn);
                command.Parameters.AddWithValue("@hlutverk", this.Hlutverk);
                command.Parameters.AddWithValue("@abyrgd_umsjon", this.Abyrgd_umsjon);
                command.Parameters.AddWithValue("@starfseining", this.Starfseining);
                command.Parameters.AddWithValue("@tengilidur_starfseiningar", this.Tengilidur_starfseiningar);
                command.Parameters.AddWithValue("@birgi", this.Birgi);
                command.Parameters.AddWithValue("@hysing", this.Hysing);
                command.Parameters.AddWithValue("@dags_tekid_i_notkun", this.Dags_tekid_i_notkun);
                command.Parameters.AddWithValue("@dags_tilkynnt", this.Dags_tilkynnt);
                command.Parameters.AddWithValue("@vardveisla", this.Vardveisla);
                command.Parameters.AddWithValue("@staerd", this.Staerd);
                command.Parameters.AddWithValue("@notkun", this.Notkun);
                command.Parameters.AddWithValue("@athugasemdir", this.Athugasemdir);
                command.Parameters.AddWithValue("@aaetlud_skil", this.Aaetlud_skil);
                command.Parameters.AddWithValue("@skilad", this.Skilad);

                //id, herAudkenni, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                if (this.ID == 0)
                {  //id, herAudkenni, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                    command.CommandText = string.Format("INSERT INTO `kortlagning` SET  `herAudkenni`=@herAudkenni, `skjalID`=@skjalID, `heiti_kerfis`=@heiti_kerfis, `rafraen_sofn`=@rafraen_sofn, `hlutverk`=@hlutverk, `abyrgd_umsjon`=@abyrgd_umsjon, `starfseining`=@starfseining, `tengilidur_starfseiningar`=@tengilidur_starfseiningar, `birgi`=@birgi, `hysing`=@hysing, `dags_tekid_i_notkun`=@dags_tekid_i_notkun, `dags_tilkynnt`=@dags_tilkynnt, `vardveisla`=@vardveisla, `staerd`=@staerd, `notkun`=@notkun, `athugasemdir`=@athugasemdir, `aaetlud_skil`=@aaetlud_skil, `skilad`=@skilad;");
                }
                else
                {
                    command.CommandText = string.Format("UPDATE `kortlagning` SET  `herAudkenni`=@herAudkenni, `skjalID`=@skjalID, `heiti_kerfis`=@heiti_kerfis, `rafraen_sofn`=@rafraen_sofn, `hlutverk`=@hlutverk, `abyrgd_umsjon`=@abyrgd_umsjon, `starfseining`=@starfseining, `tengilidur_starfseiningar`=@tengilidur_starfseiningar, `birgi`=@birgi, `hysing`=@hysing, `dags_tekid_i_notkun`=@dags_tekid_i_notkun, `dags_tilkynnt`=@dags_tilkynnt, `vardveisla`=@vardveisla, `staerd`=@staerd, `notkun`=@notkun, `athugasemdir`=@athugasemdir, `aaetlud_skil`=@aaetlud_skil, `skilad`=@skilad WHERE id={0};", this.ID);
                }
                command.ExecuteNonQuery();
                conn.Dispose();
                command.Dispose();
            }
        
    }
}