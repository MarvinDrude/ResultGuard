
namespace ResultGuard;

public static partial class RGuardExtensions {

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="E"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">Optional custom error message.</param>
    /// <returns>true if the argument is null</returns>
    public static bool Null<T, E>(this RGuard guard, 
        [NotNullWhen(false)] T? argument, 
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (argument == null) {

            result = Result<E>.FromException(new ArgumentNullException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">Optional custom error message.</param>
    /// <returns>true if the argument is null</returns>
    public static bool Null<T>(this RGuard guard,
        [NotNullWhen(false)] T? argument,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        return guard.Null<T, T>(argument, out result, parameterName, message);

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null or an empty string.
    /// </summary>
    /// <typeparam name="E"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">Optional custom error message.</param>
    /// <returns>true if the argument is null or an empty string.</returns>
    public static bool NullOrEmpty<E>(this RGuard guard,
        [NotNullWhen(false)] string? argument,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (RGuard.Is.Null(argument, out Result<E>? res, parameterName, message)) {

            result = res;
            return true;

        }

        if (argument == string.Empty) {

            result = Result<E>.FromException(new ArgumentException(message ?? $"Argument {parameterName} is empty.", parameterName));
            return true;

        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null or an empty guid.
    /// </summary>
    /// <typeparam name="E"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message"></param>
    /// <returns>true if the argument is null or an empty guid.</returns>
    public static bool NullOrEmpty<E>(this RGuard guard,
        [NotNullWhen(false)] Guid? argument,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (RGuard.Is.Null(argument, out Result<E>? res, parameterName, message)) {

            result = res;
            return true;

        }

        if (argument == Guid.Empty) {

            result = Result<E>.FromException(new ArgumentException(message ?? $"Argument {parameterName} is empty.", parameterName));
            return true;

        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null or an empty enumerable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="E"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message"></param>
    /// <returns>true if the argument is null or an empty enumerable.</returns>
    public static bool NullOrEmpty<T, E>(this RGuard guard,
        [NotNullWhen(false)] IEnumerable<T>? argument,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (RGuard.Is.Null(argument, out Result<E>? res, parameterName, message)) {

            result = res;
            return true;

        }

        if ((argument is Array and { Length: 0 }) || (argument.TryGetNonEnumeratedCount(out var count) && count == 0) || (!argument.Any())) {

            result = Result<E>.FromException(new ArgumentException(message ?? $"Argument {parameterName} is empty.", parameterName));
            return true;

        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null or an empty enumerable.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message"></param>
    /// <returns>true if the argument is null or an empty enumerable.</returns>
    public static bool NullOrEmpty<T>(this RGuard guard,
        [NotNullWhen(false)] IEnumerable<T>? argument,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        return guard.NullOrEmpty<T, T>(argument, out result, parameterName, message);

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null or an empty/whitespace string.
    /// </summary>
    /// <typeparam name="E"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message"></param>
    /// <returns>true if the argument is null or an empty/whitespace string.</returns>
    public static bool NullOrWhiteSpace<E>(this RGuard guard,
        [NotNullWhen(false)] string? argument,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (RGuard.Is.Null(argument, out Result<E>? res, parameterName, message)) {

            result = res;
            return true;

        }

        if (string.IsNullOrWhiteSpace(argument)) {

            result = Result<E>.FromException(new ArgumentException(message ?? $"Argument {parameterName} is empty/only whitespace.", parameterName));
            return true;

        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null or the predicate func returns true.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="E"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">Optional custom error message.</param>
    /// <returns>true if the argument is null or the predicate func returns true.</returns>
    public static bool NullOrPredicate<T, E>(this RGuard guard,
        [NotNullWhen(false)] T? argument,
        Func<T, bool> predicate,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (RGuard.Is.Null(argument, out Result<E>? res, parameterName, message)) {

            result = res;
            return true;

        }

        if (RGuard.Is.Predicate(argument, predicate, out res, parameterName, message)) {

            result = res;
            return true;

        }

        result = null;
        return false;

    }

    /// <summary>
    /// Returns true and an <see langword="out"/> result in error state if <paramref name="argument"/> is null or the predicate func returns true.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="guard"></param>
    /// <param name="argument"></param>
    /// <param name="result"></param>
    /// <param name="parameterName"></param>
    /// <param name="message">Optional custom error message.</param>
    /// <returns>true if the argument is null or the predicate func returns true.</returns>
    public static bool NullOrPredicate<T>(this RGuard guard,
        [NotNullWhen(false)] T? argument,
        Func<T, bool> predicate,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        return guard.NullOrPredicate<T, T>(argument, predicate, out result, parameterName, message);

    }

}
