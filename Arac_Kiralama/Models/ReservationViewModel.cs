using System;
using System.ComponentModel.DataAnnotations;

namespace Arac_Kiralama.Models
{
    public class ReservationViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Araç ID zorunludur.")]
        public int CarId { get; set; }

        public string CarName { get; set; }

        public string CarImageUrl { get; set; }

        public decimal DailyPrice { get; set; }

        [Required(ErrorMessage = "Kullanıcı ID zorunludur.")]
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string UserPhone { get; set; }

        [Required(ErrorMessage = "Başlangıç tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Başlangıç Tarihi")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Bitiş tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Bitiş Tarihi")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Toplam Gün")]
        public int TotalDays => (EndDate - StartDate).Days;

        [Display(Name = "Toplam Tutar")]
        public decimal TotalPrice => DailyPrice * TotalDays;

        [Display(Name = "Ek Notlar")]
        public string Notes { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; }

        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}