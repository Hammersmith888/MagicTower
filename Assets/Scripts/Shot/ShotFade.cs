using UnityEngine;

public class ShotFade : MonoBehaviour
{
	const string SHOT_TAG ="Shot";

    // Первый вариант. Необходимо сделать включении анимации Fade для заклинания
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag( SHOT_TAG ) )
        {
			IOutOfGameFieldEventReceiver eventListener = coll.gameObject.GetComponent<IOutOfGameFieldEventReceiver>();
			if( eventListener == null )
			{
				Destroy( coll.gameObject );
			}
			else
			{
				eventListener.OnOutOfGameField();
			}
        }
    }
}
