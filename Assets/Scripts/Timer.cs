using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour {
    [SerializeField]
    private TMP_Text timerText;

    private float timeElapsed = 0f;
    private int min, sec, cen = 0;

    public void Run() {
        timeElapsed += Time.deltaTime;
        min = (int)(timeElapsed / 60f);
        sec = (int)(timeElapsed - min * 60f);
        cen = (int)((timeElapsed - (int)timeElapsed) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}.{2:00}", min, sec, cen);
    }

    public void Restart() {
        timeElapsed = 0f;
    }
}
