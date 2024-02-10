import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {PlotlyModule} from "angular-plotly.js";
import {ChartComponent} from "./chart/chart.component";
import {MONTHS} from "./constants/constants";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, PlotlyModule, ChartComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'SocialMediaAnalysis.UI';
  protected readonly MONTHS = MONTHS;
}
