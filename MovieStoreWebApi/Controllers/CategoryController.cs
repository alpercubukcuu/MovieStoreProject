using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using static MovieStoreWebApi.CategoryOperations.CreateCategory.CreateCategoryCommand;
using MovieStoreWebApi.CategoryOperations.CreateCategory;
using MovieStoreWebApi.CategoryOperations.GetCategoryDetail;
using MovieStoreWebApi.CategoryOperations.UpdateCategory;
using MovieStoreWebApi.CategoryOperations.DeleteCategory;
using CategoryStoreWebApi.Application.CategoryOperations.Queries;
using Microsoft.AspNetCore.Authorization;

namespace MovieStoreWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class CategoryController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        readonly IConfiguration _configuration;
        public CategoryController(IMovieStoreDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _mapper = mapper;
        }

         
        [HttpGet]
        public IActionResult GetCategory()
        {
           GetCategoryQuery query = new GetCategoryQuery(_context, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            CategoryDetailViewModel result;
            GetCategoryDetailQuery query = new GetCategoryDetailQuery(_context, _mapper);
            query.CategoryId= id;
            GetCategoryDetailQeuryValidator validator = new GetCategoryDetailQeuryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }

        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryModel newcategory)
        {
            CreateCategoryCommand command = new CreateCategoryCommand(_context, _mapper);
            var book = _context.Categories.SingleOrDefault(x=> x.CategoryName == newcategory.CategoryName);
           
                command.Model = newcategory;
                CreateCategoryCommandValidator validator = new CreateCategoryCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
                return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id,[FromBody] UpdateCategoryModel updatecategory)
        {
            UpdateCategoryCommand command = new UpdateCategoryCommand(_context);
            command.CategoryId = id;

            command.Model = updatecategory;
            UpdateCategoryCommandValidator validator = new UpdateCategoryCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
                DeleteCategoryCommand command = new DeleteCategoryCommand(_context);
                command.CategoryId = id;
                DeleteCategoryCommandValidator validator = new DeleteCategoryCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
           
        }
    }
}