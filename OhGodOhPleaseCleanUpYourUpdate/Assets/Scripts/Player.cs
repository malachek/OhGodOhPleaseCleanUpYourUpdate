using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private int MaxBullets = 5;
    private int BulletCount = 0;

    [SerializeField]
    private GameObject Bullet;


    public delegate void PlayerShoot(float CurrentAmmoPercent);
    public PlayerShoot OnPlayerShoot;

    public delegate void BulletHitOrBlock(bool IsHit);
    public BulletHitOrBlock OnBulletHitOrBlock;

    void Start()
    {
        //BulletCount = MaxBullets;
        Reload();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();   
        }
    }

    private void Shoot()
    {
        if (BulletCount > 0) {
            BulletCount--;
            OnPlayerShoot?.Invoke(BulletCount / (float)MaxBullets);
            Bullet b = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
            b.SetUpBullet(this, transform.up);
        }

    }

    private void Reload()
    {
        BulletCount = MaxBullets;
        OnPlayerShoot?.Invoke(BulletCount / (float)MaxBullets);
    }
}
