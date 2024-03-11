using System;
using Unity.VisualScripting;
using UnityEngine;

public class View : MonoBehaviour {
    public virtual void Close() => gameObject.SetActive(false);
    public virtual void Open() => gameObject.SetActive(true);
}
