using Application.Features.CQRS_DesignPattern.Command.CategoryCommand;
using Application.Features.CQRS_DesignPattern.Handlers.CategoryHandlers;
using Application.Features.CQRS_DesignPattern.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly CreateCategoryCommandHandler _createCommandHandler;
        private readonly DeleteCategoryCommandHandler _deleteCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;

        public CategoriesController(CreateCategoryCommandHandler createCommandHandler, 
                                   DeleteCategoryCommandHandler deleteCommandHandler, 
                                   UpdateCategoryCommandHandler updateCategoryCommandHandler, 
                                   GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, 
                                   GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _deleteCommandHandler = deleteCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }



        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _getCategoryQueryHandler.Handle();
            return Ok(categories);


        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _createCommandHandler.Handle(createCategoryCommand);
            return Ok("Category addition successful");


        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _deleteCommandHandler.Handle(new DeleteCategoryCommand(id));
            return Ok("Deletion Successful");
             

        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            await _updateCategoryCommandHandler.Handle(updateCategoryCommand);
            return Ok("Updated Successful");



        }

        [HttpGet("GetCategoryById")]

        public async Task<IActionResult> GetCategoryById(int id)
        {
           var category = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
           return Ok(category);
        }



    }
}
