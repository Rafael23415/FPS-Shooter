using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    public Slider brightnesSlider;

    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    AutoExposure exposure;

    private const string BrightnessSave = "BrightnessValue";

    void Start()
    {
        brightness.TryGetSettings(out exposure);
        float savedBrightness = PlayerPrefs.GetFloat(BrightnessSave, 1f);
        brightnesSlider.value = savedBrightness;
        BrightnessChange(brightnesSlider.value);
    }

    public void BrightnessChange(float value)
    {
        if(value != 0)
        {
            exposure.keyValue.value = value;
            PlayerPrefs.SetFloat(BrightnessSave, value);
            PlayerPrefs.Save();
        }
        else
        {
            exposure.keyValue.value = 0.05f;
            PlayerPrefs.SetFloat(BrightnessSave, 0.05f);
            PlayerPrefs.Save();
        }
    }
}
