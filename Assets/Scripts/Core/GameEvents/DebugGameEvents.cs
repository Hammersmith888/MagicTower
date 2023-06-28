using UnityEngine;

#if DEBUG_MODE
namespace Core
{
	public class DebugGameEventsMono : MonoBehaviour
	{
		private DebugGameEvents gameEvents;

		private static DebugGameEventsMono current;

		public static DebugGameEvents DebugEvents
		{
			get {
				if( current == null )
				{
					current = new GameObject( "DebugGameEventsMono" ).AddComponent<DebugGameEventsMono>();
					current.gameEvents = new DebugGameEvents();
				}
				return current.gameEvents;
			}
		}
	}

	public class DebugGameEvents : AbstractGameEvents<DebugGameEvents.EDebugEvent, DebugGameEvents>
	{
		public enum EDebugEvent
		{
			MAP_COMPLETE_LVL
		}
	}
}
#endif
