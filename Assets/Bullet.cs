using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("KillMe", 10);
    }

    public void KillMe()
    {
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3.MoveTowards(transform.position, target.transform.position, speed);
    }
}
