
namespace ResultGuard.Tests.Extensions;

public sealed class RGuardNumberTests {

    private readonly ITestOutputHelper _Output;

    public RGuardNumberTests(ITestOutputHelper output) {

        _Output = output;

    }

    [Fact]
    public void NegativeIsNegativeDifferentOutput() {

        int number = -20;
        bool ret = RGuard.Is.Negative(number, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void NegativeIsZeroDifferentOutput() {

        int number = 0;
        bool ret = RGuard.Is.Negative(number, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NegativeIsPositiveDifferentOutput() {

        int number = 10;
        bool ret = RGuard.Is.Negative(number, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NegativeIsNegativeSameOutput() {

        int number = -20;
        bool ret = RGuard.Is.Negative(number, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void NegativeIsZeroSameOutput() {

        int number = 0;
        bool ret = RGuard.Is.Negative(number, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NegativeIsPositiveSameOutput() {

        int number = 10;
        bool ret = RGuard.Is.Negative(number, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void ZeroIsZeroDifferentOutput() {

        int number = 0;
        bool ret = RGuard.Is.Zero(number, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void ZeroIsNegativeDifferentOutput() {

        int number = -20;
        bool ret = RGuard.Is.Zero(number, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void ZeroIsPositiveDifferentOutput() {

        int number = 10;
        bool ret = RGuard.Is.Zero(number, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void ZeroIsZeroSameOutput() {

        int number = 0;
        bool ret = RGuard.Is.Zero(number, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void ZeroIsNegativeSameOutput() {

        int number = -20;
        bool ret = RGuard.Is.Zero(number, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void ZeroIsPositiveSameOutput() {

        int number = 10;
        bool ret = RGuard.Is.Zero(number, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NegativeOrZeroIsZeroDifferentOutput() {

        int number = 0;
        bool ret = RGuard.Is.NegativeOrZero(number, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void NegativeOrZeroIsNegativeDifferentOutput() {

        int number = -20;
        bool ret = RGuard.Is.NegativeOrZero(number, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void NegativeOrZeroIsPositiveDifferentOutput() {

        int number = 10;
        bool ret = RGuard.Is.NegativeOrZero(number, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NegativeOrZeroIsZeroSameOutput() {

        int number = 0;
        bool ret = RGuard.Is.NegativeOrZero(number, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void NegativeOrZeroIsNegativeSameOutput() {

        int number = -20;
        bool ret = RGuard.Is.NegativeOrZero(number, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void NegativeOrZeroIsPositiveSameOutput() {

        int number = 10;
        bool ret = RGuard.Is.NegativeOrZero(number, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

}
