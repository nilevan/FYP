using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetContent : MonoBehaviour
{
    public Text Content;
    public string[] ContentChose;
    public string contentChosen;
    private int time;
    public Sprite[] ContentImage;
    public Sprite ChosenSprite;
    public Image ChosenImage;

    private void Start()
    {
        time = System.DateTime.Now.Minute;
        print(time);
        int choose = Random.Range(1, (ContentChose.Length)) - 1;
        Content.text = ContentChose[choose];
        contentChosen = Content.text;
        ChosenSprite = ContentImage[choose];
        ChosenImage.sprite = ChosenSprite;
    }

    private void Update()
    {
        //int time = System.DateTime.Now.Day;

        int a = ContentChose.Length;

        if (System.DateTime.Now.Minute != time)
        {
            int b = Random.Range(1, a);
            Content.text = ContentChose[(b-1)];
            contentChosen = Content.text;
            print("contentChose = " + contentChosen);
            time = System.DateTime.Now.Minute;
        }

        for(int i=0; i<ContentChose.Length; i++)
        {
            if (Content.text == ContentChose[i])
            {
                ChosenSprite = ContentImage[i];
                ChosenImage.sprite = ChosenSprite;
            }

        }

    }
}
