using System;
using UnityEngine;

namespace UnityLayoutElementExtended
{
    [Serializable]
    public class LayoutElementExtendedValue
    {
        public enum ReferenceTypes { None, Width, Height }

        public bool Enabled = false;
        public ReferenceTypes ReferenceType = ReferenceTypes.None;
        public RectTransform Reference = null;
        public float ReferenceDelta = 0;
        public float TargetValue = 0;

        public void ProcessTargetValue(UnityEngine.Object context)
        {
            if (!Reference && ReferenceType != ReferenceTypes.None)
            {
                Debug.Log("This needs a reference to process your target Layout values", context);
                return;
            }

            switch (ReferenceType)
            {
                case ReferenceTypes.None:
                    break;
                case ReferenceTypes.Width:
                    TargetValue = Reference.rect.width;
                    break;
                case ReferenceTypes.Height:
                    TargetValue = Reference.rect.height;
                    break;
                default:
                    Debug.LogError(string.Format("No support for a referenceType of: {0}", ReferenceType), context);
                    break;
            }

            TargetValue += ReferenceDelta;
        }
    }
}
