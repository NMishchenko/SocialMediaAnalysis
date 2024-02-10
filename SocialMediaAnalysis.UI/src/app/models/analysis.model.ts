export enum TextSentiment {
    Positive,
    Neutral,
    Negative,
    Mixed,
}

export interface ConfidenceScore {
    positive: number,
    neutral: number,
    negative: number
}

export interface Sentiment {
    sentiment: TextSentiment,
    confidenceScore: ConfidenceScore
}

export interface AnalysisResponse {
    sentiment: Sentiment,
    keyPhrases: string[]
}

export interface AnalysisRequest {
    pageUrl: string
}