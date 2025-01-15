using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.DTOs.Todo;
using ProjectName.Business.Services;
using ProjectName.Domain.Entities;

namespace ProjectName.Api.Controllers
{
    public class TodosController(
        ITodoService todoService,
        IMapper mapper) : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<TodoResponseDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TodoResponseDto>>> GetAllAsync()
        {
            var todos = await todoService.GetAllAsync();
            return Ok(mapper.Map<List<TodoResponseDto>>(todos));
        }

        [HttpPost]
        [ProducesResponseType(typeof(TodoResponseDto), StatusCodes.Status201Created)]
        public async Task<ActionResult<TodoResponseDto>> CreateAsync([FromBody]TodoRequestDto todoRequestDto)
        {
            var todo = mapper.Map<Todo>(todoRequestDto);
            var createdTodo = await todoService.CreateAsync(todo);

            return Created($"{createdTodo.Id}", mapper.Map<TodoResponseDto>(createdTodo));
        }

        [Route("{todoId}")]
        [HttpPut]
        [ProducesResponseType(typeof(TodoResponseDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<TodoResponseDto>> UpdateAsync(
            [FromRoute]Guid todoId,
            [FromBody]TodoRequestDto todoRequestDto)
        {
            var todo = mapper.Map<Todo>(todoRequestDto);
            todo.Id = todoId;

            var updatedTodo = await todoService.UpdateAsync(todo);

            return Ok(mapper.Map<TodoResponseDto>(updatedTodo));
        }

        [Route("{todoId}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteAsync([FromRoute]Guid todoId)
        {
            await todoService.DeleteAsync(todoId);
            return Ok();
        }
    }
}
