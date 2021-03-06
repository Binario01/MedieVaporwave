﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Cameras;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public CameraControl cam;
    public static bool paused = false;
    public Light[] lights;
    public Color[] colors;
    public Book holdBook = null;
    [Space(10)]
    public int lockpickLvl = 0;
    public int diskLvl = 0;
    Menu menu;
    public GameObject menuInGame, gate;
    public Animator fist, sala;
    public bool cutscene;

    public MusicProgression music;
    int stage = 0;
    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        cam.transform.eulerAngles = Vector3.zero;
        if (cutscene) {
            for (int i = 0; i < lights.Length/2; i++) {
                lights[2 * i].color = colors[8];
                lights[2 * i + 1].color = colors[9];
            }

            cam.GetComponent<Raycaster>().enabled = false;
            cam.GetComponent<FreeLookCam>().enabled = false;
        } else
            fist.enabled = false;
      
    }

	// Use this for initialization
	void Start () {
        menu = this.GetComponent<Menu>();
        menuInGame.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!paused)
                menu.Pause(menuInGame);
            else
                menu.Resume(menuInGame);

            paused = !paused;
        }
	}

    public void refreshMusic(){
        stage++;
        music.stage = stage;
    }
    public void changeLights() {
        for (int i = 0; i < lights.Length; i++)
            lights[i].color = colors[i];
    }

    public void startGame() {
        cam.GetComponent<Raycaster>().enabled = true;
        cam.GetComponent<FreeLookCam>().enabled = true;
    }

    public void openGate() {
        Destroy(gate);
    }
}