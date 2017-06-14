using UnityEngine;
using UnityEngine.EventSystems;

public class DropTarget : MonoBehaviour ,IDropHandler{
    public GameObject Item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (Item == null)
        {
            DragObject.dragObject.transform.SetParent(transform);
        }
        else
        {
            Item.transform.SetParent(DragObject.dragObject.parentTransform);
            DragObject.dragObject.transform.SetParent(transform);
        }
    }
}
