
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace ResultGuard.Testing;

public static class EasyExtensions {

    public static bool NotNull<T, E>(this RGuard guard,
        [NotNullWhen(false)] T? argument,
        [MaybeNullWhen(false)] out Result<E> result,
        [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
        string? message = null) {

        if (argument != null) {

            result = Result<E>.FromException(new ArgumentNullException(parameterName, message));
            return true;

        }

        result = null;
        return false;

    }

    public static Result<string> Use() {

        object? ob = new();

        if(RGuard.Is.NotNull(ob, out Result<string>? result)) {
            return result;
        }

        return "Hey, ob is null";

    }

}
