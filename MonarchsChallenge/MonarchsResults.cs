namespace MonarchsChallenge;

/// This class needs to be tested throughly because its dealing with the collection of the data
/// and there might be a mess from one data source to another

internal static class MonarchsResults
{
    public static int CountMonarchs(this Monarch[] monarchs) => 
        monarchs.Length;

    /// TODO: Better to add some logs in the below functions
    /// in case of null results were to be returned instead of checking for that upstream
    public static Monarch? LongestRulingMonarch(this Monarch[] monarchs) => 
        monarchs.MaxBy(x => x.RulingLength);

    public static MonarchHouse? LongestRulingHouse(this Monarch[] monarchs) =>
        monarchs
            .GroupBy(x => x.House)
            .Select(x => new MonarchHouse(x.Key, x.Sum(y => y.RulingLength)))
            .MaxBy(x => x.RulingTime);


    public static string? MostCommonMonarchName(this Monarch[] monarchs) =>
        monarchs.GroupBy(m => m.FirstName)
            .MaxBy(g => g.Count())?
            .Key;
}
// TODO: Better to implement this class from an abstract class since each database will differ
internal class MonarchHouse
{
    public MonarchHouse(string houseName, int rulingTime)
    {
        HouseName = houseName;
        RulingTime = rulingTime;
    }

    // TODO: There is a possibility of null pointer reference here that should be taken care of here 
    public string HouseName { get; }
    public int RulingTime { get; }
}