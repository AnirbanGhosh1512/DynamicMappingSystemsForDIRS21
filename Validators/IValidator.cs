using System;
namespace Dynamic_Mapping_System.Validators
{
    public interface IValidator<T>
    {
        bool Validate(T obj);
        string ValidationErrorMessage { get; }
    }

}

