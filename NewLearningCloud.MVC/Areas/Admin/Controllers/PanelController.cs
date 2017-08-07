﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLearningCloud.MVC.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    //[RequireHttps]
    public class PanelController : Controller
    {
        // GET: Admin/Panel
        public ActionResult Index()
        {
            return View();
        }
    }
}