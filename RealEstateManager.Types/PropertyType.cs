using GraphQL.Types;
using RealEstateManager.Database.Models;

namespace RealEstateManager.Types;

public class PropertyType :ObjectGraphType<Property>
{
    public PropertyType()
    {
        Field(a => a.Id, type: typeof(IdGraphType)).Description("Id property from the Property object."); ;
        Field(a => a.Name).Description("Name property from the Property object."); ;
        Field(a => a.Value);
        Field(a => a.City);
        Field(a => a.Family);
        Field(a => a.Street);
    }
}