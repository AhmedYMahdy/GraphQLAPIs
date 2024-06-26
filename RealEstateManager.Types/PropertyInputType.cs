﻿using GraphQL.Types;

namespace RealEstateManager.Types;

public class PropertyInputType :InputObjectGraphType
{
    public PropertyInputType()
    {
        Field<NonNullGraphType<StringGraphType>>("name");
        Field<StringGraphType>("city");
        Field<StringGraphType>("family");
        Field<StringGraphType>("street");
        Field<DecimalGraphType>("value");
    }
}