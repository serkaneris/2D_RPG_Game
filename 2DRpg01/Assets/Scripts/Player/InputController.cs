using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class InputController : MonoBehaviour
    {
        public float HorizontalVal { get; private set; }
        public float VerticalVal { get; private set; }
        
        void Update()
        {
            HorizontalVal = Input.GetAxis("Horizontal");
            VerticalVal = Input.GetAxis("Vertical");
        }
    }
}

