using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] TMP_Text pointer;
    public static int pointCount = 0;

    void Start()
    {
        
    }

    void Update()
    {
        pointer.text = pointCount.ToString();
    }
}