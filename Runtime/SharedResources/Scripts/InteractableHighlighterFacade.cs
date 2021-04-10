namespace Tilia.Visuals.InteractableHighlighter
{
    using Malimbe.MemberChangeMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System;
    using Tilia.Interactions.Interactables.Interactables;
    using Tilia.Interactions.Interactables.Interactors;
    using UnityEngine;
    using UnityEngine.Events;
    using Zinnia.Data.Attribute;
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
        /// <summary>
        /// The <see cref="InteractableFacade"/> that is linked to the highlighter.
        /// </summary>
        [Serialized, Cleared]
        [field: Header("Highlight Settings"), DocumentedByXml]
        public InteractableFacade Interactable { get; set; }
        /// <summary>
        /// An optional <see cref="Material"/> to apply to all <see cref="Interactable"/> meshes when Highlight occurs.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public Material HighlightMaterial { get; set; }
        /// <summary>
        /// An optional <see cref="Material"/> to apply to all <see cref="Interactable"/> meshes when Unhighlight occurs.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public Material UnhighlightMaterial { get; set; }
        /// <summary>
        /// An optional rule to determine if the Interactor initiating the Interactable events is allowed to initiate the highlight.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public RuleContainer HighlightValidity { get; set; }
        #endregion

        #region Highlight Events
        /// <summary>
        /// Emitted when the Interactable is highlighted.
        /// </summary>
        [Header("Highlight Events"), DocumentedByXml]
        public UnityEvent Highlighted = new UnityEvent();
        /// <summary>
        /// Emitted when the Interactable is unhighlighted.
        /// </summary>
        [DocumentedByXml]
        public UnityEvent Unhighlighted = new UnityEvent();
        #endregion

        #region Reference Settings
        /// <summary>
        /// The linked <see cref="InteractableHighlighterConfigurator"/>.
        /// </summary>
        [Serialized]
        [field: Header("Reference Settings"), DocumentedByXml, Restricted]
        public InteractableHighlighterConfigurator Configuration { get; protected set; }
        #endregion

        /// <summary>
        /// Called before <see cref="Interactable"/> has been changed.
        /// </summary>
        [CalledBeforeChangeOf(nameof(Interactable))]
        protected virtual void OnBeforeInteractableChange()
        {
            Configuration.TearDownInteractable();
        }

        /// <summary>
        /// Called after <see cref="Interactable"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(Interactable))]
        protected virtual void OnAfterInteractableChange()
        {
            Configuration.SetupInteractable();
        }

        /// <summary>
        /// Called after <see cref="HighlightValidity"/> has been changed.
        /// </summary>
        [CalledAfterChangeOf(nameof(HighlightValidity))]
        protected virtual void OnAfterHighlightValidityChange()
        {
            Configuration.SetUpRule();
        }
    }
}