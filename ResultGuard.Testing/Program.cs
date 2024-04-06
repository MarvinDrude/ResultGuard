
using ResultGuard;

Func<string?, Result<string>> simpleUsageToLower = (string? parameter) => {

    if(RGuard.Is.Null(parameter, out var error)) {
        return error;
    }

    return parameter.ToLowerInvariant();

};

Func<string?, Result<MoreUsageToLower>> moreUsageToLower = (string? parameter) => {

    if(RGuard.Is.NullOrEmpty(parameter, out Result<MoreUsageToLower>? error)) {
        return error;
    }

    return new MoreUsageToLower() {
        Result = parameter.ToLowerInvariant(),
    };

};

var resToLower = simpleUsageToLower("AddsSATG");
var resToLowerMore = moreUsageToLower("");

Console.ReadLine();


class MoreUsageToLower {

    public required string Result { get; set; }

}