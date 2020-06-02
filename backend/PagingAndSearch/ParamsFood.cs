using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingFoodAnalyser.PagingAndSearch
{
    /// <summary>
    /// Params for sorting, searching and paging
    /// </summary>
    public class ParamsFood
    {   
        //for paging
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        //substring search
        public string Name { get; set; }  = "";     
        public string Type { get; set; } = "";


        //for sort
        public string PropertySort { get; set; } = "Name";
        public string SortDirection { get; set; } = "ASC";//ascending "ASC" descending "DESC"



        //between search
        public double CaloriesFrom { get; set; } = 0;
        public double CaloriesTo { get; set; } = double.MaxValue;

        public double CarbohydratePercentFrom { get; set; } = 0;
        public double CarbohydratePercentTo { get; set; } = double.MaxValue;

        public double ProteinPercentFrom { get; set; } = 0;
        public double ProteinPercentTo { get; set; } = double.MaxValue;

        public double FatPercentFrom { get; set; } = 0;
        public double FatPercentTo { get; set; } = double.MaxValue;
    }

}