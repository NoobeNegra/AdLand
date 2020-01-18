using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class define the constant values for the game
/// </summary>
public class Constants
{
    //Animator parameters
    public const string anim_char_movementStatus = "movementStatus";

    public const int anim_char_jumpStatus_running = 0;
    public const int anim_char_jumpStatus_preparation = 1;
    public const int anim_char_jumpStatus_ascending = 2;
    public const int anim_char_jumpStatus_ending = 3;


    //Jump constants
    public const float jump_baseForce = 600f;
    public const float jump_triggerHeight = 1.64f;
    public const float jump_preparationTime = 0.2f; //If jump is hold for longer than this, the preparation anim is played
    public const float jump_maxHoldTime = 1f;
    public const float jump_minimumJump = 0.6f;
    public static float[] jump_endTriggerHeights = new float[3] {1.2f, 1.7f,2.2f };


}
