using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoGladys.Models;
using System.Diagnostics;
using System.Security.Claims;


namespace ProyectoGladys.Controllers
{
    [Authorize]
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		
		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{

			ClaimsPrincipal claimuser = HttpContext.User;
			string nombreUsuario = "";

			if (claimuser.Identity.IsAuthenticated)
			{
				nombreUsuario = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
					.Select(c => c.Value).SingleOrDefault();
			}

			ViewData["nombreUusuario"] = nombreUsuario;


			return View();
		}

		public IActionResult Turnos()
		{
			return View();
		}

        public IActionResult Horario()
        {
            return View();
        }

        public IActionResult PreRequisitos()
        {
            return View();
        }
		
        public IActionResult Estudiantes()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

        public async Task<IActionResult> CerrarSesion()
        {
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("IniciarSesion", "Inicio");
        }
    }
}