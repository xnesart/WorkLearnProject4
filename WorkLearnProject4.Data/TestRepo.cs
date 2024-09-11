namespace WorkLearnProject4.Data;

public class TestRepo
{
    protected readonly LearnBdContext _ctx;

    public TestRepo(LearnBdContext context)
    {
        _ctx = context;
    }

    // public string Get()
    // {
    //     string name = _ctx.Test.Select(n => n.Name).ToString();
    //     return name;
    // }
}