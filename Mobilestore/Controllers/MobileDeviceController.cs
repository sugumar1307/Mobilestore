using Microsoft.AspNetCore.Mvc;
using Mobilestore.Interface;
using Mobilestore.Models;
using MongoDB.Bson;
using System.Security.Permissions;

namespace Mobilestore.Controllers
{
    public class MobileDeviceController : Controller
    {
        private readonly ImobileService _context;

        public MobileDeviceController(ImobileService context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.GetAllMobileDevices());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult createpost(MobileDeviceEntity mobiledata)
        {
            _context.Create(mobiledata); 
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string Name)
        {
            var md = _context.GetMobileDevDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult editpost(string _id,MobileDeviceEntity mobiledata)
        {
            _context.Update(_id, mobiledata);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(string Name) 
        {
             var md= _context.GetMobileDevDetails(Name);
            return View(md);
        }

        [HttpGet]
        public IActionResult Delete(string Name)
        {
            var md = _context.GetMobileDevDetails(Name);
            return View(md);
        }

        [HttpPost]
        public IActionResult DeletePost(string Name)
        {
            _context.Delete(Name);

            return RedirectToAction("Index");
        }
    }
}
