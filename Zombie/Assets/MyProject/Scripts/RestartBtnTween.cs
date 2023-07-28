using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class RestartBtnTween : MonoBehaviour, IPointerEnterHandler//, IPointerExitHandler
{
    Tween shakeAni = default;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("마우스 올려둠.");
        if (shakeAni == null || shakeAni == default)
        {
            shakeAni = transform.DOShakeScale(0.5f, 1, 10, 90, true, ShakeRandomnessMode.Full).SetAutoKill(); //트위닝이 돌아가는 동안에는 돌아가지 않게끔 해줘야함
            shakeAni.onKill += () => DisposeTween();
            return;
        }
        //Debug.Log("비어있진 않음");
        //if(shakeAni.onKill ) 
        //{
        //    shakeAni = default;
        //    Debug.Log("이제 비었다");
        //}
    }

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    transform.localScale = Vector3.one;

    //    if (shakeAni.IsComplete() == true)
    //    {
    //        shakeAni = default;
    //        Debug.Log("이제 비었다");
    //    }

    //}

    //! Tween이 kill 될 때 shakeAni 변수를 비워주는 함수
    private void DisposeTween()
    {
        shakeAni = default;
        transform.localScale = Vector3.one;
    }

}
