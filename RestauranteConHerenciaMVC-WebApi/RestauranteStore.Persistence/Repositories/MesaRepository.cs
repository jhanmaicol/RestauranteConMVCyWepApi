﻿using RestauranteStore.Entities.Entities;
using RestauranteStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.Repositories
{
    public class MesaRepository : Repository<Mesa>, IMesaRepository
    {
        public MesaRepository(RestauranteStoreDbContext context) : base(context)
        {

        }
        //private readonly RestauranteStoreDbContext _Context;

        //public MesaRepository(RestauranteStoreDbContext context)
        //{
        //    _Context = context;
        //}

        //private MesaRepository()
        //{

        //}
    }
}
