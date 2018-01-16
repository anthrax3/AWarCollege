namespace AirWarCollegeV6._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lecture")]
    public partial class Lecture
    {
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public string lectureTopic { get; set; }

        [Required]
        [StringLength(64)]
        public string speakerName { get; set; }

        [Required]
        [StringLength(64)]
        public string location { get; set; }

        [Column(TypeName = "date")]
        public DateTime date { get; set; }
    }
}
