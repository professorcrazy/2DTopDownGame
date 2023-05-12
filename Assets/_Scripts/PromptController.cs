using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PromptController : MonoBehaviour
{
    TMP_Text textField;
    public static PromptController Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        textField = GetComponentInChildren<TMP_Text>(true);
        PromptEnabled(false);
    }

    public void SetPromtText(string message) {
        textField.text = message;
        gameObject.SetActive(true);
    }
    public void PromptEnabled(bool active) {
        gameObject.SetActive(active);
    }

}
