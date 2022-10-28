using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

namespace Doublsb.Dialog
{
    public class Talk : MonoBehaviour
    {
        /// <summary>
        /// A script to show dialog when player approaches character and presses E.
        /// Features need to be added later to indicate that E needs to be pressed,
        /// and to make the character face the player.
        /// </summary>

        // The dialogue system

        [SerializeField]
        private GameObject dialogObject;
        [SerializeField]
        private GameObject dialog;
        [SerializeField]
        private GameObject character;
        [SerializeField]
        private FirstPersonController fps;

        //Checks if player is in range
        private bool inRange;

        //Checks if the game is ready to redo dialogue
        private bool ready = true;

        //Checks if Selection is active
        public static bool selectActive;

        //Events
        public delegate void TalkEvents();
        public static event TalkEvents talking;
       
        //Sets dialogue inactive
        private void Start()
        {
            dialogObject.SetActive(false);
            dialog.SetActive(false);
        }

        private void OnDisable()
        {
            DialogManager.DialogFin -= Deactivate;
        }
        //Activates objects and raises event when player presses E. Set's ready to false so player doesn't keep restarting dialog.
        private void Update()
        {
            if (inRange && Input.GetKeyDown(KeyCode.E)&&ready==true)
            {
                //This event indicates that the dialog is almost over.
                DialogManager.DialogFin += Deactivate;
                fps.Frozen(true);
                character.SetActive(true);
                dialog.SetActive(true);
                dialogObject.SetActive(true);
                ready = false;
                if(talking!=null) talking();
            }
        }

        //Checks collision to see if character is in range
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "MainCamera")
            {
                inRange = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "MainCamera")
            {
                inRange = false;
            }
        }
        //Starts when the dialog is winding down. Player must press E twice, one to see the last line, and another to close the window.
        //I know it's not exactly kosher, but I couldn't find another method of checking whether the dialog is over, and it works so IDK.
        //This deactivates everything and sets ready to true. It was suprsingly hard to make the system restart the dialog after finishing it once.
        IEnumerator Deactivate()
        {
            if (!selectActive)
            {
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                yield return new WaitForSeconds(0.01f);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                yield return new WaitForSeconds(0.01f);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                fps.Frozen(false);
                dialogObject.SetActive(false);
                dialog.SetActive(false);
                ready = true;
            }
        }
    }
}
