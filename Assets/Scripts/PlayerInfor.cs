using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfor : MonoBehaviour
{
    // [SerializeField] public BMI currentBMI = BMI.Normal;

    public float CurrentBMI { get; set; }

    void Awake()
    {
            CurrentBMI = (int)BMI.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CurrentBMI,gameObject);
    }

}
// public enum BMI { Thin = 18, Normal = 25, Fat = 35 };
