using Microsoft.EntityFrameworkCore;
using MobilyaETicaret.Core.IRepositories;
using MobilyaETicaret.Core.IServices;
using MobilyaETicaret.Core.IUnitOfWork;
using MobilyaETicaret.Core.MobilyaETicaretDatabase;
using MobilyaETicaret.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Service.Services
{
    public class IlService : Service<Iller>, IilService
    {
        private readonly IilRepository _ilRepository;
        public IlService(IUnitOfWork unitOfWork, IGenericRepository<Iller> genericRepository, IilRepository ilRepository) : base(unitOfWork, genericRepository)
        {
            _ilRepository = ilRepository;
        }

        public async Task<List<Ilceler>> GetIllerWithIlceler(int ilId)
        {
            var ilceler = await _ilRepository.GetIllerWithIlceler(ilId);
            return ilceler;
        }

        public async Task<List<Iller>> IllerListele()
        {
            var iller = await _ilRepository.GetAll().ToListAsync();
            return iller;
        }
    }
}
