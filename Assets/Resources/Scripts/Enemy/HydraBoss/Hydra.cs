using UnityEngine;

public class Hydra : MonoBehaviour {
    public Transform[] targets;
    public int lastTarget;

    public void PlaySound(string sound) {
        switch (sound) {
            case "HydraLament":
                SoundManager.Instant.PlaySound(Constant.SFX.HydraLament);
                break;

            case "HydraDig":
                SoundManager.Instant.PlaySound(Constant.SFX.HydraDig);
                break;

            case "HydraBullet":
                SoundManager.Instant.PlaySound(Constant.SFX.HydraBullet);
                break;
        }
    }

    public void AutoDestoy() {
        Destroy(gameObject);
    }
}
