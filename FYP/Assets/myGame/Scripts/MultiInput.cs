using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiInput : MonoBehaviour
{
    //https://blog.csdn.net/cbbbc/article/details/51251279#

    //方向键上的贴图    
    //public Texture imageUp;    
    //方向键下的贴图    
    //public Texture imageDown;    
    //方向键左的贴图    
    //public Texture imageLeft;    
    //方向键右的贴图    
    //public Texture imageRight;    
    //按键成功的贴图    
    public Texture imageSuccess;    
        
    //自定义方向键的储存值    
    public const int KEY_UP = 0;    
    public const int KEY_DOWN = 1;    
    public const int KEY_LEFT = 2;    
    public const int KEY_RIGHT = 3;    
    public const int KEY_FIRT = 4;    
        
    //连续按键的事件限制    
    public const int FRAME_COUNT = 100;    
    //仓库中储存技能的数量    
    public const int SAMPLE_SIZE = 3;    
    //每组技能的按键数量    
    public const int SAMPLE_COUNT = 5;    
    //技能仓库    
    int[,] Sample =     
    {    
        //下 + 前 + 下 + 前 + 拳    
        {KEY_DOWN,KEY_RIGHT,KEY_DOWN,KEY_RIGHT,KEY_FIRT},    
        //下 + 前 + 下 + 后 + 拳    
        {KEY_DOWN,KEY_RIGHT,KEY_DOWN,KEY_LEFT,KEY_FIRT},    
        //下 + 后 + 下 + 后 + 拳    
        {KEY_DOWN,KEY_LEFT,KEY_DOWN,KEY_LEFT,KEY_FIRT},    
    };    
        
    //记录当前按下按键的键值    
    int  currentkeyCode =0;    
    //标志是否开启监听按键    
    bool startFrame = false;    
    //记录当前开启监听到现在的时间    
    int  currentFrame = 0;    
    //保存一段时间内玩家输入的按键组合    
    List<int> playerSample;    
    //标志完成操作    
    bool isSuccess= false;    
        
    void Start()    
    {    
        //初始话按键组合链表    
        playerSample  = new List<int>();    
    }    
        
    void OnGUI()    
    {    
        //获得按键组合链表中储存按键的数量    
        int size = playerSample.Count;    
        //遍历该按键组合链表    
        for(int i = 0; i< size; i++)    
        {    
            //将按下按键对应的图片显示在屏幕中    
            int key = playerSample[i];    
            Texture temp = null;    
            /*switch(key)    
            {    
            case KEY_UP:    
                temp = imageUp;    
                break;    
            case KEY_DOWN:    
                temp = imageDown;    
                break;    
            case KEY_LEFT:    
                temp = imageLeft;    
                break;    
            case KEY_RIGHT:    
                temp = imageRight;    
                break;    
            } */   
            if(temp != null)    
            {    
                GUILayout.Label(temp);    
            }    
        }    
            
        if(isSuccess)    
        {    
            //显示成功贴图    
            GUILayout.Label(imageSuccess);

            //Debug.Log("Pressed");
        }    
        //默认提示信息    
        GUILayout.Label("连续组合按键1：下、前、下、前、拳");    
        GUILayout.Label("连续组合按键2：下、前、下、后、拳");    
        GUILayout.Label("连续组合按键2：下、后、下、后、拳");    
    }    
        
    void Update ()     
    {    
        //更新按键    
        UpdateKey();    
            
        if(Input.anyKeyDown)    
        {    
                
            if(isSuccess)    
            {    
                //按键成功后重置    
                isSuccess = false;    
                Reset();    
            }    
                
            if(!startFrame)    
            {    
                //启动时间计数器    
                startFrame = true;    
            }    
                
            //将按键值添加如链表中    
            playerSample.Add(currentkeyCode);    
            //遍历链表    
            int size = playerSample.Count;    
            if(size == SAMPLE_COUNT)    
            {    
                for(int i = 0; i< SAMPLE_SIZE; i++)    
                {    
                    int SuccessCount = 0;    
                    for(int j = 0; j< SAMPLE_COUNT; j++)    
                    {    
                        int temp = playerSample[j];    
                        if(temp== Sample[i,j]){    
                            SuccessCount++;    
                        }    
                    }    
                    //玩家按下的组合按键与仓库中的按键组合相同表示释放技能成功    
                    if(SuccessCount ==SAMPLE_COUNT)    
                    {    
                        isSuccess = true;    
                        break;    
                    }    
                }    
                    
            }    
        }    
            
        if(startFrame)    
        {    
            //计数器++    
            currentFrame++;    
        }    
            
        if(currentFrame >= FRAME_COUNT)    
        {    
            //计数器超时    
            if(!isSuccess)    
            {    
                Reset();    
            }    
        }    
    }    
        
     void Reset ()    
     {    
        //重置按键相关信息    
        currentFrame = 0;    
        startFrame = false;    
        playerSample.Clear();    
     }    
        
    void UpdateKey()    
    {    
        //获取当前键盘的按键信息    
        if (Input.GetKey(KeyCode.UpArrow))//GetKeyDown(KeyCode.W))    
        {    
            currentkeyCode = KEY_UP;    
        }    
        if (Input.GetKey(KeyCode.DownArrow)) //GetKeyDown (KeyCode.S))    
        {    
            currentkeyCode = KEY_DOWN;    
        }    
        if (Input.GetKey(KeyCode.LeftArrow)) //GetKeyDown (KeyCode.A))    
        {    
            currentkeyCode = KEY_LEFT;    
        }    
        if (Input.GetKey(KeyCode.RightArrow)) //GetKeyDown (KeyCode.D))    
        {    
            currentkeyCode = KEY_RIGHT;    
        }    
        if (Input.GetKeyDown (KeyCode.Space))    
        {    
            currentkeyCode = KEY_FIRT;    
        }    
    }

    /*public KeyCode[] KeyCodeSeries;// = new KeyCode[] { KeyCode.X, KeyCode.C, KeyCode.V };

    public float DelayBeforeReset = 5;

    public UnityEngine.Events.UnityEvent OnSeriesComplete;

    public UnityEngine.Events.UnityEvent OnSeriesFailed;

    public UnityEngine.Events.UnityEvent OnTimeRunnedOut;

    private int keyCodeIndex;

    private float lastKeyPressTime;

    private bool isDetected;

    public bool IsDetected() { return isDetected; }

    public MultiInput() { KeyCodeSeries = new KeyCode[0]; } 
    
    public MultiInput(KeyCode[] seq)
    {
        KeyCodeSeries = new KeyCode[seq.Length];
        seq.CopyTo(KeyCodeSeries, 0);
    }

    public bool Check()
    {
        if (KeyCodeSeries.Length > 0)
        {
            if (Input.GetKeyDown(KeyCodeSeries[keyCodeIndex])) { keyCodeIndex++; }
            else if (Input.anyKeyDown) { keyCodeIndex = 0; }

            isDetected = (keyCodeIndex == KeyCodeSeries.Length) ? true : false;

            if (isDetected) { keyCodeIndex = 0; }
        }
        else { isDetected = false; }

        return isDetected;
    }*/

    /*public float inputWindow = 5f;

    float _attack1Time;
    float _attack2Time;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _attack1Time = Time.unscaledTime;
            if (Time.unscaledTime - _attack2Time < inputWindow)
                DoTwoButtonAttact();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _attack2Time = Time.unscaledTime;
            if (Time.unscaledTime - _attack1Time < inputWindow)
                DoTwoButtonAttact();
        }
    }

    void DoTwoButtonAttact()
    {
        Debug.Log("TwoKeyCode");
    }*/
}
