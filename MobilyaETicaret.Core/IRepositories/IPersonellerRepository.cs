﻿using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface IPersonellerRepository : IGenericRepository<Personeller>
    {
        Task<List<Personeller>> PersonelVeKullanicilarAsync();
        Task<Personeller> PersonelSilAsync(int id);
    }
}
