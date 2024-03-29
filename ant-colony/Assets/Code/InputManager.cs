﻿using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	float horizontal;
	float vertical;

	private string A_INPUT = "A_Keyboard_";
	private string B_INPUT = "B_Keyboard_";
	private string A_GAMEPAD = "A_";
	private string B_GAMEPAD = "B_";
	private string X_GAMEPAD = "X_";
	private string Horizontal_INPUT = "L_XAxis_Keyboard_";
	private string Vertical_INPUT = "L_YAxis_Keyboard_";
	private string Horizontal_GAMEPAD = "L_XAxis_";
	private string Vertical_GAMEPAD = "L_YAxis_";
	private string Start_INPUT = "Start_";

	void Start () {
		int pID = 1;
		A_INPUT += pID;
		B_INPUT += pID;
		Horizontal_INPUT += pID;
		Vertical_INPUT += pID;
		A_GAMEPAD += pID;
		B_GAMEPAD += pID;
		X_GAMEPAD += pID;
		Horizontal_GAMEPAD += pID;
		Vertical_GAMEPAD += pID;
		Start_INPUT += pID;
	}
	
	void Update () {
		HandleInput();
	}

	void HandleInput() {
		horizontal = Input.GetAxisRaw(Horizontal_INPUT) + Input.GetAxisRaw(Horizontal_GAMEPAD);
		vertical = Input.GetAxisRaw(Vertical_INPUT) + Input.GetAxisRaw(Vertical_GAMEPAD);

        PlayerController.Instance.OnAxisInput(horizontal, vertical);
		
		if (Input.GetButtonDown(A_INPUT) || Input.GetButtonDown(A_GAMEPAD)) {
            OnAButton();
		}
	}

	void OnAButton() {
		if (GameStateManager.Instance.canRestart) {
            GameStateManager.Instance.Restart();
            return;
        }
        DialogueManager.Instance.Confirm();
	}

}