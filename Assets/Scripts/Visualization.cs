using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Visualization : MonoBehaviour
{
    [SerializeField] private ReverseTimer _timer;

    [SerializeField] private GameObject _upgradeFactory;
    [SerializeField] private GameObject _upgradeForest;
    [SerializeField] public  GameObject UpgradeButtonFactory;
    [SerializeField] public  GameObject UpgradeButtonForest;

    [SerializeField] private GameObject _upgradeRubbish;
    [SerializeField] private GameObject _upgradePit;
    [SerializeField] public  GameObject UpgradeButtonRub;
    [SerializeField] public  GameObject UpgradeButtonPit;

    [SerializeField] private GameObject _upgradeTower;
    [SerializeField] public  GameObject UpgradeButtonTower;

    [SerializeField] private GameObject _lossPanel;
    [SerializeField] private GameObject _winPanel;

    [SerializeField] public  GameObject BossButtonUnlock;
    [SerializeField] public  GameObject BossLevelButton;

    [SerializeField] private TextMeshProUGUI _scoreMoneyText;
    [SerializeField] private TextMeshProUGUI _scoreElectroText;
    [SerializeField] private TextMeshProUGUI _scoreGreenText;
    [SerializeField] private TextMeshProUGUI _scoreBlockText;

    [SerializeField] private TextMeshProUGUI _statusUnlckBossButton;

    [SerializeField] private GameObject _extinguisher;

    public Image Factory;
    public Image Forest;

    public Sprite FactoryUp;
    public Sprite ForestUp;

    public Image Rubbish;
    public Image Pit;

    public Sprite RubbishUp;
    public Sprite PitUp;

    public Image Tower;
    public Sprite TowerUp;

    [DllImport("__Internal")]
    private static extern void ShowAdv();
    private void Update()
    {
        _scoreMoneyText.text = Storage.ScoreMoney + "";
        _scoreElectroText.text = Storage.ScoreElectro + "";
        _scoreGreenText.text = Storage.ScoreGreen + "";
        _scoreBlockText.text = Storage.ScoreBlock + "";
        _statusUnlckBossButton.text = Storage.ScoreGreen + "";
        FinishLose();
        FinishWin();
    }
    //блок под анимацию 
    public void FactoryPointerDown()
    {
        Factory.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void FactoryPointerUp()
    {
        Factory.transform.localScale = new Vector3((1), ((1)), 1);
    }
    public void ForestPointerDown()
    {
        Forest.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void ForestPointerUp()
    {
        Forest.transform.localScale = new Vector3((1), ((1)), 1);
    }
    public void RubPointerDown()
    {
        Rubbish.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void RubPointerUp()
    {
        Rubbish.transform.localScale = new Vector3((1), ((1)), 1);
    }
    public void PitPointerDown()
    {
        Pit.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void PitPointerUp()
    {
        Pit.transform.localScale = new Vector3((1), ((1)), 1);
    }

    public void TowerPointerDown()
    {
        Tower.transform.localScale = new Vector3((0.8f), ((0.8f)), 0.8f);
    }
    public void TowerPointerUp()
    {
        Tower.transform.localScale = new Vector3((1), ((1)), 1);
    }
    public void UnlockButtonTrue()
    {
        if (Storage.ScoreGreen == 4)
        {
            BossLevelButton.SetActive(false);
            BossButtonUnlock.SetActive(true);
            Storage.SaveUnlkButton = 1;
        }
    }

    public void UnlockButtonFalse()
    {
        if (Storage.ScoreGreen == 4)
        {
            BossLevelButton.SetActive(false);
            BossButtonUnlock.SetActive(false);
            Storage.SaveUnlkButton = 1;
        }
    }
    public void FinishLose()
    {
        if (Storage.Timer < 0 && Storage.ScoreGreen < 5)
        {
            _lossPanel.SetActive(true);
            ShowAdv();
        }
    }

    public void FinishWin()
    {
        if (Storage.ScoreGreen >= 5)
        {
            _winPanel.SetActive(true);
            _upgradeTower.SetActive(false);
            ShowAdv();
        }
    }
    public void OpenUpgradeFactory()
    {
        _upgradeFactory.SetActive(!_upgradeFactory.activeSelf);
        _extinguisher.SetActive(!_extinguisher.activeSelf);
    }

    public void OpenUpgradeForest()
    {
        _upgradeForest.SetActive(!_upgradeForest.activeSelf);
        _extinguisher.SetActive(!_extinguisher.activeSelf);
    }

    public void OpenUpgradeRubbish()
    {
        _upgradeRubbish.SetActive(!_upgradeRubbish.activeSelf);
        _extinguisher.SetActive(!_extinguisher.activeSelf);
    }

    public void OpenUpgradePit()
    {
        _upgradePit.SetActive(!_upgradePit.activeSelf);
        _extinguisher.SetActive(!_extinguisher.activeSelf);
    }

    public void OpenUpgradeTower()
    {
        _upgradeTower.SetActive(!_upgradeTower.activeSelf);
        _extinguisher.SetActive(!_extinguisher.activeSelf);
    }
    public void CheckSavedImage()
    {
        switch (Storage.SwitchImage1)
        {
            case 1:
                Factory.sprite = FactoryUp;
                UpgradeButtonFactory.SetActive(false);
                break;
        }
        switch (Storage.SwitchImage2)
        {
            case 1:
                Forest.sprite = ForestUp;
                UpgradeButtonForest.SetActive(false);
                break;
        }
        switch (Storage.SwitchImage3)
        {
            case 1:
                Rubbish.sprite = RubbishUp;
                UpgradeButtonRub.SetActive(false);
                break;
        }
        switch (Storage.SwitchImage4)
        {
            case 1:
                Pit.sprite = PitUp;
                UpgradeButtonPit.SetActive(false);
                break;
        }
        switch (Storage.SwitchImage5)
        {
            case 1:
                Tower.sprite = TowerUp;
                UpgradeButtonTower.SetActive(false);
                break;
        }
    }
}

