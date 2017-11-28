﻿
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Digital_Planner_2.Models
{
    public class DPUser
    {
        public static object Identity { get; internal set; }

        //PK
        [Key]
        public int DPUserID { get; set; }

        //Attributes
        [Display(Name = "First Name")]
        public String FirstName { get; set; } = "";
        [Display(Name = "Last Name")]
        public String LastName { get; set; } = "";
        //Email & Password is in the ApplicationUser

        //FK
        [ForeignKey("User")]
        public String UserID { get; set; }

        //Navigation Properties
        public ApplicationUser User { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Availability> Availabilities { get; set; }
    }
}