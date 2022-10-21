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
        // Start is called before the first frame updat

        public void OnSelect(BaseEventData eventData)
        {
            ready = true;
            Debug.Log("Selected!");
        }
        public void OnDeselect(BaseEventData eventData)
        {
            ready = false;
            Debug.Log("Deselected!");
        }
        // Update is called once per frame
        void Update()
        {
            if (ready == true && Input.GetKeyDown(KeyCode.E))
            {
                gameObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
