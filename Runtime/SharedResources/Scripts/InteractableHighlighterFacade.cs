namespace Tilia.Visuals.InteractableHighlighter
{
    using System;
    using Tilia.Interactions.Interactables.Interactables;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
    using Zinnia.Extension;
    using Zinnia.Rule;

    /// <summary>
    /// The public interface into the InteractableHighlighter Prefab.
    /// </summary>
    public class InteractableHighlighterFacade : MonoBehaviour
    {
        /// <summary>
        /// Defines the event with the <see cref="InteractorFacade"/>.
        /// </summary>
        [Serializable]
        public class UnityEvent : UnityEvent<InteractorFacade> { }

        #region Highlight Settings
        [Header("Highlight Settings")]
        [Tooltip("Whether the highlighter is enabled and will process highlighting actions.")]
        [SerializeField]
        private bool isEnabled = true;
        /// <summary>
        /// Whether the highlighter is enabled and will process highlighting actions.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
            }
        }
        [Tooltip("The InteractableFacade that is linked to the highlighter.")]
        [SerializeField]
        private InteractableFacade interactable;
        /// <summary>
        /// The <see cref="InteractableFacade"/> that is linked to the highlighter.
        /// </summary>
        public InteractableFacade Interactable
        {
            get
            {
                return interactable;
            }
            set
            {
                if (this.IsMemberChangeAllowed())
                {
                    OnBeforeInteractableChange();
                }
                interactable = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterInteractableChange();
                }
            }
        }
        [Tooltip("An optional Material to apply to all Interactable meshes when Highlight occurs.")]
        [SerializeField]
        private Material highlightMaterial;
        /// <summary>
        /// An optional <see cref="Material"/> to apply to all <see cref="Interactable"/> meshes when Highlight occurs.
        /// </summary>
        public Material HighlightMaterial
        {
            get
            {
                return highlightMaterial;
            }
            set
            {
                highlightMaterial = value;
            }
        }
        [Tooltip("An optional Material to apply to all Interactable meshes when Unhighlight occurs.")]
        [SerializeField]
        private Material unhighlightMaterial;
        /// <summary>
        /// An optional <see cref="Material"/> to apply to all <see cref="Interactable"/> meshes when Unhighlight occurs.
        /// </summary>
        public Material UnhighlightMaterial
        {
            get
            {
                return unhighlightMaterial;
            }
            set
            {
                unhighlightMaterial = value;
            }
        }
        [Tooltip("An optional rule to determine if the Interactor initiating the Interactable events is allowed to initiate the highlight.")]
        [SerializeField]
        private RuleContainer highlightValidity;
        /// <summary>
        /// An optional rule to determine if the Interactor initiating the Interactable events is allowed to initiate the highlight.
        /// </summary>
        public RuleContainer HighlightValidity
        {
            get
            {
                return highlightValidity;
            }
            set
            {
                highlightValidity = value;
                if (this.IsMemberChangeAllowed())
                {
                    OnAfterHighlightValidityChange();
                }
            }
        }
        #endregion

        #region Highlight Events
        /// <summary>
        /// Emitted when the Interactable is highlighted.
        /// </summary>
        [Header("Highlight Events")]
        public UnityEvent Highlighted = new UnityEvent();
        /// <summary>
        /// Emitted when the Interactable is unhighlighted.
        /// </summary>
        public UnityEvent Unhighlighted = new UnityEvent();
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked InteractableHighlighterConfigurator.")]
        [SerializeField]
        [Restricted]
        private InteractableHighlighterConfigurator configuration;
        /// <summary>
        /// The linked <see cref="InteractableHighlighterConfigurator"/>.
        /// </summary>
        public InteractableHighlighterConfigurator Configuration
        {
            get
            {
                return configuration;
            }
            protected set
            {
                configuration = value;
            }
        }
        #endregion

        /// <summary>
        /// Clears <see cref="Interactable"/>.
        /// </summary>
        public virtual void ClearInteractable()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Interactable = default;
        }

        /// <summary>
        /// Clears <see cref="HighlightMaterial"/>.
        /// </summary>
        public virtual void ClearHighlightMaterial()
        {
            if (!this.IsValidState())
            {
                return;
            }

            HighlightMaterial = default;
        }

        /// <summary>
        /// Clears <see cref="UnhighlightMaterial"/>.
        /// </summary>
        public virtual void ClearUnhighlightMaterial()
        {
            if (!this.IsValidState())
            {
                return;
            }

            UnhighlightMaterial = default;
        }

        /// <summary>
        /// Clears <see cref="HighlightValidity"/>.
        /// </summary>
        public virtual void ClearHighlightValidity()
        {
            if (!this.IsValidState())
            {
                return;
            }

            HighlightValidity = default;
        }

        /// <summary>
        /// Called before <see cref="Interactable"/> has been changed.
        /// </summary>
        protected virtual void OnBeforeInteractableChange()
        {
            Configuration.TearDownInteractable();
        }

        /// <summary>
        /// Called after <see cref="Interactable"/> has been changed.
        /// </summary>
        protected virtual void OnAfterInteractableChange()
        {
            Configuration.SetupInteractable();
        }

        /// <summary>
        /// Called after <see cref="HighlightValidity"/> has been changed.
        /// </summary>
        protected virtual void OnAfterHighlightValidityChange()
        {
            Configuration.SetUpRule();
        }
    }
}