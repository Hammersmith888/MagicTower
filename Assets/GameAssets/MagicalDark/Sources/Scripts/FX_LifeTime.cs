using UnityEngine;
using System.Collections;

namespace MagicalFX
{
	public class FX_LifeTime : MonoBehaviour
	{
		public float LifeTime = 3;
		public GameObject SpawnAfterDead;
		private float spawnTime;

		void Start()
		{
            try
            {
				SpawnAfterDead = this.gameObject.transform.parent.GetComponent<GameObject>();
				spawnTime = Time.time;
				StartCoroutine(DestroyDelayCoroutine());
			}
			catch
            {
				GameObject.Destroy(this.gameObject, LifeTime);
            }
		}

		private IEnumerator DestroyDelayCoroutine( )
		{
			while( Time.time - spawnTime < LifeTime )
			{
				yield return null;
			}
            try
            {
                Instantiate(SpawnAfterDead, this.transform.position, SpawnAfterDead.transform.rotation);
            }
            catch (System.Exception) { }

            Destroy( this.gameObject );
		}
	}
}