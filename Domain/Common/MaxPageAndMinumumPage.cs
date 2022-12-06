using Domain.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Common
{
    public class MaxPageAndMinumumPage : Specification<Books>
    {
        public MaxPageAndMinumumPage(int maxPage, int minumumPage)
        {
            MaxPage = maxPage;
            MinumumPage = minumumPage;
        }
        public int MaxPage { get; set; }
        public int MinumumPage { get; set; }
        public override Expression<Func<Books, bool>> Expression()
        {
            return r => r.Page >= MinumumPage && r.Page <= MaxPage;
        }
    }
}
