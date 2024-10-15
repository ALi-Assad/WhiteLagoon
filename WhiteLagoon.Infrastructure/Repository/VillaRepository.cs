﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.Interfaces;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Infrastructure.Repository
{
    public class AmenityRepository(ApplicationDbContext db) : Repository<Amenity>(db), IAmenityRepository
    {
        private readonly ApplicationDbContext _db = db;

        public void Update(Amenity entity)
        {
            _db.Update(entity);
        }
    }
}