using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
namespace Valve.VR.InteractionSystem
{
    public class Click : MonoBehaviour
    {
        public UnityEvent OnClick;
        public UnityEvent OnUnClick;
        Hand leftHand;
        Hand rightHand;
        bool hovering;

        private void Update()
        {
            if (hovering)
            {
                GrabTypes startingGrabTypeLeft = leftHand.GetGrabStarting();
                //bool isGrabEndingLeft = leftHand.IsGrabEnding(this.gameObject);
                GrabTypes isGrabEndingLeft = leftHand.GetGrabEnding();
                GrabTypes startingGrabTypeRight = rightHand.GetGrabStarting();
                //bool isGrabEndingRight = rightHand.IsGrabEnding(this.gameObject);
                GrabTypes isGrabEndingRight = rightHand.GetGrabEnding();
                if (startingGrabTypeLeft != GrabTypes.None || startingGrabTypeRight != GrabTypes.None)
                {
                    Clicked();
                }

                //if (isGrabEndingLeft || isGrabEndingRight)
                //{
                //    Debug.Log("StopGrabbing");
                //}            

                if (isGrabEndingLeft != GrabTypes.None || isGrabEndingRight != GrabTypes.None)
                {
                    UnClicked();
                }

            }
        }

        public void Clicked()
        {
            OnClick.Invoke();
        }

        public void UnClicked()
        {
            OnUnClick.Invoke();
        }

        public void OnHoverLeftStart(Hand _leftHand)
        {
            leftHand = _leftHand;
            hovering = true;
        }

        public void OnHoverRightStart(Hand _rightHand)
        {
            rightHand = _rightHand;
            hovering = true;
        }

        public void OnHoverLeftEnd(Hand _leftHand)
        {

            leftHand = _leftHand;
            hovering = false;
        }

        public void OnHoverRightEnd(Hand _rightHand)
        {
            rightHand = _rightHand;
            hovering = false;
        }
    }
}
