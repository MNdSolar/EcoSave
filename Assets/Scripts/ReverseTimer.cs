using UnityEngine;
using TMPro;
public class ReverseTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;
    private bool _enableTimer = true;
    public float Timer = 1200;
    void Update()
    {
        if (_enableTimer)
        {
            Timer -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(Timer / 60);
            float seconds = Mathf.FloorToInt(Timer % 60);
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (Timer < 0 && Storage.ScoreGreen < 5 || Storage.ScoreGreen >= 5)
                _enableTimer = false;
        }
    }
}
