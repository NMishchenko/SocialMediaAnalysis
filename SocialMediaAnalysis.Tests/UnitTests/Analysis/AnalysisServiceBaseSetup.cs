using Moq;
using NUnit.Framework;
using SocialMediaAnalysis.BLL.Services;
using SocialMediaAnalysis.BLL.Services.Interfaces;

namespace SocialMediaAnalysis.Tests.UnitTests.Analysis;

public class AnalysisServiceBaseSetup
{
    protected Mock<INlpService> MockNlpService = null!;
    protected AnalysisService Sut = null!;
    
    [OneTimeSetUp]
    public void BaseInit()
    {
        MockNlpService = new Mock<INlpService>();
        
        Sut = new AnalysisService(MockNlpService.Object);
    }
}