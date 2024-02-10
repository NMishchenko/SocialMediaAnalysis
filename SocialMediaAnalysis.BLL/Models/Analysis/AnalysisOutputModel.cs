using SocialMediaAnalysis.BLL.Models.Nlp;

namespace SocialMediaAnalysis.BLL.Models.Analysis
{
    public class AnalysisOutputModel
    {
        public SentimentModel Sentiment { get; set; }

        public IEnumerable<string> KeyPhrases { get; set; }
    }
}
