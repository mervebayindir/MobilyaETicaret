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
                            a.Id AS AdresId,
                            a.AdresBasligi,
                            a.Adres, a.PostaKodu,
                            a.AktifMi, a.EklenmeTarih,
                            a.GuncellenmeTarih,
                            m.Adi + ' ' + m.Soyadi AS MusteriAdiSoyadi, 
                            m.Id AS MusteriId, 
                            il.IlAdi,  
                            ilce.IlceAdi   
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

        public string Sp_MusteriBilgileri()
        {
            try
            {
                string sql = @"CREATE PROCEDURE Sp_MusteriBilgileri
                                AS
                                BEGIN
                                    SELECT 
                                        k.KullaniciEmail,
                                        m.Id AS MusteriId,
                                        m.Adi + ' ' + m.Soyadi as MusteriAdSoyad,
                                        m.Cinsiyet,
                                        m.Telefonu,
                                        m.EklenmeTarih,
                                        s.Id AS SiparisId,
	                                    s.EklenmeTarih as SiparisTarihi,
                                		s.ToplamFiyat,
                                        m.AktifMi
                                    FROM Musteriler m
                                    INNER JOIN Kullanicilar k ON m.KullaniciId = k.Id
                                    LEFT JOIN Siparisler s ON m.Id = s.MusteriId
                                END";
                var list = appDbContext.Database.ExecuteSqlRaw(sql);
                return "Sp_MusteriBilgileri başarılı bir şekilde oluşturuldu";
            }
            catch (Exception ex)
            {
                return "HATA:" + ex.Message;
            }
        }

        public string Sp_KullaniciBilgileri()
        {
            try
            {
                string sql = @"CREATE PROCEDURE SP_KullaniciBilgileri
                            AS
                            BEGIN
                                SELECT 
                                    k.Id, 
                                    k.Adi + ' '  + k.Soyadi as KullaniciAdSoyad, 
                                    k.KullaniciEmail as Email, 
                                    k.EklenmeTarih, 
                                    k.GuncellenmeTarih, 
                                    k.PersonelMi, 
                                    k.AktifMi, 
                                    k.YetkiId, 
                                    y.YetkiAdi
                                FROM Kullanicilar k
                                INNER JOIN Yetkiler y ON k.YetkiId = y.Id
                            END";
                var list = appDbContext.Database.ExecuteSqlRaw(sql);
                return "Sp_KullaniciBilgileri başarılı bir şekilde oluşturuldu";
            }
            catch (Exception ex)
            {
                return "HATA:" + ex.Message;
            }
        }

        public string Sp_SiparisBilgileri()
        {
            try
            {
                string sql = @"CREATE PROCEDURE Sp_SiparisBilgileri
                                (
                                    @SiparisId INT
                                )
                                AS
                                BEGIN
                                    SELECT
                                        o.OdemeTipi,
                                        s.Id AS SiparisId,
                                        s.ToplamFiyat,
                                        s.AktifMi,
                                        s.EklenmeTarih,
                                        m.Id AS MusteriId,
                                        m.Adi + ' ' + m.Soyadi AS MusteriAdiSoyadi,         
                                        m.Telefonu,
                                        u.UrunAdi
                                    FROM Siparisler s
                                    INNER JOIN Odemeler o ON s.OdemeId = o.Id
                                    INNER JOIN Musteriler m ON s.MusteriId = m.Id
                                    INNER JOIN SiparisDetay sd ON s.Id = sd.SiparisId
                                    INNER JOIN Urunler u ON sd.UrunId = u.Id
                                    WHERE s.Id = @SiparisId;
                                END";
                var list = appDbContext.Database.ExecuteSqlRaw(sql);
                return "Sp_SiparisBilgileri başarılı bir şekilde oluşturuldu";
            }
            catch (Exception ex)
            {
                return "HATA:" + ex.Message;
            }
        }
    }
}
