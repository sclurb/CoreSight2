using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreSight2.Controllers
{
    public class IoT : Controller
    {
        // GET: IoT
        [HttpGet]
        public ActionResult GetIoT()
        {
            return View();
        }


    }
}
