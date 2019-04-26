using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour {

    [SerializeField] Text textComponent;
    [SerializeField] State startingState;

    State state;

    // Use this for initialization
    void Start () {
        state = startingState;
        textComponent.text = state.GetStateStory();

	}
	
	// Update is called once per frame
	void Update () {
        ManageState();
	}

    private void ManageState()
    {
        //var is kind of auto type in C#
        var nextStates = state.GetNextStates();

        for(int index = 0; index < nextStates.Length; index++)
        {
            //increments alpha 1 when necessary
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
            }
        }
        
        //what is the next story
        //change the start chapter in gameobject
        textComponent.text = state.GetStateStory();
    }
}
