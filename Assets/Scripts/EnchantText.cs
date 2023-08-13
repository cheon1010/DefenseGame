using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
        gameObject.transform.localScale = new Vector3(0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localScale.x<0.2f&&gameObject.transform.localScale.y<0.2f)
        {
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);
        }
        else if(gameObject.transform.localScale.x>=0.2f&&gameObject.transform.localScale.y>=0.2f)
        {
            Invoke("InvokeText", 1f);
        }
    }

    public void InvokeText()
    {
        Destroy(gameObject);
    }
}
