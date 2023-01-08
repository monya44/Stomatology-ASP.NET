using Microsoft.AspNetCore.Mvc;
using Dent.Data;
using Dent.Data.Identity;

namespace Dent.Views.Shared
{
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Reception()
        {
            return View();
        }

        [BindProperty]
        public Form Forms { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reception([Bind("Id,Name,PhoneNumber,Email,ChoseProcedure,ChoseDoctor,CheckDoctor,Comments,Delete,Price")] Form form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(form);
                await _context.SaveChangesAsync();
                return RedirectToAction("Record", "Users1");
            }
            return View();
        }
    }
}
