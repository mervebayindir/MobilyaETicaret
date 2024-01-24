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
    public class KategorilerService : Service<Kategoriler>, IKategorilerService
    {
        private readonly IKategorilerRepository _kategorilerRepository;
        public KategorilerService(IUnitOfWork unitOfWork, IGenericRepository<Kategoriler> genericRepository, IKategorilerRepository kategorilerRepository) : base(unitOfWork, genericRepository)
        {
            _kategorilerRepository = kategorilerRepository;
        }

        public IQueryable<Kategoriler> KategoriListesi()
        {
            return _kategorilerRepository.GetAll();
        }

        public async Task<object> KategoriSilAsync(int id)
        {
            var kategoriGetir = await _kategorilerRepository.GetByIdAsync(id);
            if (kategoriGetir != null)
            {
                return await _kategorilerRepository.KategoriSilAsync(kategoriGetir.Id);
            }
            return null;
        }
    }
}
