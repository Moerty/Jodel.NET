using Jodel.NET.Application.TodoLists.Queries.ExportTodos;

namespace Jodel.NET.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
