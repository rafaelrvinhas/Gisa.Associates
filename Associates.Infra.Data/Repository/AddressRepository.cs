using Associates.Domain.Interfaces;
using Associates.Domain.Models.ValueObjects;
using Associates.Infra.Data.Context;

namespace Associates.Infra.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(AssociateContext context) : base(context)
        { }

        //public Address Add(Address address)
        //{
        //    DbSet.Add(address);
        //    Db.SaveChanges();

        //    return address;
        //}
    }
}
