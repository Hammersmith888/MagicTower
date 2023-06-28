using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Gem
{
    public const int MaxLevelIndex = 9;
    public const int MaxLevel = MaxLevelIndex + 1;

    public GemType type;
    public int gemLevel;
    public Color color => GetColor(type);

    private Color GetColor(GemType type)
    {
        if (type == GemType.Blue)
            return Color.blue;
        if (type == GemType.Red)
            return Color.red;
        if (type == GemType.Yellow)
            return Color.yellow;

        return Color.white;
    }
}

[System.Serializable]
public class GemDrop
{
    public int chance;
    public Gem gem = new Gem();
}

public class EditorGems : MonoBehaviour
{
    //	[SerializeField]
    //	private Text 
    // Use this for initialization

    [SerializeField]
    private Text chanceText;
    [SerializeField]
    private Dropdown gemType;
    [SerializeField]
    private Dropdown gemLevel;
    public List<Transform> contents;
    public List<GemDrop> gem_drops;
    public LevelEditorController levelEditorScript;
    [SerializeField]
    private EditorPopupCustomDrop editorPopupCustomDrop;

    public void LoadWaveCasketContent(EnemyWave wave)
    {
        ClearDropList();
        if (wave.gem_drops != null)
        {
            for (int i = 0; i < wave.gem_drops.Count; i++)
            {
                AddDropItemCustom(wave.gem_drops[i]);
            }
        }
    }

    private void ClearDropList()
    {
        for (int i = 0; i < contents.Count; i++)
        {
            contents[i].gameObject.SetActive(false);
        }
        gem_drops.Clear();
    }

    private void AddDropItemCustom(GemDrop custom_item)
    {
        gem_drops.Add(custom_item);
        for (int i = 0; i < contents.Count; i++)
        {
            if (!contents[i].gameObject.activeSelf)
            {
                contents[i].gameObject.SetActive(true);
                contents[i].GetComponent<GemDropContent>().content = custom_item.gem.type;
                contents[i].GetComponent<GemDropContent>().level = custom_item.gem.gemLevel;
                contents[i].GetComponent<Text>().text = custom_item.chance.ToString() + "% - " + custom_item.gem.type.ToString() + " " + (custom_item.gem.gemLevel + 1).ToString();
                i = contents.Count;
            }
        }
    }
    public void LoadCustomGemDrops(List<GemDrop> newDrop)
    {
        ClearDropList();
        if (newDrop != null)
        {
            for (int i = 0; i < newDrop.Count; i++)
            {
                AddDropItemCustom(newDrop[i]);
            }
        }
    }

    public void AddDropItem()
    {
        bool can_flag = true;
        int chance_param = int.Parse(chanceText.text);
        GemType content_param = GemType.Red;
        switch (gemType.value)
        {
            case 1:
                content_param = GemType.Blue;
                break;
            case 2:
                content_param = GemType.White;
                break;
            case 3:
                content_param = GemType.Yellow;
                break;
        }
        int content_level = gemLevel.value;
        GemDrop new_drop = new GemDrop();
        new_drop.chance = chance_param;
        new_drop.gem.type = content_param;
        new_drop.gem.gemLevel = content_level;

        for (int i = 0; i < gem_drops.Count; i++)
        {
            if (gem_drops[i].gem.type == new_drop.gem.type && gem_drops[i].gem.gemLevel == new_drop.gem.gemLevel)
            {
                can_flag = false;
            }
        }

        if (can_flag != false)
        {
            gem_drops.Add(new_drop);


            for (int i = 0; i < contents.Count; i++)
            {
                if (!contents[i].gameObject.activeSelf)
                {
                    contents[i].gameObject.SetActive(true);
                    contents[i].GetComponent<GemDropContent>().content = content_param;
                    contents[i].GetComponent<Text>().text = chanceText.text + "% - " + gemType.options[gemType.value].text + " " + gemLevel.options[gemLevel.value].text;
                    i = contents.Count;
                }
            }

        }
        else
        {
            //gem_drops.RemoveAt( gem_drops.Count - 1 );
        }
        if (editorPopupCustomDrop == null)
        {
            levelEditorScript.SaveCurrentWave("gems");
        }
        else
        {
            editorPopupCustomDrop.SaveGems();
        }
    }

    public void ResetPickParams()
    {
        chanceText.text = "0";
        gemType.value = 0;
        gemLevel.value = 0;
    }

    public void RemoveItem(GameObject obj_from)
    {
        GemType content_from = obj_from.GetComponent<GemDropContent>().content;
        for (int i = 0; i < gem_drops.Count; i++)
        {
            if (gem_drops[i].gem.type == content_from)
            {
                gem_drops.RemoveAt(i);
                i = gem_drops.Count;
            }
        }
        obj_from.SetActive(false);
        if (editorPopupCustomDrop == null)
        {
            levelEditorScript.SaveCurrentWave("gems");
        }
        else
        {
            editorPopupCustomDrop.SaveGems();
        }
    }

}
