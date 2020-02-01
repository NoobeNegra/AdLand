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
    public const string anim_char_fallStatus = "m_fall";
    public const float crossfade_animation_time = 1.2f;

    //Jump constants
    public const float jump_baseForce = 600f;
    public const float jump_triggerHeight = 1.64f;
    public const float jump_preparationTime = 0.7f; //If jump is hold for longer than this, the preparation anim is played
    public const float jump_maxHoldTime = 1f;
    public const float jump_minimumJump = 0.6f;
    public static float[] jump_endTriggerHeights = new float[3] {1.2f, 1.7f,2.2f };

    //Spawner constants
    public const int time_to_destroy_cloned_object = 600;
    public const float max_distance_spawn_background = 40.0f;
    public const float next_spawn_background = 53.2f;
    public const float min_distance_object_spawn = 25.0f;
    public const float max_distance_object_spawn = 30.0f;
    public const float z_value_character = 1f;
    public const float z_value_for_plants = -0.1f;
    public const float min_height_value = -2.5f;
    public const float max_height_value = 3f;
    public const float tolerated_distance_between_objects = 2.0f;
    public const int max_amoun_dolla_bills = 10;
    public const float max_distance_between_dolla_bills = 0.3f;

    //Booster constants
    public const float boosted_speed_factor = 1.5f;
    public const float min_zoom_while_boosted = 11.0f;
    public const float normal_zoom = 5.0f;
    public const int high_jump_bost_time = 10;
    public const int triple_shot_machiatto_boost_time = 15;
    public const int triple_shot_machiatto_exhaustation_time = 5;
    public const float triple_shot_machiatto_exhaustation_speed = 0.4f;
    public const int coffee_boost_time = 5;
    public const int instant_energy_boost_time = 5;
    public const int instant_energy_kill = 20;

    //Tweener animations constants
    public const float time_to_complete_tween = 2.0f;
    public const float time_to_complete_camera_tween = 2.0f;

    //Rewards constants
    public const int value_of_quill = 10;
    public const int value_of_golden_kitty = 100;
    public const int value_of_dollar_bill = 1;
    public const int awards_per_run = 2;
    public const float possibility_of_award_spawn = 0.8f; // 20%
    public const int seconds_to_destroy_gameobject = 2;

    //Methods
    public static float GetProbabilityByName(string name)
    {
        switch (name)
        {
            case "triple_shot_macchiato(Clone)":        return 0.6f;    //40%
            case "coffee(Clone)":                       return 0f;      //100%
            case "instant_energy(Clone)":               return 0.5f;    //50%

            case "money(Clone)":                        return 0f;      //100%
            case "quill(Clone)":                        return 0.8f;    //20%
            case "golden_kitten(Clone)":                return 0.95f;   //5%

            case "cabinet_big2(Clone)":                 return 0.95f;   //5%
            case "cabinet_tall(Clone)":                 return 0.9f;    //10%
            case "cabinet2(Clone)":                     return 0.8f;    //20%
            case "cabinet_big(Clone)":                  return 0.75f;   //35%
            case "cabinet(Clone)":                      return 0.6f;    //40%
            case "chair_tall(Clone)":                   return 0.5f;    //50%
            case "lamp_tall(Clone)":                    return 0.4f;    //60%
            case "chair(Clone)":                        return 0.25f;   //75%
            case "table(Clone)":                        return 0.1f;    //100%

            case "plant1(Clone)":                       return 0.6f;    //40%
            case "plant2(Clone)":                       return 0.2f;    //80%
            case "plant3(Clone)":                       return 0f;      //100%
            default: return 2;
        }
    }

    public static Vector2[] GetObstaclesColliderPointsByName(string name)
    {
        Vector2[] toReturn;
        switch (name)
        {
            case "cabinet_big2(Clone)":
                toReturn = new Vector2[5]{
                    new Vector2(1.252485f, 1.234075f),
                    new Vector2(-1.235831f, 1.001f),
                    new Vector2(-1.242049f, -0.8567069f),
                    new Vector2(1.250725f, -0.8521721f),
                    new Vector2(1.25075f, 1.225823f)};
            break;
            case "cabinet_tall(Clone)":
                toReturn = new Vector2[5]{
                    new Vector2(0.5960295f, 1.248346f),
                    new Vector2(-0.5793753f, 1.100896f),
                    new Vector2(-0.5570524f, -1.056498f),
                    new Vector2(0.594269f, -1.151858f),
                    new Vector2(0.5800235f, 1.240094f)};
            break;
            case "cabinet2(Clone)":
                toReturn = new Vector2[5]{
                    new Vector2(1.195401f, 0.6347027f),
                    new Vector2(-1.093123f, 0.5586066f),
                    new Vector2(-1.270591f, -0.3429594f),
                    new Vector2(1.279266f, -0.2813418f),
                    new Vector2(1.193667f, 0.6407216f)};
            break;
            case "cabinet_big(Clone)":
                toReturn = new Vector2[5]{
                    new Vector2(1.266755f, 1.091367f),
                    new Vector2(-1.250102f, 1.272145f),
                    new Vector2(-1.127883f, -1.27056f),
                    new Vector2(1.264995f, -1.223213f),
                    new Vector2(1.265021f, 1.083115f)};
            break;
            case "cabinet(Clone)": 
                toReturn = new Vector2[5]{
                    new Vector2(1.223943f, 0.5776196f), 
                    new Vector2(-1.235831f, 0.6156895f),
                    new Vector2(-1.142154f, -0.1003561f),
                    new Vector2(1.008121f, -0.06728029f),
                    new Vector2(1.222208f, 0.5693679f)};
            break;
            case "chair_tall(Clone)":
                toReturn = new Vector2[5]{
                    new Vector2(-0.2375885f, 0.530077f),
                    new Vector2(-0.2995077f, -0.622221f),
                    new Vector2(0.2762733f, -0.5879326f),
                    new Vector2(0.2233119f, 0.6100986f),
                    new Vector2(-0.2463253f, 0.5357299f)};
            break;
            case "lamp_tall(Clone)":
                toReturn = new Vector2[9]{
                    new Vector2(-0.4310037f, 1.165583f),
                    new Vector2(-0.4302993f, 0.7274318f),
                    new Vector2(-0.2117562f, 0.7341321f),
                    new Vector2(-0.3685845f, -1.147205f),
                    new Vector2(0.455873f, -1.264885f),
                    new Vector2(0.08626127f, 0.7632673f),
                    new Vector2(0.3397095f, 0.7766175f),
                    new Vector2(0.3200195f, 1.245605f),
                    new Vector2(-0.4259248f, 1.157421f)};
                break;
            case "chair(Clone)":
                toReturn = new Vector2[5]{
                    new Vector2(-0.6330792f, 0.3206992f),
                    new Vector2(-0.4795473f, -0.3188772f),
                    new Vector2(0.4912271f, -0.3168545f),
                    new Vector2(0.6381247f, 0.3109193f),
                    new Vector2(0.6381247f, 0.3140812f)};
            break;
            case "table(Clone)":
                toReturn = new Vector2[10]{
                    new Vector2(-0.5749187f, 0.2741709f),
                    new Vector2(-0.63702f, 0.08804131f),
                    new Vector2(-0.5024661f, 0.0001626015f),
                    new Vector2(-0.5377074f, -0.6562076f),
                    new Vector2(0.607548f, -0.6425529f),
                    new Vector2(0.4163265f, -0.122982f),
                    new Vector2(0.5683322f, 0.6366177f),
                    new Vector2(0.3672738f, 0.3232038f),
                    new Vector2(-0.001870632f, 0.1918182f),
                    new Vector2(-0.5715542f, 0.2675529f)};
            break;
            default:
                toReturn = new Vector2[1] { Vector2.zero };
            break;
        }

        return toReturn;
    }

    public static Vector3 GetPositionToSpawnByName(string name)
    {
        switch (name)
        {
            case "cabinet(Clone)":
                return new Vector3(2.08f, -3.62f, z_value_character);
            case "cabinet2(Clone)":
                return new Vector3(2.08f, -3.94f, z_value_character);
            case "cabinet_big(Clone)":
                return new Vector3(2.08f, -3.94f, z_value_character);
            case "cabinet_big2(Clone)":
                return new Vector3(2.08f, -3.59f, z_value_character);
            case "cabinet_tall(Clone)":
                return new Vector3(2.08f, -3.59f, z_value_character);
            case "table(Clone)":
                return new Vector3(2.08f, -4.37f, z_value_character);
            case "chair(Clone)":
                return new Vector3(2.08f, -4.19f, z_value_character);
            case "chair_tall(Clone)":
                return new Vector3(2.08f, -4.19f, z_value_character);
            case "lamp_tall(Clone)":
                return new Vector3(2.08f, -3.39f, z_value_character);
            case "plant1(Clone)":
            case "plant2(Clone)":
                return new Vector3(2.08f, -3.62f, z_value_for_plants);
            case "plant3(Clone)":
                return new Vector3(2.08f, -4.36f, z_value_for_plants);
            default:
                return Vector3.zero;
        }

    }

    public static int GetValueOfAward(string name)
    {
        switch (name)
        {
            case "golden_kitten(Clone)":
                return value_of_golden_kitty;
            case "quill(Clone)":
                return value_of_quill;
            case "money(Clone)":
                return value_of_dollar_bill;
        }

        return 0;
    }

    public static object[] GetValueOfInfluence(string name)
    {
        switch (name)
        {
            case "triple_shot_macchiato(Clone)" :      return new object[3] { triple_shot_machiatto_boost_time, triple_shot_machiatto_exhaustation_speed, triple_shot_machiatto_exhaustation_time };
            case "coffee(Clone)":                      return new object[1] { coffee_boost_time };
            case "instant_energy(Clone)":              return new object[1] { instant_energy_boost_time };
            default:                                   return new object[1] { 0 };
        }
    }
}
