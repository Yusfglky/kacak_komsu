using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Karakterler")]
    public float karakter_rotate;
    public float karakter_donus_hizi;           
    void Update()
    {
        transform.Rotate(0, karakter_rotate + karakter_donus_hizi * (Time.deltaTime), 0);
    }               
}
