using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TimeControl : MonoBehaviour
{
    public float FullTime = 45f;
    public bool CanCount ;
    public GameObject Stop01, Stop02, Stop03;
    public GameObject Door01, Door02, Door03, Door04, Door05;
    public GameObject BackHome, BtnSteal, BtnPress;

    public AudioSource audioSource;
    public AudioSource BG00;

    private void Start()
    {
        Stop02.GetComponent<Animator>().enabled = false;
        Stop03.GetComponent<Animator>().enabled = false;

        Door01.GetComponent<Animator>().enabled = false;
        Door02.GetComponent<Animator>().enabled = false;
        Door03.GetComponent<Animator>().enabled = false;
        Door04.GetComponent<Animator>().enabled = false;
        Door05.GetComponent<Animator>().enabled = false;

        CanCount = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (FullTime > 30f && FullTime < 30.2f )
        {
            Stop01.GetComponent<Animator>().enabled = false;
            Stop01.GetComponent<Image>().color = Color.grey;

            Stop02.GetComponent<Animator>().enabled = true;

            Door01.GetComponent<Animator>().enabled = true;
            Door02.GetComponent<Animator>().enabled = true;
            Door03.GetComponent<Animator>().enabled = true;
            Door04.GetComponent<Animator>().enabled = true;
            Door05.GetComponent<Animator>().enabled = true;

            audioSource.Play();
        }

        if (FullTime > 15f && FullTime < 15.2f)
        {
            Stop02.GetComponent<Animator>().enabled = false;
            Stop02.GetComponent<Image>().color = Color.grey;

            Stop03.GetComponent<Animator>().enabled = true;

            audioSource.Play();
        }

        if (FullTime > 0 && CanCount == true)
        {
            FullTime -= Time.deltaTime;

            if (FullTime < 0.1f)
            {
                Stop03.GetComponent<Animator>().enabled = false;
                Stop03.GetComponent<Image>().color = Color.grey;

                CanCount = false;

                audioSource.Play();

                BackHome.SetActive(true);
                BtnSteal.SetActive(false);
                BtnPress.SetActive(false);
                BG00.Stop();
}
        }
    }
}
