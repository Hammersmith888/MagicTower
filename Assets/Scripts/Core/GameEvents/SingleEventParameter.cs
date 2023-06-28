namespace Core
{
    public class EventParameterWithSingleValue<T> : BaseEventParams
    {
        public T eventParameter
        {
            get; protected set;
        }
        public EventParameterWithSingleValue(T _eventParameter)
        {
            eventParameter = _eventParameter;
        }

        public override string ToString()
        {
            return string.Format("Value1: {0}", eventParameter);
        }
    }

    public class EventParameterWithTwoValues<T, T1> : BaseEventParams
    {
        public T value1
        {
            get; protected set;
        }

        public T1 value2
        {
            get; protected set;
        }

        public EventParameterWithTwoValues(T _value1, T1 _value2)
        {
            value1 = _value1;
            value2 = _value2;
        }

        public override string ToString()
        {
            return string.Format("Value1: {0} Value2: {1}", value1, value2);
        }
    }
}