using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace redes1_practica2.Pages
{
    public class VehiculosModel : PageModel
    {

        public IEnumerable<Vehiculo> Vehiculos { set; get; }

        VehiculosDB db = null;
        public VehiculosModel(VehiculosDB db)
        {
            this.db = db;
        }

        [BindProperty]
        public Vehiculo vehiculo { get; set; }

        public void OnGet()
        {
            this.Vehiculos = this.db.Vehiculos.ToList();
        }

        //public void OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        this.db.Vehiculos.Add(this.vehiculo);
        //        this.db.SaveChanges();
        //    }
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            this.db.Vehiculos.Add(this.vehiculo);
            await this.db.SaveChangesAsync();
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var found = await db.Vehiculos.FindAsync(id);
            var res = id;

            if (found != null)
            {
                db.Vehiculos.Remove(found);
                res = await db.SaveChangesAsync();
            }

            return RedirectToPage(new { data = res });
        }
    }
}