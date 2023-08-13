using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public List<GameObject> MonsterPool = new List<GameObject>(); //몬스터 풀
    public GameObject[] Monsters; //몬스터 배열
    public int obj_Cnt = 1;//오브젝트 개수
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
        GameObject object_cpy = Instantiate(monster); //몬스터 오브젝트 생성
        object_cpy.transform.SetParent(parent); //transform 연결
        object_cpy.SetActive(false); // 비활성화

        return object_cpy;//결과물 내보내기
    }

    IEnumerator CreateMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 5f)); //몬스터 활성화 시간
            MonsterPool[MonsterSearch()].GetComponent<MonsterMove>().transform.position =
                SP.position;
            MonsterPool[MonsterSearch()].SetActive(true); //랜덤 생성
                                                          /*
                                                          MonsterPool[MonsterSearch()].GetComponent<MonsterMove>().transform.position =
                                                              SP.position;
                                                         */

            if (GameManager.instance.EnemyCount >= GameManager.instance.EnemyFullCount)
                StopCoroutine(CreateMonster());
        }
    }

    //몬스터 서치
    int MonsterSearch()
    {
        List<int> number_lst = new List<int>();
        //몬스터 풀 만큼 반복 진행해서
        for (int i = 0; i < MonsterPool.Count; i++)
        {
            //넘버리스트에 추가
            if (!MonsterPool[i].activeSelf)
                number_lst.Add(i);
        }
        int result = 0;
        //개수 체크를 진행해
        if (number_lst.Count > 0)
            //0부터 카운트 값-1까지의 범위의 랜덤 값 설정
            result = number_lst[Random.Range(0, number_lst.Count)];

        return result;//결과 내보냄
    }

    
}
