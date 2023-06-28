using System.Collections;
using System.Collections.Generic;
using Tutorials;
using UnityEngine;
using UnityEngine.UI;

public class ShotController : MonoBehaviour
{
    #region VARIABLES
    public Spell[] spells; // Массив заклинаний
    private Spell activeSpell; // Активное заклинание
    public Spell ActiveSpell
    {
        get
        {
            return activeSpell;
        }

        set
        {
            activeSpell = value;
        }
    }

    [SerializeField]
    private Animator mageAnimator; // Маг, для включении анимации выстрела
    [SerializeField]
    private Transform startPos; // Начальная точка для выстрела
    [SerializeField]
    private GameObject activeGlow; // Подсветка активного заклинания
    [SerializeField]
    private UILowMana lowManaText;

    private Vector2 boundariesX = new Vector2(-4.5f, 8.5f), boundariesY = new Vector2(-3f, 2.5f); // Ограничения области нажатия для заклинаний по X и Y (Молния, Цепная молния)

    private GameObject shot, shotIceBreath;
    private int typeAttack;

    private Mana mana;

    private float manaTime = 1f, manaTimer = 0;
    private bool firstFramePassed;
    private Button[] spellBtns = new Button[4]; // Компонент кнопка для каждого заклинания (для включения/выключени интерактивности)
    private float beginnerCoef = 1f;
    [SerializeField]
    private Camera uiCamera;

    private LevelSettings levelSettings;

    private static ShotController _current;

    public bool canShot = true;

    private const byte MAX_COUNT_SHOT = 70;
    private int countShot = 0;
    private int tempSpellIndex = 0;
    public bool tutorialIsViewed = false;

    private int repeatedWave = 0;
    private int tempWave = 0;
    public bool changeSpellTutorial = false;

    private GameObject Tutorials1;
    public static ShotController Current
    {
        get
        {
            if (_current == null)
            {
                _current = FindObjectOfType<ShotController>();
            }
            return _current;
        }
    }

    public float StartPositionShotX
    {
        get
        {
            return startPos.position.x;
        }
    }

    public int GetSpellIsUse()
    {
        byte num = 0;
        foreach (var btn in spellBtns)
        {
            if (btn.interactable)
            {
                num++;
            }
        }
        return num;
    }

    public GameObject GetSpellButtonObject(int index)
    {
        if (index < 4)
            return spellBtns[index].gameObject;

        return null;
    }

    public int currentSpellIndex;
    public UnityEngine.Events.UnityAction _eventIceTutorial = null;

    #endregion

    int countPlaySound = 0;
    public Dictionary<string, int> spellUse = new Dictionary<string, int>();

    public int countKillEnemy;
    public bool counttemp;

