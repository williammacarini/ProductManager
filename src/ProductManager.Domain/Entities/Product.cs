using ProductManager.Domain.Enum;
using System;

namespace ProductManager.Domain.Entities
{
    public class Product
    {
        public int Code { get; private set; }
        public string Description { get; private set; }
        public ProductStatus Status { get; private set; }
        public DateTime FabricationDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public int ProviderCode { get; private set; }
        public string ProviderDescription { get; set; }
        public string CNPJ { get; private set; }

        public Product()
        {

        }

        public void SetExpireDate(DateTime date)
        {
            ExpireDate = date;
        }

        public void SetProductInfo(int code, string description, ProductStatus status)
        {
            Code = code;
            Description = description;
            Status = status;
        }

        public void SetProductDate(DateTime fabrication, DateTime? expired)
        {
            FabricationDate = fabrication.Date;
            ExpireDate = expired is null ? expired : expired.Value.Date;
        }

        public void SetProductProvider(int providerCode, string providerDescription, string cnpj)
        {
            ProviderCode = providerCode;
            ProviderDescription = providerDescription;
            CNPJ = cnpj;
        }
    }
}
