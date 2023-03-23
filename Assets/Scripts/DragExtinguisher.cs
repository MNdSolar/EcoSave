using UnityEngine;
using UnityEngine.EventSystems;

public class DragExtinguisher : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas _mainCanvas;
    [SerializeField] private RectTransform _rectTransform;

    [SerializeField] private AudioSource _extinguisherSound;
    [SerializeField] private AudioSource _gettingSound;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCanvas = GetComponentInParent<Canvas>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
        _gettingSound.Play();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        _gettingSound.Play();
    }

    public void PointerUp()
    {
        transform.localRotation = new Quaternion(0, 0, 0, 0);
    }

    public void PointerDown()
    {
        transform.localRotation = new Quaternion(0, 0, 0.12f, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");

        if (collision)
        {
            _extinguisherSound.Play();
        }
        if (!collision)
        {            
            _extinguisherSound.Stop();
        }
    }
}
   
