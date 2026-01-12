namespace SiniestrosVialesOpitech.Application.Common.Validation.Contracts;
public interface ICustomValidator<InstanceType>
{
    ValueTask<bool> Validate(InstanceType instanceToValidate);
    IEnumerable<KeyValuePair<string, string>> Failures { get; }
}
