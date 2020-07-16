using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Entities
{
    public class Task
    {
        //primary key, key ++
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }


        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please choose type.")]
        public TaskType Type { get; set; }


        [StringLength(50)]
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Please enter title.")]
        public string Title { get; set; }

        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> StartDate { get; set; }


        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> EndDate { get; set; }

        [Display(Name = "Description Of Work")]
        public string Description { get; set; }
        
       
        public int UserId { get; set; }


    }

    public enum TaskType
    {
        Daily,Weekly,Monthly
    }


}
