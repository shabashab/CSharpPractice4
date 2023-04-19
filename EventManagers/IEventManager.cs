using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice4.EventManagers
{
    internal interface IEventManager<TPayload>
    {
        event EventHandler<TPayload> OnEvent;
        void Emit(TPayload payload);
    }
}
