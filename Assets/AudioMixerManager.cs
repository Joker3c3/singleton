using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixerManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] string parameterName = "";
    public void OnValueChanged()
    {
        audioMixer.SetFloat(parameterName,
        (volumeSlider.value <= volumeSlider.minValue) ? -80f : volumeSlider.value);
    }
}
