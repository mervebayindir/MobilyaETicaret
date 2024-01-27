﻿using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Core.IServices
{
    public interface IErisimAlanlariService : IService<ErisimAlanlari>
    {
        Task<object> ErisimAlaniSilAsync(int id);
    }
}
