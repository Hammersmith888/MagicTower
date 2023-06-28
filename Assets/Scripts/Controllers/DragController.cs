using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler {

    // Номер кнопки заклинания
    public int spellBtn;
    public GameObject spellIcon; // Визуальное отображение заклинания которое перетаскиваем

    // Выстрелы
    public ShotController shotController;

    private Vector3 startIconPos;

    void Start () {
        startIconPos = spellIcon.transform.position;
    }

    public virtual void OnPointerDown(PointerEventData pointerEventData)
    {
        shotController.SetActiveSpell(spellBtn);
    }

    public virtual void OnDrag(PointerEventData pointerEventData)
    {
        if(shotController.ActiveSpell.MayShot)
        {
            spellIcon.transform.position = pointerEventData.position;
            spellIcon.SetActive(true);
        }
    }

    public virtual void OnPointerUp(PointerEventData pointerEventData)
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            DefaultSpellState();
            return;
        }

        shotController.Shot(pointerEventData.position);
        DefaultSpellState();
    }

    // Восстанавливаем начальное состояние отображения заклинания
    private void DefaultSpellState()
    {
        spellIcon.SetActive(false);
        spellIcon.transform.position = startIconPos;
    }
}