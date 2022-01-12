using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrder : MonoBehaviour
{
    private void Awake()
    {
        this.GetComponent<SpriteRenderer>().sortingOrder = -(int)transform.position.z;
        if (gameObject.layer == 6)
        {
            gameObject.AddComponent<BoxCollider>();
            GetComponent<BoxCollider>().size += Vector3.forward;
        }
    }
}
