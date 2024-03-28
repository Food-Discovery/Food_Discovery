using AutoMapper;
using Dish_Discovery.Core.Interfaces.Services;
using Dish_Discovery.Data.Models;
using Dish_Discovery.Web.ViewModels.Authors;
using Dish_Discovery.Web.ViewModels.Recipes;
using Dish_Discovery.Web.ViewModels.Types;
using Microsoft.AspNetCore.Mvc;

namespace Dish_Discovery.Web.MVC.Controllers
{
 [Route("recipes")]
    public class RecipesController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ITypeService _typeService;
        private readonly IRecipeService _recipeService;
        private readonly IMapper _mapper;

        public RecipesController(IAuthorService authorService, ITypeService typeService, IRecipeService recipeService, IMapper mapper)
        {
            this._authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
            this._typeService = typeService ?? throw new ArgumentNullException(nameof(typeService));
            this._recipeService = recipeService ?? throw new ArgumentNullException(nameof(recipeService));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allRecipes = this._recipeService.GetAll();
            var viewModels = this._mapper.Map<IEnumerable<RecipeViewModel>>(allRecipes);

            return this.View(viewModels);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var viewModel = this.PrepareFormViewModel<RecipeCreateModel>();
            return this.View(viewModel);
        }

        [HttpPost("create"), ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] RecipeCreateModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = this.PrepareFormViewModel(inputModel);
                return this.View(viewModel);
            }

            var recipe = new Recipe();
            this.ApplyChanges(recipe, inputModel);

            this._recipeService.Create(recipe);

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("details")]
        public IActionResult Details(Guid id)
        {
            var recipe = this._recipeService.GetOne(id);
            if (recipe is null) return this.NotFound();

            var viewModel = this._mapper.Map<RecipeViewModel>(recipe);
            return this.View(viewModel);
        }

        [HttpGet("delete")]
        public IActionResult Delete(Guid id)
        {
            var recipe = this._recipeService.GetOneMinified(id);
            if (recipe is null) return this.NotFound();

            var viewModel = this._mapper.Map<RecipeMinifiedViewModel>(recipe);
            return this.View(viewModel);
        }

        [HttpPost("delete"), ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._recipeService.Delete(id);
            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet("edit")]
        public IActionResult Edit(Guid id)
        {
            var recipe = this._recipeService.GetOneEdit(id);
            if (recipe is null) return this.NotFound();

            var editModel = this._mapper.Map<RecipeEditModel>(recipe);
            var formViewModel = this.PrepareFormViewModel(editModel);
            return View(formViewModel);
        }

        [HttpPost("edit"), ValidateAntiForgeryToken]
        public IActionResult Edit(RecipeEditModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = this.PrepareFormViewModel(inputModel);
                return this.View(viewModel);
            }

            var recipe = this._recipeService.GetByIdWithNavigations(inputModel.Id, [nameof(Recipe.Types)]);
            if (recipe is null) return this.NotFound();

            this.ApplyChanges(recipe, inputModel);
            this._recipeService.Update(recipe);

            return this.RedirectToAction(nameof(Index));
        }

        private RecipeFormViewModel<TInputModel> PrepareFormViewModel<TInputModel>(TInputModel? inputModel = default)
        {
            var allAuthors = this._authorService.GetAllMinified();
            var allTypes = this._typeService.GetAllMinified();

            return new RecipeFormViewModel<TInputModel>
            {
                Authors = this._mapper.Map<IEnumerable<AuthorMinifiedViewModel>>(allAuthors),
                Types = this._mapper.Map<IEnumerable<TypeMinifiedViewModel>>(allTypes),
                InputModel = inputModel
            };
        }

        private void ApplyChanges(Recipe song, RecipeCreateModel inputModel)
        {
            var author = this._authorService.GetById(inputModel.Author);
            if (author is null) throw new InvalidOperationException("Author not found");

            var types = this._typeService.GetByIds(inputModel.Types).ToList();
            if (types.Count != inputModel.Types.Length)
                throw new InvalidOperationException("Some of the types are not found.");

            this._mapper.Map(inputModel, song);
            song.Author = author;
            song.Types = types;
        }
    }
}
