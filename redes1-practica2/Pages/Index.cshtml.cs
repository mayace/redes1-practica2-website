using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace redes1_practica2.Pages
{
    public class IndexModel : PageModel
    {

        private IHttpContextAccessor _accessor = null;
        public IndexModel(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }

        public String IPAddress { get; set; }
        public Boolean EsServidorVentas { get; set; }
        public void OnGet()
        {
            this.IPAddress = this._accessor.HttpContext.Request.Host.Value;
            this.EsServidorVentas = this._accessor.HttpContext.Request.Host.Value == "192.168.76.68";
        }
    }
}
