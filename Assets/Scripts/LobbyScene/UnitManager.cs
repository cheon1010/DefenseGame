using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;
    public List<GameObject> UP; // ���� ������
    public List<GameObject> USP;    // ���� �Ƿ翧 ������
    public List<GameObject> EP; // ���� ������

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if(GameManager.instance.time>=15)
        {
            EP[0].GetComponent<MonsterMove>().Max_Hp = EP[0].GetComponent<MonsterMove>().Max_Hp * 2;
            EP[0].GetComponent<MonsterMove>().Hp = EP[0].GetComponent<MonsterMove>().Hp * 2;
            EP[0].GetComponent<MonsterMove>().Atk = EP[0].GetComponent<MonsterMove>().Atk * 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
