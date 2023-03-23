using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class DropDownRes : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private CanvasGroup _canvasGroup;
    private float _lifeTime = 5;
    public void Spawn(int DropDownOne)
    {
        _text.text = $"+{DropDownOne}";
        _canvasGroup.DOFade(endValue: 0, duration: _lifeTime);
        var trans = transform;
        var endPos = trans.position;
        endPos.y += 110;
        trans.DOMove(endPos, _lifeTime);
        StartCoroutine(routine: DestroyOnEnd());
    }
    private IEnumerator DestroyOnEnd()
    {
        yield return new WaitForSeconds(_lifeTime + 0.1f);
        Destroy(gameObject);
    }
}
