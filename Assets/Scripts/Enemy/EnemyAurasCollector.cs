using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAurasCollector : MonoBehaviour
{
    public static EnemyAurasCollector Current;
    public float updateStep;
    public GameObject prefabLine;
    List<GameObject> lineObjects = new List<GameObject>();
    public Color[] colors;

    public float speedColor = 1;

    public bool haveAura = false;

    private class AuraSetter
    {
        public int auraId;
        public float radius;
        public Transform transf;

        public float SqrRadius
        {
            get { return radius * radius; }
        }
    }

    private List<AuraSetter> aurasOnLevel = new List<AuraSetter>();

    void Awake()
    {
        Current = this;
    }

    void Start()
    {
        if (updateStep <= 0f)
        {
            updateStep = 0.1f;
        }
    }

    private void LateUpdate()
    {
        if (haveAura)
        {
            RecheckAuraGetters();
        }
    }

    public void SpawnAura()
    {
        haveAura = true;

        for (int i = 0;
            i < 50;
            i++) //todo dunno whats happening here so disabled this, this thing was just spawning lots of junk effects
        {
            var line = Instantiate(prefabLine);
            lineObjects.Add(line);
        }
        StartCoroutine(RecheckAuraSetters());
    }

    private IEnumerator RecheckAuraSetters()
    {
        while (true)
        {
            aurasOnLevel.Clear();
            var coutEnemy = EnemiesGenerator.Instance.enemiesOnLevelComponents.Count;

            for (int i = 0; i < coutEnemy; i++)
            {
                EnemyCharacter tempChar = EnemiesGenerator.Instance.enemiesOnLevelComponents[i];

                if (tempChar.gives_aura_id > 0 && !tempChar.IsDead)
                {
                    if (EnemiesGenerator.Instance.enemiesOnLevelComponents[i].transform != null)
                    {
                        aurasOnLevel.Add(
                            new AuraSetter()
                            {
                                auraId = tempChar.gives_aura_id,
                                radius = 5f,
                                transf = EnemiesGenerator.Instance.enemiesOnLevelComponents[i].transform
                            }
                            );
                    }
                }
            }
            if (aurasOnLevel.Count == 0)
            {
                foreach (var line in lineObjects)
                {
                    Destroy(line);
                }
                lineObjects.Clear();
                yield break;
            }
            yield return new WaitForSecondsRealtime(1);
        }
    }

    public void RemovedEnemy(Transform enemyTransf)
    {
        for (int i = 0; i < aurasOnLevel.Count; i++)
        {
            if (aurasOnLevel[i].transf == enemyTransf)
            {
                aurasOnLevel.RemoveAt(i);
                break;
            }
        }
    }

    private void RecheckAuraGetters()
    {
        List<EnemyCharacter> enemiesChars = EnemiesGenerator.Instance.enemiesOnLevelComponents;

        for (int i = 0; i < lineObjects.Count; i++)
        {
            var lineAnim = lineObjects[i].GetComponent<LineSourceAnim>();
            lineAnim.isEnable = false;
        }
        try
        {
            for (int i = 0; i < enemiesChars.Count; i++)
            {
                if (enemiesChars[i] != null && enemiesChars[i].canShowAura)
                {
                    bool anyAuraApply = false;

                    enemiesChars[i].needAura1 = false;
                    enemiesChars[i].needAura2 = false;

                    for (int j = 0; j < aurasOnLevel.Count; j++)
                    {
                        if (enemiesChars[i] == null || aurasOnLevel[j] == null)
                            continue;

                        Vector2 enemyPosition = enemiesChars[i].transform.position;
                        Vector2 auraSourcePosition = aurasOnLevel[j].transf.position;
                        var dst = Vector2.Distance(enemyPosition, auraSourcePosition);

                        if (aurasOnLevel[j].transf != null && dst < aurasOnLevel[j].radius)
                        {
                            if (i < lineObjects.Count)
                            {
                                var lines = lineObjects[i].GetComponent<LineRenderer>();
                                lines.SetPositions(new Vector3[] { new Vector3(auraSourcePosition.x, auraSourcePosition.y, 0), new Vector3(enemyPosition.x, enemyPosition.y, 0) });
                                lineObjects[i].GetComponent<LineSourceAnim>().isEnable = true;
                                lines.material.SetTextureScale("_MainTex", new Vector2(dst / 5 * 5.4f, 1));
                                lines.material.SetTextureOffset("_MainTex", new Vector2(lineObjects[i].GetComponent<LineSourceAnim>().current, 0));
                                lines.startColor = lines.endColor = colors[indexColor(aurasOnLevel[j].auraId)];
                            }
                            enemiesChars[i].SetAuraModifier(aurasOnLevel[j].auraId);
                            anyAuraApply = true;
                        }
                    }

                    if (!anyAuraApply)
                    {
                        enemiesChars[i].SetAuraModifier(0);
                    }
                }
            }
            for (int i = 0; i < lineObjects.Count; i++)
            {
                SetLineEnable(lineObjects[i].GetComponent<LineRenderer>(), lineObjects[i].GetComponent<LineSourceAnim>().isEnable, i);
            }
        }
        catch (System.Exception)
        {
        }
    }

    void SetLineEnable(LineRenderer line, bool value, int index)
    {
        var f = Mathf.Clamp(line.startColor.a + Time.deltaTime * (value ? (speedColor) : (-speedColor)), 0, colors[0].a);
        lineObjects[index].GetComponent<LineSourceAnim>().aColor = f;
        line.startColor = line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, f) ;
    }

    int indexColor(int id)
    {
        var i = 0;

        if (id == 2)
            i = 1;

        return i;
    }
}
