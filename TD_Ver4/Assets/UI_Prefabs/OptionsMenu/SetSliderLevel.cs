using UnityEngine;
using UnityEngine.UI;

public class SetSliderLevel : MonoBehaviour
{
    

    private void Start() {
        Slider slider = gameObject.GetComponent<Slider>();

        slider.value = GameControl.control.GetAudioLevel();

        slider.onValueChanged.AddListener(delegate {
            GameControl.control.SetAudioLevel();
        });

    }
}
