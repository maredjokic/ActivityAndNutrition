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
    public class ParamsTraining
    {
        //for paging
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;

        //substring search
        public string Name { get; set; }


        //for sort
        public string PropertySort { get; set; } = "Name";
        public string SortDirection { get; set; } = "ASC"; //ascending "ASC" descending "DESC"


        //between search
        public double CaloriesBurnedHourFrom { get; set; } = 0; 
        public double CaloriesBurnedHourTo { get; set; } = double.MaxValue;
    }
}