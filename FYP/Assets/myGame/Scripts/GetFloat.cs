using UnityEngine;
using UnityEngine.UI;

public class GetFloat : MonoBehaviour
{
    //public Slider sliderValue;
    public AudioSource BGSound;

    private void Start()
    {
        PlayerPrefs.GetFloat("SliderValue");
        //sliderValue.value = PlayerPrefs.GetFloat("SliderValue");
        //BGSound.volume = sliderValue.value;
        BGSound.volume = PlayerPrefs.GetFloat("SliderValue");
        print("Slider Value (Get) " + PlayerPrefs.GetFloat("SliderValue"));
    }
}
