
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
    public static bool Null<T, E>(
        this RGuard guard, 
        [NotNullWhen(false)] T? argument, 
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if(argument == null) {

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
    public static bool Null<T>(
        this RGuard guard,
        [NotNullWhen(false)] T? argument,
        [MaybeNullWhen(false)] out Result<T> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        return guard.Null<T, T>(argument, out result, parameterName, message);

    }

}
