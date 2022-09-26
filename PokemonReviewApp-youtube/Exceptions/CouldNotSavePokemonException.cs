namespace PokemonReviewApp_youtube.Exceptions
{
    public class CouldNotSavePokemonException : Exception
    {
        public CouldNotSavePokemonException() { }

        public CouldNotSavePokemonException(string message) : base(message) { }
    
    }
}
