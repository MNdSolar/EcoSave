using UnityEngine;
public class FireEnterCollider : MonoBehaviour
{
    private float _timer;
    private bool _hasCollided;
    private const float _checkPeriod = 1f;
    private float m_LastCheck = _checkPeriod;


    private void OnTriggerEnter2D (Collider2D other)
    {
        _hasCollided = true;
        _timer = 0f;
    }

    private void Update()
    {
        if (_hasCollided)
        {
            _timer += Time.deltaTime;
            if (_timer >= 3f)
            {
                Debug.Log("Worked");
                Destroy(gameObject);
            }
        }

        m_LastCheck -= Time.deltaTime;
        if (m_LastCheck < 0)
        {
            FireEvent();
            m_LastCheck = _checkPeriod;
        }
    }
    private void FireEvent()
    {
        Storage.ScoreBlock -= 2;
        Storage.ScoreElectro -= 2;
        Storage.ScoreMoney -= 2;
    }
}
