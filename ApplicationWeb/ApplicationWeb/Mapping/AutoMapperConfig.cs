using ApplicationWeb.Config.Profiles;
using ApplicationWeb.Mapping.Profiles;
using AutoMapper;

namespace ApplicationWeb.Config
{
    public class AutoMapperConfig
    {
        public static IMapper Configure()
        {

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<UserProfile>();
                c.AddProfile<ProductProfile>();
                c.AddProfile<SellOrderProfile>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            return mapper;
        }
    }
}
