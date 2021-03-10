using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabChange : MonoBehaviour
{
    public GameObject TabMove;

    private void Start()
    {
        TabMove.SetActive(false);
    }

    public void TabToMove()
    {
        TabMove.SetActive(true);
    }

    public void TabTarget()
    {
        TabMove.SetActive(false);
    }
}
