
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TrainingFoodAnalyser.Models
{
  public class DnevnoTrcanje
  {
    public int Id { get; set; }
    public int KorisnikId { get; set; }
    public double Vreme { get; set;}
    public double Duzina { get; set; }
    
    [Column(TypeName="Date")]
    public DateTime Dan { get; set; }

    [IgnoreDataMember]
    public Korisnik Korisnik {get; set;}
      
  }
}