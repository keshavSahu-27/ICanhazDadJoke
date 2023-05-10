using System.Text.Json;
using AutoMapper;
using ICanHazDadJoke.Contract;
using ICanHazDadJoke.Dto;

namespace ICanHazDadJoke.Service;
public class ICanHazDadJokeService: IICanHazDadJokeService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;

    public ICanHazDadJokeService(IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _httpClientFactory = httpClientFactory;
        _mapper = mapper;
    }

    public async Task<Dto.RandomJoke?> FetchRandomJoke()
    {

        var httpClient = _httpClientFactory.CreateClient("ICanHazDadJoke");

        var httpResponseMessage = await httpClient.GetAsync("/");

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            var parseObject = JsonDocument.Parse(contentStream);
            var joke = parseObject.RootElement.Deserialize<RandomJoke>();
            var result = _mapper.Map<Dto.RandomJoke>(joke);
            return result;
        }

        throw new HttpRequestException(httpResponseMessage.ReasonPhrase);
    }

    public async Task<Dto.SearchJoke?> FetchJokeByTerm(int? page, int? limit, string? term)
    {

        var httpClient = _httpClientFactory.CreateClient("ICanHazDadJoke");

        var httpResponseMessage = await httpClient.GetAsync($"/search?page={page}&limit={limit}&term={term}");


        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();
            var parseObject = JsonDocument.Parse(contentStream);
            var jokes = parseObject.RootElement.Deserialize<SearchJoke>();
            var result = _mapper.Map<Dto.SearchJoke>(jokes);
            return result;
        }

        throw new HttpRequestException(httpResponseMessage.ReasonPhrase);
    }
}

