using System;
namespace ICanHazDadJoke.Dto
{
    public class SearchJoke
    {
        public int CurrentPage { get; set; }
        public int Limit { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
        public IEnumerable<DadJoke> Results { get; set; } = Enumerable.Empty<DadJoke>();
        public string SearchTerm { get; set; } = "";
        public int Status { get; set; }
        public int TotalJokes { get; set; }
        public int TotalPages { get; set; }
    }
}

