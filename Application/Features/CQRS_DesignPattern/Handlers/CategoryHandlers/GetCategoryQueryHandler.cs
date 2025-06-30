using Application.Features.CQRS_DesignPattern.Result.CategoryResult;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MyContext _context;

        public GetCategoryQueryHandler(MyContext context)
        {
            _context = context;
        }


        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var value = await _context.Categories.ToListAsync();
            return value.Select(x => new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,

            }).ToList();
                
               



        }


    }
}
