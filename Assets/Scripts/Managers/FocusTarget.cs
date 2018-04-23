﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusTarget : Clickable {

    public bool isMain;
    public bool haveFocus = false;
    public static FocusTarget main;
    public Interactable item;
    public Vector3 offset, ajust;

    void Awake () {
        if (isMain) {
            main = this.GetComponent<FocusTarget>();
            haveFocus = true;
        }
    }

	// Use this for initialization
	void Start () {
        MeshRenderer mr = this.GetComponent<MeshRenderer>();
        if (mr != null)
            mr.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnClick(int mouseButton) {
        if (mouseButton == 0) {
            if (!haveFocus) 
                GameManager.instance.cam.changeTarget(this);

            if (item != null)
                item.Touch();
        } else if (mouseButton == 1 && haveFocus) {
            GameManager.instance.cam.changeTarget(main);
            if (item != null)
                item.Left();
        }
    }
}
