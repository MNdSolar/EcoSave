using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
public class Langauge : MonoBehaviour
{

    [DllImport("__Internal")]

    private static extern string GetLang();

    public string CurrentLanguage; // ru en
    [SerializeField] TextMeshProUGUI _languageText;

    public static Langauge Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CurrentLanguage = GetLang();
            _languageText.text = CurrentLanguage;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
