﻿using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository.Repositories
{
    public class ILRepository : GenericRepository<Iller>, IilRepository
    {
        public ILRepository(AppDbContext mobilyaETicaretDB) : base(mobilyaETicaretDB)
        {
        }

        public async Task<List<Ilceler>> GetIllerWithIlceler(int ilId)
        {
            var ilceler = await _appDbContext.Iller.Where(il => il.IlKodu == ilId).SelectMany(il => il.Ilceler).ToListAsync();
            return ilceler;
        }

        public async Task<List<Iller>> IllerListele()
        {
            return await GetAll().ToListAsync();
        }
    }
}
