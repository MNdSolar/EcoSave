using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    [SerializeField] private Image _musicOn;
    [SerializeField] private Sprite _musicOff;
    public void OnClick()
    {
        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause)
        {
            _musicOn.sprite = _musicOff;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/OnMusic");
        }
    }
}
