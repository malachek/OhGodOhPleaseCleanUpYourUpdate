using UnityEngine;

public class Bullet_Bad : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D Collider;

    private Player_Bad player;

    private Vector3 MovementVector;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private string EnemyTag = "Enemy";
    [SerializeField]
    private string BlockTag = "Blocker";

    private bool HasCollided = false;
    public void SetUpBullet(Player_Bad playerRef, Vector3 ShootVector)
    {
        Debug.Log("1");
        player = playerRef;
        MovementVector = ShootVector;
        Debug.Log("2");
    }

    private void Update()
    {
        Debug.Log("3");
        transform.position += (Time.deltaTime * Speed) * MovementVector;
        Debug.Log("4");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!HasCollided)
        {
            Debug.Log(collision.gameObject.tag);
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
