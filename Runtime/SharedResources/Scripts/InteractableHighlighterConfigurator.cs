namespace Tilia.Visuals.InteractableHighlighter
{
    using System.Collections.Generic;
    using Tilia.Interactions.Interactables.Interactables;
    using Tilia.Interactions.Interactables.Interactors;
    using Tilia.Interactions.Interactables.Interactors.Event.Proxy;
    using UnityEngine;
    using Zinnia.Data.Attribute;

    /// <summary>
    /// Sets up the InteractableHighlighter Prefab based on the provided user settings.
    /// </summary>
    public class InteractableHighlighterConfigurator : MonoBehaviour
    {
        #region Facade Settings
        [Header("Facade Settings")]
        [Tooltip("The public interface facade.")]
        [SerializeField]
        [Restricted]
        private InteractableHighlighterFacade facade;
        /// <summary>
        /// The public interface facade.
        /// </summary>
        public InteractableHighlighterFacade Facade
        {
            get
            {
                return facade;
            }
            protected set
            {
                facade = value;
            }
        }
        #endregion

        #region Reference Settings
        [Header("Reference Settings")]
        [Tooltip("The linked InteractorFacadeEventProxyEmitter for highlighting.")]
        [SerializeField]
        [Restricted]
        private InteractorFacadeEventProxyEmitter highlighterProxyEmitter;
        /// <summary>
        /// The linked <see cref="InteractorFacadeEventProxyEmitter"/> for highlighting.
        /// </summary>
        public InteractorFacadeEventProxyEmitter HighlighterProxyEmitter
        {
            get
            {
                return highlighterProxyEmitter;
            }
            protected set
            {
                highlighterProxyEmitter = value;
            }
        }
        [Tooltip("The linked InteractorFacadeEventProxyEmitter for unhighlighting.")]
        [SerializeField]
        [Restricted]
        private InteractorFacadeEventProxyEmitter unhighlighterProxyEmitter;
        /// <summary>
        /// The linked <see cref="InteractorFacadeEventProxyEmitter"/> for unhighlighting.
        /// </summary>
        public InteractorFacadeEventProxyEmitter UnhighlighterProxyEmitter
        {
            get
            {
                return unhighlighterProxyEmitter;
            }
            protected set
            {
                unhighlighterProxyEmitter = value;
            }
        }
        #endregion

        /// <summary>
        /// A cache of existing used materials.
        /// </summary>
        protected Dictionary<Renderer, Material[]> cachedMaterials = new Dictionary<Renderer, Material[]>();

        /// <summary>
        /// Sets up the Interactable for the highlight process.
        /// </summary>
        public virtual void SetupInteractable()
        {
            CacheInteractableMaterials(Facade.Interactable);
            RegisterInteractableEvents(Facade.Interactable);
        }

        /// <summary>
        /// Tears down the Interactable from the highlight process.
        /// </summary>
        public virtual void TearDownInteractable()
        {
            ResetInteractableMaterialsFromCache();
            UnregisterInteractableEvents(Facade.Interactable);
        }

        /// <summary>
        /// Sets up the Rule for the highlight process.
        /// </summary>
        public virtual void SetUpRule()
        {
            HighlighterProxyEmitter.ReceiveValidity = Facade.HighlightValidity;
            UnhighlighterProxyEmitter.ReceiveValidity = Facade.HighlightValidity;
        }

        /// <summary>
        /// Attempts to highlight the <see cref="Facade.Interactbale"/> meshes.
        /// </summary>
        /// <param name="interactor">The Interactor initiating the interaction.</param>
        public virtual void AttemptHighlight(InteractorFacade interactor)
        {
            if (!Facade.IsEnabled)
            {
                return;
            }

            if (Facade.HighlightMaterial != null)
            {
                ApplyMaterialToAllMeshes(Facade.Interactable, Facade.HighlightMaterial);
            }

            Facade.Highlighted?.Invoke(interactor);
        }

        /// <summary>
        /// Attempts to unhighlight the <see cref="Facade.Interactbale"/> meshes.
        /// </summary>
        /// <param name="interactor">The Interactor initiating the interaction.</param>
        public virtual void AttemptUnhighlight(InteractorFacade interactor)
        {
            if (!Facade.IsEnabled)
            {
                return;
            }

            if (Facade.UnhighlightMaterial != null)
            {
                ApplyMaterialToAllMeshes(Facade.Interactable, Facade.UnhighlightMaterial);
            }
            else if (Facade.HighlightMaterial != null)
            {
                ResetInteractableMaterialsFromCache();
            }

            Facade.Unhighlighted?.Invoke(interactor);
        }

        protected virtual void OnEnable()
        {
            SetupInteractable();
            SetUpRule();
        }

        protected virtual void OnDisable()
        {
            TearDownInteractable();
        }

        /// <summary>
        /// Caches all of the materials associated with the given <see cref="InteractableFacade"/>.
        /// </summary>
        /// <param name="interactable">The source of the materials to cache.</param>
        protected virtual void CacheInteractableMaterials(InteractableFacade interactable)
        {
            if (interactable == null)
            {
                return;
            }

            cachedMaterials.Clear();
            foreach (Renderer currentRenderer in interactable.GetComponentsInChildren<Renderer>())
            {
                if (currentRenderer == null)
                {
                    continue;
                }

                cachedMaterials.Add(currentRenderer, currentRenderer.materials);
            }
        }

        /// <summary>
        /// Applies the given <see cref="Material"/> to all of the meshes in the given <see cref="InteractableFacade"/>.
        /// </summary>
        /// <param name="interactable">The target to change the mesh materials on.</param>
        /// <param name="materialToApply">The material to apply.</param>
        protected virtual void ApplyMaterialToAllMeshes(InteractableFacade interactable, Material materialToApply)
        {
            if (interactable == null)
            {
                return;
            }

            foreach (Renderer currentRenderer in interactable.GetComponentsInChildren<Renderer>())
            {
                if (currentRenderer == null)
                {
                    continue;
                }

                currentRenderer.material = materialToApply;
            }
        }

        /// <summary>
        /// Resets all of the materials on the <see cref="Facade.Interactable"/> to the cached materials.
        /// </summary>
        protected virtual void ResetInteractableMaterialsFromCache()
        {
            foreach (KeyValuePair<Renderer, Material[]> currentRenderer in cachedMaterials)
            {
                if (currentRenderer.Key == null)
                {
                    continue;
                }

                currentRenderer.Key.materials = currentRenderer.Value;
            }
        }

        /// <summary>
        /// Registers the appropriate events on the given <see cref="InteractableFacade"/>.
        /// </summary>
        /// <param name="interactable">The source of the interaction events.</param>
        protected virtual void RegisterInteractableEvents(InteractableFacade interactable)
        {
            if (interactable == null)
            {
                return;
            }

            interactable.FirstTouched.AddListener(HandleFirstTouched);
            interactable.LastUntouched.AddListener(HandleLastUntouched);
            interactable.FirstGrabbed.AddListener(HandleFirstGrabbed);
            interactable.LastUngrabbed.AddListener(LastUngrabbed);
        }

        /// <summary>
        /// Unregisters the appropriate events on the given <see cref="InteractableFacade"/>.
        /// </summary>
        /// <param name="interactable">The source of the interaction events.</param>
        protected virtual void UnregisterInteractableEvents(InteractableFacade interactable)
        {
            if (interactable == null)
            {
                return;
            }

            interactable.FirstTouched.RemoveListener(HandleFirstTouched);
            interactable.LastUntouched.RemoveListener(HandleLastUntouched);
            interactable.FirstGrabbed.RemoveListener(HandleFirstGrabbed);
            interactable.LastUngrabbed.RemoveListener(LastUngrabbed);
        }

        /// <summary>
        /// Handles when the <see cref="InteractableFacade"/> is first touched.
        /// </summary>
        /// <param name="interactor">The Interactor initiating the event.</param>
        protected virtual void HandleFirstTouched(InteractorFacade interactor)
        {
            if (HighlighterProxyEmitter == null)
            {
                return;
            }

            HighlighterProxyEmitter.Receive(interactor);
        }

        /// <summary>
        /// Handles when the <see cref="InteractableFacade"/> is last untouched.
        /// </summary>
        /// <param name="interactor">The Interactor initiating the event.</param>
        protected virtual void HandleLastUntouched(InteractorFacade interactor)
        {
            UnhighlighterProxyEmitter.Receive(interactor);
        }

        /// <summary>
        /// Handles when the <see cref="InteractableFacade"/> is first grabbed.
        /// </summary>
        /// <param name="interactor">The Interactor initiating the event.</param>
        protected virtual void HandleFirstGrabbed(InteractorFacade interactor)
        {
            if (HighlighterProxyEmitter == null || UnhighlighterProxyEmitter == null)
            {
                return;
            }

            HighlighterProxyEmitter.gameObject.SetActive(false);
            UnhighlighterProxyEmitter.Receive(interactor);
        }

        /// <summary>
        /// Handles when the <see cref="InteractableFacade"/> is last ungrabbed.
        /// </summary>
        /// <param name="interactor">The Interactor initiating the event.</param>
        protected virtual void LastUngrabbed(InteractorFacade interactor)
        {
            if (HighlighterProxyEmitter == null)
            {
                return;
            }

            HighlighterProxyEmitter.gameObject.SetActive(true);
            if (Facade.Interactable.TouchingInteractors.Count > 0)
            {
                HighlighterProxyEmitter.Receive(interactor);
            }
            else
            {
                UnhighlighterProxyEmitter.Receive(interactor);
            }
        }
    }
}