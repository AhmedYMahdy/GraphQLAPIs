using RealEstateManager.Database;
using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly RealEstateContext _context;

    public PropertyRepository(RealEstateContext context)
    {
        _context = context;
    }

    public IEnumerable<Property> GetAll()
    {
        return _context.Properties.ToList();
    }

    public Property GetPropertyById(int id)
    {
        return _context.Properties.SingleOrDefault(a => a.Id == id);
    }

    public Property Add(Property property)
    {
        _context.Properties.Add(property);
        _context.SaveChanges();
        return property;
    }
}