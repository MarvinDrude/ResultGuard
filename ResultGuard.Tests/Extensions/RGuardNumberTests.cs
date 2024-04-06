
namespace ResultGuard.Tests.Extensions;

public sealed class RGuardNumberTests {

    private readonly ITestOutputHelper _Output;

    public RGuardNumberTests(ITestOutputHelper output) {

        _Output = output;

    }

    [Fact]
    public void NullIsNullDifferentOutput() {

        object? ob = null;
        bool ret = RGuard.Is.Null(ob, out Result<bool>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

}
