using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnitControl : MonoBehaviour
{
    public static UnitControl instance;

    public float MaxUHp;    // 유닛 최대체력
    public float UHp;       // 유닛 체력
    public float UAtk;      // 유닛 공격력
    public string UName;    // 유닛 이름
    public string EUName;   // 유닛 영어이름
    public int Level = 1;   // 유닛 레벨
    public int Max_Level = 5;   // 유닛 최대 레벨
    public string UOccupation;    // 유닛 직업군
    public bool BT;     // 적과의 전투 트리거
    public float Cost;  // 배치 코스트
    public int EnchantCost;   // 강화비용
    public int EnchantPer;    // 강화확률
    public bool CT;     // 적 충돌확인 트리거

    public int CC;  // 근접유닛의 현재 저지 카운트
    public int Max_CC;  // 근접유닛의 최대 저지 카운트

    public Sprite USP;

    public Image UIS;
    public GameObject UISObj;
    public Sprite UnitSprite;  // 유닛 스프라이트이미지

    //public GameObject CT;

    private Rigidbody2D rigidbody;
    public Animator animator; // Animator 속성 변수 생성

    public GameObject Monster = null;
    #region 스나이퍼유닛용
    public int Max_AtkCnt;
    public int AtkCnt;
    #endregion

    public Text HP;
    public float hpbar_H = 0.7f;


    public GameObject EnchantSucces;    // 강화성공텍스트
    public GameObject EnchantFail;  // 강화실패 텍스트
    SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        instance = this;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // animator 변수를 Player의 Animator 속성으로 초기화'
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
     * 원거리유닛 적 범위내에 있으면 CT=true
     * 한마리만 포착되도록
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
                    //Debug.Log("전투 종료");
                }
                else if (collision.gameObject==Monster)
                {
                    StopCoroutine(Battle());
                    Monster = null;
                    BT = false;
                }
                //Debug.Log("전투 종료");
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
                //Debug.Log("사격종료");
            }
            */
        }
    }

    


    public IEnumerator Battle()    // 근거리유닛 공격 코루틴
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

    public IEnumerator S_Attack()  // 원거리유닛 공격 코루틴
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
            GameManager.instance.UHP.text = "체력 " + UHp.ToString() + " / " + MaxUHp.ToString();
            GameManager.instance.UATK.text = "공격력 " + UAtk.ToString();
            GameManager.instance.UnitCC.text = "제어 가능 수 " + Max_CC.ToString();
            GameManager.instance.UCost.text = "배치 비용 " + Cost.ToString();
            GameManager.instance.UenchantCost.text = " 강화비용 " + Cost.ToString();
            GameManager.instance.UCost.text = "강화성공률 " + Cost.ToString();
        }
    }
    
    public void UnitDeath()
    {
        gameObject.SetActive(false);
    }


}
