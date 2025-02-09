using NUnit.Framework;
using UnityEngine;

public class EnemyDespawner : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D BoxCollider2D;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy")){
            Destroy(collision.transform.parent.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Bullet")) { 
            Destroy(collision.gameObject);
        }
    }
}
