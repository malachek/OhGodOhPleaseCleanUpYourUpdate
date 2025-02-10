using System.Collections;
using UnityEngine;

public class EnemySpawnner_Good : MonoBehaviour
{
    [SerializeField]
    private Vector2 RandomVariation = new Vector2(-.5f,.5f);

    [SerializeField]
    private float BaseTimeBetweenSpawns = 2f;

    [SerializeField]
    private bool CanSpawn = true;

    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private float[] SpawnAngles = { 0, -90, 180, 90 };
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTimer()
    {
        EnemyLogic_Good e = Instantiate(EnemyPrefab, transform.position, Quaternion.Euler(0, 0, SpawnAngles[Random.Range(0, SpawnAngles.Length - 1)])).GetComponent<EnemyLogic_Good>();
        e.SetDirection(-transform.right);

        float TimeToSpawn = BaseTimeBetweenSpawns + Random.Range(RandomVariation.x, RandomVariation.y);
        yield return new WaitForSeconds(TimeToSpawn);
        if (CanSpawn)
        {
            StartCoroutine(SpawnTimer());
        }
    }

 }
