using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernatePostgre.Domains;

namespace NHibernatePostgre.Maps
{
    public class CategoryMap : ClassMapping<Category>
    {
        public CategoryMap()
        {
            Table("Category");
            Id(x => x.Id, map =>
            {
                map.Column("Id");
                map.Generator(Generators.Identity);
            });

            Property(x => x.CategoryTitle, map =>
            {

            });

            Set(x => x.Products, colMap =>
            {
                colMap.Cascade(Cascade.All);
                colMap.Inverse(true);
                colMap.Table("ProductCategory");
                colMap.Key(k =>
                {
                    k.Column("CategoryId");
                });

            }, relatMap =>
            {
                relatMap.ManyToMany(m =>
                {
                    m.Column("ProductId");
                });
            });
        }
    }
}