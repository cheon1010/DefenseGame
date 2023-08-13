using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragEvent : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{
    public static Vector2 DefaultPos;
    public GameObject UnitSprite;
    public GameObject UnitPrefab;
    public void OnBeginDrag(PointerEventData eventData)
    {
        DefaultPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = DefaultPos ;
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
