using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4._07._23_2_.Models
{
    public class JobSeeker
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string ? ad { get; set; }
        public string ? soyad { get; set; }
        public string ? mail { get; set; }
        public ulong telno { get; set; }
        public string ? sehir { get; set; }
        public string ? ilce { get; set; }

        public DateTime dogumtarihi { get; set; }
        public string ? egitimSeviyesi { get; set; }

        public string ? cinsiyet { get; set; }

        [Required]
        public string ? KullanıcıSifresi { get; set; }


        [NotMapped]
        public string? Role { get; set; } = "Kullanıcı";
    }


    public class IsBakanMeslek
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public int MeslekId { get; set; } // meslek

        [ForeignKey("MeslekId")]
        public virtual Meslek ? Meslek { get; set; }  
        public int JobSeekerId { get; set; } //job seeker

        [ForeignKey("JobSeekerId")]
        public virtual JobSeeker ? JobSeeker { get; set; }
    
    }


    public class IsBakanIlan
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public int JobSeekerId { get; set; }

        [ForeignKey("JobSeekerId")]
        public virtual JobSeeker ? JobSeeker { get; set; }
        public int IlanId { get; set; }
        [ForeignKey("IlanId")]
        public virtual Ilan ? Ilan { get; set; }

    }
    public class IsSahibi
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string ? ad { get; set; }
        public string ?soyisim { get; set; }
        public string ? mail { get; set; }
        public ulong telno { get; set; }
        public string ? KullanıcıSifresi { get; set; }
    }

    public class Ilan
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string aciklama { get; set; }
        public int DeneyimId { get; set; }

        [ForeignKey("DeneyimId")]
        public virtual Deneyim ? Deneyim { get; set; }
        public DateTime GetDate { get; set; } = DateTime.Now;

        public string ?egitimseviyesi { get; set; }

        public int maaş { get; set; }
        public int FirmaId { get; set; }
        [ForeignKey("FirmaId")]
        public virtual Firma? Firma { get; set; }
        public string ? firmaWebSite { get; set; }
        public int CalismaTuruId { get; set; }

        [ForeignKey("CalismaTuruId")]
        public virtual CalismaTuru ?CalismaTuru { get; set; }


        //public int IsSahibiId { get; set; }

        //[ForeignKey("IsSahibiId")]
        //public virtual IsSahibi ? IsSahibi { get; set; }
    }

    public class Meslek
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string ? ad { get; set; }
    }

    public class CalismaTuru
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string ? ad { get; set; }
    }

    public class Deneyim
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string ? ad { get; set; }
    }


    public class Firma
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string? ad { get; set; }

        public string ?Adres { get; set; }

        public string ? mail { get; set;}

        public int ? kurulusYili { get; set;}

        public string ? website {get; set;}

        public ulong telno {get; set;}

        public string ? aciklama { get; set;}
        
        public int? IsSahibiId { get; set; } // iş sahibi
        //[ForeignKey("IsSahibiId")]
        //public virtual IsSahibi ? IsSahibi { get; set;}
    }

    public class Sektor
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string ? ad { get; set; }
    }

    public class FirmaSektor
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public int FirmaId { get; set; } // firma
        [ForeignKey("FirmaId")]
        public virtual Firma? Firma { get; set; }
        public int? SektorId { get; set; } // sektör
        [ForeignKey("SektorId")]
        public virtual Sektor? Sektor { get; set; }
    }

    [NotMapped]
    public class Login
    {

    }
}