using UnityEngine;
using UnityEngine.UI;
public class Food_script : MonoBehaviour
{
    public Slider Hunger_Slider;

    public void HungerMax(int Hunger)
    {
        Hunger_Slider.maxValue = Hunger;
        Hunger_Slider.value = Hunger;
    }
    public void HungerValue(int Hunger)
    {
        Hunger_Slider.value = Hunger;
    }
}
