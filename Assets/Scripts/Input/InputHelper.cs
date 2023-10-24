using UnityEngine;

namespace Scripts.Input
{
    public class InputHelper : MonoBehaviour
    {
        public static InputHelper Instance { get; private set; }

        public Vector2 Direction => joystick.Direction;
        [SerializeField]
        private FixedJoystick joystick;

        public void Awake()
        {
            Instance = this;
        }
    }
}

