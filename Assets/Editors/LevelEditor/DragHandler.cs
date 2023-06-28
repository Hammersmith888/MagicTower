using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject enemyPrefab;
    //public GameObject casketChance, casketContent;
	public int giveAuraId;
    public static GameObject itemBeingDragged;
	public LevelEditorController levelEditorScript;
    Vector3 startPosition;

	[SerializeField]
	private Text chanceText;
	[SerializeField]
	private Dropdown contentDD;

    public void OnBeginDrag(PointerEventData _eventData)
    {
        CameraMover.scrollCanvas.SetActive(false);

        itemBeingDragged = gameObject;
        startPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData _eventData)
    {
        CameraMover.scrollCanvas.SetActive(false);


        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData _eventData)
    {
        CameraMover.scrollCanvas.SetActive(true);


        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.position = startPosition;

        // Создать врага в этой позиции
        Vector3 spawnPosition = new Vector3(Helpers.getMainCamera.ScreenToWorldPoint(_eventData.position).x, Helpers.getMainCamera.ScreenToWorldPoint(_eventData.position).y, -1);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation) as GameObject;
		EnemyCharacter enemyCharacter = enemy.GetComponent<EnemyCharacter> ();
		if (enemyCharacter != null)
			enemyCharacter.gives_aura_id = giveAuraId + 1;
        // Передаем текущие настройки сундука для данного зомби
        var editorEnemyMover = enemy.GetComponent<EditorEnemyMover>();
        if (editorEnemyMover != null && editorEnemyMover.enemyType == EnemyType.casket)
        {
            editorEnemyMover.SetCasketParameters(int.Parse(chanceText.text), contentDD.value);
		}
		levelEditorScript.SaveCurrentWave ("enemies");
    }
}