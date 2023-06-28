using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinsWindow : MonoBehaviour
{

    private const string RESOURCES_PATH_FORMAT = "UI/Canvas_COINS_GET_WINDOW";
    [SerializeField]
    Text messageLbl;

    [SerializeField] private UIConsFlyAnimation effect;
    private Transform target;
    [SerializeField] private Canvas canvas;
    private Camera _camera;

    private void Start()
    {
        string scene = SceneManager.GetActiveScene().name;

        target = GameObject.FindGameObjectWithTag("CoinIcon").transform;

        if (scene == "Map")
        {
            _camera = GameObject.FindGameObjectWithTag("CameraMap").GetComponent<Camera>();
        }
        else
        {
            _camera = Camera.main;
        }
        if (_camera != null)
        {
            canvas.worldCamera = _camera;
        }
    }

    public static void Show(string message, Transform parent)
    {
        GameObject obj = Resources.Load(string.Format(RESOURCES_PATH_FORMAT)) as GameObject;

        if (obj != null && !string.IsNullOrEmpty(message))
        {
            var o = Instantiate(obj) as GameObject;
                o.GetComponentInChildren<CoinsWindow>().Init(message);
                o.transform.localPosition = Vector3.zero;
        }
    }


    // Start is called before the first frame update
    public void Init(string message)
    {
        messageLbl.text = ParseValue(message);
    }

    private string ParseValue(string message)
    {
        if (message == "10000")
        {
            return "10.000";
        }
        else if (message == "50000")
        {
            return "50.000";
        }
        else if (message == "140000")
        {
            return "140.000";
        }
        else 
        {
            return "400.000";
        }
    }

    public void Take()
    {
        effect.GetComponent<Image>().color = Color.clear;
        effect.PlayEffect(target.position);
        StartCoroutine(CloseWindow());
    }

    private IEnumerator CloseWindow()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(transform.parent.gameObject);
    }
}
