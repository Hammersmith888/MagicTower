using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class FadeInOutParticles : MonoBehaviour {

  private EffectSettings effectSettings;
  private ParticleSystem[] particles;
  private bool oldVisibleStat;

  private void GetEffectSettingsComponent(Transform tr)
  {
    var parent = tr.parent;
    if (parent != null)
    {
      effectSettings = parent.GetComponentInChildren<EffectSettings>();
      if (effectSettings == null)
        GetEffectSettingsComponent(parent.transform);
    }
  }
  
  void Start()
  {
    GetEffectSettingsComponent(transform);
		if (effectSettings == null)
			return;
    particles  = effectSettings.GetComponentsInChildren<ParticleSystem>();
    oldVisibleStat = effectSettings.IsVisible;
  }

  void Update()
  {
		if (effectSettings == null)
			return;
    if (effectSettings.IsVisible!=oldVisibleStat) {
      if (effectSettings.IsVisible)
        foreach (var particle in particles) {
            if (effectSettings.IsVisible)
            {
                particle.Play();
                var emiss = particle.emission;
                emiss.enabled = false;
            }
        }
      else
        foreach (var particle in particles) {
            if (!effectSettings.IsVisible)
            {
                particle.Stop();
                var emiss = particle.emission;
                emiss.enabled = false;
            }
        }
    }
    oldVisibleStat = effectSettings.IsVisible;
  }

}
