using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	/// <summary>
	/// Currently redundant class need to be replaced with BaseBackButtonListener on objects
	/// </summary>
	public class UIZombariumBackButtonListener : MonoBehaviour, IOnbackButtonClickListener
	{
		[SerializeField]
		private Button closeBtn;

		private void OnEnable( )
		{
			if( closeBtn == null )
			{
				closeBtn = GetComponentInChildren<Button>();
			}
			UIControl.Current.AddOnBackButtonListener( this );
		}

		private void OnDisable( )
		{
			UIControl.Current.RemoveOnBackButtonListener( this );
		}

		public void OnBackButtonClick( )
		{
			if( closeBtn != null )
			{
				closeBtn.onClick.Invoke();
			}
		}
	}
}
