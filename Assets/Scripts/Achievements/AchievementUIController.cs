using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Achievement
{
    public class AchievementUIController : MonoBehaviour
    {
        public static AchievementUIController instance;
        private void Awake()
        {
            instance = this;
        }

        [SerializeField]
        Transform parent;
        [SerializeField]
        GameObject prefab;

        List<AchievementItem> items = new List<AchievementItem>();

        void OnEnable()
        {
            UpdateData();
        }

        // используется еще только при получении награды
        public void UpdateData()
        {
            StartCoroutine(_Upd());
        }

        IEnumerator _Upd()
        {
            foreach (var o in items)
                Destroy(o.gameObject);
            items.Clear();
            for (int i = 0; i < AchievementController.instance.data.Count; i++)
            {
                //if (i > 5)
                //    yield return new WaitForEndOfFrame();
                GameObject obj = Instantiate(prefab, parent) as GameObject;
                AchievementItem item = obj.GetComponent<AchievementItem>();
                item.Set(AchievementController.instance.data[i]);
                items.Add(item);
            }

            Filter();

            yield return new WaitForEndOfFrame();
        }

        private void Filter()
        {
            items.Sort((x, y) => y.data.midleCount.CompareTo(x.data.midleCount));

            foreach (var achive in items)
                achive.transform.SetAsLastSibling();

            foreach (var achive in items)
            {
                if (!achive.data.save.took && achive.data.isSuccess)
                    achive.transform.SetAsFirstSibling();
                else if (achive.data.isSuccess)
                    achive.transform.SetAsLastSibling();
            }
        }
    }
}