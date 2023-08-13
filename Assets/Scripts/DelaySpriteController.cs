using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelaySpriteController : MonoBehaviour
{
    public float UC;
    public GameObject arrangementSprite;
    public Image It;
    public float fillAmount = 1;
    public Text DelayText;
    public float Cooltime;
    

    public float TotalTime; // 쿨타임 시간
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelayCoolTime());
        //StartCoroutine(DelayCoolTimeText());
        It.fillAmount = 0;
        DelayText.text = "";
    }

    private void Awake()
    {
        if (UC == 1)
        {
            TotalTime = 5f;
            Cooltime = 5f;
        }
        else if (UC == 2)
        {
            TotalTime = 3f;
            Cooltime = 3f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        CooltimeText();
    }

    private void FixedUpdate()
    {
        /*
        if (arrangementSprite.GetComponent<ObjectDetector>().isArrange == true)
        {
            Debug.Log("코루틴 시작");
            StartCoroutine(DelayCoolTime());
        }
        else if (arrangementSprite.GetComponent<ObjectDetector>().isArrange == false)
        {
            Debug.Log("코루틴 종료");
            StopCoroutine(DelayCoolTime());
        }
        */
    }

    /*
    public void Cooltime()
    {
        if(fillAmount>0)
        {
            fillAmount = fillAmount - (Time.deltaTime / (TotalTime - 1));
            It.fillAmount = fillAmount;
            if(fillAmount<=0)
            {
                arrangementSprite.GetComponent<ObjectDetector>().isArrange = false;
            }
        }
    }
    */

    public void SetCoolTime()
    {
        Debug.Log("재배치 쿨타임 가동");
        if ((fillAmount > 0)&&(arrangementSprite.GetComponent<ObjectDetector>().isArrange==true))
        {
            if (UC == 1)
                TotalTime = 5;
            else if (UC == 2)
                TotalTime = 3;
            fillAmount = 1 - (Time.deltaTime / (TotalTime - 1));
            It.fillAmount = fillAmount;
            if (fillAmount <= 0)
            {
                arrangementSprite.GetComponent<ObjectDetector>().isArrange = false;
            }
        }
    }

    IEnumerator DelayCoolTime()
    {
        while(true)
        {
            if(arrangementSprite.GetComponent<ObjectDetector>().isArrange==true)
            {
                fillAmount = fillAmount - (Time.deltaTime / (TotalTime - 1));
                It.fillAmount = fillAmount;
                if (fillAmount <= 0)
                {
                    arrangementSprite.GetComponent<ObjectDetector>().isArrange = false;
                    fillAmount = 0;
                    if (UC == 1)
                        Cooltime = 5f;
                    else if (UC == 2)
                        Cooltime = 3f;
                }
                /*
                if (arrangementSprite.GetComponent<ObjectDetector>().isArrange == true)
                {
                    fillAmount = fillAmount - (Time.deltaTime / (TotalTime - 1));
                    It.fillAmount = fillAmount;
                    if (fillAmount <= 0)
                    {
                        arrangementSprite.GetComponent<ObjectDetector>().isArrange = false;
                    }
                }
                */
                //SetCoolTime();
            }
            yield return new WaitForFixedUpdate();
        }
    }
    IEnumerator DelayCoolTimeText()
    {
        while (true)
        {
            if (arrangementSprite.GetComponent<ObjectDetector>().isArrange == true)
            {
                if(Cooltime>0)
                {
                    Cooltime -= 0.1f;
                    DelayText.text = Cooltime.ToString("F1");
                }
                else if(Cooltime<=0)
                {
                    Time.timeScale = 0.0f;
                    DelayText.text = "";
                }
            }
            else if(arrangementSprite.GetComponent<ObjectDetector>().isArrange == false)
            {
                DelayText.text = "";
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    void CooltimeText()
    {
        if (arrangementSprite.GetComponent<ObjectDetector>().isArrange == true)
        {
            DelayText.gameObject.SetActive(true);
            if (Cooltime > 0)
            {
                Cooltime -= Time.deltaTime;
                DelayText.text = Cooltime.ToString("F1");
            }
            else if (Cooltime <= 0)
            {
                Time.timeScale = 0.0f;
                DelayText.text = "";
            }
        }
        else if (arrangementSprite.GetComponent<ObjectDetector>().isArrange == false)
            DelayText.text = "";
    }
}
