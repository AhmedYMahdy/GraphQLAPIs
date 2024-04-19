using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories;

public interface IPaymentRepository
{
    IEnumerable<Payment> GetAll();
    IEnumerable<Payment> GetAllForProperty(int propertyId, int last=0);
}