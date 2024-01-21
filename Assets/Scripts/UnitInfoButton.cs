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
    }

    public void UnitState()
    {
        Debug.Log(BatchUnit.ToString() + "������ ������ �ҷ��ɴϴ�.");
        GameManager.instance.UIT = true;
        GameManager.instance.BatchUnit = BatchUnit;
        CameraScript.instance.SelectedUnit = BatchUnit;
    }
}
