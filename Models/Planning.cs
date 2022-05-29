using System;
using System.Collections.Generic;

namespace WdprPretparkDenhaag.Models
{


    public class Planning
    {

        public Guid Id { get; set; }
        public DateTime TotaleKosten { get; set; }
    public List<Attractie> AttractieLijst { get; set; }
    public int BezoekersId { get; set; }
        

    }
}