using UnityEngine;

namespace Core
{
	public enum EBattleEvent
	{
		ENEMY_DEAD,
        PAUSE,
        LEVEL_COMPLETED,
        LOW_HEALTH,
        LOW_MANA,
        POTION_USE,
        ON_ITEM_PICKED_BY_PLAYER,
        ENEMY_WAVE_SPAWNED,
        SPELL_USE,
        ENEMY_50_PERCENT_HEALTH,
        GEM_SPAWN,
        CONTINUE_GAME_USED
    }

	public class BattleEventsMono : MonoBehaviour
	{
		private BattleEvents battleEvents;

		private static BattleEventsMono current;
		public static BattleEvents BattleEvents
		{
			get {

				if( current == null )
				{
					current = new GameObject( "BattleEventsMono" ).AddComponent<BattleEventsMono>();
					current.battleEvents = new BattleEvents();
				}
				return current.battleEvents;
			}
		}
	}

	public class BattleEvents : AbstractGameEvents<EBattleEvent, BattleEvents>
	{

	}
}

