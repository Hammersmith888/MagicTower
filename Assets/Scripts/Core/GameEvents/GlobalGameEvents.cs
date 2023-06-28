namespace Core
{
	public enum EGlobalGameEvent
	{
		RESOLUTION_CHANGE, TUTORIAL_START
	}

	public class GlobalGameEvents : AbstractGameEvents<EGlobalGameEvent, GlobalGameEvents>
	{
		private static GlobalGameEvents _instance;
		public static GlobalGameEvents Instance
		{
			get {
				if( _instance == null )
				{
					_instance = new GlobalGameEvents();
				}
				return _instance;
			}
		}
	}

}
