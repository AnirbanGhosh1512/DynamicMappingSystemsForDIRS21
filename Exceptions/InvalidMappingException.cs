using System;
namespace Dynamic_Mapping_System.Exceptions
{
	public class InvalidMappingException:Exception
	{
        public string SourceType { get; }
        public string TargetType { get; }

        public InvalidMappingException(string message, string sourceType, string targetType)
            : base(message)
        {
            SourceType = sourceType;
            TargetType = targetType;
        }
    }
}

