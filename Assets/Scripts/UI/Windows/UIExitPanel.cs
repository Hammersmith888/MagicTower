using System;
using UnityEngine;

namespace UI
{
    public class UIExitPanel : UIWindowBase
    {
        override protected void OnEnable()
        {
            Time.timeScale = 0;
            base.OnEnable();
        }

        void OnDisable()
        {
            try//todo refactor. not the best decision but for now will do check more
            {
                Time.timeScale = LevelSettings.Current.usedGameSpeed;
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }

        protected override void OnCloseWithBackButton()
        {
            PlayerPrefs.SetString("EscapePressedFrom", "none");
            base.OnCloseWithBackButton();
        }

        public void YesBtn()
        {
            Application.Quit();
        }

        public void NoBtn()
        {
            gameObject.SetActive(false);
        }
    }
}
