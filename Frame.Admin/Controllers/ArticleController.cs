﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frame.Admin.Controllers
{
    public class ArticleController:Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}