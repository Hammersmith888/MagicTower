using UnityEngine;
using System.Collections;

namespace I2.Loc
{
	public partial class Localize
	{
		#region Cache

		UnityEngine.UI.Text 		mTarget_uGUI_Text;
		UnityEngine.UI.Image 		mTarget_uGUI_Image;
		UnityEngine.UI.RawImage 	mTarget_uGUI_RawImage;
        TextAnchor mAlignmentUGUI_RTL = TextAnchor.UpperRight;
        TextAnchor mAlignmentUGUI_LTR = TextAnchor.UpperLeft;

        public void RegisterEvents_UGUI()
		{
			EventFindTarget += FindTarget_uGUI_Text;
			EventFindTarget += FindTarget_uGUI_Image;
			EventFindTarget += FindTarget_uGUI_RawImage;
		}
		
		#endregion
		
		#region Find Target
		
		void FindTarget_uGUI_Text() 	{ FindAndCacheTarget (ref mTarget_uGUI_Text, SetFinalTerms_uGUI_Text, DoLocalize_uGUI_Text, true, true, false); }
		void FindTarget_uGUI_Image() 	{ FindAndCacheTarget (ref mTarget_uGUI_Image, SetFinalTerms_uGUI_Image, DoLocalize_uGUI_Image, false, false, false); }
		void FindTarget_uGUI_RawImage()	{ FindAndCacheTarget (ref mTarget_uGUI_RawImage, SetFinalTerms_uGUI_RawImage, DoLocalize_uGUI_RawImage, false, false, false); }

		#endregion
		
		#region SetFinalTerms
		
		void SetFinalTerms_uGUI_Text(string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
		{
			string second = (mTarget_uGUI_Text.font!=null ? mTarget_uGUI_Text.font.name : string.Empty);
			SetFinalTerms (mTarget_uGUI_Text.text, second,		out primaryTerm, out secondaryTerm, true);
			
		}
		
		public void SetFinalTerms_uGUI_Image(string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
		{
			SetFinalTerms (mTarget_uGUI_Image.mainTexture.name, 	null,	out primaryTerm, out secondaryTerm, false);
		}

		public void SetFinalTerms_uGUI_RawImage(string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
		{
			SetFinalTerms (mTarget_uGUI_RawImage.texture.name, 	null,	out primaryTerm, out secondaryTerm, false);
		}

		#endregion
		
		#region DoLocalize

		public static T FindInParents<T> (Transform tr) where T : Component
		{
			if (!tr) 
				return null;

			T comp = tr.GetComponent<T>();
			while (!comp && tr)
			{
				comp = tr.GetComponent<T>();
				tr = tr.parent;
			}
			return comp;
		}
		
		public void DoLocalize_uGUI_Text(string MainTranslation, string SecondaryTranslation)
		{
			//--[ Localize Font Object ]----------
			Font newFont = GetSecondaryTranslatedObj<Font>(ref MainTranslation, ref SecondaryTranslation);
			if (newFont!=null && newFont!=mTarget_uGUI_Text.font) 
				mTarget_uGUI_Text.font = newFont;

			if (mInitializeAlignment)
			{
				mInitializeAlignment = false;
                InitAlignment_UGUI(mTarget_uGUI_Text.alignment, out mAlignmentUGUI_LTR, out mAlignmentUGUI_RTL);
			}

			if (!string.IsNullOrEmpty(MainTranslation) && mTarget_uGUI_Text.text != MainTranslation) 
			{
				if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
				{
                    mTarget_uGUI_Text.alignment = LocalizationManager.IsRight2Left ? mAlignmentUGUI_RTL : mAlignmentUGUI_LTR;
				}
				

				mTarget_uGUI_Text.text = MainTranslation;
				mTarget_uGUI_Text.SetVerticesDirty();

                // In the editor, sometimes unity "forgets" to show the changes
#if UNITY_EDITOR
                if (!Application.isPlaying)
                    UnityEditor.EditorUtility.SetDirty(mTarget_uGUI_Text);
#endif
            }
		}

        void InitAlignment_UGUI(TextAnchor alignment, out TextAnchor alignLTR, out TextAnchor alignRTL)
        {
            alignLTR = alignRTL = alignment;

            if (LocalizationManager.IsRight2Left)
            {
                switch (alignment)
                {
                    case TextAnchor.UpperRight: alignLTR = TextAnchor.UpperLeft; break;
                    case TextAnchor.MiddleRight: alignLTR = TextAnchor.MiddleLeft; break;
                    case TextAnchor.LowerRight: alignLTR = TextAnchor.LowerLeft; break;
                }
            }
            else
            {
                switch (alignment)
                {
                    case TextAnchor.UpperLeft: alignRTL = TextAnchor.UpperRight; break;
                    case TextAnchor.MiddleLeft: alignRTL = TextAnchor.MiddleRight; break;
                    case TextAnchor.LowerLeft: alignRTL = TextAnchor.LowerRight; break;
                }
            }
        }

        public void DoLocalize_uGUI_Image(string MainTranslation, string SecondaryTranslation)
		{
			Sprite Old = mTarget_uGUI_Image.sprite;
			if (Old==null || Old.name!=MainTranslation)
				mTarget_uGUI_Image.sprite = FindTranslatedObject<Sprite>(MainTranslation);

            // If the old value is not in the translatedObjects, then unload it as it most likely was loaded from Resources
            //if (!HasTranslatedObject(Old))
            //	Resources.UnloadAsset(Old);

            // In the editor, sometimes unity "forgets" to show the changes
        #if UNITY_EDITOR
            if (!Application.isPlaying)
                UnityEditor.EditorUtility.SetDirty(mTarget_uGUI_Image);
        #endif
        }

        public void DoLocalize_uGUI_RawImage(string MainTranslation, string SecondaryTranslation)
		{
			Texture Old = mTarget_uGUI_RawImage.texture;
			if (Old==null || Old.name!=MainTranslation)
				mTarget_uGUI_RawImage.texture = FindTranslatedObject<Texture>(MainTranslation);

            // If the old value is not in the translatedObjects, then unload it as it most likely was loaded from Resources
            //if (!HasTranslatedObject(Old))
            //	Resources.UnloadAsset(Old);

            // In the editor, sometimes unity "forgets" to show the changes
            #if UNITY_EDITOR
            if (!Application.isPlaying)
                UnityEditor.EditorUtility.SetDirty(mTarget_uGUI_RawImage);
            #endif
        }
        #endregion
    }
}

