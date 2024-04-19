using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories;
using RealEstateManager.Types;

namespace RealEstateManager.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            Field<ListGraphType<PropertyType>>(
                "properties",
                resolve: context => propertyRepository.GetAll());
        }
    }
}