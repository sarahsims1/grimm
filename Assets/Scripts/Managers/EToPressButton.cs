using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Doublsb.Dialog
{
    public class EToPressButton : MonoBehaviour, ISelectHandler, IDeselectHandler
    {

        private bool ready;

        public void OnSelect(BaseEventData eventData)
        {
            ready = true;
        }
        public void OnDeselect(BaseEventData eventData)
        {
            ready = false;
        }
        void Update()
        {
            if (ready == true && Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
