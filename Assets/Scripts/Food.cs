using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Food", menuName = "Die - t/Food", order = 0)]
public class Food : ScriptableObject {
    public string name;
    public float protein;
    public GameObject prefab;
}