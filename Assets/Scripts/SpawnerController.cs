using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] BoxCollider2D[] spawners;

    public void Spawn(SpawnerEnum from, Enemy prefab) {
        int idx = (int)from;
        Vector3 position = ChooseSpotWithinBounds(spawners[idx]);
        Enemy enemy = Instantiate(prefab, position, Quaternion.identity);
        enemy.SetPlayer(player);
    }

    public void Spawn(SpawnerEnum from, Enemy prefab, System.Action enemyKilledHandler) {
        int idx = (int)from;
        Vector3 position = ChooseSpotWithinBounds(spawners[idx]);
        Enemy enemy = Instantiate(prefab, position, Quaternion.identity);
        enemy.OnEnemyKilled += enemyKilledHandler;
        enemy.SetPlayer(player);
    }

    private Vector3 ChooseSpotWithinBounds(BoxCollider2D spawner) {
        float xPos = Mathf.Round(Random.Range(spawner.bounds.min.x, spawner.bounds.max.x));
        float yPos = Mathf.Round(Random.Range(spawner.bounds.min.y, spawner.bounds.max.y));

        return new Vector3(xPos, yPos, 0);
    }
}
