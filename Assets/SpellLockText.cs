using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class SpellLockText : MonoBehaviour
{
    private Animation anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animation>();
        gameObject.SetActive(false);
    }

    public void Init(bool state)
    {
        gameObject.SetActive(state);
    }
    
    public IEnumerator UnlockText()
    {
        yield return new WaitForSeconds(1f);

        anim.enabled = true;
        gameObject.SetActive(true);
        anim.Play();

        yield return new WaitForSeconds(0.5f);

        anim.enabled = false;
    }
}
