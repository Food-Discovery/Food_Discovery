using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dish_Discovery.Data;
using Dish_Discovery.Data.Models;
using AutoMapper;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Web.ViewModels.Authors;
using Dish_Discovery.Web.ViewModels.Recipes;
using Dish_Discovery.Web.ViewModels.Types;

namespace Dish_Discovery.Web.MVC.Controllers
{
    [Route("artists")]
    public class ArtistsController : Controller
    {
        [HttpGet("details")]
        public IActionResult Details(Guid id)
        {
            return this.Ok(id);
        }
    }
}
