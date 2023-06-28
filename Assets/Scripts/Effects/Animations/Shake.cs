using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animations
{
    public class Shake : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve shakeCurve;
        [SerializeField]
        private float shakeTime;
        [SerializeField]
        private FloatRange shakePowerOverTime;


        [Space(10f)][SerializeField]
        private Vector3 range;
        [SerializeField]
        private float   timeInterval;


        private BaseTimer shakeIntervalTimer;
        private BaseTimer shakeTimer;
        private Vector3 startPosition;

        private Transform _transform;

        private void Awake()
        {
            shakeIntervalTimer = new BaseTimer(timeInterval);
            shakeTimer = new BaseTimer(shakeTime, true );
            _transform = transform;
            startPosition = _transform.localPosition;
            UpdateShake();
        }

        public void StopShake()
        {
            shakeIntervalTimer.Pause();
            _transform.localPosition = startPosition;
        }

        private void UpdateShake()
        {
            shakeIntervalTimer.Start();
            _transform.localPosition = startPosition + new Vector3(Random.Range(-range.x,range.x), Random.Range(-range.y, range.y), Random.Range(-range.z, range.z)) 
                * shakePowerOverTime.Lerp(shakeCurve.Evaluate(shakeTimer.progress));
        }


        private void Update()
        {
            if (shakeIntervalTimer.Update(Time.deltaTime))
            {
                UpdateShake();
            }
            if (shakeTimer.Update(Time.deltaTime))
            {
                StopShake();
            }
        }
    }
}
