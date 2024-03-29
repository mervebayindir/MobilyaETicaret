﻿using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IRepositories
{
    public interface IYetkilerRepository : IGenericRepository<Yetkiler>
    {
        Task<Yetkiler> YetkiSilAsync(int id);
    }
}
