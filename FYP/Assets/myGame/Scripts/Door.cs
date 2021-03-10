using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public TimeControl TimeCon;
    public GameObject BackHome, btnSteal;

    public AudioSource BG;

    private void Start()
    {
        BackHome.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )//&& TimeCon.CanCount == false)
        {
            BackHome.SetActive(true);
            TimeCon.CanCount = false;
            btnSteal.SetActive(false);
            BG.Stop();
        }
    }
}
