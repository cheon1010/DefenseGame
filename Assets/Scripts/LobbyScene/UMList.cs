using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UMList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        Destroy(gameObject.transform.GetChild(1));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
