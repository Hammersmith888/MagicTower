using System.Collections;
using System.Linq;
using Tutorials;
using UnityEngine;

public class TutorialDoneController : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(2f);
        int openLevel = SaveManager.GameProgress.Current.finishCount.Count(i => i > 0) + 1;

        var scrollItems = PPSerialization.Load<Scroll_Items>(EPrefsKeys.Scrolls);
        if (scrollItems == null)
            yield break;

        if (openLevel > 1)
        {
            SaveManager.GameProgress.Current.tutorial[1] = true;
            scrollItems[0].effectUnlock = true;
        }
        else if (openLevel > 2)
        {
            int idTutor = (int)ETutorialType.FIRST_CRYSTAL_SHOP;
            SaveManager.GameProgress.Current.tutorial[idTutor] = true;
            SaveManager.GameProgress.Current.tutAchivement = true;
        }
        else if(openLevel > 4)
        {
            scrollItems[(int)Scroll.ScrollType.Barrier].effectUnlock = true;
        }
        else if(openLevel > 5)
        {
            SaveManager.GameProgress.Current.tutorial[8] = true;
        }
        else if(openLevel > 6)
        {
            int idTutor = (int)ETutorialType.COMBINE_TWO_CRYSTALS;
            SaveManager.GameProgress.Current.tutorial[idTutor] = true;
        }
        else if(openLevel > 8)
        {
            SaveManager.GameProgress.Current.tutorial[9] = true;
        }
        else if(openLevel > 9)
        {
            SpecialOffer.saveData.newStartOffer = true;
        }
        else if(openLevel >= 12)
        {
            SaveManager.GameProgress.Current.tutorial[10] = true;
        }
        else if(openLevel > 13)
        {
            int idTutor = (int)ETutorialType.SPELL_4_SLOT;
            SaveManager.GameProgress.Current.tutorial[idTutor] = true;
        }
        else if(openLevel > 16)
        {
            SaveManager.GameProgress.Current.tutorialSlot17 = true;
        }
        else if(openLevel > 18)
        {
            SaveManager.GameProgress.Current.tutorial[11] = true;
        }
        else if(openLevel > 55)
        {
            int idTutor = (int)ETutorialType.SCROLL_4_SLOT;
            SaveManager.GameProgress.Current.tutorial[idTutor] = true;
        }
        PPSerialization.Save<SpecialOffer.SaveData>("special_offer", SpecialOffer.saveData);
        PPSerialization.Save<Scroll_Items>(EPrefsKeys.Scrolls, scrollItems);
        SaveManager.GameProgress.Current.Save();
    }
}
