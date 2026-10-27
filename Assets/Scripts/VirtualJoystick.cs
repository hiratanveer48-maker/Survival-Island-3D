using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private RectTransform backgroundRect;
    private RectTransform handleRect;
    private Vector2 inputVector = Vector2.zero;

    void Start()
    {
        backgroundRect = GetComponent<RectTransform>();
        handleRect = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            backgroundRect, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / backgroundRect.sizeDelta.x);
            pos.y = (pos.y / backgroundRect.sizeDelta.y);

            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            handleRect.anchoredPosition = new Vector2(
                inputVector.x * (backgroundRect.sizeDelta.x / 3),
                inputVector.y * (backgroundRect.sizeDelta.y / 3));
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handleRect.anchoredPosition = Vector2.zero;
    }

    public float Horizontal => inputVector.x;
    public float Vertical => inputVector.y;
}
