using Dapper;
using System.Data;

namespace Bookify.Infrastructure.Data;

/// <summary>
/// This is related to Dapper because we're using DateOnly types in the date range value objects, I need to tell Dapper how to be able to map this type, because it doesn't support it out of the box.
/// </summary>
internal sealed class DateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override DateOnly Parse(object value) => DateOnly.FromDateTime((DateTime)value);

    public override void SetValue(IDbDataParameter parameter, DateOnly value)
    {
        parameter.DbType = DbType.Date;
        parameter.Value = value;
    }
}