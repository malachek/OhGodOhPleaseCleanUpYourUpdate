using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D Collider;

    private Player player;

    private Vector3 MovementVector;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private string EnemyTag = "Enemy";
    [SerializeField]
    private string BlockTag = "Blocker";

    private bool HasCollided = false;
    public void SetUpBullet(Player playerRef, Vector3 ShootVector)
    {
        player = playerRef;
        MovementVector = ShootVector;
    }

    private void Update()
    {
        transform.position += (Time.deltaTime * Speed) * MovementVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!HasCollided)
        {
            if (collision.gameObject.CompareTag(EnemyTag))
            {
                player.OnBulletHitOrBlock(true);
                Destroy(collision.transform.parent.gameObject);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag(BlockTag))
            {
                player.OnBulletHitOrBlock(false);
                Destroy(gameObject);
            }
            HasCollided = true;
        }

    }
}
