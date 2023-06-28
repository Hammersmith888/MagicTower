
using UnityEngine;

namespace Animations
{
    public class Blinking : MonoBehaviour
    {
        [SerializeField]
        private Renderer Target;
        [SerializeField]
        private float timeBetweenBlinks;
        [SerializeField]
        private float visibleStateTime;

        [SerializeField]
        private bool autoStart;

        private float timer;

        private bool isBlinking;

        private void Awake()
        {
            this.GetComponentIfNull<Renderer>(ref Target);
            if (autoStart)
            {
                StartBlinking();
            }
        }

        public void StartBlinking()
        {
            if (!isBlinking)
            {
                isBlinking = true;
                timer = 0;
            }
        }


        public void StopBlinking()
        {
            if (isBlinking)
            {
                isBlinking = false;
            }
        }

        private void Update()
        {
            if (isBlinking)
            {
                timer += Time.deltaTime;

                if (Target.enabled)
                {
                    if (timer >= visibleStateTime)
                    {
                        timer = 0;
                        Target.enabled = false;
                    }
                }
                else
                {
                    if (timer >= timeBetweenBlinks)
                    {
                        timer = 0;
                        Target.enabled = true;
                    }
                }
            }
        }

    }
}
