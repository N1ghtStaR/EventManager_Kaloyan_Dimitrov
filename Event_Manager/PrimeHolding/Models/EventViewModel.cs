namespace PrimeHolding.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EventViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MinLength(4, ErrorMessage = "Event name must not be less than 4 symbols!")]
        [MaxLength(64, ErrorMessage = "Event name must be less than 64 symbols!")]
        [DisplayName("Event name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DisplayName("Event location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.DateTime)]
        [DisplayName("Date of starting")]
        public DateTime Start { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [DataType(DataType.DateTime)]
        [DisplayName("Date of finishing")]
        public DateTime Finish { get; set; }

        public EventViewModel()
        { }
    }
}