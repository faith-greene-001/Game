using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


    public class start : MonoBehaviour
    {
        public Button mybutton;
        // Use this for initialization]
        private void Start()
        {
            Button btn = mybutton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }
        void TaskOnClick()
        {

            SceneManager.LoadScene("sence");

        }
    
        private void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
}
