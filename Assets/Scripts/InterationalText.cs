using TMPro;
using UnityEngine;

public class InterationalText : MonoBehaviour
{
    [SerializeField] string _en;
    [SerializeField] string _ru;

    private void Start()
    {
        if (Langauge.Instance.CurrentLanguage == "en")
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
        else if (Langauge.Instance.CurrentLanguage == "ru")
        {
            GetComponent<TextMeshProUGUI>().text = _ru;
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
    }
}
