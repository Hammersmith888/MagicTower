namespace Core
{
    public enum EShopGameEvent
    {
        SPELL_UNLOCKED, SPELL_UPGRADED, POTION_BOUGHT, POTION_UPGRADED, BONUS_BOUGHT
    }

    public class ShopGameEvents : AbstractGameEvents<EShopGameEvent, ShopGameEvents>
    {
        private static ShopGameEvents _instance;
        public static ShopGameEvents Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ShopGameEvents();
                }
                return _instance;
            }
        }
    }
}
