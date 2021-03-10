using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateTime : MonoBehaviour
{
    public int MinuteNum;
    public List<GameObject> TestObject;
     Renderer cubeColor;
     Text colorTxt;
     Material[] mat;

    void Start()
    {
        string time = System.DateTime.Now.Day.ToString();
        print("Time: " + time); // print the date e.g. today is 25 Jan 2021, it print 25

        MinuteNum = System.DateTime.Now.Minute;
        print(MinuteNum);
    }

    private void Update()
    {
        if (System.DateTime.Now.Minute != MinuteNum)
        {
            /*int a = Random.Range(0, TestObject.Count);
            Debug.Log(a);
            Destroy(GameObject.FindGameObjectWithTag("test"));
            GameObject b = Instantiate(TestObject[Random.Range(0, TestObject.Count)], this.transform.position, Quaternion.identity);*/
            int a = Random.Range(0, mat.Length);
            print("No: " + a);
            cubeColor.material = mat[a];

            switch (cubeColor.material.name)
            {
                case "green (Instance)":
                    colorTxt.text = "Color 0";
                    print(mat[0].name);
                    break;
                case "red (Instance)":
                    colorTxt.text = "Color 1";
                    print(mat[1].name);
                    break;
                case "white (Instance)":
                    colorTxt.text = "Color 2";
                    print(mat[2].name);
                    break;
                case "yellow (Instance)":
                    colorTxt.text = "Color 3";
                    print(mat[3].name);
                    break;
            }

            /*if (cubeColor.material.name == "green (Instance)")
            {
                colorTxt.text = "Color 0";
                print(mat[0].name);
            }else if (cubeColor.material.name == "red (Instance)")
            {
                colorTxt.text = "Color 1";
                print(mat[1].name);
            }else if(cubeColor.material.name == "white (Instance)")
            {
                colorTxt.text = "Color 2";
                print(mat[2].name);
            }
            else if (cubeColor.material.name == "yellow (Instance)")
            {
                colorTxt.text = "Color 3";
                print(mat[3].name);
            }*/

            MinuteNum = System.DateTime.Now.Minute;
            print(MinuteNum);
        }
    }

}
