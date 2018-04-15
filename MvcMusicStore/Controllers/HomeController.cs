using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcMusicStore.Models;
using NLog;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicStoreEntities _storeContext = new MusicStoreEntities();

        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }

        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            _logger.Info("Home controller was started");

            _logger.Debug($"Albums count: {_storeContext.Albums.Count()}");

            try
            {
                throw new Exception("test exception special for mentoring");
            }
            catch (Exception ex)
            {
                _logger.Error($"Home controller failed, method index. Inner details: '{ex.Message}'");
            }

            return View(await _storeContext.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(6)
                .ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}