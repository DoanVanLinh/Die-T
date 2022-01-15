using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Country
{
    public string name;
    public GameObject road;
    public List<GameObject> building = new List<GameObject>();
    public List<GameObject> detailObject = new List<GameObject>();
}