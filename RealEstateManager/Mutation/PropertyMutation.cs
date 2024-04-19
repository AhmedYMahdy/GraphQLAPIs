using GraphQL;
using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories;
using RealEstateManager.Database.Models;
using RealEstateManager.Types;

namespace RealEstateManager.Mutation;

public class PropertyMutation : ObjectGraphType
{
    public PropertyMutation(IPropertyRepository propertyRepository)
    {
        Field<PropertyType>(
            "addProperty",
            arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = "property" }),
            resolve: context => propertyRepository.Add(context.GetArgument<Property>("property")));
    }
}
