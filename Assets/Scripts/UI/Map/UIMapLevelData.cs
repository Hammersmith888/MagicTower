using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMapLevelData : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    private Button openedLvlBtn;
    [SerializeField]
    private Button completedLvlBtn;
    [SerializeField]
    private Text levelNumberLabel;
    [SerializeField]
    private Image lockIcon;
    [SerializeField]
    private GameObject backBoard;
    [SerializeField]
    private Transform arrowAnchorTransform;
    public ImageChanger shadowImageChanger;

    private int levelNumber;
    private System.Action<int> onLevelClick;

    [SerializeField]
    UIConsFlyAnimation fly;



    #endregion

    #region PROPERTIES
    public ImageChanger getShadowImageChanger
    {
        get
        {
            return shadowImageChanger;
        }
    }

    public GameObject getBackBoardObj
    {
        get
        {
            return backBoard;
        }
    }

    public Image getLockIcon
    {
        get
        {
            return lockIcon;
        }
    }

    public Vector3 getArrowAnchorPos
    {
        get
        {
            return arrowAnchorTransform.position;
        }
    }

    public float GetXPosition
    {
        get
        {
            return transform.position.x;
        }
    }
    #endregion

    public void Init(int levelNumber, System.Action<int> onLevelClick)
    {
        this.levelNumber = levelNumber;
        levelNumberLabel.text = levelNumber.ToString();

        this.onLevelClick = onLevelClick;

        openedLvlBtn.onClick.AddListener(OnLevelClick);
        completedLvlBtn.onClick.AddListener(OnLevelClick);
    }

    public void PlayFly(Vector3 pos, float stop)
    {
        fly.gameObject.SetActive(true);
        fly.PlayEffect(pos, stop);
    }

    private void OnLevelClick()
    {
        onLevelClick.Invoke(levelNumber);
        UIMap.currentLevel = levelNumber;
    }

    public void ToggleBetweenOpenedOrCompletedState(bool opened)
    {
        openedLvlBtn.gameObject.SetActive(opened);
        completedLvlBtn.gameObject.SetActive(!opened);
    }

    public void ToggleLockAndBackBoard(bool lockIconState, bool boardState)
    {
        lockIcon.enabled = lockIconState;
        backBoard.SetActive(boardState);
    }

    public void ToggleLevelButtonsState(bool enabled)
    {
        openedLvlBtn.enabled = enabled;
        completedLvlBtn.enabled = enabled;
    }

    public void ShowCompletedAndHideOpenedButtons(bool _on, float _time, bool _momental, float delay)
    {
        StartCoroutine(ShowHideSomething(completedLvlBtn.gameObject, _on, _time, _momental, delay, true));
        StartCoroutine(ShowHideSomething(openedLvlBtn.gameObject, !_on, _time, _momental, delay, false));
        openedLvlBtn.enabled = true;
    }

    IEnumerator ShowHideSomething(GameObject _obj, bool _on, float _time, bool _momental, float delay, bool complete)
    {
        yield return new WaitForSeconds(delay);
        _obj.SetActive(true);
        Image _image = _obj.GetComponent<Image>();
        _image.enabled = true;
        float _timer = _time + 0.00001f;
        if (!_on)
        {
            _image.color = new Color(!complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, 1f);
        }
        else
        {
            _image.color = new Color(!complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, 0f);
        }
        if (!_momental)
        {
            while (_timer > 0f)
            {
                _timer -= Time.deltaTime;
                if (!_on)
                    _image.color = new Color(!complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, _timer);
                else
                    _image.color = new Color(!complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, 1f - _timer);
                yield return null;
            }
        }
        else
        {
            if (!_on)
                _image.color = new Color(!complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, 0f);
            else
                _image.color = new Color(!complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, !complete ? 1f : 0.6603774f, 1f);
        }
        _image.enabled = _on;
        yield break;
    }


//#if UNITY_EDITOR
//    [SerializeField]
//    private bool pickReferences_EDITOR = true;
//    private void OnDrawGizmos()
//    {
//        if (pickReferences_EDITOR)
//        {
//            pickReferences_EDITOR = false;
//            openedLvlBtn = transform.Find("Icon").GetComponent<Button>();
//            completedLvlBtn = transform.Find("Open2Icon").GetComponent<Button>();
//            levelNumberLabel = transform.GetComponentInChildren<Text>();
//            lockIcon = transform.Find("Block").GetComponent<Image>();
//            backBoard = transform.Find("Block").Find("back_board").gameObject;
//            arrowAnchorTransform = transform.Find("arrowAnchor");
//            shadowImageChanger = GetComponentInChildren<ImageChanger>();
//        }
//    }

//    public void InitInEditor(int levelNumber, bool deleteShadow = true)
//    {
//        levelNumberLabel.text = levelNumber.ToString();
//        gameObject.name = "Level_" + levelNumber.ToString();
//        if (deleteShadow && shadowImageChanger != null)
//        {
//            DestroyImmediate(shadowImageChanger.gameObject);
//        }
//    }
//#endif
}
