using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingFoodAnalyser.Models;
using TrainingFoodAnalyser.PagingAndSearch;
using TrainingFoodAnalyser.Services.MainServices;
using TrainingFoodAnalyser.Repositories;
using TrainingFoodAnalyser.Data;
using Microsoft.EntityFrameworkCore;

namespace TrainingFoodAnalyser.Controllers
{
	[Route("api/Korisnik")]
	[ApiController]
	public class KorisnikController : ControllerBase
	{	
		private readonly ApplicationDbContext _context;
        public KorisnikController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<Korisnik>>> GetAsync()
		{
			return await _context.Korisnik.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Korisnik>> GetById(int id)
		{
			return await _context.Korisnik.FindAsync(id);
		}

        [HttpPost]
		public async Task<ActionResult<Korisnik>> Post(Korisnik korisnik)
		{
			await _context.Korisnik.AddAsync(korisnik);
			await _context.SaveChangesAsync();
			return korisnik;
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Korisnik>> Put( int id, Korisnik korisnik)
		{
			Korisnik oldKorisnik = await _context.Korisnik.FindAsync(id);

			oldKorisnik.Godine = korisnik.Godine;
			oldKorisnik.Tezina = korisnik.Tezina;
			oldKorisnik.Visina = korisnik.Visina;			

			_context.Korisnik.Update(oldKorisnik);
			await _context.SaveChangesAsync();
			return oldKorisnik;
		}

        [HttpDelete("{id}")]
		public async Task<ActionResult<Korisnik>> Delete(int id)
		{
			Korisnik oldKorisnik = await _context.Korisnik.FindAsync(id);

			_context.Korisnik.Remove(oldKorisnik);
			
			return oldKorisnik;
		}

		[HttpGet("Evidencije/{id}")]
		public async Task<ActionResult<List<DnevnaEvidencija>>> ListEvidencije(int id)
		{
			return await _context.Evidencija.Select(t => t).Where(t => t.KorisnikId == id).ToListAsync();
		}

		[HttpGet("Trcanja/{id}")]
		public async Task<ActionResult<List<DnevnoTrcanje>>> ListTrcanje(int id)
		{
			return await _context.Trcanja.Select(t => t).Where(t => t.KorisnikId == id).ToListAsync();
		}

		[HttpPost("Trcanja/{id}")]
		public async Task<ActionResult<DnevnoTrcanje>> AddTrcanje(int id, DnevnoTrcanje trcanje)
		{
			Korisnik korisnik = await _context.Korisnik.FindAsync(id);
			trcanje.KorisnikId = id;
			//trcanje.Korisnik=korisnik;

			_context.Trcanja.Add(trcanje);
			await _context.SaveChangesAsync();
			return trcanje;
		}

		[HttpGet("Trcanja/{id}/7dana")]
		public async Task<ActionResult<List<double>>> ListTrcanje7Dana(int id)
		{
			DateTime dt = DateTime.Now;
			int dan = dt.Day;
			int mesec = dt.Month;
			int godina = dt.Year;
			Console.WriteLine(dan);
			Console.WriteLine(mesec);
			Console.WriteLine(godina);

			List<double> result = new List<double>();

			for(int i = 6; i > -1 ; i--)
			{
				var query =  _context.Trcanja
					.Select(t => t)
					.Where(t => t.KorisnikId == id && t.Dan.Year.Equals(godina) &&
					t.Dan.Month.Equals(mesec) &&
					t.Dan.Day.Equals(dan - i) );

				int count = await query.CountAsync();

				if(count != 0)
				{
					DnevnoTrcanje trcanje = await query.FirstAsync();
					result.Add(trcanje.Vreme/(trcanje.Duzina/1000));
				}
				else 
				{
					result.Add(0.0);
				}
			}

			return result;
		}

		[HttpPost("Evidencije/{id}")]
		public async Task<ActionResult<DnevnaEvidencija>> DodajEvidenciju(int id, DnevnaEvidencija de)
		{
			await _context.Korisnik.FindAsync(id);
			de.KorisnikId=id;

			_context.Evidencija.Add(de);
			await _context.SaveChangesAsync();
			return de;
		}

		[HttpGet("Trcanja/{id}/7meseci")]
		public async Task<ActionResult<List<double>>> ListTrcanje7Meseci(int id)
		{
			DateTime dt = DateTime.Now;
			Console.WriteLine(dt);
			int mesec = dt.Month;
			int godina = dt.Year;

			List<double> result = new List<double>();

			for(int i = 6; i > -1 ; i--)
			{		
				var query =  _context.Trcanja
					.Select(t => t)
					.Where(t => t.KorisnikId == id && t.Dan.Year == godina &&
					t.Dan.Month == (mesec - i));

				int count = await query.CountAsync();

				if(count != 0)
				{
					double duzina = 0;
					double vreme = 0;
					IEnumerable<DnevnoTrcanje> trcanje = await query.ToListAsync();
					foreach(var dtrc in trcanje)
					{
						duzina += dtrc.Duzina;
						vreme += dtrc.Vreme;
						Console.WriteLine(dtrc.Vreme);
					}
					result.Add(vreme/(duzina/1000));
				}
				else 
				{
					result.Add(0.0);
				}
			}

			return result;
		}

		[HttpGet("EvidencijaKalorije/{id}/7dana")]
		public async Task<ActionResult<List<double>>> ListEvidencija7Dana(int id)
		{
			DateTime dt = DateTime.Now;
			int dan = dt.Day;
			int mesec = dt.Month;
			int godina = dt.Year;
			Console.WriteLine(dan);
			Console.WriteLine(mesec);
			Console.WriteLine(godina);

			List<double> result = new List<double>();

			for(int i = 6; i > -1 ; i--)
			{
				var query =  _context.Evidencija
					.Select(t => t)
					.Where(t => t.KorisnikId == id && t.Dan.Year.Equals(godina) &&
					t.Dan.Month.Equals(mesec) &&
					t.Dan.Day.Equals(dan - i) );

				int count = await query.CountAsync();

				if(count != 0)
				{
					DnevnaEvidencija evidencija = await query.FirstAsync();
					result.Add( evidencija.KalorijePotrosene - evidencija.KalorijeUnete);
				}
				else 
				{
					result.Add(0.0);
				}
			}

			return result;
		}

		[HttpGet("EvidencijaNutrijenata/{id}/7dana")]
		public async Task<ActionResult<List<NutrijentiResurs>>> Evidencija7Dana(int id)
		{
			DateTime dt = DateTime.Now;
			int dan = dt.Day;
			int mesec = dt.Month;
			int godina = dt.Year;
			Console.WriteLine(dan);
			Console.WriteLine(mesec);
			Console.WriteLine(godina);

			List<NutrijentiResurs> result = new List<NutrijentiResurs>();

			for(int i = 6; i > -1 ; i--)
			{
				var query =  _context.Evidencija
					.Select(t => t)
					.Where(t => t.KorisnikId == id && t.Dan.Year.Equals(godina) &&
					t.Dan.Month.Equals(mesec) &&
					t.Dan.Day.Equals(dan - i) );

				int count = await query.CountAsync();

				if(count != 0)
				{
					DnevnaEvidencija evidencija = await query.FirstAsync();
					NutrijentiResurs n = new NutrijentiResurs(){
						Uh = evidencija.Ugljenihidrati,
						Prot = evidencija.Proteini,
						Fat = evidencija.Masti
					};

					result.Add(n);
				}
				else 
				{
					NutrijentiResurs n = new NutrijentiResurs(){
						Uh = 0.0,
						Prot = 0.0,
						Fat = 0.0
					};
					result.Add(n);
				}
			}

			return result;
		}

		[HttpDelete("Evidencije/{id}")]
		public async Task<ActionResult<DnevnaEvidencija>> EvidencijaBrisanje(int id)
		{	
			DnevnaEvidencija de = await _context.Evidencija.FindAsync(id);
			_context.Evidencija.Remove(de);
			await _context.SaveChangesAsync();

			return de;
		}

		[HttpDelete("Trcanje/{id}")]
		public async Task<ActionResult<DnevnoTrcanje>> TrcanjeBrisanje(int id)
		{	
			DnevnoTrcanje dt = await _context.Trcanja.FindAsync(id);
			_context.Trcanja.Remove(dt);
			await _context.SaveChangesAsync();

			return dt;
		}
    }
}