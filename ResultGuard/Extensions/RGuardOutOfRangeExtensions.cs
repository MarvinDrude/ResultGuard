
namespace ResultGuard;

public static partial class RGuardExtensions {

    public static bool NotEqual<T, E>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IEquatable<T> {

        if (!EqualityComparer<T>.Default.Equals(argument, other)) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    public static bool NotEqual<T>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IEquatable<T> {

        return guard.NotEqual<T, T>(argument, other, out result, parameterName, message);

    }

    public static bool Equal<T, E>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IEquatable<T> {

        if (EqualityComparer<T>.Default.Equals(argument, other)) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    public static bool Equal<T>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IEquatable<T> {

        return guard.Equal<T, T>(argument, other, out result, parameterName, message);

    }

    public static bool GreaterThan<T, E>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IComparable<T> {

        if (argument.CompareTo(other) > 0) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    public static bool GreaterThan<T>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IComparable<T> {

        return guard.GreaterThan<T, T>(argument, other, out result, parameterName, message);

    }

    public static bool GreaterThanOrEqual<T, E>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IComparable<T> {

        if (argument.CompareTo(other) >= 0) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    public static bool GreaterThanOrEqual<T>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IComparable<T> {

        return guard.GreaterThanOrEqual<T, T>(argument, other, out result, parameterName, message);

    }

    public static bool LessThan<T, E>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IComparable<T> {

        if (argument.CompareTo(other) < 0) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    public static bool LessThan<T>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IComparable<T> {

        return guard.LessThan<T, T>(argument, other, out result, parameterName, message);

    }

    public static bool LessThanOrEqual<T, E>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IComparable<T> {

        if (argument.CompareTo(other) <= 0) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    public static bool LessThanOrEqual<T>(this RGuard guard,
        T argument,
        T other,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : IComparable<T> {

        return guard.LessThanOrEqual<T, T>(argument, other, out result, parameterName, message);

    }

}
