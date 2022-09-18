using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    Canvas canvas;

    private PlayerControls PlayerControls;

    private bool m_Pressed;
    //private bool m_Released;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        m_Pressed = false;
    }

     private void Awake(){
        PlayerControls = new PlayerControls();
        PlayerControls.GameMenu.Pause.performed += ctx => m_Pressed = true;
        //PlayerControls.GameMenu.Pause.canceled += ctx => m_Pressed = true;
    }
    private void OnEnable(){
        PlayerControls.Enable();
    }
    private void OnDisable(){
        PlayerControls.Disable();
    }

    void Update()
    {
        if (m_Pressed){
            canvas.enabled = !canvas.enabled;
            Time.timeScale = Time.timeScale == 0? 1 : 0; //timescale = 0 จะได้เป็น 1 ถ้าไม่เท่ากับ 0 จะเป็น 0

            if(Time.timeScale == 0){
                paused.TransitionTo(0.05f); //ให้ trandsition ไปด้วยความเร็ว 0.05f
            }
            else{
                unpaused.TransitionTo(0.05f);
            }
        }

        m_Pressed = false;
        
    }
}
