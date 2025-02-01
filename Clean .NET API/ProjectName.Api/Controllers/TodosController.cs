using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.DTOs.Todo;
using ProjectName.Business.Services;
using ProjectName.Domain.Entities;

namespace ProjectName.Api.Controllers
{
    public class TodosController : BaseApiController
    {
        private readonly ITodoService _todoService;
        private readonly IMapper _mapper;

        public TodosController(ITodoService todoService, IMapper mapper)
        {
            _todoService = todoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TodoResponseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TodoResponseDto>>> GetAllAsync()
        {
            var userId = GetUserId();
            var todos = await _todoService.GetAllTodosForUserAsync(userId);

            return Ok(_mapper.Map<List<TodoResponseDto>>(todos));
        }

        [Route("{todoId}")]
        [HttpGet]
        [ProducesResponseType(typeof(TodoResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoResponseDto>> GetByIdAsync([FromRoute]Guid todoId)
        {
            var userId = GetUserId();
            var todos = await _todoService.GetTodoForUserByIdAsync(todoId, userId);

            return Ok(_mapper.Map<TodoResponseDto>(todos));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TodoResponseDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<TodoResponseDto>> CreateAsync([FromBody]TodoRequestDto todoRequestDto)
        {
            var userId = GetUserId();
            var todo = _mapper.Map<Todo>(todoRequestDto);

            var createdTodo = await _todoService.CreateTodoForUserAsync(todo, userId);

            return Created($"{createdTodo.Id}", _mapper.Map<TodoResponseDto>(createdTodo));
        }

        [Route("{todoId}")]
        [HttpPut]
        [ProducesResponseType(typeof(TodoResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoResponseDto>> UpdateAsync(
            [FromRoute]Guid todoId,
            [FromBody]TodoRequestDto todoRequestDto)
        {
            var userId = GetUserId();
            var todo = _mapper.Map<Todo>(todoRequestDto);

            var updatedTodo = await _todoService.UpdateTodoForUserAsync(todo, todoId, userId);

            return Ok(_mapper.Map<TodoResponseDto>(updatedTodo));
        }

        [Route("{todoId}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteAsync([FromRoute]Guid todoId)
        {
            var userId = GetUserId();
            await _todoService.DeleteTodoForUserAsync(todoId, userId);

            return Ok();
        }
    }
}
