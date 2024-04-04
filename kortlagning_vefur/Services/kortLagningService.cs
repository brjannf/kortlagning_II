using System.Collections.Generic;
using cClassKortLagning;
using System.IO;
using System.Linq;
using System.Text.Json;
using kortlagning_vefur.Models;
using Microsoft.AspNetCore.Hosting;
using cClassKortLagning;
using System.Data;
using Org.BouncyCastle.Asn1.Mozilla;


namespace kortlagning_vefur.Services
{
    /// <summary>
    /// klasi til að nálgast gögn og skrá.
    /// </summary>
    public class kortLagningService
    {
        cKortLagningListi kort = new cKortLagningListi();
        cVorslustofnanir varsla = new cVorslustofnanir();
        cSkjalamyndarar skjalam = new cSkjalamyndarar();

        public kortLagningService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public string strLogin(string strUser, string strPass)
        {
            string strRet = null;

            strRet = varsla.getLogin(strUser, strPass);
        
            return strRet;
        }

        public IQueryable<kortlagning> getHluverk()
        {
            DataTable dt = kort.getHlutverk();
            {
                return (IQueryable<kortlagning>)dt.AsEnumerable().Select(row => new kortlagning
                {
                    //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                    ID = Convert.ToInt32(row["id"]),
                    Hlutverk = row["hlutverk"].ToString()
                }).AsQueryable();

            }
        }

