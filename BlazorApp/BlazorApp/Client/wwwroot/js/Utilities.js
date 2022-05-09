function DotNetStaticMethodTest() {
    DotNet.invokeMethodAsync("BlazorApp.Client", "GetCurrentCount")
        .then(result => {
            console.log("Current count from javascript is " + result);
        });
}

function DotNetInstanceMethodTest(dotNetHelper) {
    dotNetHelper.invokeMethodAsync("IncrementCount");
}