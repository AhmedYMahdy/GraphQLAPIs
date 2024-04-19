using GraphQL.Types;
using RealEstateManager.Database.Models;

namespace RealEstateManager.Types;

public class PaymentType :ObjectGraphType<Payment>
{
    public PaymentType()
    {
        Field(a => a.Id).Description("Id property from the Property object."); 
        Field(a => a.Value);
        Field(a => a.DateCreated);
        Field(a => a.DateOverdue);
        Field(a => a.Paid);
    }
}