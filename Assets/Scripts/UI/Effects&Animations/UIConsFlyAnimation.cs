using System.Collections;
using UnityEngine;

public class UIConsFlyAnimation : MonoBehaviour
{
	[SerializeField]
	private AnimationCurve particleFlyCurve;
	[SerializeField]
	private int particlesNumber;
	[SerializeField]
	private float spawnTime;
	public ParticleSystem effectParticles;
	[SerializeField]
	private bool animateAsLine;
	[SerializeField]
	private bool unscaledTime;
    [SerializeField]
    float speedEffect = 1;

	private ParticleSystem.Particle[] particles;

	private Vector3 startPosition, targetPosition;
	
	private float getTimeDelta
	{
		get {
			return unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
		}
	}

	public void PlayEffect()
	{
		PlayEffect(transform.position, targetPosition_EDITOR.position);
	}

	public void PlayEffect( Vector3 targetPosition )
	{
		PlayEffect( transform.position, targetPosition );
	}

    public void PlayEffect(Vector3 targetPosition, float stop)
    {
        PlayEffect(transform.position, targetPosition, stop);
    }

    public void PlayEffect( Vector3 startPosition, Vector3 targetPosition, float stopTime = -1 )
	{
		transform.position = startPosition;
		startPosition.z -= 1f;
		startPosition.z = targetPosition.z;
		this.startPosition = startPosition;
		this.targetPosition = targetPosition;

		particles = new ParticleSystem.Particle[ particlesNumber ];
		ParticleSystem.MainModule main = effectParticles.main;
		main.maxParticles = particlesNumber;

		if( animateAsLine )
		{
			StartCoroutine( SpawnParticlesCoroutine () );
			StartCoroutine( AnimateParticlesWithLerp() );
		}
		else
		{
			
			effectParticles.Emit( particlesNumber );
			StartCoroutine( AnimateParticles(stopTime) );
		}
	}

	private IEnumerator SpawnParticlesCoroutine( )
	{
		float timeElapsed = 0;
		float spawnParticleTimer = 0;
		//float spawnParticleInterval = startParticlesNumber / spawnTime;
		int particlesPerFrame;
		int particlesLeft = particlesNumber - 1;
		effectParticles.Emit( 1 );
		while( timeElapsed < spawnTime )
		{
			timeElapsed += getTimeDelta;
			spawnParticleTimer += getTimeDelta;
			particlesPerFrame = ( int ) ( spawnParticleTimer * particlesNumber );
			if( particlesPerFrame > 0 )
			{
				spawnParticleTimer = 0;
			}
			//Debug.Log( particlesPerFrame + "  " + particlesLeft );
			if( particlesPerFrame > particlesLeft )
			{
				effectParticles.Emit( particlesLeft );
				yield break;
			}
			else
			{
				particlesLeft -= particlesPerFrame;
				effectParticles.Emit( particlesPerFrame );
				if( particlesLeft == 0 )
				{
					yield break;
				}
			}
			yield return null;
		}
		if( particlesLeft > 0 )
		{
			effectParticles.Emit( particlesLeft );
		}
	}

	private IEnumerator AnimateParticles(float stop )
	{
        if(stop > 0)
        {
            yield return new WaitForSeconds(stop);
        }
		int particlesAlive = effectParticles.GetParticles( particles );
		int i;
		float normalizedLifeTime;
		while( particlesAlive > 0 )
		{
			particlesAlive = effectParticles.GetParticles( particles );
			//Debug.Log( particlesAlive );
			for( i = 0; i < particlesAlive; i++ )
			{
				normalizedLifeTime = particleFlyCurve.Evaluate( 1f - ( particles[ i ].remainingLifetime  ) / ( particles[ i ].startLifetime ) );
                particles[ i ].position += ( targetPosition - particles[ i ].position ) * Time.deltaTime * speedEffect;
                //particles[i].position = Vector3.Lerp(particles[i].position, targetPosition, Time.deltaTime * speedEffect);

            }
			effectParticles.SetParticles( particles, particlesAlive );
			yield return null;
		}
		//Debug.Log("Effect Stop");
		effectParticles.Stop();
	}

	private IEnumerator AnimateParticlesWithLerp( )
	{
		int particlesAlive = effectParticles.GetParticles( particles );
		int i;
		float normalizedLifeTime;
		while( particlesAlive > 0 )
		{
			particlesAlive = effectParticles.GetParticles( particles );
			//Debug.Log( particlesAlive );
			for( i = 0; i < particlesAlive; i++ )
			{
				normalizedLifeTime = particleFlyCurve.Evaluate( 1f - ( particles[ i ].remainingLifetime  ) / ( particles[ i ].startLifetime ) );
				particles[ i ].position = Vector3.Lerp( startPosition, targetPosition, normalizedLifeTime );
			}
			effectParticles.SetParticles( particles, particlesAlive );
			yield return null;
		}

		effectParticles.Stop();
	}

	private void Update( )
	{
		if( unscaledTime )
		{
			effectParticles.Simulate( Time.unscaledDeltaTime, false, false );
		}

		//if (animate_Editor)
		//{
		//	animate_Editor = false;
		//	StopAllCoroutines();
		//	effectParticles.Stop();
		//	effectParticles.Clear();
		//	PlayEffect(transform.position, targetPosition_EDITOR.position);
		//}
	}

	[SerializeField]
	private Transform targetPosition_EDITOR;

#if UNITY_EDITOR
	[Space(15f)]
	
	[SerializeField]
	private bool animate_Editor;

	private void OnDrawGizmosSelected( )
	{
		if( animate_Editor )
		{
			animate_Editor = false;
			StopAllCoroutines();
			effectParticles.Stop();
			effectParticles.Clear();
			PlayEffect( transform.position, targetPosition_EDITOR.position );
		}
	}
#endif
}
