using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using NavMeshPlus;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Animator animator;
    public static GameManager instance;
    public Camera MCamera;

    public int Mana = 0;    // ����(���Ͱ�ȭ��)
    int Max_Mana = 300;  // �ִ� ����

    public Image MHB;
    public Canvas MC;
    public Image UHB;

    public Text LeftEnemy;
    public Text BaseHP;
    public Text CostTXT;

    public float EnemyFullCount = 40;
    public float EnemyCount;
    public float BaseHPCount;
    public float Cost;
    public Image CostFill;
    public Image CostFillMana;

    public float time;
   
    public Text BatchCountText; // ��ġ���ɼ� �ؽ�Ʈ
    #region UI/��������â
    public Image UnitSprite;   // �����Ϸ���Ʈ
    public GameObject UIP;  // ��������â
    public Text UName;  // ���� �̸�
    public Text ULevel; // ���� ����
    public Text UOccupation;    // ���� ������
    public Text UHP;   // ���� ü��
    public Text UATK;   // ���� ���ݷ�
    public Text UnitCC; // ���� �������ɼ�
    public Text UCost;  // ���� ��ġ���
    public Text UenchantCost;   // ���� ��ȭ���
    public Text UEnchantPer;    // ���� ��ȭȮ��
    public GameObject NEC;  //��ġ�����˸�â
    public GameObject BannedUnit;   // ��ġ����â
    public GameObject PosBanned;    // ��ǥ����â
    public GameObject SUS;  // ���õ� ���� ǥ���ϴ� ������
    public GameObject BatchUnit;   // ���õ� ����
    private Vector3 velocity = Vector3.zero;
    public GameObject BUT;   //���õ� ������ ��ǥ ȣ��
    #endregion

    public bool UIT;    // ��������â Ʈ����
    public int BatchCount = 6;
    GameObject PoolManager;
    GameObject UList;
    GameObject PauseCanvas;
    public GameObject SPanel;
    public GameObject PauseSquare;
    SpriteRenderer spriteRenderer;

    public GameObject OptionPanel;


    public Text ManaText;
    GameObject BGM;
    AudioSource BattleBGM;
    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas = GameObject.Find("PauseCanvas");
        animator = GetComponent<Animator>();
        time = 0;
        UList = GameObject.Find("UnitList");
        PoolManager = GameObject.Find("PoolManager");
        UIT = false;
        SUS.SetActive(false);
        UIP.SetActive(false);
        CostFill.fillAmount = 0;
        CostFillMana.fillAmount = 0;
        EnemyCount = 0;
        BaseHPCount = 5;
        NEC.SetActive(false);
        BannedUnit.SetActive(false);
        PosBanned.SetActive(false);
        BatchCountText.text = "��ġ���� �� : " + BatchCount;
        Invoke("StartBattleBGM", 1.2f);
        spriteRenderer = PauseSquare.GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        CostFill.fillAmount += 0.05f*Time.deltaTime;
        CostFillMana.fillAmount += 0.01f * Time.deltaTime;
        CostFilling();
        CostTXT.text = Cost.ToString();
        BaseHP.text = BaseHPCount.ToString();
        LeftEnemy.text = EnemyCount.ToString() + " / "+EnemyFullCount.ToString();
        StopCreateMonster();
        UIPActive();
        BatchCountText.text = "��ġ���� �� : " + BatchCount;
        ManaText.text = Mana.ToString();
        SignalRotate();
        CameraZoom();
        GameOver();
        TimeCount();
    }

    void GameOver()
    {
        if(BaseHPCount==0)
        {
            Debug.Log("Game Over");
            PoolManager.SetActive(false);
            UList.SetActive(false);
            PauseSquare.SetActive(true);
            spriteRenderer.color = new Color(1f, 0f, 0f, 0.44f);
        }
    }

    void CostFilling()
    {
        if(BaseHPCount==0)
        {
            CostFill.fillAmount = 0f;
            CostFillMana.fillAmount = 0f;
        }
        else
        {
            CostFill.fillAmount += 5f * Time.deltaTime;
            CostFillMana.fillAmount += 1f * Time.deltaTime;
        }
        
        if (CostFill.fillAmount==1)
        {
            if(Cost>=99)
            {
                CostFill.fillAmount = 0;
            }
            else
            {
                Cost += 1;
                CostFill.fillAmount = 0;
            }
        }
        if(CostFillMana.fillAmount==1)
        {
            if(Mana>=Max_Mana)
            {
                CostFillMana.fillAmount = 0;
            }
            else
            {
                Mana += 1;
                CostFillMana.fillAmount = 0;
            }
        }
        
    }

    void StopCreateMonster()
    {
        if (EnemyCount >= EnemyFullCount)
        {
            EnemyCount = EnemyFullCount;
        }
        if (BaseHPCount <= 0)
            BaseHPCount = 0;
    }

    void TimeCount()
    {
        time += Time.deltaTime;
    }

    void UIPActive()
    {
        if(UIT==false)
        {
            UIP.SetActive(false);
            SUS.SetActive(false);
        }
        else if (UIT==true)
        {
            BUT.transform.position = new Vector3(BatchUnit.transform.position.x, BatchUnit.transform.position.y, -10f);
            if (Time.timeScale == 0)
                return;
            else if(Time.timeScale==1)
                SUS.SetActive(true);
            SUS.transform.position = new Vector3(BatchUnit.transform.position.x, BatchUnit.transform.position.y + 0.78f, BatchUnit.transform.position.z);
            UIP.SetActive(true);
            UnitSprite.sprite = BatchUnit.GetComponent<UnitControl>().USP;
            UName.text = BatchUnit.GetComponent<UnitControl>().UName;
            ULevel.text = "Level. " + BatchUnit.GetComponent<UnitControl>().Level.ToString();
            UOccupation.text = "������"+" "+BatchUnit.GetComponent<UnitControl>().UOccupation;
            UHP.text ="ü�� : "+ BatchUnit.GetComponent<UnitControl>().UHp.ToString() + " / " +
                BatchUnit.GetComponent<UnitControl>().MaxUHp.ToString();
            UATK.text = "���ݷ� :    "+BatchUnit.GetComponent<UnitControl>().UAtk.ToString();
            UnitCC.text = "����ɼ� :   "+BatchUnit.GetComponent<UnitControl>().Max_CC.ToString();
            UCost.text = "��ġ��� : "+BatchUnit.GetComponent<UnitControl>().Cost.ToString();
            UenchantCost.text = "��ȭ��� : "+BatchUnit.GetComponent<UnitControl>().EnchantCost.ToString();
            UEnchantPer.text = "��ȭ ������ : "+BatchUnit.GetComponent<UnitControl>().EnchantPer.ToString()+"%";
        }
    }

    public void SignalRotate()
    {
        SUS.transform.Rotate(10f, 0, 0);
    }
    
    public void CameraZoom()
    {
        if (Time.timeScale == 0)
            return;
        else if(Time.timeScale==1)
        {
            if (UIT == true)
            {
                if (MCamera.orthographicSize > 3f)
                {
                    MCamera.transform.position = Vector3.SmoothDamp(MCamera.transform.position, BUT.transform.position,
                    ref velocity, 0.1f);
                    MCamera.orthographicSize -= 0.2f;
                    if (MCamera.orthographicSize <= 3f)
                    {
                        MCamera.orthographicSize = 3f;
                    }
                }
                else if (MCamera.orthographicSize <= 3f)
                {
                    MCamera.orthographicSize = 3f;
                }
            }
            else if (UIT == false)
            {
                MCamera.transform.position = Vector3.SmoothDamp(BUT.transform.position, new Vector3(0, 0, MCamera.transform.position.z),
                    ref velocity, -0.1f);
                MCamera.orthographicSize += 0.2f;
                if (MCamera.orthographicSize >= 5f)
                {
                    MCamera.orthographicSize = 5f;
                    MCamera.transform.position = new Vector3(0, 0, -10);
                }
            }
        }
    }

    public void SurrenderPanelOn()
    {
        SPanel.SetActive(true);
    }

    public void SurrenderFunctionYes()
    {
        SPanel.SetActive(false);
        animator.SetBool("Fade", true);
        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime>=1f)
        {
            Time.timeScale = 1f;
            Invoke("SurrenderScene", 1f);
        }
    }

    public void SurrenderFunctionNo()
    {
        SPanel.SetActive(false);

    }

    public void SurrenderScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void OptionOn()
    {
        if (OptionPanel.activeSelf == false)
            OptionPanel.SetActive(true);
    }

}
