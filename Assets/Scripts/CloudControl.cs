using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    private int timeInvisible = 0;
    void Start()
    {
        direction = Random.Range(-1f, 1f) > 0 ? Vector3.right : Vector3.left;
        speed = Random.Range(0.2f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
    private void OnBecameInvisible()
    {
        timeInvisible++;
        if(timeInvisible>1)
            Destroy(gameObject);
    }
}
