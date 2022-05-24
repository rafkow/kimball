using System.ComponentModel.DataAnnotations;

namespace Kimball.Models {
    public class Record {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        
        [Display(Name = "Wartość")]
        public int Value { get; set; }

        [Display(Name = "Pilne")]
        public bool IsUrgent { get; set; }
    }
}
