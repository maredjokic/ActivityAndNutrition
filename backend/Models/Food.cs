
using System.ComponentModel.DataAnnotations;

namespace TrainingFoodAnalyser.Models 
{    
    public class Food   
    {        
        public long Id { get; set; }      
        public string Name { get; set; }  
        public string Type { get; set; }       
        public double Calories { get; set; }
        public double CarbohydratePercent { get; set; } 
        public double ProteinPercent { get; set; }
        public double FatPercent { get; set; }
    }
}