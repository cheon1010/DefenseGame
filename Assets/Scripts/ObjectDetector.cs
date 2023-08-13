using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetector : MonoBehaviour
{
    public bool isArrange = false;  // 배치확인 (true면 배치완료상태)
    private bool isClicked = false;
    public static ObjectDetector instance;

    public GameObject alpha150 = null;
    public GameObject createalpha = null;
    public GameObject GreenSquare = null;  // 유닛 배치시 표현할 절대좌표스프라이트
    public GameObject createSquarealpha = null;
    public GameObject unitprefab = null;
    GameObject UP;
    //public GameObject NEC;  // 배치부족 알림오브젝트
    public GameObject DelaySprite;
    public bool fail;
    public int UnitCount;
    public Sprite UnitIllust;
    public Sprite UnitSprite;
    public Text TestText;   // 좌표확인용 텍스트, 확인끝나면 지울 것
    public GameObject GSalpha;  // 배치범위 표현
    public GameObject RSalpha;  // 배치불가능범위 표현
    public Vector3 mousepos;


    GameObject UnitList;

    #region 유닛정보창(UI)
    public Image UIP;   // 유닛 일러스트
    public Text UName;  // 유닛 이름
    public Text UOccu;  // 유닛 직업군
    public Text UHP;   // 유닛 체력
    public Text UATK;  // 유닛 공격력
    public Text UCC;     // 유닛 제어가능수
    public Text UCost; // 유닛 비용
    #endregion
    public Text DC; // 쿨타임 텍스트 표기

    public GameObject UnitInfoPanel;
    public GameObject SA;

    private void Start()
    {
        GSalpha.SetActive(false);
        //NEC = GameObject.Find("NotEnoughCost");
        isClicked = false;
        //NEC.SetActive(false);
        fail = false;
        //DelaySprite.SetActive(false);
        isArrange = false;
        //DC.text = "";
    }

    private void Awake()
    {
        UnitList = GameObject.Find("UnitList");
        instance = this;
        if(transform.parent.name=="Select0")
        {
            UP = UnitManager.instance.UP[0];
        }
        else if(transform.parent.name=="Select1")
        {
            UP = UnitManager.instance.UP[1];
        }
    }

    private void Update()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isArrange == false)
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        else if (isArrange == true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            DC.text = "";
        }
        //gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnMouseDown()
    {
        if (Time.timeScale == 0)
            return;
        else if(Time.timeScale>=0f)
        {
            Debug.Log("Click");
            isClicked = true;
            createSquarealpha = Instantiate(GreenSquare, transform);
            createalpha = Instantiate(alpha150, transform);
            //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 1.0f;
            createalpha.transform.position = mousepos;
            createSquarealpha.transform.position = mousepos;
            UIP.sprite = UnitIllust;
            if (GameManager.instance.UIT)
            {
                GameManager.instance.UIP.SetActive(false);
                //GameManager.instance.UName.text = unitprefab.GetComponent<UnitControl>().UName.ToString();
                GameManager.instance.UName.text = UP.GetComponent<UnitControl>().UName.ToString();
                //GameManager.instance.UOccupation.text = unitprefab.GetComponent<UnitControl>().UOccupation.ToString();
                //GameManager.instance.UOccupation.text = UP.GetComponent<UnitControl>().UOccupation.ToString();
                GameManager.instance.UOccupation.text = UP.GetComponent<UnitControl>().UOccupation.ToString();
                //GameManager.instance.UHP.text = "체력 " + unitprefab.GetComponent<UnitControl>().UHp.ToString() + " / " + unitprefab.GetComponent<UnitControl>().MaxUHp.ToString();
                GameManager.instance.UHP.text = "체력 " + UP.GetComponent<UnitControl>().UHp.ToString() + " / " + UP.GetComponent<UnitControl>().MaxUHp.ToString();
                //GameManager.instance.UATK.text = "공격력 " + unitprefab.GetComponent<UnitControl>().UAtk.ToString();
                GameManager.instance.UATK.text = "공격력 " + UP.GetComponent<UnitControl>().UAtk.ToString();
                //GameManager.instance.UnitCC.text = "제어 가능 수 " + unitprefab.GetComponent<UnitControl>().Max_CC.ToString();
                GameManager.instance.UnitCC.text = "제어 가능 수 " + UP.GetComponent<UnitControl>().Max_CC.ToString();
                //GameManager.instance.UCost.text = "배치 비용 " + unitprefab.GetComponent<UnitControl>().Cost.ToString();
                GameManager.instance.UCost.text = "배치 비용 " + UP.GetComponent<UnitControl>().Cost.ToString();
                GameManager.instance.UIP.SetActive(true);
            }
            else
            {
                GameManager.instance.UIT = true;
                //GameManager.instance.UName.text = unitprefab.GetComponent<UnitControl>().UName.ToString();
                GameManager.instance.UName.text = UP.GetComponent<UnitControl>().UName.ToString();
                //GameManager.instance.UOccupation.text = unitprefab.GetComponent<UnitControl>().UOccupation.ToString();
                GameManager.instance.UOccupation.text = UP.GetComponent<UnitControl>().UOccupation.ToString();
                //GameManager.instance.UHP.text = "체력 " + unitprefab.GetComponent<UnitControl>().UHp.ToString() + " / " + unitprefab.GetComponent<UnitControl>().MaxUHp.ToString();
                GameManager.instance.UHP.text = "체력 " + UP.GetComponent<UnitControl>().UHp.ToString() + " / " + UP.GetComponent<UnitControl>().MaxUHp.ToString();
                //GameManager.instance.UATK.text = "공격력 " + unitprefab.GetComponent<UnitControl>().UAtk.ToString();
                GameManager.instance.UATK.text = "공격력 " + UP.GetComponent<UnitControl>().UAtk.ToString();
                //GameManager.instance.UnitCC.text = "제어 가능 수 " + unitprefab.GetComponent<UnitControl>().Max_CC.ToString();
                GameManager.instance.UnitCC.text = "제어 가능 수 " + UP.GetComponent<UnitControl>().Max_CC.ToString();
                //GameManager.instance.UCost.text = "배치 비용 " + unitprefab.GetComponent<UnitControl>().Cost.ToString();
                GameManager.instance.UCost.text = "배치 비용 " + UP.GetComponent<UnitControl>().Cost.ToString();
                GameManager.instance.UIP.SetActive(true);
            }
        }
        /*
        Debug.Log("Click");
        isClicked = true;
        createSquarealpha = Instantiate(GreenSquare, transform);
        createalpha = Instantiate(alpha150, transform);
        //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 1.0f;
        createalpha.transform.position = mousepos;
        createSquarealpha.transform.position = mousepos;
        UIP.sprite = UnitIllust;
        if (GameManager.instance.UIT)
        {
            GameManager.instance.UIP.SetActive(false);
            //GameManager.instance.UName.text = unitprefab.GetComponent<UnitControl>().UName.ToString();
            GameManager.instance.UName.text = UP.GetComponent<UnitControl>().UName.ToString();
            //GameManager.instance.UOccupation.text = unitprefab.GetComponent<UnitControl>().UOccupation.ToString();
            //GameManager.instance.UOccupation.text = UP.GetComponent<UnitControl>().UOccupation.ToString();
            GameManager.instance.UOccupation.text = UP.GetComponent<UnitControl>().UOccupation.ToString();
            //GameManager.instance.UHP.text = "체력 " + unitprefab.GetComponent<UnitControl>().UHp.ToString() + " / " + unitprefab.GetComponent<UnitControl>().MaxUHp.ToString();
            GameManager.instance.UHP.text = "체력 " + UP.GetComponent<UnitControl>().UHp.ToString() + " / " + UP.GetComponent<UnitControl>().MaxUHp.ToString();
            //GameManager.instance.UATK.text = "공격력 " + unitprefab.GetComponent<UnitControl>().UAtk.ToString();
            GameManager.instance.UATK.text = "공격력 " + UP.GetComponent<UnitControl>().UAtk.ToString();
            //GameManager.instance.UnitCC.text = "제어 가능 수 " + unitprefab.GetComponent<UnitControl>().Max_CC.ToString();
            GameManager.instance.UnitCC.text = "제어 가능 수 " + UP.GetComponent<UnitControl>().Max_CC.ToString();
            //GameManager.instance.UCost.text = "배치 비용 " + unitprefab.GetComponent<UnitControl>().Cost.ToString();
            GameManager.instance.UCost.text = "배치 비용 " + UP.GetComponent<UnitControl>().Cost.ToString();
            GameManager.instance.UIP.SetActive(true);
        }
        else
        {
            GameManager.instance.UIT = true;
            //GameManager.instance.UName.text = unitprefab.GetComponent<UnitControl>().UName.ToString();
            GameManager.instance.UName.text = UP.GetComponent<UnitControl>().UName.ToString();
            //GameManager.instance.UOccupation.text = unitprefab.GetComponent<UnitControl>().UOccupation.ToString();
            GameManager.instance.UOccupation.text = UP.GetComponent<UnitControl>().UOccupation.ToString();
            //GameManager.instance.UHP.text = "체력 " + unitprefab.GetComponent<UnitControl>().UHp.ToString() + " / " + unitprefab.GetComponent<UnitControl>().MaxUHp.ToString();
            GameManager.instance.UHP.text = "체력 " + UP.GetComponent<UnitControl>().UHp.ToString() + " / " + UP.GetComponent<UnitControl>().MaxUHp.ToString();
            //GameManager.instance.UATK.text = "공격력 " + unitprefab.GetComponent<UnitControl>().UAtk.ToString();
            GameManager.instance.UATK.text = "공격력 " + UP.GetComponent<UnitControl>().UAtk.ToString();
            //GameManager.instance.UnitCC.text = "제어 가능 수 " + unitprefab.GetComponent<UnitControl>().Max_CC.ToString();
            GameManager.instance.UnitCC.text = "제어 가능 수 " + UP.GetComponent<UnitControl>().Max_CC.ToString();
            //GameManager.instance.UCost.text = "배치 비용 " + unitprefab.GetComponent<UnitControl>().Cost.ToString();
            GameManager.instance.UCost.text = "배치 비용 " + UP.GetComponent<UnitControl>().Cost.ToString();
            GameManager.instance.UIP.SetActive(true);
        }
        */
    }

    private void OnMouseDrag()
    {
        if (isClicked == true)
        {
            //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TestText.text = mousepos.ToString();
            mousepos.z = 1.0f;
            createalpha.transform.position = mousepos;
            createSquarealpha.transform.position = mousepos;
            #region 유닛배치좌표
            #region 1종 좌표구현
            if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-4.5f, 3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-4.5f, 3f, 0);
                }
            }
            else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-3.5f, 3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-3.5f, 3f, 0);
                }
            }
            else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-2.5f, 3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-2.5f, 3f, 0);
                }
            }
            else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-1.5f, 3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-1.5f, 3f, 0);
                }
            }
            else if ((mousepos.x > -1f && mousepos.x < 0.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-0.5f, 3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-0.5f, 3f, 0);
                }
            }
            else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(1.5f, 3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(1.5f, 3f, 0);
                }
            }
            else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(2.5f, 3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(2.5f, 3f, 0);
                }
            }
            else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(3.5f, 3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(3.5f, 3f, 0);
                }
            }
            #endregion
            #region 2종 좌표구현
            if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-4.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-4.5f, 2f, 0);
                }
            }
            else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-3.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-3.5f, 2f, 0);
                }
            }
            else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-2.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-2.5f, 2f, 0);
                }
            }
            else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-1.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-1.5f, 2f, 0);
                }
            }
            else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-0.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-0.5f, 2f, 0);
                }
            }
            else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(1.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(1.5f, 2f, 0);
                }
            }
            else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(2.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(2.5f, 2f, 0);
                }
            }
            else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(3.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(3.5f, 2f, 0);
                }
            }
            else if ((mousepos.x > 4f && mousepos.x < 4.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(4.5f, 2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(4.5f, 2f, 0);
                }
            }
            #endregion
            #region 3종 좌표구현
            if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-4.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-4.5f, 1f, 0);
                }
            }
            else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-3.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-3.5f, 1f, 0);
                }
            }
            else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-2.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-2.5f, 1f, 0);
                }
            }
            else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-1.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-1.5f, 1f, 0);
                }
            }
            else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-0.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-0.5f, 1f, 0);
                }
            }
            else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(1.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(1.5f, 1f, 0);
                }
            }
            else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(2.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(2.5f, 1f, 0);
                }
            }
            else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(3.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(3.5f, 1f, 0);
                }
            }
            else if ((mousepos.x > 4f && mousepos.x < 4.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(4.5f, 1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(4.5f, 1f, 0);
                }
            }
            #endregion
            #region 4종 좌표구현
            if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-4.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-4.5f, 0f, 0);
                }
            }
            else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-3.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-3.5f, 0f, 0);
                }
            }
            else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-2.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-2.5f, 0f, 0);
                }
            }
            else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-1.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-1.5f, 0f, 0);
                }
            }
            else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-0.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-0.5f, 0f, 0);
                }
            }
            else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(1.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(1.5f, 0f, 0);
                }
            }
            else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(2.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(2.5f, 0f, 0);
                }
            }
            else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(3.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(3.5f, 0f, 0);
                }
            }
            else if ((mousepos.x > 4f && mousepos.x < 4.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(4.5f, 0f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(4.5f, 0f, 0);
                }
            }
            #endregion
            #region 5종 좌표구현
            if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-4.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-4.5f, -1f, 0);
                }
            }
            else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-3.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-3.5f, -1f, 0);
                }
            }
            else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-2.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-2.5f, -1f, 0);
                }
            }
            else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-1.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-1.5f, -1f, 0);
                }
            }
            else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-0.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-0.5f, -1f, 0);
                }
            }
            else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(1.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(1.5f, -1f, 0);
                }
            }
            else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(2.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(2.5f, -1f, 0);
                }
            }
            else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(3.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(3.5f, -1f, 0);
                }
            }
            else if ((mousepos.x > 4f && mousepos.x < 4.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(4.5f, -1f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(4.5f, -1f, 0);
                }
            }
            #endregion
            #region 6종 좌표구현
            if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-4.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-4.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-3.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-3.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-2.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-2.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-1.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-1.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-0.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-0.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > 0f && mousepos.x < 0.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(0.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(0.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(1.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(1.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(2.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(2.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(3.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(3.5f, -2f, 0);
                }
            }
            else if ((mousepos.x > 4f && mousepos.x < 4.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(4.5f, -2f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(4.5f, -2f, 0);
                }
            }
            #endregion
            #region 7종 좌표구현
            if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-4.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-4.5f, -3f, 0);
                }
            }
            else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-3.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-3.5f, -3f, 0);
                }
            }
            else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-2.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-2.5f, -3f, 0);
                }
            }
            else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-1.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-1.5f, -3f, 0);
                }
            }
            else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(-0.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(-0.5f, -3f, 0);
                }
            }
            else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(1.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(1.5f, -3f, 0);
                }
            }
            else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(2.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(2.5f, -3f, 0);
                }
            }
            else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(3.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(3.5f, -3f, 0);
                }
            }
            else if ((mousepos.x > 4f && mousepos.x < 4.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
            {
                if (GSalpha.activeSelf == true)
                    GSalpha.transform.position = new Vector3(4.5f, -3f, 0);
                else
                {
                    GSalpha.SetActive(true);
                    GSalpha.transform.position = new Vector3(4.5f, -3f, 0);
                }
            }
            #endregion
            #endregion
        }
    }

    private void OnMouseUp()
    {
        if (Time.timeScale == 0)
            return;
        else if(Time.timeScale>=0)
        {
            Destroy(createalpha);
            //if (GameManager.instance.Cost < unitprefab.GetComponent<UnitControl>().Cost)
            if (GameManager.instance.Cost < UP.GetComponent<UnitControl>().Cost)
            {
                isClicked = false;
                Destroy(createalpha);
                Destroy(createSquarealpha);
                GameManager.instance.NEC.SetActive(true);
                //NEC.SetActive(true);
                Invoke("CBPOn", 2f);
                GameManager.instance.UIT = false;
                GameManager.instance.UIP.SetActive(false);
                GSalpha.SetActive(false);
                return;
            }
            if (GameManager.instance.BatchCount <= 0)
            {
                isClicked = false;
                Destroy(createalpha);
                Destroy(createSquarealpha);
                GameManager.instance.BannedUnit.SetActive(true);
                Invoke("CBPOn", 2f);    // 더이상 배치불가능합니다 문구로 변환할 것
                GameManager.instance.UIT = false;
                GameManager.instance.UIP.SetActive(false);
                GSalpha.SetActive(false);
                return;
            }
            else
            {
                //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isClicked = false;
                isArrange = true;
                Destroy(createalpha);
                /*
                DelaySprite.GetComponent<DelaySpriteController>().It.fillAmount = 1;
                DelaySprite.GetComponent<DelaySpriteController>().fillAmount = 1;
                */
                GameManager.instance.UIT = false;
                GameManager.instance.UIP.SetActive(false);
                GameManager.instance.BatchCount -= 1;
                GSalpha.SetActive(false);
                if ((mousepos.x > -5f && mousepos.x < 5f) && (mousepos.y > -3.5f && mousepos.y < 3.5f))
                {
                    #region 1종 유닛배치
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-4.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-3.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-2.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-1.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-0.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(1.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(2.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(3.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    #endregion
                    #region 2종 유닛배치
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-4.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-3.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-2.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-1.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-0.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(1.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(2.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(3.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
                    {
                        Instantiate(UP, new Vector3(4.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    #endregion
                    #region 3종 유닛배치
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-4.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-3.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-2.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-1.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-0.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(1.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(2.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(3.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
                    {
                        Instantiate(UP, new Vector3(4.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    #endregion
                    #region 4종 유닛배치
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-4.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-3.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-2.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-1.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-0.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(1.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(2.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(3.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
                    {
                        Instantiate(UP, new Vector3(4.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    #endregion
                    #region 5종 유닛배치
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-4.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-3.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-2.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-1.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-0.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(1.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(2.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(3.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
                    {
                        Instantiate(UP, new Vector3(4.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    #endregion
                    #region 6종 유닛배치
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-4.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-3.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-2.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-1.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-0.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 0f && mousepos.x < 0.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(0.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(1.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(2.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(3.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
                    {
                        Instantiate(UP, new Vector3(4.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    #endregion
                    #region 7종 유닛배치
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-4.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-3.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-2.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-1.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(-0.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(1.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(2.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                    {
                        Instantiate(UP, new Vector3(3.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
                    {
                        Instantiate(UP, new Vector3(4.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    #endregion
                }
                else
                {
                    isClicked = false;
                    Destroy(createalpha);
                    Destroy(createSquarealpha);
                    GameManager.instance.PosBanned.SetActive(true);
                    Invoke("CBPOn", 2f);    // 더이상 배치불가능합니다 문구로 변환할 것
                    GameManager.instance.UIT = false;
                    GameManager.instance.UIP.SetActive(false);
                }
                TestText.text = mousepos.ToString();
            }
        }
        /*
        Destroy(createalpha);
        //if (GameManager.instance.Cost < unitprefab.GetComponent<UnitControl>().Cost)
        if (GameManager.instance.Cost < UP.GetComponent<UnitControl>().Cost)
        {
            isClicked = false;
            Destroy(createalpha);
            Destroy(createSquarealpha);
            GameManager.instance.NEC.SetActive(true);
            //NEC.SetActive(true);
            Invoke("CBPOn", 2f);
            GameManager.instance.UIT = false;
            GameManager.instance.UIP.SetActive(false);
            GSalpha.SetActive(false);
            return;
        }
        if (GameManager.instance.BatchCount <= 0)
        {
            isClicked = false;
            Destroy(createalpha);
            Destroy(createSquarealpha);
            GameManager.instance.BannedUnit.SetActive(true);
            Invoke("CBPOn", 2f);    // 더이상 배치불가능합니다 문구로 변환할 것
            GameManager.instance.UIT = false;
            GameManager.instance.UIP.SetActive(false);
            GSalpha.SetActive(false);
            return;
        }
        else
        {
            //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isClicked = false;
            isArrange = true;
            Destroy(createalpha);
            /*
            DelaySprite.GetComponent<DelaySpriteController>().It.fillAmount = 1;
            DelaySprite.GetComponent<DelaySpriteController>().fillAmount = 1;
            GameManager.instance.UIT = false;
            GameManager.instance.UIP.SetActive(false);
            GameManager.instance.BatchCount -= 1;
            GSalpha.SetActive(false);
            if ((mousepos.x > -5f && mousepos.x < 5f) && (mousepos.y > -3.5f && mousepos.y < 3.5f))
            {
                #region 1종 유닛배치
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-4.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-3.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-2.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-1.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-0.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(1.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(2.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(3.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                #endregion
                #region 2종 유닛배치
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-4.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-3.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-2.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-1.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-0.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(1.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(2.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(3.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < 2.5f && mousepos.y > 1.5f))
                {
                    Instantiate(UP, new Vector3(4.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                #endregion
                #region 3종 유닛배치
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-4.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-3.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-2.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-1.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-0.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(1.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(2.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(3.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < 1.5f && mousepos.y > 0.5f))
                {
                    Instantiate(UP, new Vector3(4.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                #endregion
                #region 4종 유닛배치
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-4.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-3.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-2.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-1.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-0.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(1.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(2.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(3.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < 0.5f && mousepos.y > -0.5f))
                {
                    Instantiate(UP, new Vector3(4.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                #endregion
                #region 5종 유닛배치
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-4.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-3.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-2.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-1.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-0.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(1.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(2.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(3.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < -0.5f && mousepos.y > -1.5f))
                {
                    Instantiate(UP, new Vector3(4.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                #endregion
                #region 6종 유닛배치
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-4.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-3.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-2.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-1.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-0.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 0f && mousepos.x < 0.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(0.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(1.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(2.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(3.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < -1.5f && mousepos.y > -2.5f))
                {
                    Instantiate(UP, new Vector3(4.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                #endregion
                #region 7종 유닛배치
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-4.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-3.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-2.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-1.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(-0.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(1.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(2.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // 절대좌표 배치
                {
                    Instantiate(UP, new Vector3(3.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 4f && mousepos.x < 4.95) && (mousepos.y < -2.5f && mousepos.y > -3.5f))
                {
                    Instantiate(UP, new Vector3(4.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                #endregion
            }
            else
            {
                isClicked = false;
                Destroy(createalpha);
                Destroy(createSquarealpha);
                GameManager.instance.PosBanned.SetActive(true);
                Invoke("CBPOn", 2f);    // 더이상 배치불가능합니다 문구로 변환할 것
                GameManager.instance.UIT = false;
                GameManager.instance.UIP.SetActive(false);
            }
                TestText.text = mousepos.ToString();
            }
    */
        }

        void CBPOn()
        {
            if (GameManager.instance.NEC.activeSelf == true)
                GameManager.instance.NEC.SetActive(false);
            if (GameManager.instance.BannedUnit.activeSelf == true)
                GameManager.instance.BannedUnit.SetActive(false);
            if (GameManager.instance.PosBanned.active == true)
                GameManager.instance.PosBanned.SetActive(false);
            
        }

    public void Delay()
    {
        DelaySprite.GetComponent<DelaySpriteController>().It.fillAmount = 1;
        DelaySprite.GetComponent<DelaySpriteController>().fillAmount = 1;
    }

    
}
