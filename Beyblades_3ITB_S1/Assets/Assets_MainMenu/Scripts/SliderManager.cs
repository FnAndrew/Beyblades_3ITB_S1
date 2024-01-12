using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [SerializeField] Slider slider;

    public float sliderVal = 0;
    public float forceVal = 0;
    float force = 100;
    [SerializeField]
    public bool started { get; private set; } = false; //game is/was started

    public float speed = 1f; // Speed of the slider movement

    private bool increasing = true;
    private bool fired = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) && !fired)
        {
            if (increasing)
            {
                slider.value += speed * Time.deltaTime; // Increase the slider value
                if (slider.value >= slider.maxValue)
                {
                    slider.value = slider.maxValue; // Cap the value at maximum
                    increasing = false; // Change direction to decrease
                }
            }
            else
            {
                slider.value -= speed * Time.deltaTime; // Decrease the slider value
                if (slider.value <= slider.minValue)
                {
                    slider.value = slider.minValue; // Cap the value at minimum
                    increasing = true; // Change direction to increase
                }
            }

            sliderVal = slider.value;
            forceVal = sliderVal * force;

            Debug.Log($"Slider val: {sliderVal} | Force val: {forceVal}");
        }
        else if (!fired) /* Pressed */
        {
            fired = true;
            started = true;
            Debug.Log("Fire! s " + $"Slider val: {sliderVal} | Force val: {forceVal}");
            //Destroy(gameObject); GRISA ZA TO MUZE
            // schovat

        }


    }
}