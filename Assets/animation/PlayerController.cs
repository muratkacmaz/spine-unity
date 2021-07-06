using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class PlayerController : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, enter, run;
    public string currentState;

    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        currentState = "animation";
        SetCharacterState(currentState);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(ProgressBar.slider.value != 0 ){
            skeletonAnimation.state.Update(ProgressBar.slider.value);
        }
    }
    // sets character animation    
    public void SetAnimation(AnimationReferenceAsset animation , bool loop, float timeScale ){
        skeletonAnimation.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
        ProgressBar.slider.value = 0;
        Debug.Log( "ProgressBar.slider.value" +ProgressBar.slider.value);     

    }
// checks character state and sets the animation accordingly
    public void SetCharacterState(string state){
        if(state.Equals("animation")){
            SetAnimation(idle,false,0f);
        }
        else if(state.Equals("kapidan_girme")){
            SetAnimation(enter,true,1f);
        }
        else if(state.Equals("kosma")){
            SetAnimation(run,true,1f);
        }
    }

    public void Move(){
        if (Input.GetKeyDown("space"))
        {
            SetCharacterState("kapidan_girme");
        }
        else if (Input.GetKeyDown("tab"))
        {
            SetCharacterState("kosma");
        }
        else if (Input.GetKeyDown("a"))
        {
            SetCharacterState("animation");
        }
    }
}
