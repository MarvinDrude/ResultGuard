
namespace ResultGuard.Tests.Extensions;

public sealed class RGuardOutOfRangeTests {

    private readonly ITestOutputHelper _Output;

    public RGuardOutOfRangeTests(ITestOutputHelper output) {

        _Output = output;

    }

    [Fact]
    public void NotEqualIsNotEqualDifferentOutput() {

        int numberA = -20;
        int numberB = -22;

        bool ret = RGuard.Is.NotEqual(numberA, numberB, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void NotEqualIsEqualDifferentOutput() {

        int numberA = -20;
        int numberB = -20;

        bool ret = RGuard.Is.NotEqual(numberA, numberB, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NotEqualIsNotEqualSameOutput() {

        int numberA = -20;
        int numberB = -22;

        bool ret = RGuard.Is.NotEqual(numberA, numberB, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void NotEqualIsEqualSameOutput() {

        int numberA = -20;
        int numberB = -20;

        bool ret = RGuard.Is.NotEqual(numberA, numberB, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void EqualIsNotEqualDifferentOutput() {

        int numberA = -20;
        int numberB = -22;

        bool ret = RGuard.Is.Equal(numberA, numberB, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void EqualIsEqualDifferentOutput() {

        int numberA = -20;
        int numberB = -20;

        bool ret = RGuard.Is.Equal(numberA, numberB, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void EqualIsNotEqualSameOutput() {

        int numberA = -20;
        int numberB = -22;

        bool ret = RGuard.Is.Equal(numberA, numberB, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void EqualIsEqualSameOutput() {

        int numberA = -20;
        int numberB = -20;

        bool ret = RGuard.Is.Equal(numberA, numberB, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void GreaterThanIsNotDifferentOutput() {

        int numberA = 20;
        int numberB = 20;

        bool ret = RGuard.Is.GreaterThan(numberA, numberB, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void GreaterThanIsGreaterDifferentOutput() {

        int numberA = 22;
        int numberB = 21;

        bool ret = RGuard.Is.GreaterThan(numberA, numberB, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void GreaterThanIsNotSameOutput() {

        int numberA = 20;
        int numberB = 20;

        bool ret = RGuard.Is.GreaterThan(numberA, numberB, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void GreaterThanIsGreaterSameOutput() {

        int numberA = 22;
        int numberB = 21;

        bool ret = RGuard.Is.GreaterThan(numberA, numberB, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void GreaterThanOrEqualIsNotDifferentOutput() {

        int numberA = 20;
        int numberB = 21;

        bool ret = RGuard.Is.GreaterThanOrEqual(numberA, numberB, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void GreaterThanOrEqualIsEqualDifferentOutput() {

        int numberA = 22;
        int numberB = 22;

        bool ret = RGuard.Is.GreaterThanOrEqual(numberA, numberB, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void GreaterThanOrEqualIsNotSameOutput() {

        int numberA = 20;
        int numberB = 21;

        bool ret = RGuard.Is.GreaterThanOrEqual(numberA, numberB, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void GreaterThanOrEqualIsEqualSameOutput() {

        int numberA = 22;
        int numberB = 22;

        bool ret = RGuard.Is.GreaterThanOrEqual(numberA, numberB, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void LessThanIsNotDifferentOutput() {

        int numberA = 20;
        int numberB = 20;

        bool ret = RGuard.Is.LessThan(numberA, numberB, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void LessThanIsLessDifferentOutput() {

        int numberA = 20;
        int numberB = 21;

        bool ret = RGuard.Is.LessThan(numberA, numberB, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void LessThanIsNotSameOutput() {

        int numberA = 20;
        int numberB = 20;

        bool ret = RGuard.Is.LessThan(numberA, numberB, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void LessThanIsLessSameOutput() {

        int numberA = 20;
        int numberB = 21;

        bool ret = RGuard.Is.LessThan(numberA, numberB, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void LessThanOrEqualIsNotDifferentOutput() {

        int numberA = 22;
        int numberB = 20;

        bool ret = RGuard.Is.LessThanOrEqual(numberA, numberB, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void LessThanOrEqualIsEqualDifferentOutput() {

        int numberA = 20;
        int numberB = 20;

        bool ret = RGuard.Is.LessThanOrEqual(numberA, numberB, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

    [Fact]
    public void LessThanOrEqualIsNotSameOutput() {

        int numberA = 22;
        int numberB = 20;

        bool ret = RGuard.Is.LessThanOrEqual(numberA, numberB, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void LessThanOrEqualIsEqualSameOutput() {

        int numberA = 20;
        int numberB = 20;

        bool ret = RGuard.Is.LessThanOrEqual(numberA, numberB, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentOutOfRangeException);

    }

}
