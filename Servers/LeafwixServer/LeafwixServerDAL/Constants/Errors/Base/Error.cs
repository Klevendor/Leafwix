namespace LeafwixServerDAL.Constants.Errors.Base
{
    public class Error
    {
        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }

        public Error(string code, string description, ErrorType type = ErrorType.Failure)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public enum ErrorType
        {
            Failure,
            Unexpected,
            Validation,
            Conflict,
            NotFound,
            Unauthorized,
            Forbidden
        }
    }
}
