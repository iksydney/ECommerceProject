using API.DTO;
using AutoMapper;
using AutoMapper.Execution;
using Core.Entities;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductViewModel, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductViewModel destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Image))
            {
                return _config["ApiUrl"] + source.Image;
            }
            return null;
        }
    }
}
