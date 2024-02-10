import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {PlotlyModule} from "angular-plotly.js";
import {ChartComponent} from "./chart/chart.component";
import {MONTHS} from "./constants/constants";
import { Article, NewsResponse } from './models/news.model';
import { SourcesResponse } from './models/source.model';
import { NewsService } from './services/news.service';
import { AnalysisService } from './services/analysis.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, PlotlyModule, ChartComponent, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'SocialMediaAnalysis.UI';
  protected readonly MONTHS = MONTHS;
  newsResponse!: NewsResponse;
  firstArticles!: Article[];
  secondArticles!: Article[];
  sources!: SourcesResponse;
  searchText!: string;
  sourceName!: string;

  constructor(
    private newsService: NewsService,
    private analysisService: AnalysisService
  ) {}

  ngOnInit(): void {
    this.newsService.getSources().subscribe(sources => {
      this.sources = sources;
    })
  }

  public searchResults(): void {
    if (!this.searchText) return;
    
    let sourceName = this.sourceName;
    if (sourceName == "everywhere") sourceName = "";

    this.newsService.getNews(this.searchText, this.sourceName).subscribe(news => {
      news.articles = news.articles.filter((v) => v.description && v.description != "[Removed]");
      this.newsResponse = news;
      if (news && news.articles) {
        this.firstArticles = news.articles.filter((v, i) => i % 2);
        this.secondArticles = news.articles.filter((v, i) => !(i % 2));
      }
    })
  }
}
