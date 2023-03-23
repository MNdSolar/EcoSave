using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class TrainingButton : MonoBehaviour
{
    [SerializeField] private GameObject _trainingPanel;
    [SerializeField] private TextMeshProUGUI _buttonText;

    private int _firstLaunch = 0;

    [DllImport("__Internal")]
    private static extern void ShowAdv();

    private void Start()
    {
        LoadFirstLaunchCondition();
        Time.timeScale = 0;
        RuButtonlocalization();
        EnButtonlocalization();
    }

    private void Update()
    {
        RuButtonlocalization();
        EnButtonlocalization();
    }

    public void OnClick()
    {
        SaveFirstLaunchCondition();
        _firstLaunch += 1;
        _trainingPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickGuide()
    {
        SaveFirstLaunchCondition();
        _trainingPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void SaveFirstLaunchCondition()
    {
        PlayerPrefs.SetInt("Condition", _firstLaunch);
        PlayerPrefs.Save();
        Debug.Log("Save Condition");
    }

    public void LoadFirstLaunchCondition()
    {
        if (PlayerPrefs.HasKey("Condition"))
        {
            _firstLaunch = PlayerPrefs.GetInt("Condition");
            Debug.Log("Condition loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void RuButtonlocalization() {
        if (_firstLaunch >= 1 && Langauge.Instance.CurrentLanguage == "ru")
        {
            _buttonText.text = "œ–ŒƒŒÀ∆»“‹?";
        }
        else if (_firstLaunch < 1 && Langauge.Instance.CurrentLanguage == "ru")
        {
            _buttonText.text = "Õ¿◊¿“‹ »√–”!";
        }
    }
    public void EnButtonlocalization()
    {
        if (_firstLaunch >= 1 && Langauge.Instance.CurrentLanguage == "en")
        {
            _buttonText.text = "CONTINUE?";
        }
        else if (_firstLaunch < 1 && Langauge.Instance.CurrentLanguage == "en")
        {
            _buttonText.text = "START GAME!";
        }
    }

}
