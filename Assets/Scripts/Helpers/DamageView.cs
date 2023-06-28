using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageView : MonoBehaviour, IPoolObject
{
    [System.Serializable]
    public class DamageViewData
    {
        public DamageType resist = DamageType.NONE;
        public DamageType vulnarable = DamageType.NONE;
        public DamageType incomingDmgType = DamageType.NONE;
        public float percent = 0;
        public float crit = 0;
        public Transform target;
        public bool isSpell;
    }

    private const float MoveUpTime = 1.5f;
    private const float ScaleAnimationTime = 0.4f;

    [SerializeField]
    private Text textComponent, percentText;
    [SerializeField]
    private Image shieldImage, heartImage;
    private Transform transf;
    [SerializeField]
    private Transform iconTransf;
    [SerializeField]
    private Color colorAir, colorEarth, colorFire, colorFireSpeel, colorWater, colorCrit;
    [SerializeField]
    private Outline outline;
    [SerializeField]
    private Shadow shadow;

    [Space(10f)]
    [SerializeField]
    private AnimationCurve scaleAnimationCurve;
    [SerializeField]
    private AnimationCurve scaleAnimationCritCurve;
    [SerializeField]
    private AnimationCurve textMoveUpCurve;

    private AnimationCurve currentScaleCurve;

    public bool canBeUsed
    {
        get
        {
            return !gameObject.activeSelf;
        }
    }

    public void Init()
    {
        transf = transform;
        gameObject.SetActive(false);
    }

    public void Spawn(Vector3 pos, int damage, DamageViewData damageViewData, bool isDeath = false, bool delay = false)
    {
        gameObject.SetActive(true);
        StartCoroutine(_Spawn(pos, damage, damageViewData, isDeath, delay));
    }

    IEnumerator _Spawn(Vector3 pos, int damage, DamageViewData damageViewData, bool isDeath = false, bool delay = false)
    {
        if(delay)
            yield return new WaitForSeconds(Random.Range(0.3f, 1f));
        Color usingColor = Color.white;
        if (!isDeath)
        {
            shieldImage.gameObject.SetActive(true);
            heartImage.gameObject.SetActive(true);
            percentText.gameObject.SetActive(true);
        }

        bool itsResist = true;
        if (damageViewData.resist == DamageType.NONE)
        {
            itsResist = false;
            shieldImage.gameObject.SetActive(false);
            heartImage.gameObject.SetActive(false);
            percentText.gameObject.SetActive(false);
        }
        if (damageViewData.vulnarable == DamageType.NONE)
        {
            heartImage.gameObject.SetActive(false);
            //percentText.gameObject.SetActive(itsResist);
            // percentText.gameObject.SetActive(false);
        }

        heartImage.color = GetDmgColor(damageViewData.vulnarable);
        shieldImage.color = GetDmgColor(damageViewData.resist);
        Color textColor;
        // Debug.Log($"LevelSettings.Current.IsCriticalModifier(damageViewData.crit): {LevelSettings.Current.IsCriticalModifier(damageViewData.crit)}");
        //Debug.Log($"damageViewData.crit: {damageViewData.crit}");
        if (LevelSettings.Current.IsCriticalModifier(damageViewData.crit))
        {
            currentScaleCurve = scaleAnimationCritCurve;
            textColor = colorCrit;
            //Debug.Log($"textColor : {textColor}");
        }
        else
        {
            currentScaleCurve = scaleAnimationCurve;
            textColor = GetDmgColor(damageViewData.incomingDmgType);
        }




        textComponent.color = !damageViewData.isSpell ? textColor : colorFireSpeel;
        textComponent.text = "- " + damage.ToString();

        if (damageViewData.isSpell)
        {
            textComponent.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        }


        if (itsResist)
        {
            percentText.text = "-" + ((damageViewData.percent * 100f)).ToString("F0") + "%";
        }
        else
        {
            percentText.text = "+" + ((damageViewData.percent * 100f)).ToString("F0") + "%";
        }
        //Debug.Log($"show: {((damageViewData.percent * 100f).ToString("F0"))}, %: {damageViewData.percent}");
        transf.SetAsFirstSibling();
        transf.position = pos;
        iconTransf.position = pos - new Vector3(0f, 40f, 0f);
        textComponent.transform.localPosition = Vector3.zero;
        gameObject.SetActive(true);
        StartCoroutine(AnimateIt(damageViewData.isSpell));
    }

    private IEnumerator AnimateIt(bool isSpell)
    {
        StartCoroutine(ScaleAnimationCurve());
        SetAlphaForAll(1f);

        if (isSpell)
            yield return new WaitForSeconds(0.6f);

        var timer = 0f;
        var startPosition = textComponent.transform.localPosition;
        startPosition.x += Random.Range(-8f, 8f);
        startPosition.y += Random.Range(-8f, 8f);
        var targetPosition = startPosition;
        targetPosition.y += 90f;
        var alpha = 0f;
        var fadeOutTimer = 0f;
        var startFadeOutTime = MoveUpTime * 0.5f;
        var fadeOutTime = MoveUpTime - startFadeOutTime;

        while (timer < MoveUpTime)
        {
            timer += Time.deltaTime;
            textComponent.transform.localPosition = Vector3.Lerp(startPosition, targetPosition, textMoveUpCurve.Evaluate(timer / MoveUpTime));
            if (timer >= startFadeOutTime)
            {
                fadeOutTimer += Time.deltaTime;
                alpha = 1f - (fadeOutTimer / fadeOutTime);
                SetAlphaForAll(alpha);
            }
            yield return null;
        }
        gameObject.SetActive(false);
        yield break;
    }

    private IEnumerator ScaleAnimationCurve()
    {
        var timer = 0f;
        var startScale = 1f;
        var animationScale = 1.25f;
        var oneScale = new Vector3(1f, 1f, 1f);
        while (timer < ScaleAnimationTime)
        {
            timer += Time.deltaTime;
            transf.localScale = oneScale * Mathf.Lerp(startScale, animationScale, currentScaleCurve.Evaluate(timer / ScaleAnimationTime));
            yield return null;
        }
    }

    private void SetAlphaForAll(float alpha)
    {
        Color textColor = textComponent.color;
        Color percentColor = percentText.color;
        Color shieldColor = shieldImage.color;
        Color heartColor = heartImage.color;
        Color outlineColor = outline.effectColor;
        Color shadowColor = shadow.effectColor;

        textColor.a = alpha;
        shieldColor.a = alpha;
        heartColor.a = alpha;
        percentColor.a = alpha;
        outlineColor.a = alpha;
        shadowColor.a = alpha;

        percentText.color = percentColor;
        shieldImage.color = shieldColor;
        heartImage.color = heartColor;
        outline.effectColor = outlineColor;
        shadow.effectColor = shadowColor;
        textComponent.color = textColor;
    }

    private Color GetDmgColor(DamageType damageType)
    {
        Color usingColor = Color.white;
        switch (damageType)
        {
            case DamageType.AIR:
                usingColor = colorAir;
                break;
            case DamageType.EARTH:
                usingColor = colorEarth;
                break;
            case DamageType.FIRE:
                usingColor = colorFire;
                break;
            case DamageType.WATER:
                usingColor = colorWater;
                break;
        }
        return usingColor;
    }
}
