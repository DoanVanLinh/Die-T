using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour
{
    private Vector3 direction;
    private float speed;

    void Start()
    {
        direction = Random.Range(-1f, 1f) > 0 ? Vector3.right : Vector3.left;
        speed = Random.Range(0.2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }
}
