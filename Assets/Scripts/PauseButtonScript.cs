using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : MonoBehaviour
{
    GameObject PAUSE;
    // Start is called before the first frame update
    void Start()
    {
        PAUSE = GameObject.Find("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        PAUSE.GetComponent<Pause>().GamePause();
    }

    public void Setting()
    {

    }

    public void Surrender()
    {

    }
}
