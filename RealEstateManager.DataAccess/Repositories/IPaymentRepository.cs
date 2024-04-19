using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories;

public interface IPaymentRepository
{
    IEnumerable<Payment> GetAll();
}