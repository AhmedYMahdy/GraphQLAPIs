using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories;

public interface IPropertyRepository
{
    IEnumerable<Property> GetAll();
    Property GetPropertyById(int id);
    Property Add(Property property);
}
