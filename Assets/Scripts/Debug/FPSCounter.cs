using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
	private Text 	textMesh;
	public 	float		frequency;//частота обновления в секундах
	private float		timer;
	private int			frameCount = 0;
	// Use this for initialization
	void Awake () {
		textMesh = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		timer += Time.deltaTime;
		frameCount ++;
		if( timer >= frequency )
		{
			timer = 0;
            var x = Mathf.RoundToInt(frameCount / frequency);

            textMesh.text = Time.timeScale.ToString() + " | " + x.ToString();
			frameCount = 0;
		}
	}
}
