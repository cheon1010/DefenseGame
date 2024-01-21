using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Text TimeScale;
    public List<Sprite> PI;  // �Ͻ����� ������
    public Image Icon;
    GameObject PS;  //�Ͻ����� ȭ��
    GameObject PT;  // �Ͻ����� �ؽ�Ʈ
    public GameObject PauseCanvas;  // �Ͻ������� ��µǴ� ĵ����

    public GameObject Option;
    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(false);
        GameManager.instance.SPanel.SetActive(false);
        PS = GameObject.Find("PauseSquare");
        PT = GameObject.Find("Pausetext");
        Icon.sprite = PI[0];
        PS.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimeScale.text = Time.timeScale.ToString();
        if (PS.active == true)
        {
            PT.SetActive(true);
            PauseCanvas.SetActive(true);
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
