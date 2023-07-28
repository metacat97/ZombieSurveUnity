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
        Debug.Log("���콺 �÷���.");
        if (shakeAni == null || shakeAni == default)
        {
            shakeAni = transform.DOShakeScale(0.5f, 1, 10, 90, true, ShakeRandomnessMode.Full).SetAutoKill(); //Ʈ������ ���ư��� ���ȿ��� ���ư��� �ʰԲ� �������
            shakeAni.onKill += () => DisposeTween();
            return;
        }
        //Debug.Log("������� ����");
        //if(shakeAni.onKill ) 
        //{
        //    shakeAni = default;
        //    Debug.Log("���� �����");
        //}
    }

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    transform.localScale = Vector3.one;

    //    if (shakeAni.IsComplete() == true)
    //    {
    //        shakeAni = default;
    //        Debug.Log("���� �����");
    //    }

    //}

    //! Tween�� kill �� �� shakeAni ������ ����ִ� �Լ�
    private void DisposeTween()
    {
        shakeAni = default;
        transform.localScale = Vector3.one;
    }

}
