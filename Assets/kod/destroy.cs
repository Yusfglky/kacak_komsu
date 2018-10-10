using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float kaybolma_suresi;
    public float verilecek_puan;
    public GameObject particle;
    public static bool dead;
    private void Start()
    {                                                                
        Destroy(gameObject, kaybolma_suresi);
    }                             
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "silah")
        {
            if (karakter_control.hit_)
            {
                if (karakter_control.vurulabilir)
                {
                    karakter_control.hit_ = false;
                    karakter_control.vurulabilir = false;
                    canvas_ozellikleri._puan += verilecek_puan;
                    Destroy(gameObject.transform.parent.gameObject);
                }
            }
        }
        if (col.collider.name== "head_")
        {                                 
            dead = true;
        }
        if (col.collider.name=="alt")
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (!particle.activeInHierarchy)
            {   
                particle.SetActive(true);
            }       
        }
    }               
}                                                      