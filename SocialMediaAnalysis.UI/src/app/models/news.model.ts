import { Source } from "./source.model";

export interface Article {
    source: Source,
    author: string,
    title: string,
    description: string,
    url: string,
    urlToImage: string,
    publishedAt: Date,
    content: string
}

export interface NewsResponse {
    totalResults: number,
    articles: Article[]
}