import {Component, Input} from '@angular/core';
import {PlotlySharedModule} from "angular-plotly.js";

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
  @Input()
  y!: number[];
  @Input()
  x!: any[];
  graph: any;

  ngOnInit(): void {
    this.initGraph();
  }

  initGraph(): void {
    this.graph = {
      data: [
        { x: this.x, y: [2, 6, 3, 4, 5, 4, 1, 2], type: 'scatter', marker: {color: 'white'}, line: {width: 5}, name: 'Popularity' },
        { x: this.x, y: [1, 3, 7, 2, 5, 2, 1, 2], type: 'scatter', marker: {color: '#3f8a7f'}, line: {width: 5}, name: 'Emotion' },
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
