
using System.Diagnostics.CodeAnalysis;

namespace ResultGuard;

/// <summary>
/// Monad borrowed concept from other languages.
/// <para>Implicit conversion from <typeparamref name="T"/> -> <see cref="Result{T}"/></para>
/// <para><see langword="null"/> can be handled as valid state</para>
/// </summary>
/// <typeparam name="T"></typeparam>
public readonly struct Result<T> : IEquatable<Result<T>> {

    private readonly Exception? _Exception;

    private readonly ResultType _ResultType;
    private readonly T? _Value;

    public Result(T? resultValue) {

        _ResultType = ResultType.Complete;
        _Value = resultValue;

        _Exception = null;

    }

    public static Result<T> FromException(Exception error) {

        return new Result<T>(error);

    }

    private Result(Exception error) {

        _ResultType = ResultType.Failed;
        _Value = default;

        _Exception = error;

    }

    [MemberNotNullWhen(true, nameof(_Exception), nameof(Exception))]
    [MemberNotNullWhen(false, nameof(_Value), nameof(Value))]
    public bool IsFailed => _ResultType == ResultType.Failed;

    [MemberNotNullWhen(true, nameof(_Value), nameof(Value))]
    [MemberNotNullWhen(false, nameof(_Exception), nameof(Exception))]
    public bool IsCompleted => _ResultType == ResultType.Complete;

    public Exception? Exception {
        get {
            return _Exception;
        }
    }

    public T? Value {
        get {
            return _Value;
        }
    }

    public static implicit operator Result<T>(T? value) => new(value);

    public override string ToString() {
        return IsCompleted
            ? (_Value?.ToString() ?? "(null)") : _Exception?.ToString() ?? "(null)";
    }

    public override bool Equals([NotNullWhen(true)] object? obj) {
        return obj is Result<T> a && Equals(a);
    }

    public override int GetHashCode() {

        return IsFailed ? -10 : _Value?.GetHashCode() ?? 10;

    }

    public bool Equals(Result<T> other) {
        return (
            (other.IsFailed && IsFailed && other.Exception!.GetType() == Exception!.GetType())
            || (other.IsCompleted && IsCompleted && other._Value != null && other._Value.Equals(_Value)));
    }

    public static bool operator ==(Result<T> left, Result<T> right) {
        return left.Equals(right);
    }

    public static bool operator !=(Result<T> left, Result<T> right) {
        return !(left == right);
    }

}

public enum ResultType : byte {

    Complete = 1,
    Failed = 2,
    Invalid = 3,

}