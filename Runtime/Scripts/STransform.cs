using UnityEngine;

namespace ASPax.Utilities
{
    /// <summary>
    /// Easy and safety access of all elements from transform, rectTransform and Screen/World Positions
    /// </summary>
    public class STransform : MonoBehaviour
    {
#if UNITY_EDITOR
        [Header("VALUES - Editor Test", order = 0)]
        [SerializeField] private Vector3 position;
        [SerializeField] private Vector3 localPosition;
        [SerializeField] private Vector3 anchoredPosition;
        [SerializeField] private Vector3 localScale;
        [Space(20, order = 0)]
        [SerializeField] private Quaternion rotation;
        [SerializeField] private Quaternion localRotation;
        [SerializeField] private Vector3 eulerAngles;
        [SerializeField] private Vector3 localEulerAngles;
        [Space(20, order = 0)]
        [SerializeField] private Vector3 screenToWorldPointPosition;
        [SerializeField] private Vector3 screenToWorldPointLocalPosition;
        [SerializeField] private Vector3 screenToWorldPointAnchoredPosition;
        /// Reset to default values.
        private void Reset()
        {
            AssignValues();
        }
        /// Editor-only function that Unity calls when the script is loaded or a value changes in the Inspector.
        private void OnValidate()
        {
            UnityEditor.EditorApplication.delayCall += () =>
            {
                bool conditional =
                UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode ||
                UnityEditor.EditorApplication.isCompiling ||
                UnityEditor.EditorApplication.isUpdating;

                if (conditional)
                    return;

                try
                {
                    AssignValues();
                }
                catch
                {
                    return;
                }
            };
        }
        /// Update is called every frame, if the MonoBehaviour is enabled.
        private void Update()
        {
            AssignValues();
        }
        /// <summary>
        /// Assign values to the serialized fields
        /// </summary>
        private void AssignValues()
        {
            position = Position;
            localPosition = LocalPosition;
            rotation = Rotation;
            localRotation = LocalRotation;
            eulerAngles = EulerAngles;
            localEulerAngles = LocalEulerAngles;
            localScale = Scale;
            anchoredPosition = GetAnchoredPosition();
            screenToWorldPointPosition = ScreenToWorldPointPosition;
            screenToWorldPointLocalPosition = ScreenToWorldPointLocalPosition;
            screenToWorldPointAnchoredPosition = ScreenToWorldPointAnchoredPosition;
        }
#endif
        private bool _isItRectTransform;
        private RectTransform _rectTransform;
        private Camera _mainCamera;
        /// Awake is called when an enabled script instance is being loaded.
        private void Awake()
        {
            ComponentsAssignment();
        }
        /// Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        private void Start()
        {
            _mainCamera = Camera.main;
        }
        /// <summary>
        /// Assignment of components and variables
        /// </summary>
        [ContextMenu("Components Assignment")]
        private void ComponentsAssignment()
        {
            if (_rectTransform == null)
            {
                _isItRectTransform = TryGetComponent(out RectTransform rectTransform);

                if (_isItRectTransform)
                    _rectTransform = rectTransform;
            }
        }
        /// <summary>
        /// Set the anchored position of the RectTransform if it has
        /// </summary>
        private void SetAchoredPosition(Vector3 anchoredPosition)
        {
            if (_isItRectTransform)
                _rectTransform.anchoredPosition = anchoredPosition;
        }
        /// <summary>
        /// Get the anchored position of the RectTransform
        /// </summary>
        private Vector3 GetAnchoredPosition()
        {
            if (_isItRectTransform)
                return _rectTransform.anchoredPosition;
            else
                return Vector3.zero;
        }
        /// <summary>
        /// Return main camera (<see cref="Camera.main"/>) initialized in Awake if it exists using out parameter
        /// </summary>
        /// <returns>if exists return true</returns>
        /// <remarks>This function must be called after Start( )</remarks>
        public bool TryGetMainCamera(out Camera camera)
        {
            var isNull = _mainCamera == null;
            camera = isNull ? null : _mainCamera;
            return isNull;
        }
        /// <summary>
        /// Return Rect Trabsform if it has
        /// </summary>
        public RectTransform RectTransform => _rectTransform;
        public int TestInt { get; set; }
        /// <summary>
        /// Get or Set local scale
        /// </summary>
        public Vector3 Scale
        {
            get => transform.localScale;
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    transform.localScale = vector;
                }
                else
                {
                    transform.localScale = value;
                }
            }
        }
        /// <summary>
        /// Get or Set Position
        /// </summary>
        public Vector3 Position
        {
            get => transform.position;
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    transform.position = vector;
                }
                else
                {
                    transform.position = value;
                }
            }
        }
        /// <summary>
        /// Get or Set Local Position
        /// </summary>
        public Vector3 LocalPosition
        {
            get => transform.localPosition;
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    transform.localPosition = vector;
                }
                else
                {
                    transform.localPosition = value;
                }
            }
        }
        /// <summary>
        /// Get or Set Anchored Position if it has
        /// </summary>
        public Vector3 AnchoredPosition
        {
            get => GetAnchoredPosition();
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    SetAchoredPosition(vector);
                }
                else
                {
                    SetAchoredPosition(value);
                }
            }
        }
        /// <summary>
        /// Get or Set Rotation
        /// </summary>
        public Quaternion Rotation
        {
            get => transform.rotation;
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);
                var isNaN_w = float.IsNaN(value.w);

                if (isNaN_x || isNaN_y || isNaN_z || isNaN_w)
                {
                    var quaternion = new Quaternion
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z,
                        w = isNaN_w ? 0f : value.w
                    };

                    transform.rotation = quaternion;
                }
                else
                {
                    transform.rotation = value;
                }
            }
        }
        /// <summary>
        /// Get or Set local rotation
        /// </summary>
        public Quaternion LocalRotation
        {
            get => transform.localRotation;
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);
                var isNaN_w = float.IsNaN(value.w);

                if (isNaN_x || isNaN_y || isNaN_z || isNaN_w)
                {
                    var quaternion = new Quaternion
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z,
                        w = isNaN_w ? 0f : value.w
                    };

                    transform.localRotation = quaternion;
                }
                else
                {
                    transform.localRotation = value;
                }
            }
        }
        /// <summary>
        /// Get or Set Euler Angles
        /// </summary>
        public Vector3 EulerAngles
        {
            get => transform.eulerAngles;
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    transform.eulerAngles = vector;
                }
                else
                {
                    transform.eulerAngles = value;
                }
            }
        }
        /// <summary>
        /// Get or Set Local Euler Angles
        /// </summary>
        public Vector3 LocalEulerAngles
        {
            get => transform.localEulerAngles;
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    transform.localEulerAngles = vector;
                }
                else
                {
                    transform.localEulerAngles = value;
                }
            }
        }
        /// <summary>
        /// Get or Set Camera Screen To World Point from Position
        /// </summary>
        public Vector3 ScreenToWorldPointPosition
        {
            get => _mainCamera.ScreenToWorldPoint(transform.position);
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    transform.position = _mainCamera.ScreenToWorldPoint(vector);
                }
                else
                {
                    transform.position = _mainCamera.ScreenToWorldPoint(value);
                }
            }
        }
        /// <summary>
        /// Get or Set Camera Screen To World Point from Local Position
        /// </summary>
        public Vector3 ScreenToWorldPointLocalPosition
        {
            get => _mainCamera.ScreenToWorldPoint(transform.localPosition);
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    transform.localPosition = _mainCamera.ScreenToWorldPoint(vector);
                }
                else
                {
                    transform.localPosition = _mainCamera.ScreenToWorldPoint(value);
                }
            }
        }
        /// <summary>
        /// Get or Set Camera Screen To World Point from Anchored Position if it has
        /// </summary>
        public Vector3 ScreenToWorldPointAnchoredPosition
        {
            get => _mainCamera.ScreenToWorldPoint(GetAnchoredPosition());
            set
            {
                var isNaN_x = float.IsNaN(value.x);
                var isNaN_y = float.IsNaN(value.y);
                var isNaN_z = float.IsNaN(value.z);

                if (isNaN_x || isNaN_y || isNaN_z)
                {
                    var vector = new Vector3
                    {
                        x = isNaN_x ? 0f : value.x,
                        y = isNaN_y ? 0f : value.y,
                        z = isNaN_z ? 0f : value.z
                    };

                    SetAchoredPosition(_mainCamera.ScreenToWorldPoint(vector));
                }
                else
                {
                    SetAchoredPosition(_mainCamera.ScreenToWorldPoint(value));
                }
            }
        }
    }
}

