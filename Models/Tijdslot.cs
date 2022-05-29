using System;
using System.ComponentModel.DataAnnotations;


namespace WdprPretparkDenhaag.Models
{


    public class Tijdslot
    {

        [Key]
        public Guid Id { get; set; }
        public DateTime BeginTijd { get; set; }
        public  DateTime EindTijd { get; set; }
        public bool IsVolgeboekt { get; set; }
        public int Capaciteit { get; set; }
        public int Duur { get; set; }
        public int AantalMensen { get; set; }


    }

}