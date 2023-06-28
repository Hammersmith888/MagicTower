using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpellEffects : MonoBehaviour
{
    public class Effect
    {
        public enum EffectTypes
        {
            Paralysis, FireBurn, Freezing, Slowdown, IceSlowdown, IceBurn, PoisonBurn, EarthSlowdown, EarthBurn
        }

        public enum DamageType
        {
            Electric, Fire, Water, Poison, Earth
        }

        public bool CompareDamageType(DamageType damageType)
        {
            if (damageType == DamageType.Electric)
            {
                if (type == EffectTypes.Paralysis)
                    return true;
            }
            else if (damageType == DamageType.Fire)
            {
                if (type == EffectTypes.FireBurn)
                    return true;
            }
            else if (damageType == DamageType.Water)
            {
                if (type == EffectTypes.Freezing || type == EffectTypes.IceSlowdown || type == EffectTypes.IceBurn)
                    return true;
            }
            else if (damageType == DamageType.Poison)
            {
                if (type == EffectTypes.PoisonBurn)
                    return true;
            }
            else if (damageType == DamageType.Earth)
            {
                if (type == EffectTypes.EarthSlowdown || type == EffectTypes.EarthBurn)
                    return true;
            }

            return false;
        }

        public EffectTypes type;
        public float value = 1.0f;
        public float appliedTime;
        public float duration;
    }

    List<Effect> effects = new List<Effect>(); // Эффекты которые применены для персонажа в данный момент

    private EnemyCharacter enemyCharacter;

    private GameObject fireEffectObject;
    private GameObject iceEffectObject;
    private GameObject acidEffectObject;
    private GameObject electricEffectObject;
    private GameObject earthEffectObject;

    private static GameObject fireEffectPrefab;
    private static GameObject iceEffectPrefab;
    private static GameObject acidEffectPrefab;
    private static GameObject electricEffectPrefab;
    private static GameObject earthEffectPrefab;

    private float tempResist = 0;
    private bool isFirstBossFreeze = true;
    public void Init(EnemyCharacter enemyCharacter)
    {
        this.enemyCharacter = enemyCharacter;

        ColorizedMeshes = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer skin in ColorizedMeshes)
        {
            if (skin.sharedMaterial != null)
            {
                Colors.Add(skin.sharedMaterial.color);
            }
        }

        for (int i = 0; i < enemyCharacter.lowHealthDisableObjs.Count; i++)
        {
            MeshRenderer tempMesh = enemyCharacter.lowHealthDisableObjs[i].GetComponent<MeshRenderer>();
            if (tempMesh != null)
            {
                Colors.Add(tempMesh.sharedMaterial.color);
            }
        }

        if (fireEffectPrefab == null)
        {
            fireEffectPrefab = Resources.Load("Effects/FireEffect") as GameObject;
            iceEffectPrefab = Resources.Load("Effects/IceEffect") as GameObject;
            acidEffectPrefab = Resources.Load("Effects/AcidEffect") as GameObject;
            electricEffectPrefab = Resources.Load("Effects/ElectricEffect") as GameObject;
            earthEffectPrefab = Resources.Load("Effects/EarthEffect") as GameObject;
        }
    }

    public bool FreezedOrParalysed
    {
        get
        {
            return IsEffectApplyed(Effect.EffectTypes.Freezing) || IsEffectApplyed(Effect.EffectTypes.Paralysis);
        }
    }

    public bool IsEffectApplyed(Effect.EffectTypes effectType)
    {
        int count = effects.Count;
        for (int i = 0; i < count; i++)
        {
            if (effects[i].type == effectType)
            {
                return true;
            }
        }
        return false;
    }

    public float GetSlowdownValue()
    {
        float result = 1.0f;
        for (int i = 0; i < effects.Count; i++)
        {
            if (effects[i].type == Effect.EffectTypes.Slowdown || effects[i].type == Effect.EffectTypes.IceSlowdown || effects[i].type == Effect.EffectTypes.EarthSlowdown)
            {
                result = Mathf.Min(result, effects[i].value);
            }
        }

        return result;
    }

    private float CheckBossResist(float duration) // Проверка босса на резист к заморозке
    {
        if (!isFirstBossFreeze)
            duration = Mathf.Clamp(tempResist / 2, 0.1f, duration);
        else
            isFirstBossFreeze = false;

            tempResist = duration;
        return duration;
    }

    private bool IsBoss() // Узнаем босс ли это
    {
        if (enemyCharacter.enemyType == EnemyType.zombie_boss ||
            enemyCharacter.enemyType == EnemyType.ghoul_boss ||
            enemyCharacter.enemyType == EnemyType.demon_boss ||
            enemyCharacter.enemyType == EnemyType.burned_king ||
            enemyCharacter.enemyType == EnemyType.skeleton_king)
                return true;

        return false; 
    }

    private float CheckTypeEffect(Effect.EffectTypes type, float duration) // Режем эффект заморозки и шока у боссов 
    {
        if (type == Effect.EffectTypes.Freezing || type == Effect.EffectTypes.Paralysis)
        {
            return CheckBossResist(duration);
        }
        return duration;
    }

    public void AddEffect(Effect.EffectTypes type, float duration, float value = 1.0f, bool force = false, bool isSpell = false)
    {
        if (!IsCharacterAvailableForEffects())
            return;

        if (enemyCharacter.IsJumping)
            return;

        if (enemyCharacter.enemyType == EnemyType.demon_boss && (type == Effect.EffectTypes.Freezing || type == Effect.EffectTypes.Paralysis || type == Effect.EffectTypes.Slowdown))
        {
            if (enemyCharacter.currentHealth < enemyCharacter.health / 3)
                return;
        }

        Effect effect = new Effect();
        effect.type = type;
        effect.appliedTime = Time.time;
        effect.duration = (IsBoss() && isSpell) ? CheckTypeEffect(type, duration) : duration;
        effect.value = value;

        if (type == Effect.EffectTypes.Freezing)
        {
            if (BuffsLoader.Instance != null)
                effect.duration *= (1.0f + BuffsLoader.Instance.GetBuffValue(BuffType.frozenTime));
        }

        if (type == Effect.EffectTypes.Freezing || type == Effect.EffectTypes.Paralysis)
        {
            if (enemyCharacter.indexFreeze != 0)
                effect.duration /= enemyCharacter.indexFreeze;
        }

        if (type == Effect.EffectTypes.FireBurn || type == Effect.EffectTypes.IceBurn || type == Effect.EffectTypes.EarthBurn || type == Effect.EffectTypes.PoisonBurn)
        {
            if (BuffsLoader.Instance != null)
                effect.duration *= (1.0f + BuffsLoader.Instance.GetBuffValue(BuffType.burnTime));
        }

        if (type == Effect.EffectTypes.Slowdown || type == Effect.EffectTypes.IceSlowdown || type == Effect.EffectTypes.EarthSlowdown)
        {
            effect.value *= 0.01f;
        }

        bool damageTypesConflicted = false;
        if (effect.CompareDamageType(Effect.DamageType.Earth))
        {
            if (HasEffectWithDamageType(Effect.DamageType.Fire))
            {
                RemoveAllEffectsByDamageType(Effect.DamageType.Fire);
                damageTypesConflicted = true;
            }
        }
        else if (effect.CompareDamageType(Effect.DamageType.Water))
        {
            if (HasEffectWithDamageType(Effect.DamageType.Fire))
            {
                RemoveAllEffectsByDamageType(Effect.DamageType.Fire);
                damageTypesConflicted = true;
            }
        }
        else if (effect.CompareDamageType(Effect.DamageType.Fire))
        {
            if (HasEffectWithDamageType(Effect.DamageType.Water))
            {
                RemoveAllEffectsByDamageType(Effect.DamageType.Water);
                damageTypesConflicted = true;
            }
            if (HasEffectWithDamageType(Effect.DamageType.Earth))
            {
                RemoveAllEffectsByDamageType(Effect.DamageType.Earth);
                damageTypesConflicted = true;
            }
        }

        if (damageTypesConflicted && !force)
            return;

        effects.Add(effect);
    }

    private bool HasEffectWithDamageType(Effect.DamageType damageType)
    {
        foreach (Effect effect in effects)
        {
            if (effect.CompareDamageType(damageType))
                return true;
        }

        return false;
    }

    private void RemoveAllEffectsByDamageType(Effect.DamageType damageType)
    {
        int effectsCount = effects.Count;
        for (int i = effectsCount - 1; i >= 0; i--)
        {
            if (effects[i].CompareDamageType(damageType))
                effects.RemoveAt(i);
        }
    }

    private void Start()
    {
        StartCoroutine(BurnCoroutine());
    }

    private void Update()
    {
        if (!IsCharacterAvailableForEffects())
            effects.Clear();

        int effectsCount = effects.Count;
        for (int i = effectsCount - 1; i >= 0; i--)
        {
            if (Time.time - effects[i].appliedTime > effects[i].duration)
                effects.RemoveAt(i);
        }
    }

    private void LateUpdate()
    {
        UpdateVisualObjects();
    }

    private bool IsCharacterAvailableForEffects()
    {
        if (enemyCharacter == null)
            return false;
        if (enemyCharacter.IsDead || enemyCharacter.IsDeadBeforeSpawn)
            return false;
        if (enemyCharacter.burnedKing != null && enemyCharacter.burnedKing.enraged)
            return false;

        return true;
    }

    private IEnumerator BurnCoroutine()
    {
        while (gameObject.activeSelf)
        {
            yield return new WaitForSeconds(1.0f);

            if (enemyCharacter != null)
            {
                DamageType burnDamageType = DamageType.NONE;
                float damageValue = 0.0f;

                foreach (Effect effect in effects)
                {
                    bool isBurnEffect = false;
                    if (effect.type == Effect.EffectTypes.FireBurn)
                    {
                        burnDamageType = DamageType.FIRE;
                        isBurnEffect = true;
                    }
                    else if (effect.type == Effect.EffectTypes.IceBurn)
                    {
                        burnDamageType = DamageType.WATER;
                        isBurnEffect = true;
                    }
                    else if(effect.type == Effect.EffectTypes.PoisonBurn)
                    {
                        burnDamageType = DamageType.EARTH;
                        isBurnEffect = true;
                        yield return new WaitForSeconds(.5f);
                    }
                    else if (effect.type == Effect.EffectTypes.EarthBurn)
                    {
                        burnDamageType = DamageType.EARTH;
                        isBurnEffect = true;
                    }

                    if (isBurnEffect)
                    {
                        damageValue = effect.value;
                        break;
                    }
                }

                if (burnDamageType != DamageType.NONE)
                    enemyCharacter.Hit(damageValue, false, burnDamageType, false, 0, true);
            }
        }
    }

    private SkinnedMeshRenderer[] ColorizedMeshes;
    [SerializeField]
    private List<Color> Colors = new List<Color>();

    private void UpdateVisualObjects()
    {
        if (SceneManager.GetActiveScene().name == "LevelEditor")
            return;

        bool fireEffectShouldBeEnabled = false;
        bool iceEffectShouldBeEnabled = false;
        bool acidEffectShouldBeEnabled = false;
        bool electricEffectShouldBeEnabled = false;
        bool earthEffectShouldBeEnabled = false;

        bool iceColorShouldBeEnabled = false;
        bool acidColorShouldBeEnabled = false;
        bool earthColorShouldBeEnabled = false;

        foreach (Effect effect in effects)
        {
            if (effect.type == Effect.EffectTypes.FireBurn)
            {
                fireEffectShouldBeEnabled = true;
            }
            if (effect.type == Effect.EffectTypes.IceBurn || effect.type == Effect.EffectTypes.IceSlowdown || effect.type == Effect.EffectTypes.Freezing)
            {
                iceColorShouldBeEnabled = true;
                if (effect.type == Effect.EffectTypes.Freezing)
                    iceEffectShouldBeEnabled = true;
            }
            if (effect.type == Effect.EffectTypes.PoisonBurn)
            {
                acidEffectShouldBeEnabled = true;
                acidColorShouldBeEnabled = true;
            }
            if (effect.type == Effect.EffectTypes.Paralysis)
            {
                electricEffectShouldBeEnabled = true;
            }
            if (effect.type == Effect.EffectTypes.EarthBurn || effect.type == Effect.EffectTypes.EarthSlowdown)
            {
                earthColorShouldBeEnabled = true;
                earthEffectShouldBeEnabled = true;
            }
        }

        GameObject spawnedEffectObject = null;

        if (fireEffectShouldBeEnabled && fireEffectObject == null)
            fireEffectObject = spawnedEffectObject = Instantiate(fireEffectPrefab, transform);

        if (iceEffectShouldBeEnabled && iceEffectObject == null)
            iceEffectObject = spawnedEffectObject = Instantiate(iceEffectPrefab, transform);

        if (acidEffectShouldBeEnabled && acidEffectObject == null)
            acidEffectObject = spawnedEffectObject = Instantiate(acidEffectPrefab, transform);

        if (electricEffectShouldBeEnabled && electricEffectObject == null)
            electricEffectObject = spawnedEffectObject = Instantiate(electricEffectPrefab, transform);

        if (earthEffectShouldBeEnabled && earthEffectObject == null)
            earthEffectObject = spawnedEffectObject = Instantiate(earthEffectPrefab, transform);

        if (spawnedEffectObject != null)
            spawnedEffectObject.transform.localPosition = Vector3.zero;

        if (spawnedEffectObject != null && earthEffectObject != null)
            earthEffectObject.transform.localRotation = Quaternion.Euler(-70, 0, 0);

        if (!fireEffectShouldBeEnabled && fireEffectObject != null)
            Destroy(fireEffectObject);

        if (!iceEffectShouldBeEnabled && iceEffectObject != null)
            Destroy(iceEffectObject);

        if (!acidEffectShouldBeEnabled && acidEffectObject != null)
            Destroy(acidEffectObject);

        if (!electricEffectShouldBeEnabled && electricEffectObject != null)
            Destroy(electricEffectObject);

        if (!earthEffectShouldBeEnabled && earthEffectObject != null)
            Destroy(earthEffectObject);

        Color targetColor = Color.black;
        if (iceColorShouldBeEnabled)
            targetColor = new Color(0f, 0.5f, 1f);
        if (acidColorShouldBeEnabled)
            targetColor = new Color(0.65f, 1.0f, 0.65f);
        if (earthColorShouldBeEnabled)
            targetColor = new Color(0.82f, 0.53f, 0.32f);

        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        var propertyID = Shader.PropertyToID("_Color");

        int j = 0;
        if (ColorizedMeshes != null)
        {
            foreach (SkinnedMeshRenderer skin in ColorizedMeshes)
            {
                skin.GetPropertyBlock(propertyBlock);
                if (targetColor == Color.black)
                    propertyBlock.SetColor(propertyID, Color.Lerp((propertyBlock.GetColor(propertyID) == Color.clear ? Color.white : propertyBlock.GetColor(propertyID)), Colors[j], Time.deltaTime * 1f));
                else
                    propertyBlock.SetColor(propertyID, targetColor);
                skin.SetPropertyBlock(propertyBlock);
                j++;
            }
            for (int i = 0; i < enemyCharacter.lowHealthDisableObjs.Count; i++)
            {
                MeshRenderer tempMesh = enemyCharacter.lowHealthDisableObjs[i].GetComponent<MeshRenderer>();
                if (tempMesh != null)
                {
                    tempMesh.GetPropertyBlock(propertyBlock);
                    if (targetColor == Color.black)
                        propertyBlock.SetColor(propertyID, Color.Lerp(propertyBlock.GetColor(propertyID), Colors[j], Time.deltaTime * 1f));
                    else
                        propertyBlock.SetColor(propertyID, targetColor);
                    tempMesh.SetPropertyBlock(propertyBlock);
                    j++;
                }
            }
        }
    }
}