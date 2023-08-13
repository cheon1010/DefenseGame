using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public GameObject HowToPanel;
    public GameObject HowTo1;
    public GameObject HowTo2;
    public GameObject QuitPanel;

    public Animator animator;

    GameObject BGM;
    AudioSource BGMusic;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        BGM = GameObject.Find("AudioTest");
        BGMusic = BGM.GetComponent<AudioSource>();
        DontDestroyOnLoad(BGM);
        QuitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKey(KeyCode.Escape))

            {
                if (QuitPanel.activeSelf == false)
                    QuitPanel.SetActive(true);
                else
                    QuitPanel.SetActive(false);

            }

        }
    }

    public void GotoLobby()
    {
        animator.SetBool("Fade", true);
        Invoke("StartButton", 1f);
    }
    

    public void StartButton()   // 스타트화면에서 로비씬으로
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void DefenseStart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitButton()
    {
        if (QuitPanel.activeSelf == false)
            QuitPanel.SetActive(true);
    }

    public void HowToPlayButton()
    {
        HowToPanel.SetActive(true);
    }

    public void PanelExitButton()
    {
        HowToPanel.SetActive(false);
    }

    public void PanelRightButton()
    {
        if(HowTo1.activeSelf==true)
        {
            HowTo1.SetActive(false);
            HowTo2.SetActive(true);
        }
        else if(HowTo2.activeSelf==true)
        {
            HowTo1.SetActive(true);
            HowTo2.SetActive(false);
        }
    }

    public void PanelLeftButton()
    {
        if (HowTo1.activeSelf == true)
        {
            HowTo1.SetActive(false);
            HowTo2.SetActive(true);
        }
        else if (HowTo2.activeSelf == true)
        {
            HowTo1.SetActive(true);
            HowTo2.SetActive(false);
        }
    }

    public void Button_Yes()
    {
        Application.Quit();
    }

    public void Button_No()
    {
        if (QuitPanel.activeSelf == true)
            QuitPanel.SetActive(false);
    }

    
}
