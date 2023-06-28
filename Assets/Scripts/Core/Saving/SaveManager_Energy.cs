
using UnityEngine;
public partial class SaveManager
{
    [System.Serializable]
    public class Energy
    {
        public int MaxEnergy => LMConfig.BASIC_LIFE_SLOTS;

        [SerializeField]
        private int energyCharged; // Количество заряженных энергий
        public float timeStumpOnStartCharge; // Стартовое время, с которого начался заряд текущей энергии

        public int EnergyCharged => energyCharged;

        public bool IsFull => energyCharged == MaxEnergy;
        public bool IsEmty => energyCharged == 0;

        private static Energy m_Current;
        public static Energy Current
        {
            get
            {
                EnsureDataExists();
                return m_Current;
            }
        }

        private static void EnsureDataExists()
        {
            if (m_Current == null)
            {
                m_Current = PPSerialization.Load<Energy>(EPrefsKeys.Energy.ToString());
                if (m_Current == null)
                {
                    m_Current = new Energy();
                    m_Current.energyCharged = 5;
                    PPSerialization.Save(EPrefsKeys.Energy, m_Current);
                }
            }
        }

        public static void Validate()
        {
            EnsureDataExists();
        }

        public static void ForceReload()
        {
            m_Current = null;
            EnsureDataExists();
        }

        public void Change(int amount, bool saveToCloud =false)
        {
            energyCharged += amount;
            energyCharged = Mathf.Clamp(energyCharged, 0, MaxEnergy);
            Save(saveToCloud);
        }

        public void Save(bool toCloud)
        {
            PPSerialization.Save(EPrefsKeys.Energy, m_Current, toCloud);
        }
    }
}
