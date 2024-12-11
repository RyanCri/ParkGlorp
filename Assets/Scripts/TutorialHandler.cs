using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    [Header("References")]

    public TMP_Text DaiqDialogue;


    public string[] DaiqDialogueStrings =
        {
            "Hello Mimosa! Welcome to the practice space station! Move with WASD and Jump with space!",
            "You can Air Dash by using right click while in the air. Hold the button down to aim!",
            "Woo!",
            "Next is wallrunning. Hold SPACE while facing parallel a yellow wall and you can skate across it. Let go to jump",
            "Nice! Now try to combine air dashing and wall running to cross this gap."
        };
    

    public int tutorialState;
    
    // Start is called before the first frame update
    void Start()
    {
        // DaiqDialogue.SetText("Hello Mimosa! Welcome to the practice space station!");
    }

    void Update()
    {
        TutorialStateHandler();
    }

    private void TutorialStateHandler()
    {
        DaiqDialogue.SetText(DaiqDialogueStrings[tutorialState]);
    }

    private void DialogueHandler()
    {
        
    }


}
