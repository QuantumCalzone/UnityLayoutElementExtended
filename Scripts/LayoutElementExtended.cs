using UnityEngine;
using UnityEngine.UI;

namespace UnityLayoutElementExtended
{
    [AddComponentMenu("Layout/Extended/Layout Element Extended")]
    [RequireComponent(typeof(RectTransform))]
    public class LayoutElementExtended : LayoutElement
    {
        public LayoutElementExtendedValue MinWidthExtended = new LayoutElementExtendedValue();
        public LayoutElementExtendedValue MinHeightExtended = new LayoutElementExtendedValue();
        public LayoutElementExtendedValue PreferredWidthExtended = new LayoutElementExtendedValue();
        public LayoutElementExtendedValue PreferredHeightExtended = new LayoutElementExtendedValue();
        public LayoutElementExtendedValue FlexibleWidthExtended = new LayoutElementExtendedValue();
        public LayoutElementExtendedValue FlexibleHeightExtended = new LayoutElementExtendedValue();

        public LayoutElementExtendedValue MaxWidth = new LayoutElementExtendedValue();
        public LayoutElementExtendedValue MaxHeight = new LayoutElementExtendedValue();

        private RectTransform rectTransform = null;
        public RectTransform GetRectTransform {
            get {
                if (!rectTransform) rectTransform = GetComponent<RectTransform>();
                return rectTransform;
            }
        }

        public float Width {
            get {
                var valueToReturn = 0f;

                if (MinWidthExtended.Enabled && !PreferredWidthExtended.Enabled)
                {
                    valueToReturn = MinWidth;
                }
                else if (!MinWidthExtended.Enabled && PreferredWidthExtended.Enabled)
                {
                    valueToReturn = PreferredWidth;
                }
                else if (MinWidthExtended.Enabled && PreferredWidthExtended.Enabled)
                {
                    valueToReturn = PreferredWidth > MinWidth ? PreferredWidth : MinWidth;
                }

                return valueToReturn;
            }
        }

        public float Height {
            get {
                var valueToReturn = 0f;

                if (MinHeightExtended.Enabled && !PreferredHeightExtended.Enabled)
                {
                    valueToReturn = MinHeight;
                }
                else if (!MinHeightExtended.Enabled && PreferredHeightExtended.Enabled)
                {
                    valueToReturn = PreferredHeight;
                }
                else if (MinHeightExtended.Enabled && PreferredHeightExtended.Enabled)
                {
                    valueToReturn = PreferredHeight > MinHeight ? PreferredHeight : MinHeight;
                }

                return valueToReturn;
            }
        }

        #region Min

        private float MinWidth {
            get {
                var valueToReturn = 0f;

                if (MinWidthExtended.Enabled)
                {
                    MinWidthExtended.ProcessTargetValue(gameObject);

                    valueToReturn = MinWidthExtended.TargetValue;

                    if (MaxWidth.Enabled)
                    {
                        MaxWidth.ProcessTargetValue(gameObject);

                        if (valueToReturn > MaxWidth.TargetValue)
                            valueToReturn = MaxWidth.TargetValue;
                    }
                }

                return valueToReturn;
            }
        }

        private float MinHeight {
            get {
                var valueToReturn = 0f;

                if (MinHeightExtended.Enabled)
                {
                    MinHeightExtended.ProcessTargetValue(gameObject);

                    valueToReturn = MinHeightExtended.TargetValue;

                    if (MaxHeight.Enabled)
                    {
                        MaxHeight.ProcessTargetValue(gameObject);

                        if (valueToReturn > MaxHeight.TargetValue)
                            valueToReturn = MaxHeight.TargetValue;
                    }
                }

                return valueToReturn;
            }
        }

        #endregion

        #region Preferred

        private float PreferredWidth {
            get {
                var preferredWidth = 0f;

                if (PreferredWidthExtended.Enabled)
                {
                    PreferredWidthExtended.ProcessTargetValue(gameObject);

                    preferredWidth = PreferredWidthExtended.TargetValue;

                    if (MaxWidth.Enabled)
                    {
                        MaxWidth.ProcessTargetValue(gameObject);

                        if (preferredWidth > MaxWidth.TargetValue)
                            preferredWidth = MaxWidth.TargetValue;
                    }
                }

                return preferredWidth;
            }
        }

        private float PreferredHeight {
            get {
                var preferredHeight = 0f;

                if (PreferredHeightExtended.Enabled)
                {
                    PreferredHeightExtended.ProcessTargetValue(gameObject);

                    preferredHeight = PreferredHeightExtended.TargetValue;

                    if (MaxHeight.Enabled)
                    {
                        MaxHeight.ProcessTargetValue(gameObject);

                        if (preferredHeight > MaxHeight.TargetValue)
                            preferredHeight = MaxHeight.TargetValue;
                    }
                }

                return preferredHeight;
            }
        }

        #endregion

        #region Flexible

        private float FlexibleWidth {
            get {
                var flexibleWidth = 0f;

                if (FlexibleWidthExtended.Enabled)
                {
                    FlexibleWidthExtended.ProcessTargetValue(gameObject);

                    flexibleWidth = FlexibleWidthExtended.TargetValue;
                }

                return flexibleWidth;
            }
        }

        private float FlexibleHeight {
            get {
                var flexibleHeight = 0f;

                if (FlexibleHeightExtended.Enabled)
                {
                    FlexibleHeightExtended.ProcessTargetValue(gameObject);

                    flexibleHeight = FlexibleHeightExtended.TargetValue;
                }

                return flexibleHeight;
            }
        }

        #endregion

        #region Unity Methods

        public override void CalculateLayoutInputHorizontal()
        {
            minWidth = MinWidthExtended.Enabled ? MinWidth : -1;
            preferredWidth = PreferredWidthExtended.Enabled ? PreferredWidth : -1;
            flexibleWidth = FlexibleWidthExtended.Enabled ? FlexibleWidth : -1;

            base.CalculateLayoutInputHorizontal();
        }

        public override void CalculateLayoutInputVertical()
        {
            minHeight = MinHeightExtended.Enabled ? MinHeight : -1;
            preferredHeight = PreferredHeightExtended.Enabled ? PreferredHeight : -1;
            flexibleHeight = FlexibleHeightExtended.Enabled ? FlexibleHeight : -1;

            base.CalculateLayoutInputVertical();
        }
#if UNITY_EDITOR
        private void Update()
        {
            CalculateLayoutInputHorizontal();
            CalculateLayoutInputVertical();
        }
#endif
        #endregion
    }
}
