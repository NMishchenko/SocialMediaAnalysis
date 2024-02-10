import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { AnalysisRequest, AnalysisResponse } from '../models/analysis.model';

@Injectable({
  providedIn: 'root'
})
export class AnalysisService {
  constructor(
    private httpClient: HttpClient
  ) {}
  API_URL = environment.apiUrl;

  getAnalysis(url: string): Observable<AnalysisResponse> {
    const analysisRequestModel: AnalysisRequest = {
      pageUrl: url
    }

    return this.httpClient.post<AnalysisResponse>(
      `${this.API_URL}/analysis`, analysisRequestModel);
  }
}