        public IQueryable<kortlagning> getVardveisla()
        {
            DataTable dt = kort.getEnumVardveit();
            {
                return (IQueryable<kortlagning>)dt.AsEnumerable().Select(row => new kortlagning
                {
                    //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                    Vardveisla = row["gerd"].ToString()
                }).AsQueryable();

            }
        }
        public IQueryable<kortlagning> getGerd()
        {
            DataTable dt = kort.getEnumGerd();
            {
                return (IQueryable<kortlagning>)dt.AsEnumerable().Select(row => new kortlagning
                {
                    //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                    Rafraen_sofn = row["gerd"].ToString()
                }).AsQueryable();

            }
        }
        public IQueryable<kortlagning> getNotkun()
        {
            DataTable dt = kort.getEnumNotkun();
            {
                return (IQueryable<kortlagning>)dt.AsEnumerable().Select(row => new kortlagning
                {
                    //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                    Notkun = row["gerd"].ToString()
                }).AsQueryable();

            }
        }

       
        public IQueryable<kortlagning> GetKortlagningarVorslu(string strVarsla, string strLeitVorslustofnun, string strLeitSkjalmyndari, string strLeitSveitarfélag, string strLeitHeitiKerfis, string strLeitGerdSafns, string strLeitHlutverk, string strleitAbyrgd, string strLeitStarfsEining, string strLeitTengilidur, string strLeitBirgi, string strLeitHysing, string strLeitDagsNotkun, string strLeitDagsTilkynnt, string strLeitVardveisla, string strLeitStaerd, string strLeitNotkun, string strLeitAthugasemdir, string strLeitSkil, bool bLeitSkilad)
        {
            kort.hreinsaHlut();
            if (!string.IsNullOrEmpty(strLeitVorslustofnun))
            {
                kort.Varsla_heiti = strLeitVorslustofnun;  
            }
            if (!string.IsNullOrEmpty(strLeitSkjalmyndari))
            {
                kort.Skjalm_heiti = strLeitSkjalmyndari;
            }
            if (!string.IsNullOrEmpty(strLeitSveitarfélag))
            {
                kort.Sveitarfelag = strLeitSveitarfélag;
            }
            if (!string.IsNullOrEmpty(strLeitHeitiKerfis))
            {
                kort.Heiti_kerfis = strLeitHeitiKerfis;
            }
            if (!string.IsNullOrEmpty(strLeitGerdSafns) && strLeitGerdSafns != "0")
            {
                kort.Rafraen_sofn = strLeitGerdSafns;
            }
            if (!string.IsNullOrEmpty(strLeitHlutverk) && strLeitHlutverk != "0")
            {
                kort.Hlutverk = strLeitHlutverk;
            }
            if (!string.IsNullOrEmpty(strleitAbyrgd))
            {
                kort.Abyrgd_umsjon = strleitAbyrgd;
            }
            if (!string.IsNullOrEmpty(strLeitStarfsEining))
            {
                kort.Starfseining = strLeitStarfsEining;
            }
            
            if (!string.IsNullOrEmpty(strLeitTengilidur))
            {
                kort.Tengilidur_starfseiningar = strLeitTengilidur;
            }
            if (!string.IsNullOrEmpty(strLeitBirgi))
            {
                kort.Birgi = strLeitBirgi;
            }
            if (!string.IsNullOrEmpty(strLeitHysing))
            {
                kort.Hysing = strLeitHysing;
            }
            if (!string.IsNullOrEmpty(strLeitDagsNotkun))
            {
                kort.Dags_tekid_i_notkun = strLeitDagsNotkun;
            }
            if (!string.IsNullOrEmpty(strLeitDagsTilkynnt))
            {
                kort.Dags_tilkynnt = strLeitDagsTilkynnt;
            }
            if (!string.IsNullOrEmpty(strLeitVardveisla) && strLeitVardveisla != "0")
            {
                kort.Vardveisla = strLeitVardveisla;
            }
            if (!string.IsNullOrEmpty(strLeitStaerd))
            {
                kort.Staerd = strLeitStaerd;
            }
            if (!string.IsNullOrEmpty(strLeitNotkun) && strLeitNotkun != "0")
            {
                kort.Notkun = strLeitNotkun;
            }
            if (!string.IsNullOrEmpty(strLeitAthugasemdir))
            {
                kort.Athugasemdir = strLeitAthugasemdir;
            }
            if (!string.IsNullOrEmpty(strLeitSkil))
            {
                kort.Aaetlud_skil = strLeitSkil;
            }
            if(bLeitSkilad != null)
            {
                kort.Skilad = bLeitSkilad;
            }
            DataTable dt = kort.getKortLagningLeitVarsla(strVarsla);

            return (IQueryable<kortlagning>)dt.AsEnumerable().Select(row => new kortlagning
            {
                //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                ID = Convert.ToInt32(row["ID"]),
                Varsla_heiti = row["varsla_heiti"].ToString(),
                Varsla_audkenni = row["audkenni"].ToString(),
                SkjalID = Convert.ToInt32(row["skjalID"]),
                Skjalm_heiti = row["skjalm_heiti"].ToString(),
                Sveitarfelag = row["sveitarfelag"].ToString(),
                Heiti_kerfis = row["heiti_kerfis"].ToString(),
                Rafraen_sofn = row["rafraen_sofn"].ToString(),
                Hlutverk = row["hlutverk"].ToString(),
                Abyrgd_umsjon = row["abyrgd_umsjon"].ToString(),
                Starfseining = row["starfseining"].ToString(),
                Tengilidur_starfseiningar = row["tengilidur_starfseiningar"].ToString(),
                Birgi = row["birgi"].ToString(),
                Hysing = row["hysing"].ToString(),
                Dags_tekid_i_notkun = row["dags_tekid_i_notkun"].ToString(),
                Dags_tilkynnt = row["dags_tilkynnt"].ToString(),
                Vardveisla = row["vardveisla"].ToString(),
                Staerd = row["staerd"].ToString(),
                Notkun = row["notkun"].ToString(),
                Athugasemdir = row["athugasemdir"].ToString(),
                Aaetlud_skil = row["aaetlud_skil"].ToString(),
                Skilad = Convert.ToBoolean(row["skilad"])

            }).AsQueryable();

        }


