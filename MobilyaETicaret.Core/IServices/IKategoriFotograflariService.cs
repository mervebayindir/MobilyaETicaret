﻿using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface IKategoriFotograflariService : IService<KategoriFotograflari>
    {
        Task<KategoriFotograflari> KategoriveFotografGetir(int kategoriId);
    }
}
