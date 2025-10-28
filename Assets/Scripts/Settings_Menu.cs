using UnityEngine;
using UnityEngine.Audio;

public class Settings_Menu : MonoBehaviour
{
    public AudioMixer mixer;
    public void setvolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }

    public void Qualitylevel(int Qualityindex)
    {
        QualitySettings.SetQualityLevel(Qualityindex);
    }
}
