
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorials
{
    public static class TutorialUtils
    {
        public class TutorialCanvasOverride
        {
            private const int StartSortingOrder = 10;
            private int currentSortingOrder;

            public static event System.Action OnCanvasOverrideCleared;

            private static TutorialCanvasOverride m_Current;
            public static TutorialCanvasOverride Current
            {
                get
                {
                    if (m_Current == null)
                    {
                        m_Current = new TutorialCanvasOverride();
                    }
                    return m_Current;
                }
            }

            private List<Tuple<Canvas,GraphicRaycaster>> currentOverridenCanvas;

            public TutorialCanvasOverride()
            {
                currentSortingOrder = StartSortingOrder;
                currentOverridenCanvas = new List<Tuple<Canvas, GraphicRaycaster>>();
            }

            public void AddObjects(GameObject[] objects, bool addRaycaster = true)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    //Debug.LogFormat("<b>{0}</b> {1} {2}", objects[i].name,
                    //    objects[i].activeInHierarchy,
                    //    objects[i].transform.parent.gameObject.activeInHierarchy);
                    objects[i].SetActive(true);
                    var canvas = objects[i].AddComponent<Canvas>();
                    canvas.overrideSorting = true;
                    canvas.sortingOrder = currentSortingOrder;

                    GraphicRaycaster graphicRaycaster = null;
                    if (addRaycaster)
                    {
                        graphicRaycaster = objects[i].AddComponent<GraphicRaycaster>();
                    }
                    currentOverridenCanvas.Add(new Tuple<Canvas, GraphicRaycaster>() { object1 = canvas, object2 = graphicRaycaster });
                }
                currentSortingOrder++;
            }

            public static void ClearOverries(bool dispose = true)
            {
                if (m_Current != null)
                {
                    var currentOverridenCanvas = m_Current.currentOverridenCanvas;
                    var count = currentOverridenCanvas.Count;

                    for (int i = 0; i < count; i++)
                    {
                        if (currentOverridenCanvas[i].object2 != null)
                        {
                            Component.Destroy(currentOverridenCanvas[i].object2);
                        }

                        Component.Destroy(currentOverridenCanvas[i].object1);
                    }
                    OnCanvasOverrideCleared.InvokeSafely();
                    currentOverridenCanvas.Clear();
                    m_Current.currentSortingOrder = StartSortingOrder;
                    m_Current = null;
                }
            }
        }

        public static void AddCanvasOverride(params GameObject[] gameObjects)
        {
            TutorialCanvasOverride.Current.AddObjects(gameObjects);
        }

        public static void AddCanvasOverrideWithoutRaycaster(params GameObject[] gameObjects)
        {
            TutorialCanvasOverride.Current.AddObjects(gameObjects, false);
        }

        public static void ClearAllCanvasOverrides()
        {
            TutorialCanvasOverride.ClearOverries();
        }

    }
}
