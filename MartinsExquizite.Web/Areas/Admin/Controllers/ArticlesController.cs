﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartinsExquizite.Web.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Admin/Articles
        public ActionResult Index()
        {
            return View();
        }
    }
}