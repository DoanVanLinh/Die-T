using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrder : MonoBehaviour
{
    private Camera mainCam;
    private bool isFood;
    private void Awake()
    {
        mainCam = Camera.main;
        gameObject.AddComponent<AutoDestroy>();
        SpriteRenderer thisSprite = this.GetComponent<SpriteRenderer>();
        thisSprite.sortingLayerName = ((int)transform.position.z).ToString();
        //Food
        isFood = gameObject.layer == 10?true:false;
        if (gameObject.layer == 10 && !gameObject.TryGetComponent(out BoxCollider collider))
        {
            gameObject.AddComponent<BoxCollider>();
            GetComponent<BoxCollider>().size += Vector3.forward;
        }
        else
            transform.localScale *= transform.position.z / 50f + Random.Range(9, 15) * 0.1f;
    }
    private void LateUpdate()
    {
        // if(isFood)
        //     transform.LookAt(transform.position-mainCam.transform.position);
    }
}
