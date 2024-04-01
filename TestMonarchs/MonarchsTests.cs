using MonarchsChallenge;
using NUnit.Framework.Internal;
using NLog;
namespace TestMonarchs;

public class MonarchsTests
{
    private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

    private Monarch[] monarchs;

    [SetUp]
    public async Task Setup()
    {
        var customHttpClient = new CustomClient(); 
        var collector = new MonarchsCollector(customHttpClient);
        monarchs = await collector.GetMonarchs();

        Assert.IsNotNull(monarchs);
        Assert.IsNotEmpty(monarchs);
    }

    [Test]
    public void CountMonarchs_ReturnsCorrectCount()
    {
        const int expectedMonarchsCount = 57;
        var count = monarchs.CountMonarchs();
        
        logger.Info($"Check that there are {expectedMonarchsCount} monarchs in the list");
        Assert.That(count, Is.EqualTo(expectedMonarchsCount));
    }

    [Test]
    public void LongestRulingMonarch_ReturnsLongestRulingMonarch()
    {
        const int expectedRulingLength = 72;
        const string expectedName = "Elizabeth II";
        const string expectedHouse = "House of Windsor";
        var longestRulingMonarch = monarchs.LongestRulingMonarch();

        logger.Info($"Check the longest ruling time is {expectedRulingLength} years, and the longest ruling monarch is {expectedName} of {expectedHouse}");
        Assert.That(longestRulingMonarch.RulingLength, Is.EqualTo(expectedRulingLength));
        Assert.That(longestRulingMonarch.Name, Is.EqualTo(expectedName));
        Assert.That(longestRulingMonarch.House, Is.EqualTo(expectedHouse));
    }

    [Test]
    public void LongestRulingHouse_ReturnsLongestRulingHouse()
    {
        const int expectedYears = 187;
        const string expectedHouse = "House of Hanover";

        var longestRulingHouse = monarchs.LongestRulingHouse();

        logger.Info( $"Check that longest house's ruling time is {expectedYears} years, and the longest ruling house is {expectedHouse}.");
        Assert.That(longestRulingHouse.RulingTime, Is.EqualTo(expectedYears));
        Assert.That(longestRulingHouse!.HouseName, Is.EqualTo(expectedHouse));
    }

    [Test]
    public void MostCommonMonarchName_ReturnsMostCommonName()
    {
        const string expectedName = "Edward";
        var mostCommonName = monarchs.MostCommonMonarchName();

        logger.Info( $"Check that the most common name is {expectedName}");
        Assert.That(mostCommonName, Is.EqualTo(expectedName));
    }
}