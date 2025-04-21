using System;
using System.ComponentModel.DataAnnotations;

namespace EventTracker.Models
{
    public class EventModel
    {
        // Etkinlik için benzersiz kimlik
        public int Id { get; set; }

        // Etkinlik başlığı (zorunlu alan)
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [Display(Name = "Başlık")]
        public string Title { get; set; }

        // Etkinlik açıklaması (isteğe bağlı alan)
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        // Etkinlik tarihi (zorunlu alan)
        [Required(ErrorMessage = "Tarih alanı zorunludur.")]
        [Display(Name = "Tarih")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
