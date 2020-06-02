using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingFoodAnalyser.PagingAndSearch
{
    public class PaginatedList<T> //not used yet
    {
        public IEnumerable<T> Data { get; set; }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }//number of all elements 
        public int TotalPages { get; set; }

        public PaginatedList(IEnumerable<T> data, int totalCount, int page , int pageSize)
        {
            CurrentPage = page;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
            PageSize = pageSize;

            Data = data;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
    }
}
