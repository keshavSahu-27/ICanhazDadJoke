using System;
namespace ICanHazDadJoke.Service
{
    public class SearchJoke
    {
        public int current_page { get; set; }
        public int limit { get; set; }
        public int next_page { get; set; }
        public int previous_page { get; set; }
        public IEnumerable<DadJoke> results { get; set; } = Enumerable.Empty<DadJoke>();
        public string search_term { get; set; } = "";
        public int status { get; set; }
        public int total_jokes { get; set; }
        public int total_pages { get; set; }
    }
}

