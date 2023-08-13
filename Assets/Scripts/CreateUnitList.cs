using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateUnitList : MonoBehaviour
{
    public List<GameObject> BU;
    public List<GameObject> BannedUnitPanel;
    private void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            BU[i].SetActive(false);
            BannedUnitPanel[i].SetActive(false);
        }
        /*
        for (int i = 0; i < 6; i++)
        {
            BannedUnitPanel[i].SetActive(false);
        }
        */
    }

    private void Update()
    {
        UnitCheck();
    }

    public void UnitCheck()
    {
        for (int i = 0; i < 6; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf == true)
            {
                BU[i].SetActive(true);
            }
            else if (gameObject.transform.GetChild(i).gameObject.activeSelf == false)
            {
                BU[i].SetActive(false);
                BannedUnitPanel[i].SetActive(true);
            }
        }
    }

    /*
    public void UnitInfoCheck()
    {
        for (int i = 0; i < 6; i++)
        {
            if(BU[i].activeSelf==true)
            {
                Debug.Log("Å¬¸¯");
                GameManager.instance.UIT=true;
                GameManager.instance.UnitSprite.sprite = gameObject.transform.GetChild(i).gameObject.GetComponent<UnitControl>().USP;
                GameManager.instance.UName.text = gameObject.transform.GetChild(i).gameObject.GetComponent<UnitControl>().UName;
                GameManager.instance.UOccupation.text = gameObject.transform.GetChild(i).gameObject.GetComponent<UnitControl>().UOccupation;
                GameManager.instance.UHP.text = gameObject.transform.GetChild(i).gameObject.GetComponent<UnitControl>().UHp.ToString() + " / " + gameObject.transform.GetChild(i).gameObject.GetComponent<UnitControl>().MaxUHp.ToString();
                GameManager.instance.UATK.text = gameObject.transform.GetChild(i).gameObject.GetComponent<UnitControl>().UAtk.ToString();
                GameManager.instance.UnitCC.text = gameObject.transform.GetChild(i).gameObject.GetComponent<UnitControl>().Max_CC.ToString();
                GameManager.instance.UCost.text = gameObject.transform.GetChild(i).gameObject.GetComponent<UnitControl>().Cost.ToString();
            }
        }
    }
    */
}
