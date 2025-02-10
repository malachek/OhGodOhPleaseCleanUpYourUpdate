using UnityEngine;

public class Bullet_Good : MonoBehaviour
{
    private Player_Good player;
    private Vector3 movementVector;
    private bool HasCollided = false;

    [SerializeField] private float speed;

    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private string blockTag = "Blocker";

    public void SetUpBullet(Player_Good playerRef, Vector3 shootVector)
    {
        player = playerRef;
        movementVector = speed * shootVector;
    }

    private void Update()
    {
        transform.position += Time.deltaTime * movementVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(HasCollided) return;
        
        if (collision.gameObject.CompareTag(enemyTag))
        {
            player.OnBulletHitOrBlock(true);
            Destroy(collision.transform.parent.gameObject);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag(blockTag))
        {
            player.OnBulletHitOrBlock(false);
            Destroy(gameObject);
        }
        HasCollided = true;

    }
}
