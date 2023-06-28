using System.Collections.Generic;
using System.Diagnostics;

namespace Core
{
    public class AbstractGameEvents<T, TypeImpl> where TypeImpl : AbstractGameEvents<T, TypeImpl>, new()
    {
        private Dictionary<T, List<System.Action<BaseEventParams>>> eventActions;

        public AbstractGameEvents()
        {
            eventActions = new Dictionary<T, List<System.Action<BaseEventParams>>>();
        }

        #region Public methods
        public void LaunchEvent(T eventType, BaseEventParams parameters = null)
        {
            int i;
            if (eventActions.ContainsKey(eventType))
            {
                //Not the best, bust fast solution for situation then action remove itself from event right after execution
                System.Action<BaseEventParams>[] actions = eventActions[eventType].ToArray();
//                UnityEngine.Debug.Log($"event core count: {actions.Length}, of type : {eventType.ToString()}");
                for (i = 0; i < actions.Length; i++)
                {
                    actions[i](parameters);
                }
            }
        }

        public void LaunchEvent<T1>(T eventType, T1 parameter)
        {
            int i;
            if (eventActions.ContainsKey(eventType))
            {
                //Not the best, bust fast solution for situation then action remove itself from event right after execution
                System.Action<BaseEventParams>[] actions = eventActions[eventType].ToArray();
                for (i = 0; i < actions.Length; i++)
                {
                    actions[i](new EventParameterWithSingleValue<T1>(parameter));
                }
            }
        }

        public void LaunchEvent<T1, T2>(T eventType, T1 parameter1, T2 parametere2)
        {
            int i;
            if (eventActions.ContainsKey(eventType))
            {
                //Not the best, bust fast solution for situation then action remove itself from event right after execution
                System.Action<BaseEventParams>[] actions = eventActions[eventType].ToArray();
                for (i = 0; i < actions.Length; i++)
                {
                    actions[i](new EventParameterWithTwoValues<T1, T2>(parameter1, parametere2));
                }
            }
        }


        public void AddListenerToEvent(T eventType, System.Action<BaseEventParams> listener)
        {
            if (eventActions.ContainsKey(eventType))
            {
                eventActions[eventType].Add(listener);
                // Debug.Log(eventType+"  "+ eventActions[ eventType ].Count );
            }
            else
            {
                eventActions.Add(eventType, new List<System.Action<BaseEventParams>>() { listener });
            }
        }

        public void RemoveListenerFromEvent(T eventType, System.Action<BaseEventParams> listener)
        {
            //Debug.Log( eventType + " Removed" );
            if (eventActions.ContainsKey(eventType))
            {
                eventActions[eventType].Remove(listener);
            }
        }

        public void ClearAllListenersForEvent(T eventType)
        {
            if (eventActions.ContainsKey(eventType))
            {
                eventActions[eventType].Clear();
            }
        }

        public void ClearAllListenersForEvents()
        {
            eventActions.Clear();
        }
        #endregion
    }
}

public static class EventsExtensions
{
    public static bool GetParameter<T>(this Core.BaseEventParams baseEventParams, out T result)
    {
        Core.EventParameterWithSingleValue<T> singeEventParameter = (baseEventParams as Core.EventParameterWithSingleValue<T>);
        result = default(T);
        if (singeEventParameter != null)
        {
            result = singeEventParameter.eventParameter;
            return true;
        }
        return false;
    }

    public static T GetParameterSafe<T>(this Core.BaseEventParams baseEventParams)
    {
        Core.EventParameterWithSingleValue<T> singeEventParameter = (baseEventParams as Core.EventParameterWithSingleValue<T>);
        return singeEventParameter == null ? default(T) : singeEventParameter.eventParameter;
    }

    public static T GetParameterUnSafe<T>(this Core.BaseEventParams baseEventParams)
    {
        return (baseEventParams as Core.EventParameterWithSingleValue<T>).eventParameter;
    }
}

