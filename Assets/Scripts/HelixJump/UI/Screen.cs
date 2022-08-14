using UnityEngine;
using System.Collections;

namespace UI
{

    public abstract class Screen : MonoBehaviour
    {
        public abstract void ShowScreen();
        public abstract void HideScreen();
    }
}