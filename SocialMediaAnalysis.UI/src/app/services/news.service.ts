import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { NewsResponse } from '../models/news.model';
import { SourcesResponse } from '../models/source.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NewsService {
  constructor(
    private httpClient: HttpClient
  ) {}
  API_URL = environment.apiUrl;

  getNews(text: string, source: string): Observable<NewsResponse> {
    return this.httpClient.get<NewsResponse>(
      `${this.API_URL}/news?q=${text}&sources=${source}`);
  }

  getSources(): Observable<SourcesResponse> {
    return this.httpClient.get<SourcesResponse>(
      `${this.API_URL}/news/sources`);
  }

  downloadRss(text: string, source: string) {
    return this.httpClient.get(`${this.API_URL}/rss?q=${text}&sources=${source}`, { responseType: 'blob' });
  }
}
