import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {PlotlyModule} from "angular-plotly.js";
import {ChartComponent} from "./chart/chart.component";
import { Article, NewsResponse } from './models/news.model';
import { SourcesResponse } from './models/source.model';
import { NewsService } from './services/news.service';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { saveAs } from 'file-saver';
import {PostAnalyticsComponent} from "./post-analytics/post-analytics.component";
import AOS from "aos";
import { finalize } from 'rxjs';
import { NgxSpinnerModule, NgxSpinnerService } from "ngx-spinner";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, PlotlyModule, ChartComponent, FormsModule, PostAnalyticsComponent, NgxSpinnerModule ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  newsResponse!: NewsResponse;
  firstArticles!: Article[];
  secondArticles!: Article[];
  sources!: SourcesResponse;
  searchText!: string;
  selectedSource: string = "everywhere";

  constructor(
    private newsService: NewsService,
    private ngxSpinnerService: NgxSpinnerService
  ) {}

  ngOnInit(): void {
    AOS.init();

    this.newsService.getSources().subscribe(sources => {
      this.sources = sources;
    })
  }

  public searchResults(): void {
    this.ngxSpinnerService.show();
    AOS.init();

    if (!this.searchText) return;
    let sourceName = this.selectedSource;
    if (sourceName == "everywhere") sourceName = "";

    this.newsService.getNews(this.searchText, sourceName).pipe(finalize(() => this.ngxSpinnerService.hide())).subscribe(news => {
      news.articles = news.articles.filter((v) => v.description && v.description != "[Removed]");
      this.newsResponse = news;
      if (news && news.articles) {
        this.firstArticles = news.articles.filter((v, i) => !(i % 2));
        this.secondArticles = news.articles.filter((v, i) => i % 2);
      }
    })
  }

  public downloadRss(): void {
    if (!this.searchText) return;
    
    let sourceName = this.selectedSource;
    if (sourceName == "everywhere") sourceName = "";

    let currentDate = new Date();
    let currentDateString = new DatePipe("en-US").transform(currentDate, 'yyyy-MM-dd-h-mm-ss-a');
    this.newsService.downloadRss(this.searchText, sourceName).subscribe(data => saveAs(data, `news_${currentDateString}.rss`));
  }
}
