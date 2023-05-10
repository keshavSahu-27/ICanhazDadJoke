using System;
using System.Globalization;
using AutoMapper;
using ICanHazDadJoke.Contract;
using ICanHazDadJoke.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ICanHazDadJoke.Controllers
{
    [ApiController]
    public class ICanHazDadJokeController : Controller
    {
        public ICanHazDadJokeController(IICanHazDadJokeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/fetchRandomJoke")]
        public async Task<ActionResult<RandomJoke?>> FetchRandomJoke()
        {
            var joke = await _service.FetchRandomJoke();
            return Ok(joke);
        }

        [HttpGet]
        [Route("api/getJokesByTerm")]
        public async Task<ActionResult<ModSearchJoke?>> FetchJokeByTerm([FromQuery] int? page, [FromQuery] int? limit, [FromQuery]string? term)
        {
            var joke = await _service.FetchJokeByTerm(page, limit, term);
            if (joke == null)
            {
                return Ok(joke);
            }
            if (!string.IsNullOrEmpty(term))
            {
                var results = new List<Dto.DadJoke>(joke.Results);
                foreach (var res in joke.Results.Select((r,index) => (r.Joke,index)))
                {
                    var modJoke = res.Joke.Replace(term, $"<{term}>",
                        StringComparison.OrdinalIgnoreCase);
                    results[res.index].Joke = modJoke;
                        
                }

                joke.Results = results;
            }
            var modJokes = _mapper.Map<ModSearchJoke>(joke);
            modJokes.Results.Short = joke.Results.Where(s => s.Joke.Split(' ').Length < 10).Distinct().ToList();
            modJokes.Results.Medium = joke.Results.Where(s => {
                var length = s.Joke.Split(' ').Length;
                return length < 20 && length >= 10;
            }).ToList();
            modJokes.Results.Long = joke.Results.Where(s => s.Joke.Split(' ').Length >= 20).ToList();
            
            return Ok(modJokes);
        }

        #region Helpers
        private readonly IICanHazDadJokeService _service;
        private readonly IMapper _mapper;
        #endregion
    }
}
