using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    int index = 0;
    [SerializeField]
    private Text[] options;
    [SerializeField]
    float delay = 0.5f;

    private void CycleOptions() {
        int previousIndex = index;
        if (Input.GetKeyDown("up")) {
            index++;
        } else if (Input.GetKeyDown("down")) {
            index--;
        }
        if (index > options.Length - 1) {
            index = 0;
        }
        if (index < 0) {
            index = options.Length - 1;
        }
        if (index != previousIndex) {
            MakeTransparent();
        }
    }

    private void MakeTransparent() {
        for (int i = 0; i < options.Length; i++)
        {
            if (i != index) {
                Color textColor = options[index].color;
                textColor.a = 0f;
                options[index].color = textColor;
            }
        }
    }

    private void ChangeTransparency() {
        float transparency = options[index].color.a == 0f ? 1f : 0f;
        Color textColor = options[index].color;
        textColor.a = transparency;
        options[index].color = textColor;
    }

    float elapsed = 0f;
    void Update() {
        elapsed += Time.deltaTime;
        if (elapsed >= delay) {
            elapsed = elapsed % delay;
            CycleOptions();
            ChangeTransparency();
            //Debug.Log(index);
        }
    }
}
