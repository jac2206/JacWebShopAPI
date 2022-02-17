﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JacWebShopAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class JacShopDBEntities : DbContext
    {
        public JacShopDBEntities()
            : base("name=JacShopDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<uspGetAllProducts_Result> uspGetAllProducts()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetAllProducts_Result>("uspGetAllProducts");
        }
    
        public virtual int uspInsertNewProduct(string category, string nameProduct, Nullable<long> productCode, Nullable<long> priceProduct, string description)
        {
            var categoryParameter = category != null ?
                new ObjectParameter("Category", category) :
                new ObjectParameter("Category", typeof(string));
    
            var nameProductParameter = nameProduct != null ?
                new ObjectParameter("NameProduct", nameProduct) :
                new ObjectParameter("NameProduct", typeof(string));
    
            var productCodeParameter = productCode.HasValue ?
                new ObjectParameter("ProductCode", productCode) :
                new ObjectParameter("ProductCode", typeof(long));
    
            var priceProductParameter = priceProduct.HasValue ?
                new ObjectParameter("PriceProduct", priceProduct) :
                new ObjectParameter("PriceProduct", typeof(long));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspInsertNewProduct", categoryParameter, nameProductParameter, productCodeParameter, priceProductParameter, descriptionParameter);
        }
    }
}
