using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitControl : MonoBehaviour
{
    public static UnitControl instance;

    public float MaxUHp;    // ���� �ִ�ü��
    public float UHp;       // ���� ü��
    public float UAtk;      // ���� ���ݷ�
    public string UName;    // ���� �̸�
    public string EUName;   // ���� �����̸�
    public int Level = 1;   // ���� ����
    public int Max_Level = 5;   // ���� �ִ� ����
    public string UOccupation;    // ���� ������
    public bool BT;     // ������ ���� Ʈ����
    public float Cost;  // ��ġ �ڽ�Ʈ
    public int EnchantCost;   // ��ȭ���
    public int EnchantPer;    // ��ȭȮ��
    public bool CT;     // �� �浹Ȯ�� Ʈ����

    public int CC;  // ���������� ���� ���� ī��Ʈ
    public int Max_CC;  // ���������� �ִ� ���� ī��Ʈ

    public Sprite USP;

    public Image UIS;
    public GameObject UISObj;
    public Sprite UnitSprite;  // ���� ��������Ʈ�̹���

    //public GameObject CT;

    private Rigidbody2D rigidbody;
    public Animator animator; // Animator �Ӽ� ���� ����

    public GameObject Monster = null;
    #region �����������ֿ�
    public int Max_AtkCnt;
    public int AtkCnt;
    #endregion

    public Text HP;
    public float hpbar_H = 0.7f;


    public GameObject EnchantSucces;    // ��ȭ�����ؽ�Ʈ
    public GameObject EnchantFail;  // ��ȭ���� �ؽ�Ʈ
    SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        instance = this;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // animator ������ Player�� Animator �Ӽ����� �ʱ�ȭ'
        transform.GetChild(1).gameObject.SetActive(false);

        if(gameObject.CompareTag("Unit"))
        {
            UnitSprite = GameObject.Find("H_Sprite").GetComponent<ObjectDetector>().UnitSprite;
        }
        else if(gameObject.CompareTag("Sniper"))
        {
            UnitSprite = GameObject.Find("S_Sprite").GetComponent<ObjectDetector>().UnitSprite;
        }

    }

    private void Start()
    {
        CC = 0;
        AtkCnt = 0;
        CT = false;
        if (gameObject.CompareTag("Sniper"))
            animator.SetBool("Start", true);
    }

    private void FixedUpdate()
    {
        if(gameObject.GetComponent<UnitControl>().Level==1)
        {
            EnchantCost = 5;
            EnchantPer =100;
        }
        else if(gameObject.GetComponent<UnitControl>().Level==2)
        {
            EnchantCost = 15;
            EnchantPer =80;
        }
        else if (gameObject.GetComponent<UnitControl>().Level == 3)
        {
            EnchantCost = 35;
            EnchantPer =50;
        }
        else if (gameObject.GetComponent<UnitControl>().Level == 4)
        {
            EnchantCost = 55;
            EnchantPer =30;
        }
    }
    


    public void Damage(float UAtk)
    {
        UHp -= UAtk;
        StartCoroutine(HitColor());
        //nowHpBar.fillAmount = (float)UHp / (float)MaxUHp;

        if (UHp<=0)
        {
            //gameObject.SetActive(false);
            BT = false;
            if(gameObject.CompareTag("Unit"))
            {
                StopCoroutine(Battle());
                animator.SetBool("Death", true);
                Invoke("UnitDeath", 1.06f);
            }
            else if(gameObject.CompareTag("Sniper"))
            {
                StopCoroutine(S_Attack());
                gameObject.SetActive(false);
            }
        }
    }


    /*
     * ���Ÿ����� �� �������� ������ CT=true
     * �Ѹ����� �����ǵ���
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(CC<Max_CC)
        {
            if(gameObject.CompareTag("Unit"))
            {
                if(collision.gameObject.tag=="Enemy")
                {
                    if(BT==false)
                    {
                        Monster = collision.gameObject;
                        BT = true;
                        StartCoroutine(Battle());
                    }
                    else if(BT==true)
                    {
                        return;
                    }
                }
            }
            /*
            if(gameObject.CompareTag("Sniper"))
            {
                if(collision.gameObject.tag=="Enemy")
                {
                    if(BT==false)
                    {
                        Monster = collision.gameObject;
                        BT = true;
                        Instantiate(TargetSignal,gameObject.transform);
                        StartCoroutine(S_Attack());
                    }
                    else if (BT==true)
                    {
                        return;
                    }
                }
            }
            */
        }
        else if(CC>=Max_CC)
        {
            if(gameObject.CompareTag("Unit"))
            {
                if (CC > Max_CC)
                    CC = Max_CC;
                return;
            }
            if(gameObject.CompareTag("Sniper"))
            {
                if (CC > Max_CC)
                    CC = Max_CC;
                return;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(CC<Max_CC)
        {
            if(gameObject.CompareTag("Unit"))
            {
                if (collision.gameObject.tag == "Enemy")
                {
                    if(BT==true)
                    {
                        return;
                    }
                    else if(BT==false)
                    {
                        Monster = collision.gameObject;
                        BT = true;
                        StartCoroutine(Battle());
                    }
                }
            }
            /*
            else if(gameObject.CompareTag("Sniper"))
            {
                if(collision.gameObject.tag=="Enemy")
                {
                    if (BT == true)
                        return;
                    else if(BT==false)
                    {
                        Monster = collision.gameObject;
                        BT = true;
                        StartCoroutine(S_Attack());
                    }
                }
            }
            */
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (gameObject.CompareTag("Unit"))
            {
                if (CC == 0)
                {
                    StopCoroutine(Battle());
                    Monster = null;
                    BT = false;
                    //Debug.Log("���� ����");
                }
                else if (collision.gameObject==Monster)
                {
                    StopCoroutine(Battle());
                    Monster = null;
                    BT = false;
                }
                //Debug.Log("���� ����");
            }
            /*
            else if(gameObject.CompareTag("Sniper"))
            {
                StopCoroutine(S_Attack());
                Monster = null;
                BT = false;
                CT = false;

                //Destroy(transform.GetChild(0).gameObject);
                //TargetSignalScript.instance.TargetSignalDestroy();
                //Debug.Log("�������");
            }
            */
        }
    }

    


    public IEnumerator Battle()    // �ٰŸ����� ���� �ڷ�ƾ
    {
        while(true)
        {
            if (BT==true)
            {
                animator.SetBool("Battle", true);
                Monster.GetComponent<MonsterMove>().Damage(UAtk);
                yield return new WaitForSeconds(1.08f);
            }
            else if (BT==false)
            {
                animator.SetBool("Battle", false);
                yield return new WaitForSeconds(1.08f);
            }

        }
    }

    public IEnumerator S_Attack()  // ���Ÿ����� ���� �ڷ�ƾ
    {
        while(true)
        {
            if(BT)
            {
                animator.SetBool("Attack", true);
                Monster.GetComponent<MonsterMove>().Damage(UAtk);
                yield return new WaitForSeconds(3f);
            }
            else if(!BT)
            {
                animator.SetBool("Attack", false);
                yield return new WaitForSeconds(3f*Time.deltaTime);
            }
        }
    }

    public IEnumerator HitColor()
    {
        mySpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        if(UHp>0)
        {
            mySpriteRenderer.color = new Color(255, 255, 255);
        }
    }

    public void UnitInfo()
    {
        UIS.sprite = USP;
        if (GameManager.instance.UIT)
        {
            GameManager.instance.UIP.SetActive(false);
            GameManager.instance.UIT = false;
        }
        else if (GameManager.instance.UIT == false)
        {
            GameManager.instance.UIT = true;
            GameManager.instance.UnitSprite = UIS;
            GameManager.instance.UIP.SetActive(true);
            GameManager.instance.UName.text = UName.ToString();
            GameManager.instance.UOccupation.text = UOccupation.ToString();
            GameManager.instance.UHP.text = "ü�� " + UHp.ToString() + " / " + MaxUHp.ToString();
            GameManager.instance.UATK.text = "���ݷ� " + UAtk.ToString();
            GameManager.instance.UnitCC.text = "���� ���� �� " + Max_CC.ToString();
            GameManager.instance.UCost.text = "��ġ ��� " + Cost.ToString();
            GameManager.instance.UenchantCost.text = " ��ȭ��� " + Cost.ToString();
            GameManager.instance.UCost.text = "��ȭ������ " + Cost.ToString();
        }
    }
    
    public void UnitDeath()
    {
        gameObject.SetActive(false);
    }


}
