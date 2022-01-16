using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private int timeInvisible = 0;

    private void OnBecameInvisible()
    {
        // timeInvisible++;
        // if (timeInvisible > 1)
            Destroy(gameObject);
    }
    private void Update()
    {
        if (gameObject.layer == 9 && transform.childCount == 0)
            Destroy(gameObject);
    }
}
