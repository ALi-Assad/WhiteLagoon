using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
     public class UnitOfWork(ApplicationDbContext db) : IUnitOfWork
    {
        IVillaRepository IUnitOfWork.Villa => new VillaRepository(db);
        IVillaNumberRepository IUnitOfWork.VillaNumber => new VillaNumberRepository(db);
        IAmenityRepository IUnitOfWork.Amenity => new AmenityRepository(db);

        void IUnitOfWork.Save()
        {
            db.SaveChanges();
        }
    }
}
