using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public List<GameObject> MonsterPool = new List<GameObject>(); //���� Ǯ
    public GameObject[] Monsters; //���� �迭
    public int obj_Cnt = 1;//������Ʈ ����
    public Transform SP;


    private void Awake()
    {
        for (int i = 0; i < Monsters.Length; i++)
        {
            for (int j = 0; j < obj_Cnt; j++)
            {
                MonsterPool.Add(CreateObject(Monsters[i], SP));
            }
        }
    }

    void Start()
    {
        instance = this;
        StartCoroutine(CreateMonster());
    }

    private void Update()
    {

    }

    GameObject CreateObject(GameObject monster, Transform parent)
    {
        GameObject object_cpy = Instantiate(monster); //���� ������Ʈ ����
        object_cpy.transform.SetParent(parent); //transform ����
        object_cpy.SetActive(false); // ��Ȱ��ȭ

        return object_cpy;//����� ��������
    }

    IEnumerator CreateMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f)); //���� Ȱ��ȭ �ð�
            MonsterPool[MonsterSearch()].GetComponent<MonsterMove>().transform.position =
                SP.position;
            MonsterPool[MonsterSearch()].SetActive(true); //���� ����
                                                          /*
                                                          MonsterPool[MonsterSearch()].GetComponent<MonsterMove>().transform.position =
                                                              SP.position;
                                                         */

            if (GameManager.instance.EnemyCount >= GameManager.instance.EnemyFullCount)
                StopCoroutine(CreateMonster());
        }
    }

    //���� ��ġ
    int MonsterSearch()
    {
        List<int> number_lst = new List<int>();
        //���� Ǯ ��ŭ �ݺ� �����ؼ�
        for (int i = 0; i < MonsterPool.Count; i++)
        {
            //�ѹ�����Ʈ�� �߰�
            if (!MonsterPool[i].activeSelf)
                number_lst.Add(i);
        }
        int result = 0;
        //���� üũ�� ������
        if (number_lst.Count > 0)
            //0���� ī��Ʈ ��-1������ ������ ���� �� ����
            result = number_lst[Random.Range(0, number_lst.Count)];

        return result;//��� ������
    }

    
}
