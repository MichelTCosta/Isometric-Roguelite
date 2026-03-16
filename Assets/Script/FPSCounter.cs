using UnityEngine;
using TMPro; // Necessário para TMP

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private float pollingTime = 0.5f; // Atualiza a cada 0.5s
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.unscaledDeltaTime;
        frameCount++;

        if (time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = frameRate.ToString() + " FPS";
            
            time -= pollingTime;
            frameCount = 0;
        }
    }
}
