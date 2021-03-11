using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public void Maxmana(int mana){
        slider.maxValue = mana;
        slider.value = mana;
    }
    
    public void Setmana(int mana){
        slider.value = mana;
    }
    
}
