
using System.Numerics;

namespace ResultGuard.Extensions;

public static partial class RGuardExtensions {

    public static bool NegativeOrZero<T, E>(this RGuard guard,
        T argument,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : INumberBase<T> {

        if (T.IsZero(argument) || T.IsNegative(argument)) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName} is zero or negative."));
            return true;

        }

        result = null;
        return false;

    }

    public static bool NegativeOrZero<T>(this RGuard guard,
        T argument,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : INumberBase<T> {

        return guard.NegativeOrZero<T, T>(argument, out result, parameterName, message);

    }

    public static bool Zero<T, E>(this RGuard guard,
        T argument,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : INumberBase<T> {

        if (T.IsZero(argument)) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName} is zero."));
            return true;

        }

        result = null;
        return false;

    }

    public static bool Zero<T>(this RGuard guard,
        T argument,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : INumberBase<T> {

        return guard.Zero<T, T>(argument, out result, parameterName, message);

    }

    public static bool Negative<T, E>(this RGuard guard,
        T argument,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : INumberBase<T> {

        if (T.IsNegative(argument)) {

            result = Result<E>.FromException(new ArgumentOutOfRangeException(parameterName, message ?? $"{parameterName} is negative."));
            return true;

        }

        result = null;
        return false;

    }

    public static bool Negative<T>(this RGuard guard,
        T argument,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null)

        where T : INumberBase<T> {

        return guard.Negative<T, T>(argument, out result, parameterName, message);

    }

}
