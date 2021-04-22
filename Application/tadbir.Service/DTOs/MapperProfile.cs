using AutoMapper;
using tadbir.Entities;
using tadbir.Service.DTOs.InvoiceDTOs;
using tadbir.Service.DTOs.ProductDTOs;

namespace tadbir.Service.DTOs
{

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // #region  Products
            CreateMap<Product, ProductDto>()
                .ReverseMap()
                .ForMember(p => p.Id, options => options.Ignore());

            CreateMap<Product, ProductListDto>();
            // #endregion

            #region  Invoice
            CreateMap<InvoiceDto, Invoice>()
                .ForMember(i => i.Id, options => options.Ignore())
                .ForMember(i => i.Rows, options => options.Ignore());

            CreateMap<Invoice, DetailedInvoiceDto>();

            CreateMap<InvoiceRowDto, InvoiceRow>();

            CreateMap<InvoiceRow, DetailedInvoiceRowDto>();//.ForMember(d => d.ProductTitle, options => options.MapFrom(r => r.Product.Title))
            #endregion
        }
    }
}