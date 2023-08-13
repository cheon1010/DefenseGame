using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRange : MonoBehaviour
{
    public GameObject targetsignal;
    public GameObject TargetUnit;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(transform.parent.GetComponent<UnitControl>().gameObject + "가 부모의 이름입니다.");
    }


    void FixedUpdate()
    {
        if (transform.parent.GetComponent<UnitControl>().AtkCnt >=
            transform.parent.GetComponent<UnitControl>().Max_AtkCnt)
        {
            transform.parent.GetComponent<UnitControl>().AtkCnt =
                transform.parent.GetComponent<UnitControl>().Max_AtkCnt;
        }
        else if (transform.parent.GetComponent<UnitControl>().AtkCnt < 0)
            transform.parent.GetComponent<UnitControl>().Max_AtkCnt = 0;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {  
            if (transform.parent.gameObject.GetComponent<UnitControl>().AtkCnt <
                transform.parent.gameObject.GetComponent<UnitControl>().Max_AtkCnt)
            {
                transform.parent.GetComponent<UnitControl>().AtkCnt += 1;
                TargetUnit = collision.gameObject;
                transform.parent.GetComponent<UnitControl>().Monster = collision.gameObject;
                transform.parent.GetComponent<UnitControl>().BT = true;
                //transform.parent.GetComponent<UnitControl>().Makesignal();
                Instantiate(targetsignal, gameObject.transform);
                StartCoroutine(transform.parent.GetComponent<UnitControl>().S_Attack());
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if(transform.parent.gameObject.GetComponent<UnitControl>().AtkCnt <
                transform.parent.gameObject.GetComponent<UnitControl>().Max_AtkCnt)
            {
                transform.parent.GetComponent<UnitControl>().AtkCnt += 1;
                TargetUnit = collision.gameObject;
                transform.parent.GetComponent<UnitControl>().Monster = collision.gameObject;
                transform.parent.GetComponent<UnitControl>().BT = true;
                //transform.parent.GetComponent<UnitControl>().Makesignal();
                Instantiate(targetsignal, gameObject.transform);
                StartCoroutine(transform.parent.GetComponent<UnitControl>().S_Attack());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(transform.parent.GetComponent<UnitControl>().Monster==null)
        {

        }
        else
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                transform.parent.gameObject.GetComponent<UnitControl>().Monster = null;
                TargetUnit = collision.gameObject;
                transform.parent.gameObject.GetComponent<UnitControl>().BT = false;
                transform.parent.gameObject.GetComponent<UnitControl>().AtkCnt -= 1;
                Destroy(transform.GetChild(0).gameObject);
            }
        }
    }
}
