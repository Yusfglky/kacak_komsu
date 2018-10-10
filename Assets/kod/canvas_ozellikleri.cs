using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class canvas_ozellikleri : MonoBehaviour
{
    [Header("Butonlar")]
    public GameObject Joystick;
    public GameObject A_button;
    public GameObject B_button;   
    [Header("Button Scale")]
    [Range (0.5f,1.5f)]
     public float Joystick_Scale;
    [Range(2f, 6f)]
    public float A_button_Scale;
    [Range(1f, 3f)]
    public float B_button_Scale;
    [Header("Pause Menu")]
    public GameObject pause_menu;
    public Text quality_text;
    public Text joy_text;
    public Text a_buton_text;
    public Text b_buton_text;
    [Header("Puanlama")]  
    static public float _puan;
    public Text puan_text;
   public float deltaTime;
    public Text fpsT;
    private void Start()
    {
        quality_text.text = "Quality=" + QualitySettings.names[QualitySettings.GetQualityLevel()];    
        Application.targetFrameRate = 60;
    }
    void Update ()
    {
        Scale();
        puan_olaylari();
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsT.text = fps.ToString("00");
    }
    void Scale()
    {
        Joystick.transform.localScale = new Vector3(Joystick_Scale, Joystick_Scale, Joystick_Scale);
        A_button.transform.localScale = new Vector3(A_button_Scale, A_button_Scale, A_button_Scale);
        B_button.transform.localScale = new Vector3(B_button_Scale, B_button_Scale, B_button_Scale);  
    }       
    public void pause_button()
    {
        pause_menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void resume_button()
    {
        pause_menu.SetActive(false);
        Time.timeScale =1;
    }
    public void quality_settings(float deger)
    {
        int dg = Mathf.FloorToInt(deger);
        QualitySettings.SetQualityLevel(dg);
        quality_text.text = "Quality=" + QualitySettings.names[dg];
    }
    public void joystck_scale(float deger)
    {
        Joystick_Scale = deger;
        joy_text.text = "Joystick Scale:" + deger.ToString();
    }
    public void a_scale(float deger)
    {
        A_button_Scale = deger;
        a_buton_text.text = "A Button Scale:" + deger.ToString();
    }
    public void b_scale(float deger)
    {
        B_button_Scale = deger;
        b_buton_text.text = "B Button Scale:" + deger.ToString();
    }  
    void puan_olaylari()
    {       
        _puan += Time.deltaTime; 
        _puan = Mathf.Floor(_puan);
        puan_text.text = "Point:" + _puan.ToString();
    }
    public void again()
    {
        SceneManager.LoadScene(0);  
    }             
}
