import {Component, Input} from '@angular/core';
import {NgClass, NgStyle} from "@angular/common";
import {TextSentiment} from "../models/analysis.model";
import {AnalysisService} from "../services/analysis.service";
import {Article} from "../models/news.model";
import {finalize} from "rxjs";
import {TextSentimentColorResolver} from "../constants/constants";

@Component({
  selector: 'app-post-analytics',
  standalone: true,
  imports: [
    NgClass,
    NgStyle
  ],
  templateUrl: './post-analytics.component.html',
  styleUrl: './post-analytics.component.scss'
})
export class PostAnalyticsComponent {
  protected readonly TextSentiment = TextSentiment;
  @Input() article!: Article;
  keyPhrases : string[] = [];
  sentiment = TextSentiment.Neutral;
  clicked = false;
  loading = false;

  constructor(
    private analysisService: AnalysisService
  ) {}

  handleClick(): void {
    this.loading = true;
    this.clicked = true;
    this.analysisService.getAnalysis(this.article.url)
      .pipe(finalize(() => this.loading = false))
      .subscribe(r => {
        this.keyPhrases = r.keyPhrases;
        this.sentiment = r.sentiment.sentiment;
    })
  }

  protected readonly TextSentimentColorResolver = TextSentimentColorResolver;
}
