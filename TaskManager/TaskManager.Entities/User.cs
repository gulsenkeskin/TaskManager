using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Entities
{
    public class User
    {
        //primary key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter name.")]
        [StringLength(50)]
        public string Name { get; set; }


        [Display(Name = "Surname")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please enter surname.")]
        public string Surname { get; set; }
    }
}
