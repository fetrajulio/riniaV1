using Microsoft.AspNetCore.Mvc;
using riniav1.Repo;
using System.Linq;

namespace riniav1.Controllers
{
    public class AchatController : Controller
    {
        protected riniaContext _context;
        protected LesFonctions Fonctions;
        public AchatController(riniaContext riniaContext)
        {
            Fonctions = new LesFonctions(riniaContext);
            _context = riniaContext;
        }

        public IActionResult Index()
        {
            ViewBag.context = _context;
            ViewBag.achats = Fonctions.GetAllAchat();
            return View();
        }
    }
}
