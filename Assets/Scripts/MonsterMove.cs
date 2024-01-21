using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterMove : MonoBehaviour
{
    public float Max_Hp;
    public float Hp;
    public float Atk;
    #region 데미지텍스트
    public GameObject D_Text;
    public Transform D_Position;
    #endregion

    public bool BT; // 전투 트리거 : 충돌시 전투발생
    GameObject SP;
    GameObject CU;  // 유닛 판정 : 유닛과 충돌시 해당 유닛 인식
    GameObject CU_Target;

    public GameObject exp;  // 경험치 오브젝트
    public int MANA;    // 사망시 나오는 마나

    int MonsterLayer;

    private Rigidbody2D rigidbody;
    public Animator animator;
    public SpriteRenderer rend;

    //GameObject Unit = null;
    GameObject Base;

    [SerializeField] Transform target;

    private NavMeshAgent agent;
    
    
    private void Awake()
    {
        SP = GameObject.FindGameObjectWithTag("SP");
        gameObject.transform.position = SP.transform.position;
        //Unit = GameObject.FindGameObjectWithTag("Unit");
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Point").transform;
        // rend = GetComponent<SpriteRenderer>();
        Base = GameObject.Find("Point");
        
    }

    void Start()
    {
        MonsterLayer = LayerMask.NameToLayer("Monster");
        gameObject.transform.rotation = Quaternion.identity;
        BT = false;

        if (GameManager.instance.time >= 15)
        {
            Max_Hp = Max_Hp * 2;
            Atk = Atk * 2;
            Hp = Hp * 2;
        }
    }
    private void FixedUpdate()
    {
        NavMeshagent_Target();
        Move();
        agent.SetDestination(target.position);
        if(BT)
            exp.transform.position = gameObject.transform.position;

        /*
        if (gameObject.transform.position.x == Base.transform.position.x)
        {
            gameObject.SetActive(false);
            Debug.Log("몬스터 기지 침입");
            GameManager.instance.EnemyCount += 1;
            GameManager.instance.BaseHPCount -= 1;
        }
        */
    }


    void Update()
    {

    }

    void NavMeshagent_Target()
    {
        if (BT == false)
        {
            target = GameObject.FindGameObjectWithTag("Point").transform;
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }
        else if (BT == true)
        {
            target = CU_Target.transform;
            //target = CU.transform;
            agent = GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
            if(CU.GetComponent<UnitControl>().UHp<=0)
            {
                BT = false;
            }
        }
    }

    void Move()
    {
        agent.SetDestination(target.position);
        animator.SetBool("Walk", true);
    }

    public void Damage(float Atk)
    {
        Hp -= Atk;
        //nowHpBar.fillAmount=(float)Hp/(float)Max_Hp;
        GameObject DamageText = Instantiate(D_Text);
        D_Text.transform.position = D_Position.position;
        DamageText.GetComponent<FloatingDamage>().Damage = Atk;


        if(Hp<=0)
        {
            gameObject.SetActive(false);
            BT = false;
            Hp = Max_Hp;
            gameObject.transform.position = SP.transform.position;
            CU.GetComponent<UnitControl>().StopCoroutine(Battle());
            CU.GetComponent<UnitControl>().CC -= 1;
            GameManager.instance.EnemyCount += 1;
            MANA = Random.RandomRange(5, 10);
            Debug.Log("마나가 " + MANA + "만큼 충전되었습니다.");
            for (int i = 0; i < MANA; i++)
            {
                Instantiate(exp);
            }
        }
    }



    private void OnTriggerExit2D(Collider2D collision)  // 유닛에게서 벗어나면(유닛 사망 또는 저지불가능상태)
    {
        if(collision.gameObject.tag=="Unit")
        {
            BT = false;
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // 유닛과 충돌시
    {
        if (collision.gameObject.tag == "Unit")
        {
            if (UnitControl.instance.CC < UnitControl.instance.Max_CC)
            {
                CU = collision.gameObject;
                CU_Target = CU.transform.GetChild(0).gameObject;
                BT = true;
                StartCoroutine(Battle());
                CU.GetComponent<UnitControl>().CC += 1;
                if (CU.GetComponent<UnitControl>().CC > CU.GetComponent<UnitControl>().Max_CC)
                {
                    CU.GetComponent<UnitControl>().CC = CU.GetComponent<UnitControl>().Max_CC;
                    CU = null;
                    BT = false;
                }
            }
            else
            {
                CU = null;
                target = GameObject.FindGameObjectWithTag("Point").transform;
            }
        }
        else if(collision.gameObject.tag=="Sniper")
        {
            if (UnitControl.instance.CC < UnitControl.instance.Max_CC)
            {
                CU = collision.gameObject;
                CU_Target = CU.transform.GetChild(1).gameObject;
                BT = true;
                StartCoroutine(Battle());
                CU.GetComponent<UnitControl>().CC += 1;
                if (CU.GetComponent<UnitControl>().CC > CU.GetComponent<UnitControl>().Max_CC)
                {
                    CU.GetComponent<UnitControl>().CC = CU.GetComponent<UnitControl>().Max_CC;
                    CU = null;
                    BT = false;
                }
            }
        }
            
        if(collision.gameObject.tag=="Enemy")
        {
            Debug.Log("몬스터끼리 충돌");
        }
    }




    IEnumerator Battle()
    {
        while (true)
        {
            if (BT == true)
            {
                animator.SetBool("Attack", true);
                CU.GetComponent<UnitControl>().Damage(Atk);
                if(CU.GetComponent<UnitControl>().Monster==false)
                {
                    CU.GetComponent<UnitControl>().Monster = gameObject;
                    CU.GetComponent<UnitControl>().BT = true;
                }
            }
            else if (BT == false)
            {
                animator.SetBool("Attack", false);
                animator.SetBool("Walk", true);
            }
            yield return new WaitForSeconds(0.4f);
        }
    }

}
