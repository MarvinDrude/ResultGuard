# ResultGuard
<img src="https://github.com/MarvinDrude/ResultGuard/blob/master/ResultGuard/Resources/icon.png" width="64" height="64">
A small and easy package if you want guarding without throwing all those exceptions, but returning a result in either failed or later in completed state.

## Easy to extend
You can easily write your own extension methods for RGuard like the following (NotNull is not typically something you need to guard against, but for the sake of example):
```csharp
public static bool NotNull<T, E>(this RGuard guard,
    [NotNullWhen(false)] T? argument,
    [MaybeNullWhen(false)] out Result<E> result,
    [CallerArgumentExpression(nameof(argument))] string? parameterName = null,
    string? message = null) {

    if (argument != null) {

        result = Result<E>.FromException(new ArgumentException(parameterName, message));
        return true;

    }

    result = null;
    return false;

}
```

Using it like that then (Example is a bit nonesense):
```csharp
public static Result<string> Use() {

    object? ob = new();

    if(RGuard.Is.NotNull(ob, out Result<string>? result)) {
        return result;
    }

    return "Hey, ob is null";

}
```

## Example usage
```csharp
// usage with result type different to input that is being tested
Func<string?, Result<MoreUsageToLower>> moreUsageToLower = (string? parameter) => {

    if (RGuard.Is.NullOrEmpty(parameter, out Result<MoreUsageToLower>? error)) {
        return error;
    }

    if (RGuard.Is.GreaterThan(parameter.Length, 20, out error, "ParameterName", "Parameter is longer than 20 characters.")) {
        return error;
    }

    return new MoreUsageToLower() {
        Result = parameter.ToLowerInvariant(),
    };

};

// usage with result type equal to 
Func<string?, Result<string>> simpleUsageToLower = (string? parameter) => {

    if (RGuard.Is.Null(parameter, out var error)) {
        return error;
    }

    return parameter.ToLowerInvariant();

};
```

## Built in and tested methods
### Null checks
Is Null
```csharp
RGuard.Is.Null(ob, out Result<bool>? result); //different result type
RGuard.Is.Null(ob, out var result); //result type same as ob (var -> Result<object>? if ob was object)
```
Is Null or Empty for strings
```csharp
RGuard.Is.NullOrEmpty(ob, out Result<bool>? result); //different result type
RGuard.Is.NullOrEmpty(ob, out var result); //result type same as ob (var -> Result<string>? if ob is string)
```
Is Null or Empty for guids
```csharp
RGuard.Is.NullOrEmpty(ob, out Result<bool>? result); //different result type
RGuard.Is.NullOrEmpty(ob, out var result); //result type same as ob (var -> Result<Guid>? if ob is guid)
```
Is Null or Empty for guids
```csharp
RGuard.Is.NullOrEmpty(ob, out Result<bool>? result); //different result type
RGuard.Is.NullOrEmpty(ob, out var result); //result type same as ob (var -> Result<Guid>? if ob is guid)
```
Is Null or Empty for enumerations like lists etc.
```csharp
RGuard.Is.NullOrEmpty(ob, out Result<bool>? result); //different result type
RGuard.Is.NullOrEmpty(ob, out var result); //result type similar as ob (var -> Result<IEnumerable<T>>)
```
Is Null or Whitespace for strings
```csharp
RGuard.Is.NullOrWhiteSpace(ob, out Result<bool>? result); //different result type
RGuard.Is.NullOrWhiteSpace(ob, out var result); //result type same as ob
```
Is Null or Predicate is true
Predicates also have standalone methods without the NullOr
```csharp
RGuard.Is.NullOrPredicate(ob, (o) => ob.IsWrong, out Result<string>? result); //different result type
RGuard.Is.NullOrPredicate(ob, (o) => ob.IsWrong, out var result); //result type same as ob
```
Is Null or Async Predicate is true (Async methods cant have out parameters).
Predicates also have standalone methods without the NullOr
```csharp
(bool isMatched, Result<string>? result) = await RGuard.Is.NullOrPredicateAsync<object, string>(ob, async (o) => {
    await Task.Delay(2);
    return true;
});
(bool isMatched, Result<object>? result) = await RGuard.Is.NullOrPredicateAsync(ob, async (o) => {
    await Task.Delay(2);
    return true;
});
```
### Number checks
Is number negative
```csharp
RGuard.Is.Negative(number, out Result<object>? result); //different result type
RGuard.Is.Negative(number, out var result); //result type same as ob (some number type like long etc)
```
Is number zero
```csharp
RGuard.Is.Zero(number, out Result<object>? result); //different result type
RGuard.Is.Zero(number, out var result); //result type same as ob (some number type like long etc)
```
Is number zero or negative
```csharp
RGuard.Is.NegativeOrZero(number, out Result<object>? result); //different result type
RGuard.Is.NegativeOrZero(number, out var result); //result type same as ob (some number type like long etc)
```
### Out of range checks
Inputs must implement IEquatable<T> for NotEqual/Equal, IComparable<T> for Greater/Less etc.
Input is not equal something else
```csharp
RGuard.Is.NotEqual(a, b, out Result<object>? result); //different result type
RGuard.Is.NotEqual(a, b, out var result); //result type same as a/b
```
Input is equal to something else
```csharp
RGuard.Is.Equal(a, b, out Result<object>? result); //different result type
RGuard.Is.Equal(a, b, out var result); //result type same as a/b
```
Input is greater than something else
```csharp
RGuard.Is.GreaterThan(a, b, out Result<object>? result); //different result type
RGuard.Is.GreaterThan(a, b, out var result); //result type same as a/b
```
Input is greater than or equal something else
```csharp
RGuard.Is.GreaterThanOrEqual(a, b, out Result<object>? result); //different result type
RGuard.Is.GreaterThanOrEqual(a, b, out var result); //result type same as a/b
```
Input is less than something else
```csharp
RGuard.Is.LessThan(a, b, out Result<object>? result); //different result type
RGuard.Is.LessThan(a, b, out var result); //result type same as a/b
```
Input is less than or equal something else
```csharp
RGuard.Is.LessThanOrEqual(a, b, out Result<object>? result); //different result type
RGuard.Is.LessThanOrEqual(a, b, out var result); //result type same as a/b
```
