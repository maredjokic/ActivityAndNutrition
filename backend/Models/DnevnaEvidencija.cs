using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TrainingFoodAnalyser.Models 
{    
    public class DnevnaEvidencija   
    {        
        public int Id { get; set; }     
        public int KorisnikId { get; set; } 
        public int KalorijePotrosene { get; set; }
        public int KalorijeUnete { get; set; }
        public int Proteini {get; set; }
        public int Masti { get; set; }
        public int Ugljenihidrati { get; set; }
        [Column(TypeName="Date")]
        public DateTime Dan { get; set; }
        
        [IgnoreDataMember]
        public Korisnik Korisnik {get; set;}
    }
}