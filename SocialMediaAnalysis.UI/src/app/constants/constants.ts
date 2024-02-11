import {TextSentiment} from "../models/analysis.model";

export const MONTHS = [
  "January",
  "February",
  "March",
  "April",
  "May",
  "June",
  "July",
  "August",
  "September",
  "October",
  "November",
  "December",
];

export const TextSentimentColorResolver = {
  textSentiment: {
    [TextSentiment.Positive]: 'green',
    [TextSentiment.Neutral]: 'blue',
    [TextSentiment.Negative]: 'red',
    [TextSentiment.Mixed]: 'black'
  }
};
