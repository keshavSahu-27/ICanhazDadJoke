using ICanHazDadJoke.Dto;

namespace ICanHazDadJoke.Contract;
public interface IICanHazDadJokeService
{
    Task<RandomJoke?> FetchRandomJoke();
    Task<SearchJoke?> FetchJokeByTerm(int? page, int? limit, string? term);
}