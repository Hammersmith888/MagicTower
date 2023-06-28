using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DemoCode1 : MonoBehaviour {

	// Variable that will hold an instance of LivesManager
	LivesManager lm = null;

	// Use this for initialization
	void Start () {
	
		// Get LivesManager object from the scene
		GameObject gameObject = GameObject.Find ("LivesManager");

		// If LivesManager object exist
		if (gameObject != null) {

			// Get LivesManager component
			lm = gameObject.GetComponent<LivesManager> ();

			// Display configuration values in scene. (only for demo)
			GameObject.Find ("TEXT_BASIC_LIFE_SLOTS").GetComponent<Text> ().text = "Basic Life Slots: " + LMConfig.BASIC_LIFE_SLOTS;
			GameObject.Find ("TEXT_MAX_EXTRA_LIFE_SLOTS").GetComponent<Text> ().text = "Max Extra Life Slots: " + LMConfig.MAX_EXTRA_LIFE_SLOTS;
			GameObject.Find ("TEXT_REFILL_LIFE_SECONDS").GetComponent<Text> ().text = "Life Refill Seconds: " + LMConfig.REFILL_LIFE_SECONDS;
			GameObject.Find ("TEXT_UNLIMITED_LIVES_SECONDS").GetComponent<Text> ().text = "Unlimited Lives Seconds: " + LMConfig.UNLIMITED_LIVES_SECONDS;
		} else {
			Debug.Log("ERROR: LivesManager prefab not found!");
		}
	}

	/* Ideal for when the user has:
     * 1. Watched a video ad.
	 * 2. Completed an achievment or daily misssion.
	 * 3. Received a life from a friend.
	 */ 
	public void refillOneLive(){
		if (lm) {
			if (lm.canRefillLives ()) {
				lm.refillOneLife ();
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: 1 life has been refilled!";
			} else {
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: You already have full lives!";

			}
		}
	}



	/* Ideal for when the user has played and lost one life.*/
	public void looseOneLife(){
		if (lm){
			if (lm.canLooseLife ()) {
				lm.looseOneLife ();
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: One life has been lost!";
			} else {
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: You cannot loose any lives at this state!";
			}
		}
	}

	/* Ideal for when the user has purchased a "Refill All Lives" in-app.*/
	public void refillAllLives(){
		if (lm){
			if (lm.canRefillLives ()) {
				lm.refillAllLives ();
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: All lives has been refilled!";
			} else {
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: You already have full lives.";
			}
		}
	}

	/* Ideal for when the user has purchased the Unlimited Lives in-app.*/
	public void getUnlimitedLives(){
		if (lm){
			if (lm.canGetUnlimitedLives ()) {
				lm.getUnlimitedLives ();
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: Unlimited lives have been activated!";
			} else {
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: You already have unlimited lives!";
			}
		}
	}

	/* Ideal for when user has purchased a "Extra Life Slot" package.*/
	public void getExtraLifeSlot(){

		if (lm) {
			if (lm.canGetExtraLifeSlot ()) {
				lm.getExtraLifeSlot ();
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: You got an extra life slot!";
			} else {
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: You cannot buy any extra life slots!";
			}
		}
	}

	/* Ideal for when you want to check if the user has enough lives to play. 
	 * If yes, take him to gamescene. 
	 * If not, show him the Out of Lives popup.
	 */
	public void canPlay(){
		if (lm) {
			if (lm.canPlay ())
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: You have enough lives to play!";
			else
				GameObject.Find ("TEXT_DEBUG").GetComponent<Text> ().text = "Debug: You are out of lives and cannot play!";
		}
	}



	/**To be used during development testing*/
	public void reset(){
		if (lm)
			lm.reset ();
	}
}
