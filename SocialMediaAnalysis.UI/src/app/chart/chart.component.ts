import {Component, Input} from '@angular/core';
import {PlotlySharedModule} from "angular-plotly.js";
import {Article, ChartData} from "../models/news.model";

@Component({
  selector: 'app-chart',
  standalone: true,
  imports: [
    PlotlySharedModule
  ],
  templateUrl: './chart.component.html',
  styleUrl: './chart.component.scss'
})
export class ChartComponent {
  @Input() data: ChartData[] = [];
  graph: any;

  ngOnChanges(): void {
    this.initGraph();
  }

  initGraph(): void {
    console.log(this.data);
    const x = this.data.map((d) => d.date);
    const y = this.data.map((d) => d.totalNumber);

    this.graph = {
      data: [
        { x: x, y, type: 'scatter', marker: {color: '#663290'}, line: {width: 5}, name: 'Popularity' },
      ],
      layout: {
        height: 700,
        legend: {
          orientation: 'h'
        },
        title: {
          text: '<span style=>SOCIAL MEDIA<br><b style="font-size: 34px">ANALYSIS</b></span>',
          font: {
            family: 'Courier New, monospace',
            size: 24,
          },
          xref: 'paper',
          x: 0.00,
        },
        plot_bgcolor: 'black',
        paper_bgcolor: 'black',
        font: {
          color: '#d9d9d9'
        },
        xaxis: {
          fixedrange: true
        },
        yaxis: {
          gridcolor: '#d9d9d96c',
          gridwidth: 2,
          fixedrange: true
        }},
      config: {staticPlot: false}
    };
  }
}
