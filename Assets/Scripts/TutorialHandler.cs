using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    [Header("References")]

    public TextMeshProUGUI DaiqDialogue;


    private string[] DaiqDialogueStrings =
        {
            "Hello <color=#ff7700>Mimosa</color>! Welcome to the practice space station! Move with <color=#7cff78><b>WASD</b></color> and Jump with <color=#7cff78><b>SPACE</b></color>!",
            "You can Air Dash by using <color=#7cff78><b>RIGHT CLICK</b></color> while in the air. Hold the button down to aim!",
            "Woo!",
            "Next is wallrunning. Hold <color=#7cff78><b>SPACE</b></color> while facing parallel a yellow wall and you can skate across it. Let go to jump",
            "Nice! Now try to combine air dashing and wall running to cross this gap.",
            "Excellent work! Now let's try kicking with <color=#7cff78><b>LEFT CLICK</b></color>. Take it out on that glass plane over there.",
            "Smashin'!",
            "Okay, try navigate the rest of the training course with what you've learned. Good luck!",
            "Checkpoint! If you fall down now, you'll respawn right back here"
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
        DaiqDialogue.text = DaiqDialogueStrings[tutorialState];
    }

    private void DialogueHandler()
    {
        
    }


}
