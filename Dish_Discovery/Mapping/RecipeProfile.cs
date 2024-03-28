using AutoMapper;
using Dish_Discovery.Core.Projections.Recipes;
using Dish_Discovery.Data.Models;
using Dish_Discovery.Web.ViewModels.Recipes; 

namespace Dish_Discovery.Web.MVC.Mapping
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            this.CreateMap<RecipeGeneralInfoProjection, RecipeViewModel>();
            this.CreateMap<RecipeMinifiedProjection, RecipeMinifiedViewModel>();
            this.CreateMap<RecipeCreateModel, Recipe>()
                .ForMember(x => x.Author, conf => conf.Ignore())
                .ForMember(x => x.Types, conf => conf.Ignore());

            this.CreateMap<RecipeEditProjection, RecipeEditModel>()
                .ForMember(x => x.Author, conf => conf.MapFrom(y => y.AuthorId))
                .ForMember(x => x.Types, conf => conf.MapFrom(y => y.TypeIds));
        }
    }
}
