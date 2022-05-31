using System;
using System.Collections.Generic;

namespace WdprPretparkDenhaag.Models
{


    public class Planning
    {

        public Guid Id { get; set; }
        public DateTime Dag { get; set; }
        public double TotaleKosten { get; set; }
    public List<Attractie> AttractieLijst { get; set; }
    public int BezoekersId { get; set; }
        

    }
}