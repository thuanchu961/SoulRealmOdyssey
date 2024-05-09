using UnityEngine;

public class Boss : MonoBehaviour {
    public void PlaySound(string sound) {
        switch (sound) {
            case "DragonRoar":
                SoundManager.Instant.PlaySound(Constant.SFX.DragonRoar);
                break;
            case "DragonWings":
                SoundManager.Instant.PlaySound(Constant.SFX.DragonWings);
                break;
            case "Fireball":
                SoundManager.Instant.PlaySound(Constant.SFX.Fireball);
                break;
            case "Blitz":
                SoundManager.Instant.PlaySound(Constant.SFX.Blitz);
                break;
            case "Burst":
                SoundManager.Instant.PlaySound(Constant.SFX.Burst);
                break;
            case "DragonGrowl":
                SoundManager.Instant.PlaySound(Constant.SFX.DragonGrowl);
                break;
        }
    }

    public void AutoDestoy() {
        Destroy(gameObject);
    }
}
