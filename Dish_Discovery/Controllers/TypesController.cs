using AutoMapper;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Web.ViewModels.Types;
using Microsoft.AspNetCore.Mvc;

namespace Dish_Discovery.Web.MVC.Controllers
{
[Route("types")]
    public class TypesController : Controller
    {
        private readonly ITypeService _typeService;
        private readonly IMapper _mapper;

        public TypesController(ITypeService typeService, IMapper mapper)
        {
            this._typeService = typeService ?? throw new ArgumentNullException(nameof(typeService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var types = this._typeService.GetAll();
            var viewModels = this._mapper.Map<IEnumerable<TypeViewModel>>(types);

            return this.View(viewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost("create"), ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] TypeCreateModel inputModel)
        {
            if (!ModelState.IsValid) return this.View(inputModel);

            var type = this._mapper.Map<Data.Models.Type>(inputModel);
            this._typeService.Create(type);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("delete")]
        public IActionResult Delete(Guid id)
        {
            var type = this._typeService.GetOneMinified(id);
            if (type is null) return this.NotFound();

            var viewModel = this._mapper.Map<TypeMinifiedViewModel>(type);
            return this.View(viewModel);
        }

        [HttpPost("delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._typeService.Delete(id);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("details")]
        public IActionResult Details(Guid id)
        {
            var type = this._typeService.GetOne(id);
            if (type is null) return this.NotFound();

            var viewModel = this._mapper.Map<TypeViewModel>(type);
            return this.View(viewModel);
        }

        [HttpGet("edit")]
        public IActionResult Edit(Guid id)
        {
            var type = this._typeService.GetOneEdit(id);
            if (type is null) return this.NotFound();

            var viewModel = this._mapper.Map<TypeEditModel>(type);
            return View(viewModel);
        }

        [HttpPost("edit"), ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, TypeEditModel inputModel)
        {
            if (!ModelState.IsValid) return this.View(inputModel);
            if (id != inputModel.Id) return this.NotFound();

            var type = this._typeService.GetById(id);
            if (type is null) return this.NotFound();

            this._mapper.Map(inputModel, type);
            this._typeService.Update(type);

            return this.RedirectToAction(nameof(Index));
        }
    }
}
