using CVTheque.Client.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVTheque.Client.Services.JS
{
    public interface IJsAlertifyService
    {
        Task open(string message, TypeAlertify type);
    }
}
