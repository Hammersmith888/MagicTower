using UnityEngine;
using System.Collections;

namespace MagicalFX
{
	public class FX_SpawnDirectionBarrier : MonoBehaviour
	{
		public int Number = 10;
		public float Frequency = 1;
		public bool FixRotation = false;
		public bool Normal;
		public GameObject FXSpawn;
		public float LifeTime = 0;
		public float TimeSpawn = 0;
		private float timeTemp;
		public bool UseObjectForward = true;
		public Vector3 Direction = Vector3.forward;
		public Vector3 Noise = Vector3.zero;
		
		void Start ()
		{
			counter = 0;
			timeTemp = Time.time;
			if (TimeSpawn <= 0) {
				for (int i=0; i<Number-1; i++) {
					if (UseObjectForward) {
						Direction = this.transform.forward;
					}
					Spawn (this.transform.position + (Direction * Frequency * i));
				}
				//Destroy(this.gameObject);
			}
			StartCoroutine(SetRotation());

			// Destroy(gameObject, LifeTime);
		}

		private int counter = 0;

		void Update ()
		{
            if (counter >= Number - 1)
            {
				enabled = false; // Не уничтожаем весь объект, а только выключаем скрипт, чтобы оставался коллайдер
			}
			
			if (TimeSpawn > 0.0f) {
				if (Time.time > timeTemp + TimeSpawn) {
					if (UseObjectForward) {
						Direction = this.transform.forward + (new Vector3(this.transform.right.x * Random.Range(-Noise.x,Noise.x),this.transform.right.y * Random.Range(-Noise.y,Noise.y),this.transform.right.z * Random.Range(-Noise.z,Noise.z)) * 0.01f);
					}
					Spawn (this.transform.position + (Direction * Frequency * counter));
					counter+=1;
					timeTemp = Time.time;
				}
			}
		}
		
		void Spawn (Vector3 position)
		{
			if (FXSpawn != null) {
				Quaternion rotate = this.transform.rotation;
				if (!FixRotation)
					rotate = FXSpawn.transform.rotation;
					
				GameObject fx = (GameObject)GameObject.Instantiate (FXSpawn, position, rotate);
                fx.transform.SetParent(gameObject.transform);
				if (Normal)
					fx.transform.forward = this.transform.forward;
						
				/*if (LifeTime > 0)
					GameObject.Destroy (fx.gameObject, LifeTime);*/
			}
		}

		private IEnumerator SetRotation()
        {
			int num = 0;

            while (num <= 10)
            {
				yield return new WaitForSeconds(0.001f);

				gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -num);
				num+=2;
			}
		}

	}
}
