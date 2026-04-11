using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using System.Net.Security;
using DG.Tweening;


namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }
    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> lisOfObjects;
        public List<Typper> listOfPhrases;

        public Image uiBackground;

        public bool startHided = false;

        [Header("Animation")]
        public float animationDuration = 0.3f;
        public float delayBetweenObjects = 0.05f;

        private void Start()
            {
                if (startHided)
                    HideObjects();
            }

        [Button]
        public virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }
        [Button]
        public virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");
        }
        private void ShowObjects()
        {
            for( int i=0; i<lisOfObjects.Count; i++)
            {
                var obj = lisOfObjects[i];
                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
            Invoke(nameof(StartType), delayBetweenObjects * lisOfObjects.Count);
            uiBackground.enabled = true;
        }
        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
               listOfPhrases[i].StartType();
            }
        }


        private void ForceShowObjects()
        {
            lisOfObjects.ForEach(i => i.gameObject.SetActive(true)) ;
            uiBackground.enabled = true;
        }
        private void HideObjects()
        {
            lisOfObjects.ForEach(i => i.gameObject.SetActive(false));
            uiBackground.enabled = false;   
        }
    }
}   