    IEnumerator Start()
    {
        Tutorials1 = GameObject.Find("TutorialMessages");
        _current = this;
        // Нулевое заклинание делаем активным и устанавливаем для него подсветку
        ActiveSpell = spells[0];
        activeGlow.transform.localPosition = ActiveSpell.glowPos;
        activeGlow.SetActive(true);
        float vipCoef = 1f;
        levelSettings = LevelSettings.Current;
        if (levelSettings.VIPenabled)
        {
            vipCoef = 1.1f;
        }
        // Для каждого заклинания устанавливаем значение таймера и рассчитываем скорость перезарядки
        if (mainscript.CurrentLvl <= 5) //int.Parse(PlayerPrefs.GetString("currentLvl"))
        {
            beginnerCoef *= 1.2f;
        }
        for (int i = 0; i < spells.Length; i++)
        {
            GetSpellPrefab(spells[i]);

            spells[i].MayShot = true;
            float buffParam = 1f;
            if (BuffsLoader.Instance != null &&
                (activeSpell.spellType == Spell.SpellType.ChainLightning || activeSpell.spellType == Spell.SpellType.Lightning
                || activeSpell.spellType == Spell.SpellType.ElecticPool))
            {
                buffParam += buffParam * BuffsLoader.Instance.GetBuffValue(BuffType.electroSpellCooldown);
            }
            spells[i].RechargeTimer = (spells[i].rechargeTime / beginnerCoef) * levelSettings.easyCoef / (vipCoef * buffParam);
            spells[i].SpeedBar = (vipCoef * buffParam) * (beginnerCoef * 1 / spells[i].rechargeTime) / levelSettings.easyCoef;
            spellBtns[i] = spells[i].spellIcon.GetComponent<Button>();
        }

        ///////
        /// 1 fire
        /// 3 strikre
        /// 6 ice strike
        /// 10 earth ball
        /// 13 firewall
        /// 16 chain lighting
        /// 21 ice breath
        /// 26 rolling stone
        /// 52 meteror
        /// 67 electrik pool
        /// 75 blizzard
        /// 80 gargulie
        ////////


        // Управление маной
        mana = GetComponent<Mana>();
        yield return new WaitForSeconds(0.1f);
        if(SaveManager.GameProgress.Current.autoActiveSpeel == null)
            SaveManager.GameProgress.Current.autoActiveSpeel = new int[12];
        else if(SaveManager.GameProgress.Current.autoActiveSpeel.Length == 0)
            SaveManager.GameProgress.Current.autoActiveSpeel = new int[12];
        if (mainscript.CurrentLvl == 7 && SaveManager.GameProgress.Current.autoActiveSpeel[2] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[2] = 1;
            SetShotIfHas(Spell.SpellType.IceStrike);
        }
        if (mainscript.CurrentLvl == 11 && SaveManager.GameProgress.Current.autoActiveSpeel[3] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[3] = 1;
            SetShotIfHas(Spell.SpellType.EarthBall);
        }
        if (mainscript.CurrentLvl == 14 && SaveManager.GameProgress.Current.autoActiveSpeel[4] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[4] = 1;
            SetShotIfHas(Spell.SpellType.FireWall);
        }
        if (mainscript.CurrentLvl == 17 && SaveManager.GameProgress.Current.autoActiveSpeel[5] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[5] = 1;
            SetShotIfHas(Spell.SpellType.ChainLightning);
        }
        if (mainscript.CurrentLvl == 22 && SaveManager.GameProgress.Current.autoActiveSpeel[6] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[6] = 1;
            SetShotIfHas(Spell.SpellType.IceBreath);
        }
        if (mainscript.CurrentLvl == 27 && SaveManager.GameProgress.Current.autoActiveSpeel[7] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[7] = 1;
            SetShotIfHas(Spell.SpellType.Boulder);
        }
        if (mainscript.CurrentLvl == 53 && SaveManager.GameProgress.Current.autoActiveSpeel[8] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[8] = 1;
            SetShotIfHas(Spell.SpellType.Meteor);
        }
        if (mainscript.CurrentLvl == 68 && SaveManager.GameProgress.Current.autoActiveSpeel[9] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[9] = 1;
            SetShotIfHas(Spell.SpellType.ElecticPool);
        }
        if (mainscript.CurrentLvl == 76 && SaveManager.GameProgress.Current.autoActiveSpeel[10] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[10] = 1;
            SetShotIfHas(Spell.SpellType.Blizzard);
        }
        if (mainscript.CurrentLvl == 81 && SaveManager.GameProgress.Current.autoActiveSpeel[11] == 0)
        {
            SaveManager.GameProgress.Current.autoActiveSpeel[11] = 1;
            SetShotIfHas(Spell.SpellType.FireDragon);
        }

        SaveManager.GameProgress.Current.Save();
    }

    void SetShotIfHas(Spell.SpellType _type)
    {
        int f = -1;
        for (int i = 0; i < spells.Length; i++)
        {
            if (spells[i].spellType == _type)
                f = i;
        }

        if (f != -1)
            SetActiveSpell(f);
    }

    public int IndexSpeelInSlot(Spell.SpellType type)
    {
        var x = -1;
        for (int i = 0; i < spells.Length; i++)
        {
            if (spells[i].spellType == type)
            {
                x = i;
                break;
            }
        }
        return x ;
    }


    public void Refresh()
    {
        StartCoroutine(Start());
    }

    public int GetCount()
    {
        int count = 0;
        foreach (var  o in spells)
        {
            if (o.spellType != Spell.SpellType.None)
                count++;
        }
        return count;
    }

    IEnumerator _KILL()
    {
        yield return new WaitForSecondsRealtime(0.2f);

        counttemp = false;
        if(countKillEnemy > 10)
            Achievement.AchievementController.Set(Achievement.AchievementController.Achievement.Multispell, 1);
        countKillEnemy = 0;
    }

