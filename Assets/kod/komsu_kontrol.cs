using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class komsu_kontrol : MonoBehaviour
{
    public Animator my_anim;
    public Transform walk_pos;
    public List<GameObject> atilacaklar;
    public int rnd;
    [Header("Obje Takip")]
    public GameObject hedef;
    public GameObject drop_pos;
    public float takip_hizi;
    public float atis_hizi;
    public bool atiliyor;
    public bool atis_bitir;
    void Start()
    {
        StartCoroutine(atis_bekle());
        rnd = Random.Range(0, atilacaklar.Count);
        atilacaklar[rnd].SetActive(true);
    }
    private void Update()
    {
        obje_takip();
    }
    void obje_takip()
    {
        if (!atiliyor)
        {
            atilacaklar[rnd].transform.position = Vector3.MoveTowards(atilacaklar[rnd].transform.position, hedef.transform.position, takip_hizi);  
        }
        /* else
         {      
                 if (!atis_bitir)
                 {
                     atilacaklar[rnd].transform.position = Vector3.MoveTowards(atilacaklar[rnd].transform.position, GameObject.Find("head_").transform.position, atis_hizi);
                 }  
             Invoke("atis_tamamla", 0.6f);
         }    
     }
     void atis_tamamla()
     {
         atis_bitir = true;    */
    }
    public IEnumerator atis_bekle()
    {
        yield return new WaitForSeconds(1.6f);
        transform.position = walk_pos.position;
        transform.localRotation = walk_pos.localRotation;
        esya_spawn();
        my_anim.SetBool("walk", true);
        Destroy(gameObject.transform.parent.gameObject, 3.5f);
    }
    void esya_spawn()
    {
        atilacaklar[rnd].GetComponent<Rigidbody>().useGravity = true;
        atilacaklar[rnd].gameObject.tag = "esya";
        atiliyor = true;
    }
}
