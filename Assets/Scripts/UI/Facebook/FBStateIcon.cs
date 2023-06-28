using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Social;

public class FBStateIcon : MonoBehaviour
{
	[SerializeField]
	private GameObject StateConnecting, StateConnected, InviteObj;
	private Image stateIcon;

	void Start()
	{
		stateIcon = gameObject.GetComponent<Image>();

		if (FacebookManager.Instance.isLoggedIn)
		{
			SetConnectedState();
		}
		else
		{
			SetNotConnectedState();
		}
	}

	public void SetNotConnectedState()
	{
		stateIcon.color = new Color(1, 1, 1, 0);

		StateConnecting.SetActive(false);
		StateConnected.SetActive(false);

		if( InviteObj != null )
			InviteObj.SetActive(false);

		GetComponent<Animation>().Play();
	}

	public void SetConnectingState()
	{
		stateIcon.color = new Color(1, 1, 1, 1);

		StateConnecting.SetActive(true);
		GetComponent<Animation>().Stop();
		if (InviteController.instance != null)
			InviteController.instance.UpdateFB();
	}

	public void SetConnectedState()
	{
		if (InviteObj == null)
		{
			stateIcon.color = new Color(1, 1, 1, 1);

			StateConnecting.SetActive(false);
			StateConnected.SetActive(true);
		}
		else
		{
			InviteObj.SetActive(true);
			transform.parent.gameObject.SetActive(false);
		}
		GetComponent<Animation>().Stop();
	}
}