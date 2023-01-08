using Dent.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dent.Controllers
{
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class RolesController : Controller
    {
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public RolesController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
    {
            _roleManager = roleManager;
            _context = context;
    }
     public async Task<IActionResult> Index()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return View(roles);
    }
    [HttpPost]
    public async Task<IActionResult> AddRole(string roleName)
    {
        if (roleName != null)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
        }
        return RedirectToAction("Index");
    }
     [HttpGet]
    public async Task<ActionResult> DeleteAsync(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if (role == null)
        {
            return RedirectToAction(nameof(Index), new { id = id });
        }
        var isSuccess = await _roleManager.DeleteAsync(role);

        return RedirectToAction(nameof(Index));
    }

    }
}