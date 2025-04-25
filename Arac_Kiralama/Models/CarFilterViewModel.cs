using Arac_Kiralama.Models.Dtos.Cars;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Arac_Kiralama.Models
{
    public class CarFilterViewModel
    {
        // Araç listesi
        public List<CarResponseDto> Cars { get; set; } = new List<CarResponseDto>();

        // Dropdown listeleri için SelectList'ler
        public SelectList TransmissionSelectList { get; set; }
        public SelectList FuelSelectList { get; set; }
        public SelectList ColorSelectList { get; set; }
        public SelectList BrandSelectList { get; set; }

        // Filtreleme parametreleri
        public string SelectedTransmission { get; set; }
        public string SelectedFuel { get; set; }
        public string SelectedColor { get; set; }
        public string SelectedBrand { get; set; }
        public decimal? SelectedMinPrice { get; set; }
        public decimal? SelectedMaxPrice { get; set; }
        public string SelectedSortCriteria { get; set; } = "fiyatArtan";

        // Sıralama seçenekleri için
        public List<SelectListItem> SortOptions => new List<SelectListItem>
        {
            new SelectListItem { Value = "fiyatArtan", Text = "Fiyat (Artan)", Selected = SelectedSortCriteria == "fiyatArtan" },
            new SelectListItem { Value = "fiyatAzalan", Text = "Fiyat (Azalan)", Selected = SelectedSortCriteria == "fiyatAzalan" },
            new SelectListItem { Value = "kilometreArtan", Text = "Kilometre (Artan)", Selected = SelectedSortCriteria == "kilometreArtan" },
            new SelectListItem { Value = "kilometreAzalan", Text = "Kilometre (Azalan)", Selected = SelectedSortCriteria == "kilometreAzalan" }
        };

        // Pagination için
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 9; // Sayfa başına 9 araç
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);
    }
}
