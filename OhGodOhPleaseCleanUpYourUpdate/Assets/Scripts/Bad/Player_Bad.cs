using UnityEngine;

public class Player_Bad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int MaxBullets = 5;
    private int BulletCount;

    [SerializeField] private GameObject Bullet;

    public delegate void PlayerShoot(float CurrentAmmoPercent);
    public PlayerShoot OnPlayerShoot;

    public delegate void BulletHitOrBlock(bool IsHit);
    public BulletHitOrBlock OnBulletHitOrBlock;

    void Start()
    {
        //BulletCount = MaxBullets;
        for (int i = BulletCount; i < MaxBullets; i++) //realistic reloading, 1 at a time
        {
            BulletCount = BulletCount + 1;
        }
        float BulletPercent = BulletCount / (float)MaxBullets;
        OnPlayerShoot?.Invoke(BulletPercent);
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width / 2;

        var mouseRotation = (mousePosition - gameObject.transform.position).normalized;

        bool canShoot;
        BulletCount = BulletCount - 1;
        if (BulletCount >= -1)
        {
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
                float BulletPercent = BulletCount / (float)MaxBullets;
                OnPlayerShoot?.Invoke(BulletPercent);
                Bullet_Bad b = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet_Bad>();
                b.SetUpBullet(this, mousePosition);
            }
        }
        else
        {
            BulletCount = BulletCount + 1;
        }
        var isRKeyNotPressed = !Input.GetKeyDown(KeyCode.R);
        if(isRKeyNotPressed != true) 
        {
            for (int i = BulletCount; i < MaxBullets; i++) //realistic reloading, 1 at a time
            {
                BulletCount = BulletCount + 1;
            }
            float BulletPercent = BulletCount / (float)MaxBullets;
            OnPlayerShoot?.Invoke(BulletPercent);
        }
        // ^ this code make it reloads
        
    } 
}
