using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FastLinkGameobjectsLists : MonoBehaviour
{
    [System.Serializable]
    public class IList
    {
        public List<GameObject> innerList = new List<GameObject> ();
    }
    public List<IList> bigSheet = new List<IList>();
}
