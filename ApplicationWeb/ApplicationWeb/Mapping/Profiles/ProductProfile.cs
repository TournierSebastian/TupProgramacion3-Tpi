using ApplicationWeb.Data.Dto;
using ApplicationWeb.Data.Entities;
using ApplicationWeb.Data.ViewModel;
using AutoMapper;

namespace ApplicationWeb.Mapping.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Products, DtoProducts>();
            CreateMap<ProductsViewModel, Products>();
        }

    }
}
