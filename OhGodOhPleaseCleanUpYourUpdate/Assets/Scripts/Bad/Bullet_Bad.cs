using UnityEngine;

public class Bullet_Bad : MonoBehaviour
{
    public CircleCollider2D Collider;
    private Vector3 MovementVector;
    public float Speed;
    public string EnemyTag = "Enemy";
    public string BlockTag = "Blocker";
    public bool HasCollided = false;

    public void SetUpBullet(Vector3 ShootVector)
    {
        MovementVector = ShootVector;
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3(0, 0, 0); //initialize new Vector3
        newPosition.x = (Time.deltaTime * Speed) * MovementVector.x;
        newPosition.y = (Time.deltaTime * Speed) * MovementVector.y;
        newPosition.z = 0f; // because floats are cool
        this.transform.position = this.transform.position + newPosition;
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
