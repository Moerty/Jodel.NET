using Jodel.NET.Application.Common.Interfaces;

namespace Jodel.NET.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
