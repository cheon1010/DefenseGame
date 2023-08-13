using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public Animator animator;
    GameObject BGM;
    GameObject QuitPanel;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        BGM = GameObject.Find("AudioTest");
        QuitPanel = GameObject.Find("Quit");
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

    public void GotoGameScene()
    {
        animator.SetBool("Fade", true);
        Invoke("GameSceneManger", 1f);
    }

    public void GotoUnitScene()
    {
        animator.SetBool("Fade", true);
        Invoke("UnitSceneManager", 1f);
    }

    public void GotoUnitShopScene()
    {
        animator.SetBool("Fade", true);
        Invoke("UnitManageSceneManger", 1f);
    }

    public void GotoLobbyScene()
    {
        animator.SetBool("Fade", true);
        Invoke("LobbySceneManager", 1f);
    }

    public void QuitGameScene()
    {
        animator.SetBool("Fade", true);
        Invoke("ExitGameManager", 1f);
    }

    public void GameSceneManger()
    {
        SceneManager.LoadScene("GameScene");
        Destroy(BGM);
    }
    
    public void UnitSceneManager()
    {
        SceneManager.LoadScene("UnitEnchantScene");
    }
    
    public void UnitManageSceneManger()
    {
        SceneManager.LoadScene("UnitManageScene");
    }

    public void LobbySceneManager()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void ExitGameManager()
    {
        Application.Quit();
    }

    public void QuitYes()
    {
        Application.Quit();
    }

    public void QuitNo()
    {
        QuitPanel.SetActive(false);
    }
}
