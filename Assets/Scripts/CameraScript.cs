using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static CameraScript instance;
    public GameObject SelectedUnit;

    Vector3 MousePosition;
    Camera cam;
    GameObject ColObj;
    public LayerMask layermask;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = cam.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward, 10f);
            //int layerMask = 1 << LayerMask.NameToLayer("Unit");

            //Physics2D.Raycast(transform.position, transform.TransformDirection(Vector3.forward), Mathf.Infinity,layermask);
            //Debug.Log("마우스의 위치는 " + MousePosition + "입니다.");
            Debug.DrawRay(MousePosition, transform.forward * 10, Color.red, 0.3f);
            if (GameManager.instance.UIT==true)
            {
                GameManager.instance.UIT = false;
            }
            /*
            if (hit.collider.gameObject.CompareTag("Unit"))
            {
                Debug.Log(hit.collider.name);
                UnitControl UC = hit.transform.GetComponent<UnitControl>();
                UC.UnitInfo();
            }
            */
            /*
            else if(hit.collider.gameObject.CompareTag("Enemy"))
            {
                Debug.Log(hit.collider.name);
            }
            else if(hit.collider.gameObject.CompareTag("Sniper"))
            {
                Debug.Log(hit.collider.name);
            }
            /*
            if(hit)
            {
                hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
            }
            */
        }
    }

}
