using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _fire;

    [SerializeField] private GameObject _lvl1;
    [SerializeField] private GameObject _lvl2;
    [SerializeField] private GameObject _lvl3;

    [SerializeField] private GameObject _spawnBasketLvl1;
    [SerializeField] private GameObject _spawnBasketLvl2;
    [SerializeField] private GameObject _spawnBasketLvl3;

    public float StartTimeBtwSpawns;
    private float _timeBtwSpawns;

    private int _randFire1;
    private int _randFire2;
    private int _randFire3;

    private int _randPosition1;
    private int _randPosition2;

    [SerializeField] private GameObject[] _spawnPosition1;
    [SerializeField] private GameObject[] _spawnPosition2;
    [SerializeField] private GameObject   _spawnPosition3;
    void Start()
    {
        _timeBtwSpawns = StartTimeBtwSpawns;
    }

    void Update()
    {
        ActivateRandomFireLvl1();
        ActivateRandomFireLvl2();
        ActivateRandomFireLvl3();
    }

    private void ActivateRandomFireLvl1()
    {

        if (_timeBtwSpawns <= 0 && _lvl1.activeInHierarchy == true)
        {
            _randFire1 = Random.Range(0, _fire.Length);
            _randPosition1 = Random.Range(0, _spawnPosition1.Length);
            Instantiate(_fire[_randFire1], _spawnPosition1[_randPosition1].transform.position, Quaternion.identity, _spawnBasketLvl1.transform);
            _timeBtwSpawns = StartTimeBtwSpawns;
        }
        else
        {
            _timeBtwSpawns -= Time.deltaTime;            
        }
    }

    private void ActivateRandomFireLvl2()
    {
        if (_timeBtwSpawns <= 0 && _lvl2.activeInHierarchy == true)
        {

            _randFire2 = Random.Range(0, _fire.Length);
            _randPosition2 = Random.Range(0, _spawnPosition2.Length);
            Instantiate(_fire[_randFire2], _spawnPosition2[_randPosition2].transform.position, Quaternion.identity, _spawnBasketLvl2.transform);
            _timeBtwSpawns = StartTimeBtwSpawns;
        }
        else
        {
            _timeBtwSpawns -= Time.deltaTime;
        }
    }
    private void ActivateRandomFireLvl3()
    {
        if (_timeBtwSpawns <= 0 && _lvl3.activeInHierarchy == true)
        {
            _randFire3 = Random.Range(0, _fire.Length);
            Instantiate(_fire[_randFire3], _spawnPosition3.transform.position, Quaternion.identity, _spawnBasketLvl3.transform);
            _timeBtwSpawns = StartTimeBtwSpawns;
        }
        else
        {
            _timeBtwSpawns -= Time.deltaTime;
        }
    }
} 
