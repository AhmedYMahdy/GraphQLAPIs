using RealEstateManager.Database;
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
        return _context.Payments;
    }
}