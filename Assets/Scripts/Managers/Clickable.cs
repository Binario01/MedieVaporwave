﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour {
    [HideInInspector] public bool isDragging = false;
    public virtual void OnPointerEnter() { }
    public virtual void OnPointerExit() { }
    public virtual void OnClick(int mouseButton) { }
    public virtual void OnDrag() { }
    public virtual void OnDrop() { }
}