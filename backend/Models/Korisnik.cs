using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingFoodAnalyser.Models
{
    public class Korisnik
    {
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public double Tezina { get; set; }
		public double Visina { get; set; }
		public int Godine { get; set; }
		public string Pol {get; set;}

		public ICollection<DnevnaEvidencija> Evidencije { get; set; }
		public ICollection<DnevnoTrcanje> Trcanja { get; set; }
	}
}