using UnityEngine;

public class Bullet_Bad : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D Collider;
    private Vector3 MovementVector;

    [SerializeField]
    private float Speed;

    [SerializeField]
    private string EnemyTag = "Enemy";
    [SerializeField]
    private string BlockTag = "Blocker";

    private bool HasCollided = false;
    public void SetUpBullet(Vector3 ShootVector)
    {
        MovementVector = ShootVector;
    }

    private void Update()
    {
        Vector3 newPosition = Vector3.zero; //initialize new Vector3

        newPosition.x = (Time.deltaTime * Speed) * MovementVector.x;
        newPosition.y = (Time.deltaTime * Speed) * MovementVector.y;

        transform.position = transform.position + newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!HasCollided)
        {
            string colTag = collision.gameObject.tag;
            if (colTag.Equals(EnemyTag))
            {
                Player_Bad player = GameObject.FindFirstObjectByType<Player_Bad>();// [hint] if only theres a way to give it a reference in O(1) time...
                if(player != null)
                {
                    player.GotKill(); 
                }
                Destroy(collision.transform.parent.gameObject);
                Destroy(gameObject);
            }
            else if (colTag.Equals(BlockTag))
            {
                Player_Bad player = GameObject.FindFirstObjectByType<Player_Bad>();// [hint] if only theres a way to give it a reference in O(1) time...
                if(player != null)
                {
                    player.GotKill(); 
                }                
                Destroy(gameObject);
            }
            HasCollided = true;
        }

    }

}