        public IQueryable<kortlagning> GetKortlagningarVorslu(string strVarsla)
        {
            DataTable dt = kort.getKortLagning(strVarsla);

            return (IQueryable<kortlagning>)dt.AsEnumerable().Select(row => new kortlagning
            {
                //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                ID = Convert.ToInt32(row["ID"]),
                Varsla_heiti = row["varsla_heiti"].ToString(),
                Varsla_audkenni = row["audkenni"].ToString(),
                SkjalID = Convert.ToInt32(row["skjalID"]),
                Skjalm_heiti = row["skjalm_heiti"].ToString(),
                Sveitarfelag = row["sveitarfelag"].ToString(),
                Heiti_kerfis = row["heiti_kerfis"].ToString(),
                Rafraen_sofn = row["rafraen_sofn"].ToString(),
                Hlutverk = row["hlutverk"].ToString(),
                Abyrgd_umsjon = row["abyrgd_umsjon"].ToString(),
                Starfseining = row["starfseining"].ToString(),
                Tengilidur_starfseiningar = row["tengilidur_starfseiningar"].ToString(),
                Birgi = row["birgi"].ToString(),
                Hysing = row["hysing"].ToString(),
                Dags_tekid_i_notkun = row["dags_tekid_i_notkun"].ToString(),
                Dags_tilkynnt = row["dags_tilkynnt"].ToString(),
                Vardveisla = row["vardveisla"].ToString(),
                Staerd = row["staerd"].ToString(),
                Notkun = row["notkun"].ToString(),
                Athugasemdir = row["athugasemdir"].ToString(),
                Aaetlud_skil = row["aaetlud_skil"].ToString(),
                Skilad = Convert.ToBoolean(row["skilad"])

            }).AsQueryable();

        }
        public IQueryable<kortlagning> GetKortlagningarEinFaersla(int iID)
        {
            DataTable dt = kort.getKortLagning(iID);

            return (IQueryable<kortlagning>)dt.AsEnumerable().Select(row => new kortlagning
            {
                //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                ID = Convert.ToInt32(row["ID"]),
                SkjalID = Convert.ToInt32(row["skjalID"]),
                Heiti_kerfis = row["heiti_kerfis"].ToString(),
                Rafraen_sofn = row["rafraen_sofn"].ToString(),
                Hlutverk = row["hlutverk"].ToString(),
                Abyrgd_umsjon = row["abyrgd_umsjon"].ToString(),
                Starfseining = row["starfseining"].ToString(),
                Tengilidur_starfseiningar = row["tengilidur_starfseiningar"].ToString(),
                Birgi = row["birgi"].ToString(),
                Hysing = row["hysing"].ToString(),
                Dags_tekid_i_notkun = row["dags_tekid_i_notkun"].ToString(),
                Dags_tilkynnt = row["dags_tilkynnt"].ToString(),
                Vardveisla = row["vardveisla"].ToString(),
                Staerd = row["staerd"].ToString(),
                Notkun = row["notkun"].ToString(),
                Athugasemdir = row["athugasemdir"].ToString(),
                Aaetlud_skil = row["aaetlud_skil"].ToString(),
                Heraudkenni = row["herAudkenni"].ToString(),
                Skilad = Convert.ToBoolean(row["skilad"])


            }).AsQueryable();

        }

        public IQueryable<kortlagning> GetKortlagningarAllt()
        {
            
            DataTable dt = kort.getKortLagning();

            return (IQueryable<kortlagning>)dt.AsEnumerable().Select(row => new kortlagning
            {
                //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                ID = Convert.ToInt32(row["ID"]),
                Varsla_heiti = row["varsla_heiti"].ToString(),
                Varsla_audkenni = row["audkenni"].ToString(),
                SkjalID = Convert.ToInt32(row["skjalID"]),
                Skjalm_heiti = row["skjalm_heiti"].ToString(),
                Sveitarfelag = row["sveitarfelag"].ToString(),
                Heiti_kerfis = row["heiti_kerfis"].ToString(),
                Rafraen_sofn = row["rafraen_sofn"].ToString(),
                Hlutverk = row["hlutverk"].ToString(),
                Abyrgd_umsjon = row["abyrgd_umsjon"].ToString(),
                Starfseining = row["starfseining"].ToString(),
                Tengilidur_starfseiningar = row["tengilidur_starfseiningar"].ToString(),
                Birgi = row["birgi"].ToString(),
                Hysing = row["hysing"].ToString(),
                Dags_tekid_i_notkun = row["dags_tekid_i_notkun"].ToString(),
                Dags_tilkynnt = row["dags_tilkynnt"].ToString(),
                Vardveisla = row["vardveisla"].ToString(),
                Staerd = row["staerd"].ToString(),
                Notkun = row["notkun"].ToString(),
                Athugasemdir = row["athugasemdir"].ToString(),
                Aaetlud_skil = row["aaetlud_skil"].ToString(),
                Skilad =  Convert.ToBoolean(row["skilad"])

            }).AsQueryable();

        }

