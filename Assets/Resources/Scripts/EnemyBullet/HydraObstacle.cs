using UnityEngine;

public class HydraObstacle : MonoBehaviour {
    public int damage;

    public void AutoDestroy() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(damage);
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
        }
    }

    public void PlaySound() {
        SoundManager.Instant.PlaySound(Constant.SFX.Obstacle);
    }
}
