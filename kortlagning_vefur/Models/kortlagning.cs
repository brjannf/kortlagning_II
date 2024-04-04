namespace kortlagning_vefur.Models
{
    public class kortlagning
    {
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
        public bool Skilad {  get; set; }
    }
}
