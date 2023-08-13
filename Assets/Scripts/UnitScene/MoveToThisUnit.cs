using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveToThisUnit : MonoBehaviour
{
    public GameObject UnitInfoPanel;
    public GameObject UIM; //UnitInfoManager
    public GameObject Unitprefab;
    public Image unitsprite;
    public Text UnitName;
    public Button btn;

    GameObject UP;  // ¿Ø¥÷ «¡∏Æ∆’ »£√‚
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "UB1")
        {
            UP = UnitManager.instance.UP[0];
        }
        else if (gameObject.name == "UB2")
        {
            UP = UnitManager.instance.UP[1];
        }
        //unitsprite.sprite = Unitprefab.GetComponent<UnitControl>().USP;
        unitsprite.sprite = UP.GetComponent<UnitControl>().USP;
        //UnitName.text = Unitprefab.GetComponent<UnitControl>().UName;
        UnitName.text = UP.GetComponent<UnitControl>().UName;
        if(UP==null)
        {
            return;
        }

        btn.onClick.AddListener(selectUnit);
    }

    private void Awake()
    {
        UIM = GameObject.Find("UnitInfoManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectUnit()
    {
        UIM.GetComponent<UnitInfoManager>().selectUnit = UP;
        UnitInfoPanel.SetActive(true);
    }
}
