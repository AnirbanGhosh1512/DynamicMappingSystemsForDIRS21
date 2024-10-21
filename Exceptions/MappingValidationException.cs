using System;
namespace Dynamic_Mapping_System.Exceptions
{
    using System;

    public class MappingValidationException : Exception
    {
        public string SourceType { get; }
        public string TargetType { get; }

        // Basic constructor with just the message
        public MappingValidationException(string message) : base(message)
        {
        }

        // Constructor with message and inner exception (for exception chaining)
        public MappingValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        // Constructor with source and target types for better context
        public MappingValidationException(string message, string sourceType, string targetType) : base(message)
        {
            SourceType = sourceType;
            TargetType = targetType;
        }

        // Override the ToString method to provide detailed error info
        public override string ToString()
        {
            return $"{Message}. Validation failed during mapping from {SourceType} to {TargetType}.";
        }
    }

}

