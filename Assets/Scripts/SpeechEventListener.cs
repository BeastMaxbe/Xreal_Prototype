using UnityEngine;
using TMPro;

/// <summary>
/// Example script to listen to Speech Recognition events
/// Inspector me connect kar sakte ho ya code se use kar sakte ho
/// </summary>
public class SpeechEventListener : MonoBehaviour
{
    [Header("Optional UI")]
    public TextMeshProUGUI eventLogText;

    // Yeh function call hoga jab final speech recognize hoga
    public void OnSpeechRecognized(string recognizedText)
    {
        Debug.Log("🎤 Speech Recognized: " + recognizedText);

        // Specific words check kar sakte ho
        if (recognizedText.ToLower().Contains("hello") || recognizedText.ToLower().Contains("Hello"))
        {
            Debug.Log("✅ User ne 'Hello' bola!");
            DoSomethingOnHello();
        }

        if (recognizedText.ToLower().Contains("start") || recognizedText.ToLower().Contains("Hello Everyone"))
        {
            Debug.Log("✅ User ne 'Start' bola!");
            DoSomethingOnStart();
        }

        // Log UI me bhi dikha sakte ho
        if (eventLogText != null)
        {
            eventLogText.text = "Recognized: " + recognizedText;
        }
    }

    // Real-time partial speech ke liye
    public void OnPartialSpeech(string partialText)
    {
        Debug.Log("🔊 Partial Speech: " + partialText);

        // Real-time me kuch kar sakte ho
        if (eventLogText != null)
        {
            eventLogText.text = "Listening... " + partialText;
        }
    }

    // Jab recording start ho
    public void OnRecordingStart()
    {
        Debug.Log("🔴 Recording Started!");

        // UI change kar sakte ho
        if (eventLogText != null)
        {
            eventLogText.text = "🔴 Listening...";
            eventLogText.color = Color.red;
        }
    }

    // Jab recording stop ho
    public void OnRecordingStop()
    {
        Debug.Log("⏹️ Recording Stopped!");

        if (eventLogText != null)
        {
            eventLogText.text = "⏹️ Stopped";
            eventLogText.color = Color.yellow;
        }
    }

    // Example functions - aap apne hisaab se customize kar sakte ho
    void DoSomethingOnHello()
    {
        // Jab user "Hello" bole to yeh function call hoga
        // Example: Game start karna, animation play karna, etc.
        Debug.Log("🎮 Hello command executed!");
    }

    void DoSomethingOnStart()
    {
        // Jab user "Start" bole
        Debug.Log("▶️ Start command executed!");
    }

    // Aap custom commands bhi bana sakte ho
    public void CheckForCustomCommands(string text)
    {
        text = text.ToLower();

        if (text.Contains("jump") || text.Contains("कूद"))
        {
            PlayerJump();
        }
        else if (text.Contains("fire") || text.Contains("फायर"))
        {
            PlayerFire();
        }
        else if (text.Contains("pause") || text.Contains("रोको"))
        {
            PauseGame();
        }
    }

    void PlayerJump()
    {
        Debug.Log("🦘 Player jumped!");
        // Your jump code here
    }

    void PlayerFire()
    {
        Debug.Log("🔫 Player fired!");
        // Your fire code here
    }

    void PauseGame()
    {
        Debug.Log("⏸️ Game paused!");
        Time.timeScale = 0;
    }
}