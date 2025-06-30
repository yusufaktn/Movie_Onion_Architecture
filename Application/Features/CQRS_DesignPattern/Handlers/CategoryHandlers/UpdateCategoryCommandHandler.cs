using Application.Features.CQRS_DesignPattern.Command.CategoryCommand;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MyContext _context;
        public UpdateCategoryCommandHandler(MyContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var value = await _context.Categories.FindAsync(updateCategoryCommand.CategoryId);
            if (value == null)
            {
                throw new Exception("Not Update");
                
            }
            value.CategoryName = updateCategoryCommand.CategoryName;
            await _context.SaveChangesAsync();


        }


    }
}
