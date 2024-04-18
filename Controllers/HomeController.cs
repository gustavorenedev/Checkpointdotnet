using checkpointdotnet.Data;
using checkpointdotnet.DTOs;
using checkpointdotnet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace checkpointdotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register(RegisterDTO request)
        {
            var users = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.UserEmail);

            if (users != null)
            {
                return BadRequest("Usuário ou Email já existente");
            }
            User NewUser = new User
            {
                UserEmail = request.UserEmail,
                UserName = request.UserName,
                UserPassword = request.UserPassword,
                UserPhone = request.UserPhone,
            };

            _dataContext.Usuarios.Add(NewUser);
            _dataContext.SaveChanges();

            return View("Login");
        }

        public IActionResult Login(LoginDTO request)
        {
            var find = _dataContext.Usuarios.FirstOrDefault(x => x.UserEmail == request.UserEmail);
            if (find == null)
            {
                return NotFound();
            }
            if (find.UserPassword != request.UserPassword)
            {
                return BadRequest("Senha inválida");
            }

            TempData["Message"] = "Você logou!";

            ViewBag.userData = find;
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
