using CVTheque.Client.Helpers;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVTheque.Client.Services.JS
{
    public class JsAlertifyService : IJsAlertifyService
    {
        private readonly IJSRuntime _JsRuntime;

        public JsAlertifyService(IJSRuntime jsRuntime)
        {
            _JsRuntime = jsRuntime;
        }
        public async Task open(string message, TypeAlertify type)
        {
            switch(type)
            {
                case TypeAlertify.Succes:
                    await _JsRuntime.InvokeAsync<bool>("alertify", message, "Success", 5);
                    break;
                case TypeAlertify.Error:
                    await _JsRuntime.InvokeAsync<bool>("alertify", message, "Error", 5);
                    break;
                case TypeAlertify.Warning:
                    await _JsRuntime.InvokeAsync<bool>("alertify", message, "Warning", 5);
                    break;
                default:
                    await _JsRuntime.InvokeAsync<bool>("alertify", message, "Default", 5);
                    break;
            }
        }
    }
}
