using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Spine.Unity;
public class ProgressBar : MonoBehaviour
{

    // slider'ın maxValue'su animasyonun uzunlugu kadar olmalı
    // slider'ın degerini animation time'a vermelisin. Animasyon ona göre hareket etmeli
    
    public SkeletonAnimation skeletonAnimation; 
    public Text text;
    public static Slider slider;
    private float targetProgress = 0;
   
    private void Awake() {
        slider = gameObject.GetComponent<Slider>();

    }
    string currentState = "animation";
    // Start is called before the first frame update
    void Start()
    {
        currentState = skeletonAnimation.AnimationName;
        var myAnimation = skeletonAnimation.Skeleton.Data.FindAnimation("animation");
        //Debug.Log ( myAnimation.AnimationTime );  
        text.text = (slider.value).ToString();
    }

    // Update is called once per frame

    void Update()
    {
        
        //float aa = animationTime.AnimationTime;
        skeletonAnimation.skeleton.Update(slider.value);
        Debug.Log("slider value : " + slider.value);
        text.text = (slider.value).ToString();
        AnimChanged();
        
    
    }
    public void IncrementProgress( float newProgress){
        targetProgress  =  slider.value + newProgress;
    }
    public void AnimChanged(){
        if ( currentState != skeletonAnimation.AnimationName){
            currentState = skeletonAnimation.AnimationName;
            var myAnimation = skeletonAnimation.Skeleton.Data.FindAnimation(currentState);
            Debug.Log ("anim duration" + myAnimation.Duration );  
            slider.maxValue = myAnimation.Duration;
            text.text = (slider.value).ToString();
            
        }
    }
}
