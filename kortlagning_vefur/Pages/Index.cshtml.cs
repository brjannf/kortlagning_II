
using kortlagning_vefur.Models;
using kortlagning_vefur.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace kortlagning_vefur.Pages
{
    public class IndexModel : PageModel
    {


        private readonly ILogger<IndexModel> _logger;
        public kortLagningService _KortLagningService;
        public IEnumerable<vorslustofnun> Vorslustofnanir { get; private set; } 
 
        public IndexModel(ILogger<IndexModel> logger, kortLagningService kortLagningService)
        {
            _logger = logger;
            _KortLagningService= kortLagningService;    
        }

        public void OnGet()
        {
            
        }
    }
}