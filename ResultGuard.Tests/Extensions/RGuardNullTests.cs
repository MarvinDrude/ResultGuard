
namespace ResultGuard.Tests.Extensions;

public sealed class RGuardNullTests {

    private readonly ITestOutputHelper _Output;

    public RGuardNullTests(ITestOutputHelper output) {

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

    [Fact]
    public void NullIsNullSameOutput() {

        object? ob = null;
        bool ret = RGuard.Is.Null(ob, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullIsNotNullDifferentOutput() {

        object? ob = new ();
        bool ret = RGuard.Is.Null(ob, out Result<bool>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullIsNotNullSameOutput() {

        object? ob = new ();
        bool ret = RGuard.Is.Null(ob, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullOrEmptyIsNullDifferentOutput() {

        string? ob = null;
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullOrEmptyIsEmptyDifferentOutput() {

        string? ob = "";
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public void NullOrEmptyIsFilledDifferentOutput() {

        string? ob = " aa  ";
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullOrEmptyIsNullSameOutput() {

        string? ob = null;
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullOrEmptyIsEmptySameOutput() {

        string? ob = "";
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public void NullOrEmptyIsFilledSameOutput() {

        string? ob = " aa  ";
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullOrEmptyIsGuidNullDifferentOutput() {

        Guid? ob = null;
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullOrEmptyIsGuidEmptyDifferentOutput() {

        Guid? ob = Guid.Empty;
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public void NullOrEmptyIsGuidDifferentOutput() {

        Guid? ob = Guid.NewGuid();
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullOrEmptyIsListNullDifferentOutput() {

        List<object>? ob = null;
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullOrEmptyIsListEmptyDifferentOutput() {

        List<object>? ob = [];
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public void NullOrEmptyIsListFullDifferentOutput() {

        List<object>? ob = [new object()];
        bool ret = RGuard.Is.NullOrEmpty(ob, out Result<string>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullOrEmptyIsListNullSameOutput() {

        List<object>? ob = null;
        bool ret = RGuard.Is.NullOrEmpty(ob, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullOrEmptyIsListEmptySameOutput() {

        List<object>? ob = [];
        bool ret = RGuard.Is.NullOrEmpty(ob, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public void NullOrEmptyIsListFullSameOutput() {

        List<object>? ob = [new object()];
        bool ret = RGuard.Is.NullOrEmpty(ob, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullOrWhiteSpaceIsNullDifferentOutput() {

        string? ob = null;
        bool ret = RGuard.Is.NullOrWhiteSpace(ob, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullOrWhiteSpaceIsWhiteSpaceDifferentOutput() {

        string? ob = "  \t ";
        bool ret = RGuard.Is.NullOrWhiteSpace(ob, out Result<object>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public void NullOrWhiteSpaceIsFullDifferentOutput() {

        string? ob = "  \t dsad";
        bool ret = RGuard.Is.NullOrWhiteSpace(ob, out Result<object>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullOrPredicateIsNullDifferentOutput() {

        object? ob = null;
        bool ret = RGuard.Is.NullOrPredicate(ob, (o) => false, out Result<string>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullOrPredicateIsTrueDifferentOutput() {

        object? ob = new ();
        bool ret = RGuard.Is.NullOrPredicate(ob, (o) => true, out Result<string>? result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public void NullOrPredicateIsFalseDifferentOutput() {

        object? ob = new();
        bool ret = RGuard.Is.NullOrPredicate(ob, (o) => false, out Result<string>? result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public void NullOrPredicateIsNullSameOutput() {

        object? ob = null;
        bool ret = RGuard.Is.NullOrPredicate(ob, (o) => false, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public void NullOrPredicateIsTrueSameOutput() {

        object? ob = new();
        bool ret = RGuard.Is.NullOrPredicate(ob, (o) => true, out var result);

        Assert.True(ret);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public void NullOrPredicateIsFalseSameOutput() {

        object? ob = new();
        bool ret = RGuard.Is.NullOrPredicate(ob, (o) => false, out var result);

        Assert.False(ret);
        Assert.Null(result);

    }

    [Fact]
    public async Task NullOrPredicateAsyncIsNullDifferentOutput() {

        object? ob = null;
        (bool isMatched, Result<string>? result) = await RGuard.Is.NullOrPredicateAsync<object, string>(ob, async (o) => {

            await Task.Delay(2);
            return true;

        });

        Assert.True(isMatched);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public async Task NullOrPredicateAsyncIsTrueDifferentOutput() {

        object? ob = new ();
        (bool isMatched, Result<string>? result) = await RGuard.Is.NullOrPredicateAsync<object, string>(ob, async (o) => {

            await Task.Delay(2);
            return true;

        });

        Assert.True(isMatched);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public async Task NullOrPredicateAsyncIsFalseDifferentOutput() {

        object? ob = new ();
        (bool isMatched, Result<string>? result) = await RGuard.Is.NullOrPredicateAsync<object, string>(ob, async (o) => {

            await Task.Delay(2);
            return false;

        });

        Assert.False(isMatched);
        Assert.Null(result);

    }

    [Fact]
    public async Task NullOrPredicateAsyncIsNullSameOutput() {

        object? ob = null;
        (bool isMatched, Result<object>? result) = await RGuard.Is.NullOrPredicateAsync(ob, async (o) => {

            await Task.Delay(2);
            return true;

        });

        Assert.True(isMatched);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentNullException);

    }

    [Fact]
    public async Task NullOrPredicateAsyncIsTrueSameOutput() {

        object? ob = new();
        (bool isMatched, Result<object>? result) = await RGuard.Is.NullOrPredicateAsync(ob, async (o) => {

            await Task.Delay(2);
            return true;

        });

        Assert.True(isMatched);
        Assert.NotNull(result);

        Assert.True(result.IsFailed);
        Assert.NotNull(result.Exception);

        Assert.True(result.Exception is ArgumentException);

    }

    [Fact]
    public async Task NullOrPredicateAsyncIsFalseSameOutput() {

        object? ob = new();
        (bool isMatched, Result<object>? result) = await RGuard.Is.NullOrPredicateAsync(ob, async (o) => {

            await Task.Delay(2);
            return false;

        });

        Assert.False(isMatched);
        Assert.Null(result);

    }

}
