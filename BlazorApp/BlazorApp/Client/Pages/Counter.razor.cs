using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Client.Pages
{
    public partial class Counter
    {
        [Inject]
        ServicesSingleton singleton { get; set; }
        [Inject]
        ServicesTransient transient { get; set; }
        [Inject] IJSRuntime js { get; set; }

        IJSObjectReference module;

        private int currentCount = 0;
        private static int correntCountStatic = 0;
        private async Task IncrementCountFromJavascript()
        {
            await js.InvokeVoidAsync("DotNetInstanceMethodTest",DotNetObjectReference.Create(this)); //crea una referencia del objeto del punto net que púede ser usada por js instanciade counther this
        }

        [JSInvokable]
        public async Task IncrementCount()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import","./js/Counter.js"); //estamos referenciando con counter module dependiente d ela referencia de js e guardamos la rederencia del archivo y ahora si los invocamos
            await module.InvokeVoidAsync("showAlert", "Hello World");


            currentCount++;
            correntCountStatic = currentCount;
            await js.InvokeVoidAsync("DotNetStaticMethodTest");
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(correntCountStatic);
        }
    }
}
