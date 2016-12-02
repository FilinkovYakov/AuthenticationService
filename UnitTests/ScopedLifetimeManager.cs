using System;
using Microsoft.Practices.Unity;

namespace UnitTests
{
    class ScopedLifetimeManager : LifetimeManager, IDisposable
    {
        private object _value;
        public void Dispose()
        {
            RemoveValue();
        }

        public override object GetValue()
        {
            return _value;
        }

        public override void RemoveValue()
        {
            _value = null;
        }

        public override void SetValue(object newValue)
        {
            _value = newValue;
        }
    }
}
