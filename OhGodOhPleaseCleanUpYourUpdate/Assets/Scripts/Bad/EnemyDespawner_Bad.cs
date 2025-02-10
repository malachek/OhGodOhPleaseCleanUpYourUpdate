using NUnit.Framework;
using UnityEngine;

public class EnemyDespawner_Bad : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D BoxCollider2D;


    void Start()
    {
        // doesnt need a Start
    }

    // Update is called once per frame
    void Update()
    {
        // doesnt need an Update
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy")){
            Debug.Log($"Destroying { collision.gameObject.tag}"); 
            Destroy(collision.transform.parent.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Bullet")) {
            Debug.Log($"Destroying {collision.gameObject.tag}");
            Destroy(collision.gameObject);
        }
    }
}
