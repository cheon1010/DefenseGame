using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantAnimation : MonoBehaviour
{
    Animator animator;
    public GameObject AnimObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationON()
    {
        AnimObject.GetComponent<Animator>().SetBool("Success", true);
    }
}
