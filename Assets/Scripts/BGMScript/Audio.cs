using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    AudioSource BGM;
    public AudioClip Intro;
    public AudioClip Loop;
    // Start is called before the first frame update
    void Start()
    {
        //BGM.Stop();
    }

    private void Awake()
    {
        BGM = GetComponent<AudioSource>();
        BGM.Stop();
        BGM.volume = 0.5f;
        StartCoroutine(PlayBGM());
    }

    // Update is called once per frame
    void Update()
    {
        if(BGM.isPlaying==false)
        {
            BGM.clip = Loop;
            BGM.loop = true;
            BGM.Play();
        }
    }

    IEnumerator PlayBGM()
    {
        BGM.clip = Intro;
        BGM.Play();
        while(true)
        {
            yield return new WaitForSeconds(0f);
            if(!BGM.isPlaying)
            {
                BGM.clip = Loop;
                BGM.Play();
                BGM.loop = true;
            }
        }
    }
}
