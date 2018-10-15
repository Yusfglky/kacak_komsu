using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oyun_Kontrolleri : MonoBehaviour
{
    [Header("Zaman")]
    public Text time;
    public float m, s,spawn__time;
    public GameObject spawnerlar;
    public GameObject spawner;
    public bool zamani_durdur;
    [Header("Son")]
    public GameObject Hud;
    public GameObject finish_hud;
    public GameObject finish;
    public Animator main_camera;
    public Text puan_text;
    public Text zaman_text;
    public List<GameObject> silinecekler;
    public void Start()
    {
        if (Application.targetFrameRate!=60)
        {
            Application.targetFrameRate = 60;
        }
    }
    private void Update()
    {                                                      
        zaman();
        spawner_yarat();
        olum();
    }
    void spawner_yarat()
    {
        if (!zamani_durdur)
        {
            spawn__time += Time.deltaTime;
            if (spawn__time >= 30)
            {
                spawn__time = 0;
                GameObject _spawner = (GameObject)Instantiate(spawner, spawnerlar.transform.position, Quaternion.identity, spawnerlar.transform);
            }
        }
    }
    void zaman()
    {
        if (!zamani_durdur)
        {
            s += Time.deltaTime;
            if (s >= 59)
            {
                s = 0;
                m += 1;
            }
            time.text = "Time: " + m.ToString("00") + ":" + s.ToString("00");
        }
    }
    void olum()
    {
       /* if (destroy.dead)
        {
            zamani_durdur = true;
            Hud.GetComponent<Animator>().enabled = true;
            finish_hud.SetActive(true);
            finish.SetActive(true);
            main_camera.enabled = true;
            puan_text.text ="Puan:"+canvas_ozellikleri._puan.ToString();
            zaman_text.text = "Time: " + m.ToString("00") + ":" + s.ToString("00");
            for (int i = 0; i < silinecekler.Count; i++)
            {
                Destroy(silinecekler[i],3);
            }
        }        */
    }     
    void kayit_alma()
    {

    }
}
