using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoButton : MonoBehaviour
{
    Button BTN;
    GameObject UnitList;
    GameObject BatchUnit;
    public int ButtonCount;
    // Start is called before the first frame update
    void Start()
    {
        BTN = gameObject.transform.GetComponent<Button>();
        UnitList = GameObject.Find("UnitList");
        BatchUnit = UnitList.transform.GetChild(ButtonCount).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        BTN.onClick.AddListener(UnitState);
        /*
        if(GameManager.instance.UIT==true)
        {
            //GameManager.instance.UIT = true;
            GameManager.instance.UnitSprite.sprite = BatchUnit.GetComponent<UnitControl>().USP;
            GameManager.instance.UName.text = BatchUnit.GetComponent<UnitControl>().UName;
            GameManager.instance.UOccupation.text = BatchUnit.GetComponent<UnitControl>().UOccupation;
            GameManager.instance.UHP.text = BatchUnit.GetComponent<UnitControl>().UHp.ToString() +
                " / " + BatchUnit.GetComponent<UnitControl>().MaxUHp.ToString();
            GameManager.instance.UATK.text = BatchUnit.GetComponent<UnitControl>().UAtk.ToString();
            GameManager.instance.UnitCC.text = BatchUnit.GetComponent<UnitControl>().Max_CC.ToString();
            GameManager.instance.UCost.text = BatchUnit.GetComponent<UnitControl>().Cost.ToString();
        }    
        else
        {
            GameManager.instance.UnitSprite.sprite = null;
            GameManager.instance.UName.text = null;
            GameManager.instance.UOccupation.text = null;
            GameManager.instance.UHP.text = null;
            GameManager.instance.UATK.text = null;
            GameManager.instance.UnitCC.text = null;
            GameManager.instance.UCost.text = null;
        }
        */

    }

    public void UnitState()
    {
        Debug.Log(BatchUnit.ToString() + "유닛의 정보를 불러옵니다.");
        GameManager.instance.UIT = true;
        GameManager.instance.BatchUnit = BatchUnit;
        CameraScript.instance.SelectedUnit = BatchUnit;
    }
}
