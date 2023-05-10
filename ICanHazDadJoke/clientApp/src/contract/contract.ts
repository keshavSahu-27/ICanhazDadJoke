export interface RandomJoke extends DadJoke {
    status: number;
}

export interface DadJoke {
    id: string;
    joke: string;
}

export interface ModSearchedJoke {
    currentPage: number;
    limit: number;
    nextPage: number;
    previousPage: number;
    results: JokesResults;
    searchterm: string;
    status: number;
    totalJokes: number;
    totalPages: number;
}

export interface JokesResults {
    short: DadJoke[];
    medium: DadJoke[];
    long: DadJoke[];
}