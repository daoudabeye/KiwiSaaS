namespace KiwiSaaS.Meta.Domain.Services;

public interface IAutoNumberService
{
    string GetNext(string entityName, string fieldName, Guid? tenantId = null, string? displayFormat = null, long? startingNumber = null);
}
