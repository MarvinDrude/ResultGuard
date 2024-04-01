
using ResultGuard;

Func<string?, Result<string>> simpleUsageToLower = (string? parameter) => {

    if(RGuard.Is.Null(parameter, out var error)) {
        return error;
    }

    return parameter.ToLowerInvariant();

};



var resToLower = simpleUsageToLower("AddsSATG");

Console.ReadLine();
