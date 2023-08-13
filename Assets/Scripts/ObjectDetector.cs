using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetector : MonoBehaviour
{
    public bool isArrange = false;  // ��ġȮ�� (true�� ��ġ�Ϸ����)
    private bool isClicked = false;
    public static ObjectDetector instance;

    public GameObject alpha150 = null;
    public GameObject createalpha = null;
    public GameObject GreenSquare = null;  // ���� ��ġ�� ǥ���� ������ǥ��������Ʈ
    public GameObject createSquarealpha = null;
    public GameObject unitprefab = null;
    GameObject UP;
    //public GameObject NEC;  // ��ġ���� �˸�������Ʈ
    public GameObject DelaySprite;
    public bool fail;
    public int UnitCount;
    public Sprite UnitIllust;
    public Sprite UnitSprite;
    public Text TestText;   // ��ǥȮ�ο� �ؽ�Ʈ, Ȯ�γ����� ���� ��
    public GameObject GSalpha;  // ��ġ���� ǥ��
    public GameObject RSalpha;  // ��ġ�Ұ��ɹ��� ǥ��
    public Vector3 mousepos;


    GameObject UnitList;

    #region ��������â(UI)
    public Image UIP;   // ���� �Ϸ���Ʈ
    public Text UName;  // ���� �̸�
    public Text UOccu;  // ���� ������
    public Text UHP;   // ���� ü��
    public Text UATK;  // ���� ���ݷ�
    public Text UCC;     // ���� ����ɼ�
    public Text UCost; // ���� ���
    #endregion
    public Text DC; // ��Ÿ�� �ؽ�Ʈ ǥ��

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
                //GameManager.instance.UHP.text = "ü�� " + unitprefab.GetComponent<UnitControl>().UHp.ToString() + " / " + unitprefab.GetComponent<UnitControl>().MaxUHp.ToString();
                GameManager.instance.UHP.text = "ü�� " + UP.GetComponent<UnitControl>().UHp.ToString() + " / " + UP.GetComponent<UnitControl>().MaxUHp.ToString();
                //GameManager.instance.UATK.text = "���ݷ� " + unitprefab.GetComponent<UnitControl>().UAtk.ToString();
                GameManager.instance.UATK.text = "���ݷ� " + UP.GetComponent<UnitControl>().UAtk.ToString();
                //GameManager.instance.UnitCC.text = "���� ���� �� " + unitprefab.GetComponent<UnitControl>().Max_CC.ToString();
                GameManager.instance.UnitCC.text = "���� ���� �� " + UP.GetComponent<UnitControl>().Max_CC.ToString();
                //GameManager.instance.UCost.text = "��ġ ��� " + unitprefab.GetComponent<UnitControl>().Cost.ToString();
                GameManager.instance.UCost.text = "��ġ ��� " + UP.GetComponent<UnitControl>().Cost.ToString();
                GameManager.instance.UIP.SetActive(true);
            }
            else
            {
                GameManager.instance.UIT = true;
                //GameManager.instance.UName.text = unitprefab.GetComponent<UnitControl>().UName.ToString();
                GameManager.instance.UName.text = UP.GetComponent<UnitControl>().UName.ToString();
                //GameManager.instance.UOccupation.text = unitprefab.GetComponent<UnitControl>().UOccupation.ToString();
                GameManager.instance.UOccupation.text = UP.GetComponent<UnitControl>().UOccupation.ToString();
                //GameManager.instance.UHP.text = "ü�� " + unitprefab.GetComponent<UnitControl>().UHp.ToString() + " / " + unitprefab.GetComponent<UnitControl>().MaxUHp.ToString();
                GameManager.instance.UHP.text = "ü�� " + UP.GetComponent<UnitControl>().UHp.ToString() + " / " + UP.GetComponent<UnitControl>().MaxUHp.ToString();
                //GameManager.instance.UATK.text = "���ݷ� " + unitprefab.GetComponent<UnitControl>().UAtk.ToString();
                GameManager.instance.UATK.text = "���ݷ� " + UP.GetComponent<UnitControl>().UAtk.ToString();
                //GameManager.instance.UnitCC.text = "���� ���� �� " + unitprefab.GetComponent<UnitControl>().Max_CC.ToString();
                GameManager.instance.UnitCC.text = "���� ���� �� " + UP.GetComponent<UnitControl>().Max_CC.ToString();
                //GameManager.instance.UCost.text = "��ġ ��� " + unitprefab.GetComponent<UnitControl>().Cost.ToString();
                GameManager.instance.UCost.text = "��ġ ��� " + UP.GetComponent<UnitControl>().Cost.ToString();
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
            //GameManager.instance.UHP.text = "ü�� " + unitprefab.GetComponent<UnitControl>().UHp.ToString() + " / " + unitprefab.GetComponent<UnitControl>().MaxUHp.ToString();
            GameManager.instance.UHP.text = "ü�� " + UP.GetComponent<UnitControl>().UHp.ToString() + " / " + UP.GetComponent<UnitControl>().MaxUHp.ToString();
            //GameManager.instance.UATK.text = "���ݷ� " + unitprefab.GetComponent<UnitControl>().UAtk.ToString();
            GameManager.instance.UATK.text = "���ݷ� " + UP.GetComponent<UnitControl>().UAtk.ToString();
            //GameManager.instance.UnitCC.text = "���� ���� �� " + unitprefab.GetComponent<UnitControl>().Max_CC.ToString();
            GameManager.instance.UnitCC.text = "���� ���� �� " + UP.GetComponent<UnitControl>().Max_CC.ToString();
            //GameManager.instance.UCost.text = "��ġ ��� " + unitprefab.GetComponent<UnitControl>().Cost.ToString();
            GameManager.instance.UCost.text = "��ġ ��� " + UP.GetComponent<UnitControl>().Cost.ToString();
            GameManager.instance.UIP.SetActive(true);
        }
        else
        {
            GameManager.instance.UIT = true;
            //GameManager.instance.UName.text = unitprefab.GetComponent<UnitControl>().UName.ToString();
            GameManager.instance.UName.text = UP.GetComponent<UnitControl>().UName.ToString();
            //GameManager.instance.UOccupation.text = unitprefab.GetComponent<UnitControl>().UOccupation.ToString();
            GameManager.instance.UOccupation.text = UP.GetComponent<UnitControl>().UOccupation.ToString();
            //GameManager.instance.UHP.text = "ü�� " + unitprefab.GetComponent<UnitControl>().UHp.ToString() + " / " + unitprefab.GetComponent<UnitControl>().MaxUHp.ToString();
            GameManager.instance.UHP.text = "ü�� " + UP.GetComponent<UnitControl>().UHp.ToString() + " / " + UP.GetComponent<UnitControl>().MaxUHp.ToString();
            //GameManager.instance.UATK.text = "���ݷ� " + unitprefab.GetComponent<UnitControl>().UAtk.ToString();
            GameManager.instance.UATK.text = "���ݷ� " + UP.GetComponent<UnitControl>().UAtk.ToString();
            //GameManager.instance.UnitCC.text = "���� ���� �� " + unitprefab.GetComponent<UnitControl>().Max_CC.ToString();
            GameManager.instance.UnitCC.text = "���� ���� �� " + UP.GetComponent<UnitControl>().Max_CC.ToString();
            //GameManager.instance.UCost.text = "��ġ ��� " + unitprefab.GetComponent<UnitControl>().Cost.ToString();
            GameManager.instance.UCost.text = "��ġ ��� " + UP.GetComponent<UnitControl>().Cost.ToString();
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
            #region ���ֹ�ġ��ǥ
            #region 1�� ��ǥ����
            if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
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
            #region 2�� ��ǥ����
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
            #region 3�� ��ǥ����
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
            #region 4�� ��ǥ����
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
            #region 5�� ��ǥ����
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
            #region 6�� ��ǥ����
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
            #region 7�� ��ǥ����
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
                Invoke("CBPOn", 2f);    // ���̻� ��ġ�Ұ����մϴ� ������ ��ȯ�� ��
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
                    #region 1�� ���ֹ�ġ
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-4.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-3.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-2.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-1.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-0.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(1.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(2.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(3.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    #endregion
                    #region 2�� ���ֹ�ġ
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-4.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-3.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-2.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-1.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-0.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(1.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(2.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
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
                    #region 3�� ���ֹ�ġ
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-4.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-3.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-2.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-1.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-0.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(1.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(2.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
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
                    #region 4�� ���ֹ�ġ
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-4.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-3.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-2.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-1.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-0.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(1.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(2.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
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
                    #region 5�� ���ֹ�ġ
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-4.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-3.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-2.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-1.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-0.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(1.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(2.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
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
                    #region 6�� ���ֹ�ġ
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-4.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-3.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-2.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-1.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-0.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 0f && mousepos.x < 0.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(0.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(1.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(2.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
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
                    #region 7�� ���ֹ�ġ
                    if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-4.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-3.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-2.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-1.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(-0.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(1.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                    {
                        Instantiate(UP, new Vector3(2.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                        GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                        Delay();
                    }
                    else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
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
                    Invoke("CBPOn", 2f);    // ���̻� ��ġ�Ұ����մϴ� ������ ��ȯ�� ��
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
            Invoke("CBPOn", 2f);    // ���̻� ��ġ�Ұ����մϴ� ������ ��ȯ�� ��
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
                #region 1�� ���ֹ�ġ
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-4.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-3.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-2.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-1.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-0.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(1.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(2.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 3.5f && mousepos.y > 2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(3.5f, 3.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                #endregion
                #region 2�� ���ֹ�ġ
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-4.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-3.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-2.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-1.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-0.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(1.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(2.5f, 2.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 2.5f && mousepos.y > 1.5f)) // ������ǥ ��ġ
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
                #region 3�� ���ֹ�ġ
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-4.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-3.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-2.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-1.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-0.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(1.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(2.5f, 1.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 1.5f && mousepos.y > 0.5f)) // ������ǥ ��ġ
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
                #region 4�� ���ֹ�ġ
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-4.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-3.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-2.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-1.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-0.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(1.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(2.5f, 0.4f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < 0.5f && mousepos.y > -0.5f)) // ������ǥ ��ġ
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
                #region 5�� ���ֹ�ġ
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-4.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-3.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-2.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-1.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-0.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(1.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(2.5f, -0.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -0.5f && mousepos.y > -1.5f)) // ������ǥ ��ġ
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
                #region 6�� ���ֹ�ġ
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-4.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-3.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-2.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-1.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-0.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 0f && mousepos.x < 0.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(0.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(1.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(2.5f, -1.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -1.5f && mousepos.y > -2.5f)) // ������ǥ ��ġ
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
                #region 7�� ���ֹ�ġ
                if ((mousepos.x > -5f && mousepos.x < -4.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-4.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -4f && mousepos.x < -3.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-3.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -3f && mousepos.x < -2.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-2.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -2f && mousepos.x < -1.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-1.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > -1f && mousepos.x < -0.05f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(-0.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 1f && mousepos.x < 1.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(1.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 2f && mousepos.x < 2.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
                {
                    Instantiate(UP, new Vector3(2.5f, -2.6f, 0f), Quaternion.identity, UnitList.transform);
                    GameManager.instance.Cost -= UP.GetComponent<UnitControl>().Cost;
                    Delay();
                }
                else if ((mousepos.x > 3f && mousepos.x < 3.95f) && (mousepos.y < -2.5f && mousepos.y > -3.5f)) // ������ǥ ��ġ
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
                Invoke("CBPOn", 2f);    // ���̻� ��ġ�Ұ����մϴ� ������ ��ȯ�� ��
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
