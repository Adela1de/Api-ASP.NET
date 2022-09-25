namespace PokemonReviewApp_youtube.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException() { }
        public ObjectNotFoundException(string message) : base(message) { }
    }
}
