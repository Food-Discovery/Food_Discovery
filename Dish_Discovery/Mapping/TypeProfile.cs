using AutoMapper;
using Dish_Discovery.Core.Projections.Types;
using Dish_Discovery.Data.Models;
using Dish_Discovery.Web.ViewModels.Types;

namespace Dish_Discovery.Web.MVC.Mapping
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            this.CreateMap<TypeGeneralInfoProjection, TypeViewModel>();
            this.CreateMap<TypeMinifiedProjection, TypeMinifiedViewModel>();
            this.CreateMap<TypeCreateModel, Data.Models.Type>();
            this.CreateMap<TypeEditProjection, TypeEditModel>();
        }
    }
}
