using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Bezoeker
{
    
    public string Voornaam { get; set; }
     public string Achternaam { get; set; }
     [Key]
      public Guid Id { get; set; }
       public string Email { get; set; }
  

}