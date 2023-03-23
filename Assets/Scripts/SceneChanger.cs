using System.Runtime.InteropServices;
using UnityEngine;
public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Visualization _visual;

    [SerializeField] private GameObject _nextLevelButton1;
    [SerializeField] private GameObject _backlevelButton2;
    [SerializeField] private GameObject _backLevelButton3;
    [SerializeField] private GameObject _bossLevelButton;

    [SerializeField] private GameObject _lvl1;
    [SerializeField] private GameObject _lvl2;
    [SerializeField] private GameObject _lvl3;

    [SerializeField] private AudioSource _buttonClickSound;

    [DllImport("__Internal")]
    private static extern void ShowAdv();
    public void NextLevel1()
    {
        _lvl1.SetActive(false);
        _lvl2.SetActive(true);
        _nextLevelButton1.SetActive(false);
        _backlevelButton2.SetActive(true);
        _bossLevelButton.SetActive(true);
        _visual.UnlockButtonTrue();
        _buttonClickSound.Play();
    }
    public void BackLevel2()
    {
        _lvl2.SetActive(false);
        _lvl1.SetActive(true);
        _backlevelButton2.SetActive(false);
        _nextLevelButton1.SetActive(true);
        _bossLevelButton.SetActive(false);
        _visual.UnlockButtonFalse();
        _buttonClickSound.Play();
    }

    public void NextBossLevel()
    {
        _lvl1.SetActive(false);
        _lvl2.SetActive(false);
        _lvl3.SetActive(true);
        _backlevelButton2.SetActive(false);
        _bossLevelButton.SetActive(false);
        _backLevelButton3.SetActive(true);
        _visual.UnlockButtonFalse();
        _buttonClickSound.Play();
        ShowAdv();
    }

    public void BackLevel3()
    {
        _lvl1.SetActive(false);
        _lvl2.SetActive(true);
        _lvl3.SetActive(false);
        _backlevelButton2.SetActive(true);
        _backLevelButton3.SetActive(false);
        _bossLevelButton.SetActive(true);
        _visual.UnlockButtonTrue();
        _buttonClickSound.Play();
    }

    public void NextuttonPointerDown()
    {
        _nextLevelButton1.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void NextButtonPointerUp()
    {
        _nextLevelButton1.transform.localScale = new Vector3((1), ((1)), 1);
    }
    public void BackButton2PointerDown()
    {
        _backlevelButton2.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void BackButton2PointerUp()
    {
        _backlevelButton2.transform.localScale = new Vector3((1), ((1)), 1);
    }
    public void BackButton3PointerDown()
    {
        _backLevelButton3.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void BackButton3PointerUp()
    {
        _backLevelButton3.transform.localScale = new Vector3((1), ((1)), 1);
    }
    public void BossButtonPointerDown()
    {
        _bossLevelButton.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void BossButtonPointerUp()
    {
        _bossLevelButton.transform.localScale = new Vector3((1), ((1)), 1);
    }
}
 