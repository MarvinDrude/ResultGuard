
namespace ResultGuard;

public static partial class RGuardExtensions {

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if predicate return true with given <paramref name="argument"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="E"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="predicate"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message"></param>
    /// <returns>true if predicate returns true with given argument.</returns>
    public static bool Predicate<T, E>(this RGuard guard,
        T argument,
        Func<T, bool> predicate,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (predicate.Invoke(argument)) {

            result = Result<E>.FromException(new ArgumentException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if predicate return true with given <paramref name="argument"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="predicate"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message"></param>
    /// <returns>true if predicate returns true with given argument.</returns>
    public static bool Predicate<T>(this RGuard guard,
        T argument,
        Func<T, bool> predicate,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {
        
        return guard.Predicate<T, T>(argument, predicate, out result, parameterName, message);

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if predicate return true with given <paramref name="argument"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="E"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="predicate"></param>
    /// <param name="parameterName"></param>
    /// <param name="message"></param>
    /// <returns>true if predicate returns true with given argument.</returns>
    public static async Task<(bool isMatched, Result<E>? result)> PredicateAsync<T, E>(this RGuard guard,
        T argument,
        Func<T, Task<bool>> predicate,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (await predicate.Invoke(argument)) {

            return (true, Result<E>.FromException(new ArgumentException(parameterName, message)));

        }

        return (false, null);

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if predicate return true with given <paramref name="argument"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="predicate"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message"></param>
    /// <returns>true if predicate returns true with given argument.</returns>
    public static async Task<(bool isMatched, Result<T>? result)> PredicateAsync<T>(this RGuard guard,
        T argument,
        Func<T, Task<bool>> predicate,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        return await guard.PredicateAsync<T, T>(argument, predicate, parameterName, message);

    }

}
