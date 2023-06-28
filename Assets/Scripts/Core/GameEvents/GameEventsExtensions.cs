
namespace Core.Events
{
	public static class GameEventsExtensions 
	{
		/// <summary>
		/// Use this function if you certain that BaseEventParams is SingleEventParameter<T>
		/// </summary>
		public static T GetParameter<T>(this BaseEventParams eventParameter)
		{
			return ( eventParameter as EventParameterWithSingleValue<T> ).eventParameter;
		}

		public static T GetParameterSafe<T>(this BaseEventParams eventParameter)
		{
			EventParameterWithSingleValue<T> eventWithSingeParam = eventParameter as EventParameterWithSingleValue<T>;
			return eventWithSingeParam == null ? default( T ) : eventWithSingeParam.eventParameter;
		}
	}
}
