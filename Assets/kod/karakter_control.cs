using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class karakter_control : MonoBehaviour
{                                               
    private Rigidbody k_body;
    private GameObject red_button;
    private GameObject spawn_sol;
    private GameObject spawn_sag;          
    [Header("Karakter Hit")]
    public static bool hit_;
    public static bool vurulabilir;
    [Header("Karakter Hiz")]
    public float k_hiz;
    public float vurus_hizi;
    public float normal_hiz;
    [Header("Karakter Zıplama")]
    public float ziplama_gucu;
    public bool jumpable;
    public bool ziplama;
    [Header("Animasyon")]
    private Animator k_anim;
    public Button hit_button;
    [Header("Ray Esya")]
    public GameObject ray;
    public LayerMask layer;
    public Joystick joy;
    void Start()
    {                                                                   
        k_body = GetComponent<Rigidbody>();
        k_anim = GetComponent<Animator>();   
        spawn_sol = GameObject.Find("spawn_sol");
        spawn_sag = GameObject.Find("spawn_sag");
        k_hiz = normal_hiz;
    }       
    private void Update()
    {                            
        karakter_mekanizma();                                                                              
        if (vurulabilir)
        {
            k_hiz = vurus_hizi;
        }
        else
        {
            k_hiz = normal_hiz;
        }
    }
    public void karakter_mekanizma()
    {
        float x = joy.Horizontal;
        float x_ = Input.GetAxis("Horizontal");  
        if (x < 0||x_<0)
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
            transform.Translate(0, 0, -x* k_hiz); 
            transform.Translate(0, 0, -x_ * k_hiz);
        }
        if (x> 0 || x_ > 0)
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
            transform.Translate(0, 0, x * k_hiz);
            transform.Translate(0, 0, x_ * k_hiz);
        }
        k_anim.SetFloat("SpeedX", x);
        k_anim.SetFloat("SpeedX", x_);
        /*  if (jumpable)
          {
              if (x == 0)
              {
                  if (k_anim.GetBool("hit")!=true)
                  {                               

                  }
              }
          }     */
    }
    public void zipla()
    {

        if (ziplama)
        {
            if (jumpable)
            {
                jumpable = false;
                k_body.AddForce(0, ziplama_gucu * 4, 0, ForceMode.Impulse);
            }
        }
    }
    public void vur(float y)
    {
        ray_esya();
        k_anim.SetFloat("SpeedY",y);
        vurulabilir = true;
        if (y==0)
        {   
            vurulabilir = false;
        }
    } 
    void ray_esya()
    {
        RaycastHit hit;
        Ray r1 = new Ray(ray.transform.position, ray.transform.forward);
        if (Physics.Raycast(r1,out hit))
        {                                
            if (hit.collider.gameObject.layer==11)
            {                                    
                hit_ = true;
            }
        }
    }
    ////////////////Zamanlayicilar///////////                  
    
    /////////////////collision_enter////////
    public void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "alt")
        { 
                jumpable = true;   
        }                      
    }                                         
    /////////////////isinlanma////////////
    public void OnCollisionStay(Collision col)
    {   
        if (col.collider.name == "sag")
        {
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            transform.position = spawn_sol.transform.position;
            if (transform.position == spawn_sol.transform.position)
            {
                GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            }
        }
        if (col.collider.name == "sol")
        {
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
            transform.position = spawn_sag.transform.position;
            if (transform.position == spawn_sag.transform.position)
            {
                GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
            }
        }
    }                                          
}
