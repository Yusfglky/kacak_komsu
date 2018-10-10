using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Control : MonoBehaviour
{
    public List<Transform> komsu_spawn;
    public List<GameObject> komsular;
    public List<GameObject> pencere_anim;
    [Header("Komsu Spawn Count")]        
    private bool komsu_yarat=true;
    private int rnd;
    public bool komsu_yaratma;   
    private void Start()
    {        
        StartCoroutine(komsu_spawner()); 
    }        
    public IEnumerator komsu_spawner()
    {                        
        while (komsu_yarat==true)
        {
            if (komsu_yaratma)
            {
               rnd = Random.Range(0, komsu_spawn.Count);
                if (komsu_spawn[rnd].transform.childCount == 0)
                {
                    GameObject yaratilan_komsu = (GameObject)Instantiate(komsular[0], komsu_spawn[rnd].transform.position, komsu_spawn[rnd].transform.rotation);
                    pencere_anim[rnd].GetComponentInChildren<Animator>().SetBool("ac", true);
                    pencere_anim[rnd].GetComponentInChildren<Animator>().SetBool("kapat", false);
                    StartCoroutine(anim_pen_kapatma());
                    yaratilan_komsu.transform.SetParent(komsu_spawn[rnd].transform, true);
                }
            }
            yield return new WaitForSeconds(3);
        }
    }
    public IEnumerator anim_pen_kapatma()
    {
        yield return new WaitForSeconds(1.7f);
        pencere_anim[rnd].GetComponentInChildren<Animator>().SetBool("ac", false);
        pencere_anim[rnd].GetComponentInChildren<Animator>().SetBool("kapat", true);
    }
}
