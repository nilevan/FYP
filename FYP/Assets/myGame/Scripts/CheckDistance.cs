using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDistance : MonoBehaviour
{
    Button btn;
    public GameObject myButton;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn = GameObject.Find("Btn_Steal").GetComponent<Button>();
        btn.interactable = false;

        //myButton = GameObject.Find("Button");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (btn.interactable == true)
            myButton.SetActive(true);

        if (btn.interactable == false)
        {
            myButton.SetActive(false);
        }

        if (Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position) <= 3)
        {
            btn.interactable = true;
            //Debug.Log("steal");
            
        }
        else
        {
            btn.interactable = false;
        }
            
    }

}
