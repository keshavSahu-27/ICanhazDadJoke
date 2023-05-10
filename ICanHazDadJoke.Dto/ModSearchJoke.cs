using System;
namespace ICanHazDadJoke.Dto
{
    public class ModSearchJoke
    {
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
        public JokesResults Results { get; set; } = new JokesResults();
        public string SearchTerm { get; set; } = "";
        public int Status { get; set; }
        public int TotalJokes { get; set; }
        public int TotalPages { get; set; }
    }

    public class JokesResults
    {
        public IEnumerable<DadJoke> Short { get; set; } = Enumerable.Empty<DadJoke>();
        public IEnumerable<DadJoke> Medium { get; set; } = Enumerable.Empty<DadJoke>();
        public IEnumerable<DadJoke> Long { get; set; } = Enumerable.Empty<DadJoke>();
    }
}

