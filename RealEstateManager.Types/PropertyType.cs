using GraphQL;
using GraphQL.Types;
using RealEstateManager.DataAccess.Repositories;
using RealEstateManager.Database.Models;

namespace RealEstateManager.Types;

public class PropertyType : ObjectGraphType<Property>
{
    public PropertyType(IPaymentRepository paymentRepository )
    {
        Field(a => a.Id, type: typeof(IdGraphType)).Description("Id property from the Property object.");
        Field(a => a.Name).Description("Name property from the Property object."); ;
        Field(a => a.Value);
        Field(a => a.City);
        Field(a => a.Family);
        Field(a => a.Street);
        Field<ListGraphType<PaymentType>>(
            "payments",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name="last"}),
            resolve: context => {
                var last = context.GetArgument<int?>("last");
                return paymentRepository.GetAllForProperty(context.Source.Id, last ?? 0);
                });
    }
}