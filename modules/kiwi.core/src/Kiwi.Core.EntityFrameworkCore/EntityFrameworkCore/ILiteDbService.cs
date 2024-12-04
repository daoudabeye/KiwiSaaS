using LiteDB;

namespace Kiwi.Core.EntityFrameworkCore;

public interface ILiteDbService
{
    LiteDatabase Database { get; }
}