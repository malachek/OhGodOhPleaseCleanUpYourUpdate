using UnityEngine;

public class Player_Good : MonoBehaviour
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
        Reload();
    }

    // Update is called once per frame
    void Update()
    {
        float startTime = Time.time; // DO NOT EDIT
        HandleInput();
        Debug.Log(Time.time - startTime); // DO NOT EDIT
    }

    private void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.K)) Shoot();
        if(Input.GetKeyDown(KeyCode.R)) Reload();   
    }

    private void Shoot()
    {
        // object pool????
        if (BulletCount <= 0.1f) return;
        
        Vector3 mouseRotation = GetMouseRotation();
        OnPlayerShoot?.Invoke((float)--BulletCount / MaxBullets); //cleaner and safer to float the numerator than denominator
        Bullet_Good b = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Bullet_Good>();
        b.SetUpBullet(this, mouseRotation);
    }

    private Vector3 GetMouseRotation()
    {
        //return (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.x -= Screen.width * 0.5f; //better than /2, mult more efficient than div, also assumes floats
        return (mousePosition - gameObject.transform.position).normalized;
    }
    private void Reload()
    {
        BulletCount = MaxBullets;
        OnPlayerShoot?.Invoke(1f); // 1f = BulletCount / (float)MaxBullets
    }
}
