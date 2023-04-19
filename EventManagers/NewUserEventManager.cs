using CSharpPractice3.Models;
using System;

namespace CSharpPractice4.EventManagers
{
    internal class NewUserEventManager : IEventManager<User>
    {
        public static NewUserEventManager Instance { get; } = new NewUserEventManager();

        private NewUserEventManager()
        {}

        public event EventHandler<User>? OnEvent;

        public void Emit(User payload)
        {
            OnEvent?.Invoke(this, payload); }
    }
}
