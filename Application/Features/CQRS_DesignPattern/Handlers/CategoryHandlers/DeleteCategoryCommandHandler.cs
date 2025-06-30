using Application.Features.CQRS_DesignPattern.Command.CategoryCommand;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.CategoryHandlers
{
    public class DeleteCategoryCommandHandler
    {
        private MyContext _context;
        public DeleteCategoryCommandHandler(MyContext context)
        {
            _context = context;
        }


        public async void Handle(DeleteCategoryCommand deleteCategoryCommand)
        {
            var value = await _context.Categories.FindAsync(deleteCategoryCommand.CategoryId);
            if (value != null)
            {
                throw new Exception("Not Found  Delete Category");

            }
            _context.Categories.Remove(value);
            await  _context.SaveChangesAsync();
        }





    }
}
