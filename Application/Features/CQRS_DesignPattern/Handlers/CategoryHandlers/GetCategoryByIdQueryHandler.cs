using Application.Features.CQRS_DesignPattern.Queries.CategoryQueries;
using Application.Features.CQRS_DesignPattern.Result.CategoryResult;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {

        private  readonly MyContext _context;
        public GetCategoryByIdQueryHandler(MyContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery result)
        {
            var value = await _context.Categories.FindAsync(result.CategoryId);

            return new GetCategoryByIdQueryResult
            {
                
                CategoryId = value.CategoryId,
                CategoryName = value.CategoryName
            };

        }

    }
}
