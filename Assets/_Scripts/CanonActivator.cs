using UnityEngine;

public class CanonActivator : MonoBehaviour
{
    [SerializeField] CanonController[] canonsToControl;
    [SerializeField] Color enabled, disabled;
    [SerializeField] float reactivationDelay = 5f;

    private void OnTriggerEnter2D(Collider2D collision) {
        PromptController.Instance.SetPromtText("Press E");
    }
    private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKeyDown(KeyCode.E)) {
            foreach (CanonController canon in canonsToControl) {
                canon.SetActivationStateCanon(false);
                canon.GetComponent<SpriteRenderer>().color = disabled;
                Invoke(nameof(ActivateCanon), reactivationDelay);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        PromptController.Instance.PromptEnabled(false);
    }

    void ActivateCanon() {
        foreach (CanonController canon in canonsToControl) {
            canon.SetActivationStateCanon(true);
            canon.GetComponent<SpriteRenderer>().color = enabled;
        }
    }
}