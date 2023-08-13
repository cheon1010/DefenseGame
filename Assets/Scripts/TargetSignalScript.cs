using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSignalScript : MonoBehaviour
{
    public static TargetSignalScript instance;

    float t;
    [SerializeField]float rotateSpeed;
    public GameObject Target;
    GameObject SU;  // 부모 스나이퍼 유닛 호출
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        SU = transform.parent.gameObject;
        instance = this;
        //Target = SU.GetComponent<UnitControl>().Monster;
        Target = SU.GetComponent<SniperRange>().TargetUnit;
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y - 0.2f,
            Target.transform.position.z);
        transform.Rotate(new Vector3(0, 0, -100f) * Time.deltaTime) ;
        if (Target.activeSelf == false)
            TargetSignalDestroy();

    }

    public void TargetSignalDestroy()
    {
        Destroy(gameObject);
    }
}
