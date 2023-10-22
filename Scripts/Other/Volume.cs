using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider;

    private const string VolumeSave = "VolumeValue";

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumeSave, 1f);
        volumeSlider.value = savedVolume;
    }

    // Update is called once per frame
    public void VolumeChange(float value)
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat(VolumeSave, value);
        PlayerPrefs.Save();
    }
}
