using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic_Good : MonoBehaviour
{
    [SerializeField]
    private Vector3 Direction = new Vector3(-1,0,0);

    [SerializeField]
    private float Speed = 0;

    [SerializeField]
    private GameObject Blocker;
   
    [SerializeField]
    private GameObject EnemyBody;

    void Start()
    {
        EnemyBody.transform.eulerAngles -= transform.eulerAngles;
        //Debug.Log(transform.parent.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Time.deltaTime * Speed) * Direction;
    }

    public void SetDirection(Vector3 dir)
    {
        Direction = dir;
    }
}
