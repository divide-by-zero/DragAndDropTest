using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DragObject : MonoBehaviour ,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    public static DragObject dragObject;
    public Transform parentTransform;
    private Vector3 tapRefPosition;
    private CanvasGroup canvasGroup;
    private Transform canvasTransform;

    public CanvasGroup CanvasGroup { get { return canvasGroup == null ? (canvasGroup = gameObject.GetComponent<CanvasGroup>()) : canvasGroup; }}
    public Transform CanvasTransform { get { return canvasTransform ?? (canvasTransform = GameObject.Find("Canvas").transform); } }

    public void OnBeginDrag(PointerEventData eventData)
    {
        tapRefPosition = (Vector2)transform.position - eventData.position;
        dragObject = this;
        parentTransform = transform.parent;
        transform.SetParent(CanvasTransform);
        CanvasGroup.blocksRaycasts = false;
        CanvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition + tapRefPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvasTransform)
        {
            transform.SetParent(parentTransform);
        }
        dragObject = null;
        CanvasGroup.blocksRaycasts = true;
        CanvasGroup.alpha = 1.0f;
    }

    public void Update()
    {
        if (dragObject == null)
        {
            transform.localPosition -= transform.localPosition / 3.0f;
        }
    }
}
