using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Range(0.01f,10f)]
    [SerializeField]private float smooth = 5f;
    private Camera mainCamera;
    private Vector3 distant;
    private Vector3 cameraPosition;
    private void Awake() {
        mainCamera = Camera.main;
        distant = mainCamera.transform.position - transform.position;
    }

    // Update is called once per frame
    private void LateUpdate() {
        cameraPosition = transform.position + distant;
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position ,cameraPosition,smooth * Time.deltaTime);
    }
}
