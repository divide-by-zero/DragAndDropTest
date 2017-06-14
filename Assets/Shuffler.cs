using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffler : MonoBehaviour {

    public DragObject[] _dragObjects;//ドラッグされる対象、A～K? UnityのInspectorからセットしておく

    public void Start()
    {
        _dragObjects = FindObjectsOfType<DragObject>();
        Shuffle();
    }
    //全ての_dragObjectsのparentをぐちゃぐちゃに入れ替える
    private void Shuffle()
    {
        for (var index = 0; index < _dragObjects.Length; ++index)
        {
            var dragObj = _dragObjects[index];
            var swapTarget = _dragObjects[Random.Range(0, _dragObjects.Length)];

            //parentの入れ替え
            var work = dragObj.transform.parent;
            dragObj.transform.SetParent(swapTarget.transform.parent);
            swapTarget.transform.SetParent(work);
        }
    }
}
