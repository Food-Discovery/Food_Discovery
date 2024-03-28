using AutoMapper;
using Dish_Discovery.Core.Projections.Authors;
using Dish_Discovery.Web.ViewModels.Authors;

namespace Dish_Discovery.Web.MVC.Mapping
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            this.CreateMap<AuthorMinifiedProjection, AuthorMinifiedViewModel>();
        }
    }
}
