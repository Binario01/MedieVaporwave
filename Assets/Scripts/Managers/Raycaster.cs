﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour {
    
    Clickable clickable;

    void Awake() {
        clickable = null;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 20.0f)) {
                Clickable c = hit.transform.gameObject.GetComponent<Clickable>();
                if (c != null) {
                    Hit(c);
                } else
                    NoHit();
            } else {
                NoHit();
            }
        }

        if (clickable != null) {
            if (Input.GetMouseButtonDown(0)) {
                clickable.OnClick(0);
                clickable.isDragging = true;
            }
            if (Input.GetMouseButtonDown(1)) {
                clickable.OnClick(1);
            }

            if (clickable.isDragging) {
                clickable.OnDrag();
                if (Input.GetMouseButtonUp(0)) {
                    clickable.isDragging = false;
                    clickable.OnDrop();
                }
            }

        }
    }

    void Hit(Clickable hit) {
        if (clickable != hit) {
            if (clickable != null) {
                clickable.OnPointerExit();
            }
            clickable = hit;
            clickable.OnPointerEnter();
        }
    }

    void NoHit() {
        if (clickable != null) {
            clickable.OnPointerExit();
            clickable = null;
        }
    }
}
