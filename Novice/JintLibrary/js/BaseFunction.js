(function () {
    var fnTest = function (config) {
        var someNum = 10;
        return { "isSuccess": fnSum(config.someValue, someNum) > 10 };
    };

    return {
        fnTest: fnTest
    };
})();