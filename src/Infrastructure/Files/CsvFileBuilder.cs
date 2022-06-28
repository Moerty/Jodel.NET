using System.Globalization;
using Jodel.NET.Application.Common.Interfaces;
using Jodel.NET.Application.TodoLists.Queries.ExportTodos;
using Jodel.NET.Infrastructure.Files.Maps;
using CsvHelper;

namespace Jodel.NET.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