        public IQueryable<skjalamyndari> GetSkjalamyndara(int id)
        {
            DataTable dt = skjalam.geSkjalamyndara(id);

            return (IQueryable<skjalamyndari>)dt.AsEnumerable().Select(row => new skjalamyndari
            {
                //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                ID = Convert.ToInt32(row["id"]),
                Heiti = row["heiti"].ToString(),
                Sveitarfelag = row["sveitarfelag"].ToString(),
                Tengilidur = row["tengilidur"].ToString(),
                Starfsheiti = row["starfsheiti"].ToString(),
                Heimilisfang = row["heimilisfang"].ToString(),
                Tolvupostfang = row["tolvupostfang"].ToString(),
                Simi = row["simi"].ToString()

            }).AsQueryable();

        }
        public IQueryable<skjalamyndari> GetSkjalamyndara(string strVarsla )
        {
            DataTable dt = skjalam.geSkjalamyndara(strVarsla);

            return (IQueryable<skjalamyndari>)dt.AsEnumerable().Select(row => new skjalamyndari
            {
                //id, herID, skjalID, heiti_kerfis, rafraen_sofn, hlutverk, abyrgd_umsjon, starfseining, tengilidur_starfseiningar, birgi, hysing, dags_tekid_i_notkun, dags_tilkynnt, vardveisla, staerd, notkun, athugasemdir, aaetlud_skil
                ID = Convert.ToInt32(row["id"]),
                Heiti = row["heiti"].ToString(),
                Sveitarfelag = row["sveitarfelag"].ToString(),
                Tengilidur = row["tengilidur"].ToString(),
                Starfsheiti = row["starfsheiti"].ToString(),
                Heimilisfang = row["heimilisfang"].ToString(),
                Tolvupostfang = row["tolvupostfang"].ToString(),
                Simi = row["simi"].ToString()

             }).AsQueryable();


        }
        public IEnumerable<vorslustofnun> GetKVorslustofnanir()
        {
           
            DataTable dt = kort.getKortLagning();

            return (IEnumerable<vorslustofnun>)dt.AsEnumerable().Select(row => new vorslustofnun
            {
                ID = Convert.ToInt32(row["ID"]),
                Heiti = row["heiti_kerfis"].ToString()

            }); 
       
        }

        public void eydaKort(int id)
        {
            kort.Eyda(id);
        }

        public void breytaSkjalamyndara(int iID,string strSkjalmHeiti, string strSkjalSveit, string strSkjalTengi, string strSkjalStarf, string strSkjalHeim, string strSkjalTolv, string strSkjalSimi)
        {
            skjalam.ID = iID;
            skjalam.Heiti = strSkjalmHeiti;
            skjalam.Sveitarfelag = strSkjalSveit;
            skjalam.Tengilidur = strSkjalTengi;
            skjalam.Starfsheiti = strSkjalStarf;
            skjalam.Heimilisfang = strSkjalHeim;
            skjalam.Tolvupostfang = strSkjalTolv;
            skjalam.Simi = strSkjalSimi;
            skjalam.Vista();
          
        }

        public int nyskraSkjalamyndara(string strSkjalmHeiti, string strSkjalSveit, string strSkjalTengi, string strSkjalStarf,string strSkjalHeim, string strSkjalTolv, string strSkjalSimi)
        {
            int iRet = 0;
            skjalam.Heiti = strSkjalmHeiti;
            skjalam.Sveitarfelag = strSkjalSveit;
            skjalam.Tengilidur = strSkjalTengi;
            skjalam.Starfsheiti = strSkjalStarf;
            skjalam.Heimilisfang = strSkjalHeim;
            skjalam.Tolvupostfang = strSkjalTolv;
            skjalam.Simi = strSkjalSimi;
            iRet = skjalam.Vista();
            return iRet;
        }


        public void breytaKortlagning(int iID, string strVarsla, int iIDskjal, string strKortHeiti, string strKortGerd, string strKortHlutverk, string strKortAbyrgd, string strKortStarf, string strKortTengi, string strKortBirgi, string strKortHysing, string strKortDagsNotkun, string strKortDagsTilkynnt, string strKortStaerd, string strKortAthugasemdir, string strKortAetladSkil, string strKortVardveisla, string strKortNotkun, bool bSkilad)
        {
            kort.ID = iID;
            kort.Heraudkenni = strVarsla;
            kort.SkjalID = iIDskjal;
            kort.Heiti_kerfis = strKortHeiti;
            kort.Rafraen_sofn = strKortGerd;
            kort.Abyrgd_umsjon = strKortAbyrgd;
            kort.Hlutverk = strKortHlutverk;
            kort.Starfseining = strKortStarf;
            kort.Tengilidur_starfseiningar = strKortTengi;
            kort.Birgi = strKortBirgi;
            kort.Hysing = strKortHysing;
            kort.Dags_tekid_i_notkun = strKortDagsNotkun;
            kort.Dags_tilkynnt = strKortDagsTilkynnt;
            kort.Starfseining = strKortStarf;
            kort.Athugasemdir = strKortAthugasemdir;
            kort.Aaetlud_skil = strKortAetladSkil;
            kort.Vardveisla = strKortVardveisla;
            kort.Notkun = strKortNotkun;
            kort.Staerd = strKortStaerd;
            kort.Skilad = bSkilad;
            kort.Vista();

        }
        

