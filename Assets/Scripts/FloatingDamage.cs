using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingDamage : MonoBehaviour
{
    public float MoveSpeed;
    TextMeshPro text;
    Color alpha;
    public float alphaSpeed;
    float D_Time;
    public float Damage;

    // Start is called before the first frame update
    void Start()
    {
        D_Time = 15.0f;
        text = GetComponent<TextMeshPro>();
        text.outlineWidth = 0.1f;
        text.outlineColor = new Color32(0, 0, 0, 255);

        text.text = Damage.ToString();
        alpha = text.color;
        Invoke("DestroyText", D_Time*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, MoveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
    }

    private void DestroyText()
    {
        Destroy(gameObject);
    }
}
