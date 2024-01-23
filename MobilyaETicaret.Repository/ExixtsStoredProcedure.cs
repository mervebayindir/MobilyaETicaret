using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilyaETicaret.Repository
{
    public class ExixtsStoredProcedure
    {
        AppDbContext appDbContext = new AppDbContext();
        public string Sp_AdresMusteriIl()
        {
            try
            {
                string sql = @"CREATE PROCEDURE Sp_GetMusteriAdresBilgileri
                         as
                         begin
                        SELECT    
                            a.Id AS AdresId, a.AdresBasligi, a.Adres, a.PostaKodu, a.AktifMi, a.EklenmeTarih,  a.GuncellenmeTarih,
                            m.Adi + ' ' + m.Soyadi AS MusteriAdiSoyadi, m.Id AS MusteriId, 
                            il.IlAdi,  ilce.IlceAdi   
                          FROM Adresler  a  
                          INNER JOIN Musteriler m ON a.MusteriId = m.Id    
                          INNER JOIN Ilceler ilce ON a.IlceKodu = ilce.IlceKodu    
                          INNER JOIN Iller il ON ilce.IlKodu = il.IlKodu
                       end";
                var list = appDbContext.Database.ExecuteSqlRaw(sql);
                return "Sp_GetMusteriAdresBilgileri başarılı bir şekilde oluşturuldu";
            }
            catch (Exception ex)
            {
                return "HATA:" + ex.Message;
            }
        }
    }
}
