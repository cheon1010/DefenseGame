using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class UnitInfoManager : MonoBehaviour
{
    public GameObject selectUnit = null;
    public Image UnitImage;
    public Text DefaultName;
    public Text EnglishDefaultName;
    public Text DefaultOccupation;
    public Text DefaultMaxHp;
    public Text DefaultAttack;
    public Text DefaultCC;
    public Text DefaultCost;
    public GameObject UnitInfoPanel;
    public static UnitInfoManager instance;
    
    

    string UName;
    string EUName;
    string UOccu;
    float UMaxHP;
    float UAtk;
    int UCC;
    float UCost;

    public Animator animator;

    public List<GameObject> Units;  // 유닛 프리팹

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Awake()
    {
        UnitInfoManager.instance = this;
        UnitInfoPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UName = selectUnit.GetComponent<UnitControl>().UName;
        EUName = selectUnit.GetComponent<UnitControl>().EUName;
        UOccu = selectUnit.GetComponent<UnitControl>().UOccupation;
        UMaxHP = selectUnit.GetComponent<UnitControl>().MaxUHp;
        UAtk = selectUnit.GetComponent<UnitControl>().UAtk;
        UCost = selectUnit.GetComponent<UnitControl>().Cost;
        UCC = selectUnit.GetComponent<UnitControl>().Max_CC;

        UnitImage.sprite = selectUnit.GetComponent<UnitControl>().USP;
        DefaultName.text = UName.ToString();
        EnglishDefaultName.text = EUName.ToString();
        DefaultOccupation.text = "직    업    군 : " + UOccu;
        DefaultMaxHp.text = "최 대   체 력 : " + UMaxHP.ToString();
        DefaultAttack.text = "공    격    력 : " + UAtk.ToString();
        DefaultCC.text = "저지가능 수 : " + UCC.ToString();
        DefaultCost.text = "배 치   비 용 : " + UCost.ToString();

        if(UnitInfoPanel.activeSelf==true)
        {
            UnitImage.sprite = selectUnit.GetComponent<UnitControl>().USP;
            DefaultName.text = UName.ToString();
            DefaultOccupation.text = "직    업    군 : " + UOccu;
            DefaultMaxHp.text = "최 대   체 력 : " + UMaxHP.ToString();
            DefaultAttack.text = "공    격    력 : " + UAtk.ToString();
            DefaultCC.text = "저지가능 수 : " + UCC.ToString();
            DefaultCost.text = "배 치   비 용 : " + UCost.ToString();
        }

        if (Application.platform == RuntimePlatform.Android)

        {

            if (Input.GetKey(KeyCode.Escape))
                GotoLobbyScene();

        }
    }

   


    public void GotoLobbyScene()
    {
        animator.SetBool("Fade", true);
        Invoke("LobbySceneManager", 1f);
    }

    public void LobbySceneManager()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
