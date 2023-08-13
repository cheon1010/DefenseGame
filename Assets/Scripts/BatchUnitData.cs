using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatchUnitData : MonoBehaviour
{
    GameObject UList;
    GameObject UL;
    List<GameObject> BatchUnits;
    public static BatchUnitData instance;   // 유닛 리스트
    //public List<Button> UnitInfoButton;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    private void Start()
    {
        //UL = GameObject.Find("UnitList");
        /*
        for (int i = 0; i < 6; i++)
        {
            BatchUnits[i] = UL.transform.GetChild(i).gameObject;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        for (int i = 0; i < 6; i++)
        {
            BatchUnits[i] = UL.transform.GetChild(i).gameObject;
            UnitInfoButton[i].onClick.AddListener(() =>
            {
                Debug.Log(BatchUnits[i] + "의 상태를 불러옵니다.");
                GameManager.instance.UIT = true;
                GameManager.instance.UnitSprite.sprite = BatchUnits[i].GetComponent<UnitControl>().USP;
                GameManager.instance.UName.text = BatchUnits[i].GetComponent<UnitControl>().UName;
                GameManager.instance.UOccupation.text = BatchUnits[i].GetComponent<UnitControl>().UOccupation;
                GameManager.instance.UHP.text = BatchUnits[i].GetComponent<UnitControl>().UHp.ToString() + " / " + BatchUnits[i].GetComponent<UnitControl>().MaxUHp.ToString();
                GameManager.instance.UATK.text = BatchUnits[i].GetComponent<UnitControl>().UAtk.ToString();
                GameManager.instance.UnitCC.text = BatchUnits[i].GetComponent<UnitControl>().Max_CC.ToString();
                GameManager.instance.UCost.text = BatchUnits[i].GetComponent<UnitControl>().Cost.ToString();
            });
        }
        */
    }

}