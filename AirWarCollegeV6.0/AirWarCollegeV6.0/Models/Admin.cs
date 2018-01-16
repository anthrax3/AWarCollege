namespace AirWarCollegeV6._0.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(32)]
        [Required(ErrorMessage = "Username is required")]
        public string userName { get; set; }

        [StringLength(32)]
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
    }
}
