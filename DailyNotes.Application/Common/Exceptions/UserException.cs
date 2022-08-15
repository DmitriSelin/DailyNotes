namespace DailyNotes.Application.Common.Exceptions
{
    public class UserException : Exception
    {
        public string? MessageForUser { get; }

        public UserException() { }

        public UserException(string message) : base(message) { }

        public UserException(string message, Exception innerException) : base(message, innerException) { }

        public UserException(string message, string messageForUser) : base(message)
        {
            MessageForUser = messageForUser;
        }
    }
}