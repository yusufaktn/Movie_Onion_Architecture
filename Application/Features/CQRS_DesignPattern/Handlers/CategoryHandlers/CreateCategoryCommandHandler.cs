using Application.Features.CQRS_DesignPattern.Command.CategoryCommand;
using Domain.Entity;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MyContext _context;
        public CreateCategoryCommandHandler(MyContext context)
        {
            _context = context;
        }

        public async void Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = command.CategoryName,


            });
            await _context.SaveChangesAsync();


        }

    }
}
