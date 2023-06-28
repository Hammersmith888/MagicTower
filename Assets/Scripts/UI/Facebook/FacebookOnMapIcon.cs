using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FacebookOnMapIcon : MonoBehaviour {

	[SerializeField]
	private Image		playerFacebookIcon;
	[SerializeField]
	private Button		showStatsButton;
	[SerializeField]
	private Transform	flippableFrame;
	[SerializeField]
	private GameObject	statsObject;
	[SerializeField]
	private Text		friendScoreLbl;
	[SerializeField]
	private Text        playerScoreLbl;

	private int defaultSiblingIndex;

    private static FacebookOnMapIcon currentlySelectedIcon;

	IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();
		transform.SetParent(transform.parent.parent);
		transform.SetAsLastSibling();
	}

	public void Init( Sprite avatarSprite, int currentUserScore, int selectedUserScore, bool isCurrentPlayer = false )
	{
		if( isCurrentPlayer )
		{
			Vector3 localScale = flippableFrame.localScale;
			localScale.x *= -1f;
			flippableFrame.localScale = localScale;
		}
		statsObject.SetActive( false );
		playerFacebookIcon.sprite = avatarSprite;
		friendScoreLbl.text = selectedUserScore.ToString();
		playerScoreLbl.text = currentUserScore.ToString();
		friendScoreLbl.transform.parent.gameObject.SetActive( !isCurrentPlayer );
		showStatsButton.onClick.AddListener( ToggleStatsObject );
		defaultSiblingIndex = transform.GetSiblingIndex();
	}

    public void AnimateToLevel(Transform nextLevelTransform, Vector3 iconPos)
    {
        Animations.AlphaColorAnimation alphaAnim = GetComponent<Animations.AlphaColorAnimation>();
        alphaAnim.Animate(()=>
        {
            transform.SetParent(nextLevelTransform, false);
            transform.localPosition = iconPos;
            alphaAnim.Animate(null, false);
        });
    }

	private void ToggleStatsObject( )
	{
		statsObject.SetActive(!statsObject.activeSelf );

		if( statsObject.activeSelf )
		{
			transform.SetAsLastSibling();
			if( currentlySelectedIcon != null )
			{
				currentlySelectedIcon.ToggleStatsObject();
			}
			currentlySelectedIcon = this;
		}
		else
		{
			transform.SetSiblingIndex( defaultSiblingIndex );
			currentlySelectedIcon = null;
		}
	}
}
