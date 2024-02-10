import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import * as PlotlyJS from 'plotly.js-dist-min';
import {PlotlyModule} from "angular-plotly.js";

PlotlyModule.plotlyjs = PlotlyJS;

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes)]
};
