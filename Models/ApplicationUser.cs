using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace WdprPretparkDenhaag.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<Attractie> Attracties { get; set; }
        public ICollection<Bezoeker> Bezoekers { get; set; }
         public ICollection<Planning> Planningen { get; set; }
         public ICollection<Tijdslot> Tijdsloten { get; set; }
                 public string BezoekerId { get; set; }
        public ApplicationUser Bezoeker { get; set; }
        public ApplicationUser()
        {
            // Children = new List<ApplicationUser>();
            // Clients = new List<ApplicationUser>();
            Attracties = new List<Attractie>();
            Bezoekers = new List<Bezoeker>();
            Planningen = new List<Planning>();
            Tijdsloten = new List<Tijdslot>();
        }

    }

}