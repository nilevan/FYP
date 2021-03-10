using UnityEngine;
using UnityEngine.UI;

public class SetFloat : MonoBehaviour
{
    public Slider sliderAmt;
    private float sliderFloat;
    public AudioSource BGSound;

    void Start()
    {
        if (PlayerPrefs.GetFloat("SliderValue") == null)
        {
            sliderFloat = 0.5f;
            print("First time");
        }
            
        //sliderFloat = sliderAmt.value;
        sliderFloat = PlayerPrefs.GetFloat("SliderValue");
        sliderAmt.value = sliderFloat;
        BGSound.volume = sliderAmt.value;
        print("slider value = " + sliderAmt.value);
    }

    public void ValueChange()
    {
        BGSound.volume = sliderAmt.value;

        PlayerPrefs.SetFloat("SliderValue", sliderAmt.value);
        print("PlayerPrefs value: " + sliderAmt.value);
        print(PlayerPrefs.GetFloat("SliderValue"));
    }
}
