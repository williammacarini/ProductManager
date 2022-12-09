using ProductManager.Service.DTOs.Enum;
using System;

namespace ProductManager.Service.DTOs
{
    public class ProductDto
    {
        public int Code { get; init; }
        public string Description { get; init; }
        public ProductStatusDto Status { get; init; }
        public DateTime FabricationDate { get; init; }
        public DateTime? ExpireDate { get; init; }
        public int ProviderCode { get; init; }
        public string ProviderDescription { get; init; }
        public string CNPJ { get; init; }
    }
}
