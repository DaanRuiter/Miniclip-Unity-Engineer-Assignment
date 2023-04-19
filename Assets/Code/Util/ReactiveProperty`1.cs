using System;

namespace Miniclip.Util
{
    public class ReactiveProperty<T>
    {
        public event Action<T> ValueUpdatedEvent;

        private T _value;

        public T Value
        {
            get => _value;
            set => SetValue(value);
        }

        public ReactiveProperty(T startingValue)
        {
            _value = startingValue;
        }

        public void SetValue(T value, bool forceNotify = false)
        {
            if(!forceNotify && Equals(value, _value))
            {
                return;
            }
            
            _value = value;

            ValueUpdatedEvent?.Invoke(value);
        }

        public static explicit operator T(ReactiveProperty<T> property) => property.Value;
    }
}