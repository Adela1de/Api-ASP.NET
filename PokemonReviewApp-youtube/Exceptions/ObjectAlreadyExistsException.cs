namespace PokemonReviewApp_youtube.Exceptions
{
    public class ObjectAlreadyExistsException : Exception
    {
        public ObjectAlreadyExistsException() { }
        public ObjectAlreadyExistsException(string message) : base(message) { }
    }
}