    private void Update()
    {
        if(countKillEnemy > 0 && !counttemp)
        {
            StartCoroutine(_KILL());
            counttemp = true;
        }

        if (shotIceBreath == null)
            mageAnimator.SetBool(AnimationPropertiesCach.instance.iceBreathAnim, false);
        if (!changeSpellTutorial)
        {
            // Проверяем каждое заклинание, если необходимо отсчитываем таймер перезарядки
            for (int i = 0; i < spells.Length; i++)
            {
                if (!spells[i].MayShot)
                {
                    //Debug.Log($"MAY SHOT : {spells[i].SpeedBar}");
                    spells[i].RechargeTimer -= Time.deltaTime;
                    spells[i].progressBar.fillAmount -= spells[i].SpeedBar * Time.deltaTime;

                    if (spells[i].RechargeTimer <= 0)
                    {
                        spells[i].MayShot = true;
                        spells[i].RechargeTimer = spells[i].rechargeTime / (beginnerCoef);
                        spells[i].SetSpellCostActive();
                    }
                }

                // Проверка маны для всех заклинаний, если недостаточно, то затемняем иконку заклинания
                if (spells[i].manaValue > mana.CurrentValue && spellBtns[i].interactable)
                {
                    spells[i].SetSpellInActive();
                    spells[i].SetSpellCostInActive();
                }
                else
                {
                    spells[i].SetSpellActive();
                    if (spells[i].MayShot)
                    {
                        spells[i].SetSpellCostActive();
                    }
                }
            }
        }
        if (!firstFramePassed)
        {
            if (!UIBlackPatch.Current.isOuted)
            {
                return;
            }
            firstFramePassed = true;

            if (spells[1].spellType != Spell.SpellType.None)
            {
                if (Tutorials.Tutorial_1.Current != null && EndlessMode.EndlessModeManager.Current == null)
                {
                    Tutorials.Tutorial_1.Current.ShowMessage_9(1);
                }
            }
        }
    }

    public Vector3 GetSpellSlotWorldPosition(int spellIndex)
    {
        return Helpers.getMainCamera.ViewportToWorldPoint(uiCamera.WorldToViewportPoint(spells[spellIndex].spellIcon.transform.position));
    }

    void SetUse(Spell.SpellType type)
    {
        if (!spellUse.ContainsKey(type.ToString()))
            spellUse.Add(type.ToString(), 1);
        else
            spellUse[type.ToString()]++;
    }

    public void SendUsedSpell()
    {
        var keys = new List<string>(spellUse.Keys);
        var dic = new Dictionary<string, string>();

        for (int i = 0; i < keys.Count; i++)
        {
            dic.Add(keys[i], spellUse[keys[i]].ToString());    
        }
        AnalyticsController.Instance.LogMyEvent("use spell in level " + mainscript.CurrentLvl, dic);
    }

    private bool allowShotSound = true;

