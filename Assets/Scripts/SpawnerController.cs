using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] BoxCollider2D[] spawners;

    [SerializeField] LevelPlayer levelPlayer;
    [SerializeField] GameManager gameManager;

    public void SpawnNoActions(SpawnerEnum from, Enemy prefab) {
        int idx = (int)from;
        Vector3 position = ChooseSpotWithinBounds(spawners[idx]);
        Enemy enemy = Instantiate(prefab, position, Quaternion.identity);
        enemy.SetPlayer(player);
    }

    public void Spawn(SpawnerEnum from, Enemy prefab) {
        int idx = (int)from;
        Vector3 position = ChooseSpotWithinBounds(spawners[idx]);
        Enemy enemy = Instantiate(prefab, position, Quaternion.identity);
        enemy.OnEnemyKilled += levelPlayer.EnemyKilled;
        enemy.OnEnemyKilled += gameManager.EnemyKilled;
        enemy.SetPlayer(player);
        enemy.SetSpawnedFrom(from);
    }

    private Vector3 ChooseSpotWithinBounds(BoxCollider2D spawner) {
        float xPos = Mathf.Round(Random.Range(spawner.bounds.min.x, spawner.bounds.max.x));
        float yPos = Mathf.Round(Random.Range(spawner.bounds.min.y, spawner.bounds.max.y));

        return new Vector3(xPos, yPos, 0);
    }
}
