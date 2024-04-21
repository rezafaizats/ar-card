using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

namespace RF.ArCard.Manager
{    
    public class ARGameManager : MonoBehaviour
    {
        [SerializeField] private ARSession session;
        [SerializeField] private CanvasGroup arAvaliabilityNotice;

        // Start is called before the first frame update
        IEnumerator Start()
        {
            arAvaliabilityNotice.alpha = 0;
            if ((ARSession.state == ARSessionState.None) || (ARSession.state == ARSessionState.CheckingAvailability))
            {
                yield return ARSession.CheckAvailability();
            }

            if (ARSession.state == ARSessionState.Unsupported)
            {
                // Start some fallback experience for unsupported devices
                DOTween.Init();
                arAvaliabilityNotice.DOFade(1f, 0.65f);
                arAvaliabilityNotice.alpha = 0;
            }
            else
            {
                // Start the AR session
                session.enabled = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}