using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool hasCountedAsHit = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Shredders") {
            Destroy(gameObject);
        } else if(other.gameObject.tag == "Enemy" && !hasCountedAsHit) {
            hasCountedAsHit = true;
            StatisticsManager.Instance.HandleBulletHit();
        }
    }
}
