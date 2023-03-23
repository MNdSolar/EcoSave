using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour 
{
    [SerializeField] private Visualization _visual;
    [SerializeField] private SaveLoad _saveLoad;
    [SerializeField] private ReverseTimer _timer;
    [SerializeField] private TrainingButton _trainingButton;

    [SerializeField] private AudioSource _clickSound;
    [SerializeField] private AudioSource _upgradeSound;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _lossSound;
    [SerializeField] private AudioSource _lockedSound;

    [SerializeField] private Transform _mainCanvas;
    [SerializeField] private GameObject _dropDownResurcesPrefab;

    [SerializeField] private GameObject[] _lvl3Back;
    [SerializeField] private GameObject _lvl2;

    [SerializeField] private Transform _factoryCanvas;

    private Vector3 _mousepos;

    [DllImport("__Internal")]
    private static extern void ShowAdv();
    
    
    public void Start()
    {
        _saveLoad.LoadGame();
        CheckActiveSaved();
        Resources.Load("Name");
        _visual.CheckSavedImage();
        _saveLoad.LoadTime();
        ShowAdv();
    }

    private void Update()
    {
        UnlckButtonOnLvl2();
    }
    public void UpgradeToFactory(int BonusPlus1)
    {
        if (Storage.ScoreMoney >= 2000 && Storage.ScoreBlock >= 2500)
        {
            Storage.EmptyBonus += Storage.OneBonus;
            Storage.ScoreMoney -= 2000;
            Storage.ScoreGreen += 1;
            Storage.ScoreBlock -= 2500;
            _visual.Factory.sprite = _visual.FactoryUp;
            _visual.UpgradeButtonFactory.SetActive(false);
            _upgradeSound.Play();
            Storage.SwitchImage1 += 1;
        }
        else
        {
            _lockedSound.Play();
            Debug.Log("Не хвататет денег");
        }
    }
    public void UpgradeToForest(int BonusPlus2)
    {
        if (Storage.ScoreMoney >= 500 && Storage.ScoreBlock >= 1500)
        {
            Storage.EmptyBonus2 = +Storage.OneBonus1; 
            Storage.ScoreMoney -= 500;
            Storage.ScoreBlock -= 1500;
            Storage.ScoreGreen += 1;
            _visual.UpgradeButtonForest.SetActive(false);
            _upgradeSound.Play();
            _visual.Forest.sprite = _visual.ForestUp;
            Storage.SwitchImage2 += 1;
        }
        else
        {
            _lockedSound.Play();
            Debug.Log("Не хватает денег");
        }
    }

    public void UpgradeToRubbish(int BonusPlus2)
    {
        if (Storage.ScoreMoney >= 1600 && Storage.ScoreBlock >= 2000)
        {
            Storage.EmptyBonus3 += Storage.OneBonus3;
            Storage.ScoreMoney -= 1600;
            Storage.ScoreBlock -= 2000;
            _visual.Rubbish.sprite = _visual.RubbishUp;
            Storage.ScoreGreen += 1;
            _visual.UpgradeButtonRub.SetActive(false);
            _upgradeSound.Play();
            Storage.SwitchImage3 += 1;
        }
        else
        {
            _lockedSound.Play();
            Debug.Log("Не хватает денег");
        }
    }

    public void UpgradeToPit(int BonusPlus2)
    {
        if (Storage.ScoreMoney >= 3000 && Storage.ScoreBlock >= 3500)
        {
            Storage.EmptyBonus4 += Storage.OneBonus4;
            Storage.ScoreMoney -= 3000;
            Storage.ScoreBlock -= 3500;
            _visual.Pit.sprite = _visual.PitUp;
            Storage.ScoreGreen += 1;
           _visual.UpgradeButtonPit.SetActive(false);
            _upgradeSound.Play();
            Storage.SwitchImage4 += 1;
        }
        else
        {
            _lockedSound.Play();
            Debug.Log("Не хватает денег");
        }
    }

    public void UpgradeToTower(int BonusPlus2)
    {
        if (Storage.ScoreMoney >= 3500 && Storage.ScoreBlock >= 1200  && Storage.ScoreElectro >= 2500)
        {
            Storage.ScoreMoney -= 3500;
            Storage.ScoreBlock -= 1200;
            Storage.ScoreElectro -= 2500;
            _visual.Tower.sprite = _visual.TowerUp;
            Storage.ScoreGreen += 1;
            _lvl3Back[0].SetActive(false);
            _lvl3Back[1].SetActive(true);
            Storage.SaveBack = 1;
            _visual.UpgradeButtonTower.SetActive(false);
            _upgradeSound.Play();
            Storage.SwitchImage5 += 1;
        }
        else
        {
            _lockedSound.Play();
            Debug.Log("Не хватает денег");
        }
    }
    public void OnClickFactory()
    {
        Storage.ScoreMoney += 4 + Storage.EmptyBonus;
        Storage.ScoreBlock += 1;
        Instantiate(_dropDownResurcesPrefab, _mousepos, Quaternion.identity, _mainCanvas).GetComponent<DropDownRes>().Spawn(Storage.DropDownOne);
        _clickSound.Play();
    }
    public void OnClickForest()
    {
        Storage.ScoreMoney += 2 + Storage.EmptyBonus2;
        Storage.ScoreBlock += 1;
        Instantiate(_dropDownResurcesPrefab, _mousepos, Quaternion.identity, _mainCanvas).GetComponent<DropDownRes>().Spawn(Storage.DropDownOne);
        _clickSound.Play();
    }
    public void OnClickRubbish()
    {
        Instantiate(_dropDownResurcesPrefab, _mousepos, Quaternion.identity, _mainCanvas).GetComponent<DropDownRes>().Spawn(Storage.DropDownOne);
        Storage.ScoreMoney += 1;
        Storage.ScoreBlock += 5 + Storage.EmptyBonus3;
        _clickSound.Play();
    }
    public void OnClickPit()
    {
        Instantiate(_dropDownResurcesPrefab, _mousepos, Quaternion.identity, _mainCanvas).GetComponent<DropDownRes>().Spawn(Storage.DropDownOne);
        Storage.ScoreMoney += 1;
        Storage.ScoreBlock += 7 + Storage.EmptyBonus4;
        Storage.ScoreElectro += 0;
        _clickSound.Play();
    }
    public void OnClickTower()
    {
        Instantiate(_dropDownResurcesPrefab, _mousepos, Quaternion.identity, _mainCanvas).GetComponent<DropDownRes>().Spawn(Storage.DropDownOne);
        Storage.ScoreMoney += 5;
        Storage.ScoreBlock += 5;
        Storage.ScoreElectro += 10;
        _clickSound.Play();
    }
    public void OnClickLockButton()
    {
        _lockedSound.Play();
    }
    public void Restart()
    {
        _saveLoad.ResetGame();
        _saveLoad.ResetTime();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _timer.Timer = 1200;
        ShowAdv();
    }
    public void CheckActiveSaved()
    {
        if (Storage.SaveBack == 1)
        {
            _lvl3Back[0].SetActive(false);
            _lvl3Back[1].SetActive(true);
        }
        if (Storage.SaveUnlkButton == 1)
        {
            _visual.BossLevelButton.SetActive(false);
            _visual.BossButtonUnlock.SetActive(true);
        }
    }
    public void UnlckButtonOnLvl2()
    {
        if (_lvl2.activeInHierarchy == true && Storage.ScoreGreen >= 4)
        {
            _visual.BossButtonUnlock.SetActive(true);
            _visual.BossLevelButton.SetActive(false);
        }
    }
    public void OnApplicationQuit()
    {
        _saveLoad.SaveGame();
      _trainingButton.SaveFirstLaunchCondition();
    }
    bool isPaused = false;
    public void OnGUI()
    {
        if (isPaused)
        _saveLoad.SaveTime();
        _saveLoad.SaveGame();
        _trainingButton.SaveFirstLaunchCondition();
    }
    public void OnApplicationFocus(bool hasFocus)
    {
        isPaused = !hasFocus;
    }
    public void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}

