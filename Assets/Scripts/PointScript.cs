using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            Debug.Log("몬스터 침입");
            GameManager.instance.EnemyCount += 1;
            GameManager.instance.BaseHPCount -= 1;
            AudioSource Buzzer = GetComponent<AudioSource>();
            Buzzer.Play();
        }

        else if(collision.gameObject.tag=="EXP")
        {
            collision.gameObject.transform.position=new Vector3(-5.5f, 1, 0);
        }
    }
}
