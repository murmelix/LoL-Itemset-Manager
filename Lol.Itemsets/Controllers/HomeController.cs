﻿using Lol.Api.Static;
using Lol.Api.Static.Champion;
using Lol.Api.Static.Items;
using Lol.Itemsets.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Lol.Itemsets.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ItemData = ItemModel.Items.Values;
            ViewBag.ChampData = ChampionModel.Champions.Values;
            ViewBag.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}