using RealEstateManager.Queries;

namespace RealEstateManager.Schema;

public class RealEstateSchema : GraphQL.Types.Schema
{
    public RealEstateSchema(IServiceProvider sp) 
        : base(sp)
    {
        Query = sp.GetRequiredService<PropertyQuery>();
    }
}