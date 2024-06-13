using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant
{
    public enum SCENE 
    {
        MAIN_MENU,
        TUTORIAL,
        LEVEL2,
        LEVEL3,
        LEVEL4
    }

    public enum SFX
    {
        //Player
        Hurt,
        ClothInventory,
        LeatherInventory,
        ShotgunLoad,
        Shoot2,
        Steps,
        Reload1,
        //Break
        CeramicBreak,
        WoodBreak,
        Explosion,
        MetalSlide,
        EnergyShot,
        //Enemy Minotaur
        Minotaur,
        MinotaurBreath,
        //Dragon
        DragonRoar,
        DragonWings,
        Fireball,
        Blitz,
        Burst,
        DragonGrowl,
        //Traps
        Spikes,
        FireShot,
        //GUI
        Typing,
        MenuSound,
        GameOver,
        //Hydra
        HydraLament,
        StickyBullet,
        HydraBullet,
        Obstacle,
        HydraDig,
    }

    public enum GENERAL_KEY
    {
        PLAYER_NAME,
        MUSIC_VOLUME,
        SOUND_VOLUME,

    }

    public enum ITEMS 
    {
        AmmoCrate,
        HealBig,
        HealSmall,
        end
    }

}
