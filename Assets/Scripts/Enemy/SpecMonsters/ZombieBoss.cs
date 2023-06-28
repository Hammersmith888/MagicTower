
using System.Collections;
using UnityEngine;

public class ZombieBoss : MonoBehaviour
{
    [SerializeField]
    private EnemyCharacter character;

    [SerializeField]
    private GameObject summonPrefab;

    [SerializeField]
    public CharacterReplicaLauncher characterReplicaLauncher;

    private void Awake()
    {
        character.getEnemySoundController.DisableWalkSound();
    }

    private void Start()
    {
        //if (LevelSettings.Current.currentLevel != 1)
        if (LevelSettings.Current.currentLevel > 1)
        {
            Destroy(this);
            return;
        }
        characterReplicaLauncher.showReplicaManually = true;
        character.gameObject.Toggle2DColiders<Collider2D>(false);
        character.SetMovementType(EnemyMovementType.stop);
        character.gold = 0;
        character.canBeAutoAttacked = false;
        EnemiesGenerator.Instance.progressBar.AddEnteredHealth(character.health);
        StartCoroutine(MoveIn());
    }

    private IEnumerator MoveIn()
    {
        ShotController.Current.canShot = false;
        float speed = 7.5f;
        while (transform.position.x > character.invunarableDistance - 2f)
        {
            character.SetPosition(transform.position + new Vector3(-speed * Time.deltaTime, 0, 0));
            yield return null;
        }
        StartCoroutine(CheckDialogPosition());
        yield break;
    }

    private IEnumerator CheckDialogPosition()
    {
        while (transform.position.x > character.invunarableDistance - 2f)
        {
            yield return new WaitForSeconds(0.1f);
        }

        characterReplicaLauncher.ShowReplicaManual();
        yield return new WaitForSeconds(1f);
        Spawn();
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MoveBack());
        ShotController.Current.canShot = true;
        yield break;
    }

    private IEnumerator MoveBack()
    {
        transform.Rotate(new Vector3(0f, 240f, 0f));
        float speed = 2.5f;
        var mainCameraTransform = Helpers.getMainCamera.transform;
        while (transform.position.x < character.invunarableDistance + 2f)
        {
            character.SetPosition(transform.position + new Vector3(speed * Time.deltaTime, 0, 0));
            yield return null;
        }
        character.Death();
        yield break;
    }

    public void Spawn()
    {
        EnemiesGenerator.Instance.CreateEnemy(EnemyType.zombie_walk, new Vector3(transform.position.x - 1.7f, transform.position.y + 0.3f, transform.position.z), true, true);
        EnemiesGenerator.Instance.CreateEnemy(EnemyType.zombie_walk, new Vector3(transform.position.x - 1.7f, GameConstants.MaxBottomBorder * 0.6f, transform.position.z), true, true);
        EnemiesGenerator.Instance.CreateEnemy(EnemyType.zombie_walk, new Vector3(transform.position.x - 1.7f, GameConstants.MaxTopBorder * 0.6f, transform.position.z), true, true);
    }
}
