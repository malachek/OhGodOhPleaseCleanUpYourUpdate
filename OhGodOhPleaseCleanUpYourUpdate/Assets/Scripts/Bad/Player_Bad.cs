using UnityEngine;
using System.Collections.Generic;

public class Player_Bad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int MaxBullets = 5;
    public int BulletCount;

    public GameObject Bullet;
    public int Kills;
    public int Blocks;

    void Start()
    {
        Kills = 0;
        Blocks = 0;
        BulletCount = MaxBullets;
        // [hint] maybe something about UIManager_Bad goes here
        // [hint] maybe an event call idk
    }

    void Update()
    {
        float startTime = Time.time; // [DO_NOT_EDIT]

        var mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2; // [insight] mousePosition origin is bottom left, so this puts it in the middle

        var mouseVector = (mousePosition - gameObject.transform.position).normalized;

        bool canShoot;
        if (BulletCount >= 1)
        {
            BulletCount = BulletCount - 1; // shoot it now so i dont have to later
            Debug.Log("Can shoot!" + " " + "My bullets after shooting =" + (BulletCount + 1));
            canShoot = true;
        }
        else
        {
            Debug.Log("I can't shoot");
            canShoot = false;
        }

        bool isKKeyPressed = Input.GetKeyDown(KeyCode.K);
        if(canShoot)
        {
            // shooting code
            if (isKKeyPressed == true)
            {
                // [insight] instantiate prefab
                Bullet_Bad b = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet_Bad>();
                // [insight] give it "default values"
                b.SetUpBullet(mouseVector);
            }
            else
            {
                BulletCount = BulletCount + 1; // get the bullet back, just in case i dont actually shoot it
            }
        }
        var isRKeyNotPressed = !Input.GetKeyDown(KeyCode.R);
        if(isRKeyNotPressed != true) 
        {
            //realistic loading
            BulletCount = 0; //empty the mag
            for (int i = BulletCount; i < MaxBullets; i++) //fill it up, one at a time
            {
                BulletCount = BulletCount + 1;
            }
        }
        // ^ this code make it reloads

        Debug.Log(Time.time - startTime); // [DO_NOT_EDIT]
    } 


    public void GotKill()
    {
        Kills++;
    }

    public void GotBlocked()
    {
        Blocks++;
    }
}
