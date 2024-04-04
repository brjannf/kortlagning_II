using Microsoft.AspNetCore.Mvc.Rendering;

namespace kortlagning_vefur.Models
{
    public class skjalamyndari
    {
        public int ID { get; set; }
        public string Heiti { get; set; }
        public string Sveitarfelag { get; set; }
        public string Tengilidur { get; set; }
        public string Starfsheiti { get; set; }
        public string Heimilisfang { get; set; }
        public string Tolvupostfang { get; set; }
        public string Simi { get; set; }
    }
}
