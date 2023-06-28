using UnityEngine;
using System.Collections;

namespace I2.Loc
{
	#if TextMeshPro || TextMeshPro_Pre53
	public partial class Localize
	{
		TMPro.TextMeshPro 	mTarget_TMPLabel;
		TMPro.TextMeshProUGUI mTarget_TMPUGUILabel;
        TMPro.TextAlignmentOptions mAlignmentTMPro_RTL = TMPro.TextAlignmentOptions.TopRight;
        TMPro.TextAlignmentOptions mAlignmentTMPro_LTR = TMPro.TextAlignmentOptions.TopLeft;

        [System.NonSerialized]public string TMP_previewLanguage;  // this is used because when in the editor, TMPro disables the inspector for a frame when changing fonts
		
		public void RegisterEvents_TextMeshPro()
		{
			EventFindTarget += FindTarget_TMPLabel;
			EventFindTarget += FindTarget_TMPUGUILabel;
		}
		
		void FindTarget_TMPLabel() 	{ FindAndCacheTarget (ref mTarget_TMPLabel, SetFinalTerms_TMPLabel, DoLocalize_TMPLabel, true, true, false); }

		void FindTarget_TMPUGUILabel() 	{ FindAndCacheTarget (ref mTarget_TMPUGUILabel, SetFinalTerms_TMPUGUILabel, DoLocalize_TMPUGUILabel, true, true, false); }

