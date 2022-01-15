using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrder : MonoBehaviour
{
    private void Awake()
    {
        SpriteRenderer thisSprite = this.GetComponent<SpriteRenderer>();
        thisSprite.sortingLayerName = ((int)transform.position.z).ToString();
        if (gameObject.layer == 6)
        {
            gameObject.AddComponent<BoxCollider>();
            GetComponent<BoxCollider>().size += Vector3.forward;
        }
        transform.localScale *= transform.position.z/50f + Random.Range(1,15)*0.1f;
    }
}
