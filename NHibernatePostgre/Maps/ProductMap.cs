using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernatePostgre.Domains;

namespace NHibernatePostgre.Maps
{
    public class ProductMap : ClassMapping<Product>
    {
        public ProductMap()
        {
            //Schema("Test");
            Table("Product");
            Id(x => x.Id, map =>
            {
                map.Column("Id");
                map.Generator(Generators.Identity);
            });

            Property(x => x.ProductTitle, map =>
            {

            });

            Set(x => x.Categories, colMap =>
            {
                colMap.Cascade(Cascade.All);
                colMap.Table("ProductCategory");
                colMap.Key(k =>
                {
                    k.Column("ProductId");
                });

            }, relatMap =>
            {
                relatMap.ManyToMany(m =>
                {
                    m.Column("CategoryId");
                });
            });
        }
    }
}