    public void Shot(Vector3 _dirPos)
    {
        if (!canShot)
            return;

        if (Tutorials.Tutorial_1.Current != null && mainscript.CurrentLvl != 5)
            Tutorials.Tutorial_1.Current.OnShotPerformed();


        if (!ActiveSpell.MayShot)
        {
            TryUseAvailableSpell(_dirPos);
            return;
        }

        if (CheckTutorialRules()) // Открывает туториал смены способности, если её спамить 
        {
            ChangeSkillTutorial(); 
        }

        if (ActiveSpell.MayShot && !EnoughMana(ActiveSpell.manaValue))
        {
            PotionManager.Current.AutoUsePotion(PotionManager.EPotionType.Mana);
        }


        if (ActiveSpell.MayShot && EnoughMana(ActiveSpell.manaValue))
        {
            // Случайная анимация выстрела
            typeAttack = Random.Range(0, 2);
            // Создаем заклинание
            shot = Instantiate(ActiveSpell.spellObject, startPos.position, Quaternion.identity) as GameObject;
            // Переводим нажатие в WorldPoint координаты и ограничиваем поле нажатия
            _dirPos = Helpers.getMainCamera.ScreenToWorldPoint(_dirPos);
            switch (ActiveSpell.spellType)
            {
                case Spell.SpellType.FireBall:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.FireBall);
                    shot.GetComponent<FireShot>().Activation(_dirPos);
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playFireBallSFX();
                    }
                    break;
                case Spell.SpellType.Lightning:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.Lightning);
                    _dirPos = new Vector3(Mathf.Clamp(_dirPos.x, boundariesX.x, boundariesX.y), Mathf.Clamp(_dirPos.y, boundariesY.x, boundariesY.y), 0f); // Ограничиваем поле нажатия
                    shot.GetComponent<LightningShot>().Activation(_dirPos);
                    mageAnimator.SetTrigger(AnimationPropertiesCach.instance.undirectedAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playlightningSFX();
                    }
                    break;
                case Spell.SpellType.IceStrike:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.IceStrike);
                    shot.GetComponent<IceStrikeShot>().Activation(_dirPos);
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playIceStrikeSFX();
                    }
                    break;
                case Spell.SpellType.Boulder:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.Boulder);
                    shot.GetComponent<BowlderShot>().Activation(_dirPos);
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playStoneBallSFX();
                    }
                    break; 
                case Spell.SpellType.FireWall:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.FireWall);
                    shot.GetComponent<FireWallShot>().Activation(_dirPos);
                    mageAnimator.SetTrigger(AnimationPropertiesCach.instance.undirectedAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playFireWallSFX();
                    }
                    break;
                case Spell.SpellType.ChainLightning:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.ChainLightning);
                    _dirPos = new Vector3(Mathf.Clamp(_dirPos.x, boundariesX.x, boundariesX.y), Mathf.Clamp(_dirPos.y, boundariesY.x, boundariesY.y), 0f); // Ограничиваем поле нажатия
                    shot.GetComponent<ChainLightningShot>().Activation(_dirPos);
                    mageAnimator.SetTrigger(AnimationPropertiesCach.instance.undirectedAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playChainLightningSFX();
                    }
                    break;
                case Spell.SpellType.AcidSpray_Unused:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.AcidSpray_Unused);
                    shot.GetComponent<AcidSprayShot>().Activation(startPos.position, _dirPos);
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playAcidSpraySFX();
                    }
                    break;
                case Spell.SpellType.Meteor:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.Meteor);
                    shot.GetComponent<MeteorSpell>().Activation(_dirPos);
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playAcidSpraySFX();
                    }
                    break;
                case Spell.SpellType.ElecticPool:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.ElecticPool);
                    shot.GetComponent<ElectricPoolSpell>().Activation(_dirPos);
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playAcidSpraySFX();
                    }
                    break;
                case Spell.SpellType.Blizzard:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.Blizzard);
                    shot.GetComponent<BlizzardSpell>().Activation(_dirPos);//new Vector3(1.51f,0,0) );
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playAcidSpraySFX();
                    }
                    break;
                case Spell.SpellType.FireDragon:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.FireDragon);
                    shot.GetComponent<FireDragonSpell>().Activation(_dirPos);
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playAcidSpraySFX();
                    }
                    break;
                case Spell.SpellType.EarthBall:
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.EarthBall);
                    shot.GetComponent<EarthShot>().Activation(_dirPos);
                    mageAnimator.SetTrigger((typeAttack == 0) ? AnimationPropertiesCach.instance.attackOneAnim : AnimationPropertiesCach.instance.attackTwoAnim); // Анимация выстрела
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playEarthBallSFX();
                    }
                    break;
                case Spell.SpellType.IceBreath:
                    shotIceBreath = shot;
                    Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.SPELL_USE, Spell.SpellType.IceBreath);
                    mageAnimator.SetBool(AnimationPropertiesCach.instance.iceBreathAnim, true);
                    if (allowShotSound)
                    {
                        StartCoroutine(AllowFireSound());
                        SoundController.Instanse.playIceBreathSFX();
                    }
                    break;
            }
            // Запускаем прогресс бар
            ActiveSpell.progressBar.fillAmount = 1;
            ActiveSpell.MayShot = false;
            ActiveSpell.SetSpellCostInActive();
            // Вычитаем необходимое количество маны
            mana.SpendMana(ActiveSpell.manaValue);
            SetUse(ActiveSpell.spellType);
        }
        else if (!EnoughMana(ActiveSpell.manaValue))
        {
            lowManaText.ShowLowMana();
        }
    }

    private IEnumerator AllowFireSound()
    {
        allowShotSound = false;
        yield return new WaitForSecondsRealtime(0.5f);
        allowShotSound = true;
    }


    #region SpellClickTutorial

    private void ChangeSkillTutorial() 
    {
        if (tempSpellIndex == currentSpellIndex)
        {
            countShot++;
            if (countShot >= MAX_COUNT_SHOT && CheckWave())
            {
                StartCoroutine(Tutorials.Tutorial_1.Current.ChangeSpellTutorialClickCoroutine());
            }
        }
        else
        {
            tempSpellIndex = currentSpellIndex;
            repeatedWave = 0;
            countShot = 0;
        }
    }

    private bool CheckTutorialRules()
    {
        return !tutorialIsViewed && mainscript.CurrentLvl >= 4 && !TutorialsManager.IsAnyTutorialActive;
    }
    private bool CheckWave()
    {
        if (tempWave < EnemiesGenerator.Instance.currentWave)
        {
            tempWave = EnemiesGenerator.Instance.currentWave;
            repeatedWave++;
        }

        return repeatedWave > 2;
    }

    #endregion

    // Установка активного заклинания в зависимости от номера кнопки выбора заклинания
    public void SetActiveSpell(int _spellBtn)
    {
        for (int i = 0; i < spells.Length; i++)
        {
            if (i == _spellBtn)
            {
                ActiveSpell = spells[i];
                currentSpellIndex = i;
                activeGlow.transform.localPosition = ActiveSpell.glowPos;
                break;
            }
        }
    }

    // Проверяем, достаточно ли маны?
    private bool EnoughMana(int _spellManaValue)
    {
        if (mana.CurrentValue > _spellManaValue)
        {
            return true;
        }
        else
        {
            Core.BattleEventsMono.BattleEvents.LaunchEvent(Core.EBattleEvent.LOW_MANA);
            return false;
        }
    }

    // Загружаем префаб заклинания и кэшируем для него значение времени перезарядки и количество маны
    private void GetSpellPrefab(Spell spell)
    {
        if (spell.spellType == Spell.SpellType.None)
        {
            return;
        }
        spell.spellObject = Resources.Load(GetSpellPrefabPath(spell.spellType), typeof(GameObject)) as GameObject;
        SpellBase spellBase = spell.spellObject.GetComponent<SpellBase>();
        MyGSFU.current.SetSpellParameters(spell.spellType, spellBase, levelSettings.GetSpellLevel(spell.spellType));
        spell.spellIcon.sprite = spellBase.icon;
        spell.rechargeTime = spellBase.rechargeTime;
        spell.manaValue = spellBase.manaValue;
        spell.timeOfSecondEffect = spellBase.timeOfSecondEffect;
        
        // Устанавливаем стоимость заклинания
        spell.manaText.text = spell.manaValue.ToString();
    }

    // Возвращет имя префаба, в зависимости от его уровня апгрэйда
    private string GetSpellPrefabPath(Spell.SpellType spellType)
    {
        var spellPrefabPathFormat = SpellInfoUtils.GetSpellPrefabPathFormat(spellType);
        var spellLevel = levelSettings.GetSpellLevel(spellType);
        var spellPrefabIndexBySpellLevel = (int)(spellLevel / 2f) + 1;
       // Debug.LogFormat("{0} {1} {2}", spellType, spellLevel, spellPrefabIndexBySpellLevel);
        return string.Format(spellPrefabPathFormat, spellPrefabIndexBySpellLevel);
    }

   
    public void SetManaHasteView(bool on)
    {
        mana.SetManaHasteView(on);
    }

    private void TryUseAvailableSpell(Vector3 touchPos)
    {
        if (LevelPlayerHelpersLoader.Current == null || !LevelPlayerHelpersLoader.Current.spellUse)
        {
            return;
        }

        int activeSpellId = 0;
        for (int i = 0; i < spells.Length; i++)
        {
            if (ActiveSpell == spells[i])
            {
                activeSpellId = i;
                break;
            }
        }

        int breakCounter = 4;
        bool isAnyReadySpell = false;

        while (breakCounter > 0)
        {
            activeSpellId++;

            if (activeSpellId >= spells.Length || spells[activeSpellId].spellType == Spell.SpellType.None || spells[activeSpellId] == null)
            {
                activeSpellId = 0;
            }

            if (spells[activeSpellId].MayShot && LevelPlayerHelpersLoader.Current.usedSlot[activeSpellId])
            {
                isAnyReadySpell = true;
                Debug.Log($"auto speel check: {activeSpellId}");
                SetActiveSpell(activeSpellId);
                break;
            }

            breakCounter--;
        }

        if (!isAnyReadySpell)
        {
            return;
        }

        Shot(touchPos);
    }
}