        public void flytjainnKortlagningu(DataTable dt, int idSkjal, string strVarsla)
        {
            foreach (DataRow row in dt.Rows)
            {
                kort.Heraudkenni = strVarsla;
                kort.SkjalID = idSkjal;
                kort.Heiti_kerfis = row["Heiti_kerfis"].ToString();
                kort.Rafraen_sofn = row["Rafraen_sofn"].ToString();
                kort.Abyrgd_umsjon = row["Abyrgd_umsjon"].ToString();
                //ná hér í auðkenni hlutverks eða bæta við ef ekki er til?
                string strHlutverk = row["Hlutverk"].ToString();
                IQueryable < kortlagning> hlutverk = getHluverk();
                foreach(var hlut in hlutverk)
                {
                    if (hlut.Hlutverk == strHlutverk)
                    {
                        kort.Hlutverk = hlut.ID.ToString();
                    }
                }
                if (string.IsNullOrEmpty(kort.Hlutverk))
                {
                    //skrá nýtt hlutverk?
                    kort.Hlutverk = kort.vistaHlutVerk(strHlutverk).ToString();

                }
              
                kort.Starfseining = row["Starfseining"].ToString();
                kort.Tengilidur_starfseiningar = row["Tengilidur_starfseiningar"].ToString();
                kort.Birgi = row["Birgi"].ToString(); 
                kort.Hysing = row["Hysing"].ToString(); 
                kort.Dags_tekid_i_notkun = row["Dags_tekid_i_notkun"].ToString();
                kort.Dags_tilkynnt = row["Dags_tilkynnt"].ToString();
                kort.Athugasemdir = row["Athugasemdir"].ToString();
                kort.Aaetlud_skil = row["Aaetlud_skil"].ToString(); 
                kort.Vardveisla = row["Vardveisla"].ToString();

                kort.Notkun = row["Notkun"].ToString();
                kort.Skilad = false;
                kort.Vista();

            }
        }
        public void nyskraKortlagning(string strVarsla, int iIDskjal, string strKortHeiti, string strKortGerd, string strKortHlutverk, string strKortAbyrgd, string strKortStarf, string strKortTengi, string strKortBirgi, string strKortHysing, string strKortDagsNotkun, string strKortDagsTilkynnt, string strKortStaerd, string strKortAthugasemdir, string strKortAetladSkil, string strKortVardveisla, string strKortNotkun, bool bSkilad)
        {
            kort.Heraudkenni = strVarsla;
            kort.SkjalID = iIDskjal;
            kort.Heiti_kerfis =  strKortHeiti;
            kort.Rafraen_sofn = strKortGerd;
            kort.Abyrgd_umsjon = strKortAbyrgd;
            kort.Hlutverk = strKortHlutverk;
            kort.Starfseining = strKortStarf;
            kort.Tengilidur_starfseiningar = strKortTengi;
            kort.Birgi = strKortBirgi;
            kort.Hysing = strKortHysing;    
            kort.Dags_tekid_i_notkun = strKortDagsNotkun;   
            kort.Dags_tilkynnt = strKortDagsTilkynnt;
            kort.Starfseining = strKortStaerd;
            kort.Athugasemdir = strKortAthugasemdir;
            kort.Aaetlud_skil = strKortAetladSkil;
            kort.Vardveisla = strKortVardveisla;
            kort.Notkun = strKortNotkun;
            kort.Staerd = strKortStaerd;
            kort.Skilad = bSkilad;
            kort.Vista();
        
        }
        public void nyskraVorslustofnun(string strAudkenni, string strHeiti)
        {
           
            varsla.Heiti = strHeiti;
            varsla.Audkenni = strAudkenni;
            varsla.ID = 0;
            varsla.vistaVorslustofnun();
        }
        public void updateVorslustofnanir(int iIDvarsla,string strHeiti)
        {

            varsla.Heiti = strHeiti;
            varsla.ID = iIDvarsla;
            varsla.vistaVorslustofnun();
        }
    }
}
