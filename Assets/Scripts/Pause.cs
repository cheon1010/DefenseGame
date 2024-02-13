using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Text TimeScale;
    public List<Sprite> PI;  // 일시정지 아이콘
    public Image Icon;
    GameObject PS;  //일시정지 화면
    GameObject PT;  // 일시정지 텍스트
    public GameObject DF;  // 게임오버 텍스트
    GameObject PL;  // 일시정지시 출력되는 버튼들
    public GameObject GOE; // 게임오버시 나가기버튼
    public GameObject PauseCanvas;  // 일시정지시 출력되는 캔버스

    public GameObject Option;

    public static Pause instance;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SPanel.SetActive(false);
        PS = GameObject.Find("PauseSquare");
        PT = GameObject.Find("Pausetext");
        DF = GameObject.Find("DefenseFail");
        PL = GameObject.Find("PauseLayout");
        GOE = GameObject.Find("GameOverExit");
        Icon.sprite = PI[0];
        PS.SetActive(false);
        DF.SetActive(false);
        PauseCanvas.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        TimeScale.text = Time.timeScale.ToString();
        if (PS.active == true)
        {
            if(GameManager.instance.BaseHPCount==0)
            {
                PT.SetActive(false);
                PauseCanvas.SetActive(true);
                PL.SetActive(false);
                DF.SetActive(true);
                GOE.SetActive(true);
            }
            else
            {
                PT.SetActive(true);
                PauseCanvas.SetActive(true);
                PL.SetActive(true);
            }
        }
        else
        {
            PT.SetActive(false);
            PauseCanvas.SetActive(false);
        }
    }

    public void GamePause()
    {
        if(Time.timeScale==0)
        {
            Time.timeScale = 1;
            Icon.sprite = PI[0];
            PS.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            Icon.sprite = PI[1];
            PS.SetActive(true);
        }
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        Icon.sprite = PI[0];
        PS.SetActive(false);
    }
}
