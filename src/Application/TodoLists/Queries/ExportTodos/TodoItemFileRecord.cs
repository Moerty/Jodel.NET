using Jodel.NET.Application.Common.Mappings;
using Jodel.NET.Domain.Entities;

namespace Jodel.NET.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