		void SetFinalTerms_TMPLabel(string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
		{
			string second = (mTarget_TMPLabel.font!=null ? mTarget_TMPLabel.font.name : string.Empty);
			SetFinalTerms (mTarget_TMPLabel.text, second,		out primaryTerm, out secondaryTerm, true);
		}

		void SetFinalTerms_TMPUGUILabel(string Main, string Secondary, out string primaryTerm, out string secondaryTerm)
		{
			string second = (mTarget_TMPUGUILabel.font!=null ? mTarget_TMPUGUILabel.font.name : string.Empty);
			SetFinalTerms (mTarget_TMPUGUILabel.text, second,		out primaryTerm, out secondaryTerm, true);
		}
		
		public void DoLocalize_TMPLabel(string MainTranslation, string SecondaryTranslation)
		{

			// there its a problem with TMPro that disables and renables the inspector when changing fonts, and that breaks the current preview flow
			if (!Application.isPlaying)
			{
				#if UNITY_EDITOR
				if (UnityEditor.Selection.activeGameObject == gameObject)
				{
					if (string.IsNullOrEmpty(TMP_previewLanguage))
						TMP_previewLanguage = LocalizationManager.CurrentLanguage;
				}
				#endif
			}

			//--[ Localize Font Object ]----------
			{
				#if TextMeshPro_Pre53
				TMPro.TextMeshProFont newFont = GetSecondaryTranslatedObj<TMPro.TextMeshProFont>(ref MainTranslation, ref SecondaryTranslation);
				#else
				TMPro.TMP_FontAsset newFont = GetSecondaryTranslatedObj<TMPro.TMP_FontAsset>(ref MainTranslation, ref SecondaryTranslation);
				#endif


				if (newFont != null)
				{
					if (mTarget_TMPLabel.font != newFont)
						mTarget_TMPLabel.font = newFont;
				}
				else
				{
					//--[ Localize Font Material ]----------
					Material newMat = GetSecondaryTranslatedObj<Material>(ref MainTranslation, ref SecondaryTranslation);
					if (newMat != null && mTarget_TMPLabel.fontMaterial != newMat) 
					{
						if (!newMat.name.StartsWith (mTarget_TMPLabel.font.name)) 
						{
							newFont = GetTMPFontFromMaterial (newMat.name);
							if (newFont!=null)
								mTarget_TMPLabel.font = newFont;
						}

						mTarget_TMPLabel.fontSharedMaterial/* fontMaterial*/ = newMat;
					}
				}
			}
			if (mInitializeAlignment)
			{
				mInitializeAlignment = false;
                InitAlignment_TMPro(mTarget_TMPLabel.alignment, out mAlignmentTMPro_LTR, out mAlignmentTMPro_RTL);
			}

			if (!string.IsNullOrEmpty(MainTranslation) && mTarget_TMPLabel.text != MainTranslation)
			{
				if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
				{
                    mTarget_TMPLabel.alignment = LocalizationManager.IsRight2Left ? mAlignmentTMPro_RTL : mAlignmentTMPro_LTR;
				}

				mTarget_TMPLabel.text = MainTranslation;
				//mTarget_TMPLabel.SetText( MainTranslation, 0 );
			}
		}

        void InitAlignment_TMPro(TMPro.TextAlignmentOptions alignment, out TMPro.TextAlignmentOptions alignLTR, out TMPro.TextAlignmentOptions alignRTL )
        {
            alignLTR = alignRTL = alignment;

            if (LocalizationManager.IsRight2Left)
            {
                switch (alignment)
                {
                    case TMPro.TextAlignmentOptions.TopRight: alignLTR=TMPro.TextAlignmentOptions.TopLeft; break;
                    case TMPro.TextAlignmentOptions.Right: alignLTR=TMPro.TextAlignmentOptions.Left; break;
                    case TMPro.TextAlignmentOptions.BottomRight: alignLTR=TMPro.TextAlignmentOptions.BottomLeft; break;
                    case TMPro.TextAlignmentOptions.BaselineRight: alignLTR=TMPro.TextAlignmentOptions.BaselineLeft; break;
                    case TMPro.TextAlignmentOptions.MidlineRight: alignLTR=TMPro.TextAlignmentOptions.MidlineLeft; break;
                    case TMPro.TextAlignmentOptions.CaplineRight: alignLTR=TMPro.TextAlignmentOptions.CaplineLeft; break;
                }
            }
            else
            {
                switch (alignment)
                {
                    case TMPro.TextAlignmentOptions.TopLeft: alignRTL=TMPro.TextAlignmentOptions.TopRight; break;
                    case TMPro.TextAlignmentOptions.Left: alignRTL=TMPro.TextAlignmentOptions.Right; break;
                    case TMPro.TextAlignmentOptions.BottomLeft: alignRTL=TMPro.TextAlignmentOptions.BottomRight; break;
                    case TMPro.TextAlignmentOptions.BaselineLeft: alignRTL=TMPro.TextAlignmentOptions.BaselineRight; break;
                    case TMPro.TextAlignmentOptions.MidlineLeft: alignRTL=TMPro.TextAlignmentOptions.MidlineRight; break;
                    case TMPro.TextAlignmentOptions.CaplineLeft: alignRTL=TMPro.TextAlignmentOptions.CaplineRight; break;
                }
            }
        }

 
		public void DoLocalize_TMPUGUILabel(string MainTranslation, string SecondaryTranslation)
		{
			{			
				//--[ Localize Font Object ]----------
				#if TextMeshPro_Pre53
				TMPro.TextMeshProFont newFont = GetSecondaryTranslatedObj<TMPro.TextMeshProFont>(ref MainTranslation, ref SecondaryTranslation);
				#else
				TMPro.TMP_FontAsset newFont = GetSecondaryTranslatedObj<TMPro.TMP_FontAsset>(ref MainTranslation, ref SecondaryTranslation);
				#endif

				if (newFont != null)
				{
					if (mTarget_TMPUGUILabel.font != newFont)
						mTarget_TMPUGUILabel.font = newFont;
				}
				else
				{
					//--[ Localize Font Material ]----------
					Material newMat = GetSecondaryTranslatedObj<Material>(ref MainTranslation, ref SecondaryTranslation);
					if (newMat != null && mTarget_TMPUGUILabel.fontMaterial != newMat) 
					{
						if (!newMat.name.StartsWith (mTarget_TMPUGUILabel.font.name)) 
						{
							newFont = GetTMPFontFromMaterial (newMat.name);
							if (newFont!=null)
								mTarget_TMPUGUILabel.font = newFont;
						}
						mTarget_TMPUGUILabel.fontSharedMaterial = newMat;
					}
				}
			}
			if (mInitializeAlignment)
			{
				mInitializeAlignment = false;
                InitAlignment_TMPro(mTarget_TMPUGUILabel.alignment, out mAlignmentTMPro_LTR, out mAlignmentTMPro_RTL);
			}
			if (!string.IsNullOrEmpty(MainTranslation) && mTarget_TMPUGUILabel.text != MainTranslation)
			{
                if (Localize.CurrentLocalizeComponent.CorrectAlignmentForRTL)
                {
                    mTarget_TMPUGUILabel.alignment = LocalizationManager.IsRight2Left ? mAlignmentTMPro_RTL : mAlignmentTMPro_LTR;
                }

				mTarget_TMPUGUILabel.text = MainTranslation;
				//mTarget_TMPUGUILabel.SetText(MainTranslation, 0);
			}
		}

    #if TextMeshPro_Pre53
   		TMPro.TextMeshProFont GetTMPFontFromMaterial( string matName )
		{
			int idx = matName.IndexOf (" SDF");
			if (idx>0)
			{
				var fontName = matName.Substring (0, idx + " SDF".Length);
				return GetObject<TMPro.TextMeshProFont>(fontName);
			}
			return null;
		}
    #else
        TMPro.TMP_FontAsset GetTMPFontFromMaterial( string matName )

		{
			int idx = matName.IndexOf (" SDF");
			if (idx>0)
			{
				var fontName = matName.Substring (0, idx + " SDF".Length);
				return GetObject<TMPro.TMP_FontAsset>(fontName);
			}
			return null;
		}
    #endif
    }

#else
        public partial class Localize
	{
		public static void RegisterEvents_TextMeshPro()
		{
		}
	}
#endif
}