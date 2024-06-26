﻿using RealEstateManager.Database;
using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly RealEstateContext _context;

    public PaymentRepository(RealEstateContext context)
    {
        _context = context;
    }

    public IEnumerable<Payment> GetAll()
    {
        return _context.Payments.ToList();
    }

    IEnumerable<Payment> IPaymentRepository.GetAllForProperty(int propertyId, int last = 0)
    {
        var payments= _context.Payments.Where(a => a.PropertyId == propertyId);
        if (last == 0)
            return payments;
        return payments.OrderByDescending(a => a.DateCreated).Take(last);
    }
}