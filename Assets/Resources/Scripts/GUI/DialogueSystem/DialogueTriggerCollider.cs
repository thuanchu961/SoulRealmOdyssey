using UnityEngine;

public class DialogueTriggerCollider : MonoBehaviour {
    public Dialogue dialogue;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            SoundManager.Instant.PlaySound(Constant.SFX.Typing);
            DialogueManager.Instant.StartDialogue(dialogue);
            Destroy(gameObject);
        }
    }
}
