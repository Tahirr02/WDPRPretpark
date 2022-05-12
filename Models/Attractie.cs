

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Attractie
{
    [Key]
    public Guid Id { get; set; }
    public string Naam { get; set; }
    public int MinimaleLeeftijd { get; set; }
    public int AngstFactor { get; set; }
    public string Foto { get; set; }
    public int MinimaleLengte { get; set; }
    public double Prijs { get; set; }
    public int AantalLikes { get; set; }
    public bool Inschrijfplicht { get; set; }
    public List<Tijdslot> TijdsSloten { get; set; }
    public int AantalKerenPerDag { get; set; }
    public DateTime OpeningsTijd { get; set; }
    public DateTime SluitingsTijd { get; set; }




}
