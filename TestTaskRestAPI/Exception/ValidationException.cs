namespace TestTaskRestAPI.Exception
{
    class ValidationException : System.Exception
    {
        public string Property { get; protected set; }

        public ValidationException(string message, string property) : base(message)
        {
            Property = property;
        }
    }
}
