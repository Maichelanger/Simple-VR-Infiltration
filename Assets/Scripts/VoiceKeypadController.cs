using Oculus.Voice;
using UnityEngine;

public class VoiceKeypadController : MonoBehaviour
{
    [SerializeField] private DeviceController deviceController;

    private AppVoiceExperience voiceExperience;

    private void Start()
    {
        voiceExperience = GetComponent<AppVoiceExperience>();
    }

    public void GetCode(string[] values)
    {
        string code = values[0];
        code = code.ToLower();

        Debug.Log(code);

        if (code == "zero three five one" || code == "0351")
        {
            deviceController.PlayAnims();
        }
    }

    public void ActivateVoice()
    {
        voiceExperience.Activate();
    }
}
