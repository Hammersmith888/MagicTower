using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageChanger : MonoBehaviour
{
    public Sprite ShadowImage;
    public Sprite NormalImage;
    private Image this_image;
    private bool _isNormal;
    private GameObject nextObject;
    private float _scale_x;
    private float _scale_y;
    private Button shadowButton;
    public bool isBoss = false;
    Color _color;
    public void SetColor(Color color)
    {
        this_image.color = color;
        _color = color;
    }

    // Метод Awake вызывается во время загрузки экземпляра сценария
    public void Awake()
    {
        this_image = GetComponent<Image>();
        shadowButton = GetComponent<Button>();
    }

    private void Update()
    {
        if(_color == Color.gray)
        {
            if (_color != this_image.color)
                this_image.color = _color;
        }
    }


    public void ToggleImage(bool isNormal, bool _momental)
    {
        _isNormal = isNormal;
        Sprite new_image = isNormal ? NormalImage : ShadowImage;
        if(!isBoss)
            shadowButton.interactable = isNormal;
        nextObject = Instantiate(gameObject, transform.position, Quaternion.identity) as GameObject;
        nextObject.transform.SetParent(transform);
      
        nextObject.GetComponent<Image>().sprite = new_image;

        if (gameObject.activeSelf)
        {
            if (isNormal)
            {
                _scale_x = NormalImage.bounds.size.x / ShadowImage.bounds.size.x;
                _scale_y = NormalImage.bounds.size.y / ShadowImage.bounds.size.y;
                //nextObject.transform.localScale = new Vector3(_scale_x, _scale_y, 1f);
                StartCoroutine(ShowHideSomething(gameObject, false, 1f, _momental));
                StartCoroutine(ShowHideSomething(nextObject, true, 1f, _momental));
               
            }
            else
            {
                _scale_x = 1f;
                _scale_y = 1f;
                //nextObject.transform.localScale = new Vector3(_scale_x, _scale_y, 1f);
                StartCoroutine(ShowHideSomething(gameObject, false, 1f, _momental));
                StartCoroutine(ShowHideSomething(nextObject, true, 1f, _momental));
            }
        }
    }

    IEnumerator ShowHideSomething(GameObject _obj, bool _on, float _time, bool _momental)
    {
        Image _image = _obj.GetComponent<Image>();
        float _timer = _time;
        if (!_on)
        {
            _image.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            _image.color = new Color(1f, 1f, 1f, 0f);
        }
        _obj.SetActive(true);
        if (!_momental)
        {
            while (_timer > 0f)
            {
                if (nextObject == null)
                    yield break;
                _timer -= Time.deltaTime;
                if (!_on)
                    _image.color = new Color(1f, 1f, 1f, _timer);
                else
                    _image.color = new Color(1f, 1f, 1f, 1f - _timer);
                yield return null;
            }
        }
        else
        {
            if (!_on)
                _image.color = new Color(1f, 1f, 1f, 0f);
            else
                _image.color = new Color(1f, 1f, 1f, 1f);
        }
        if (nextObject != null)
            Destroy(nextObject.gameObject);
        this_image.sprite = _isNormal ? NormalImage : ShadowImage;
        this_image.color = new Color(1f, 1f, 1f, 1f);
        //transform.localScale = new Vector3(_scale_x, _scale_y, 1f);
        yield break;
    }

}
