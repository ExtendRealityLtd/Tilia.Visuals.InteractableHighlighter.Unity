# Class InteractableHighlighterConfigurator

Sets up the InteractableHighlighter Prefab based on the provided user settings.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [cachedMaterials]
* [Properties]
  * [Facade]
  * [HighlighterProxyEmitter]
  * [UnhighlighterProxyEmitter]
* [Methods]
  * [ApplyMaterialToAllMeshes(InteractableFacade, Material)]
  * [AttemptHighlight(InteractorFacade)]
  * [AttemptUnhighlight(InteractorFacade)]
  * [CacheInteractableMaterials(InteractableFacade)]
  * [HandleFirstGrabbed(InteractorFacade)]
  * [HandleFirstTouched(InteractorFacade)]
  * [HandleLastUntouched(InteractorFacade)]
  * [LastUngrabbed(InteractorFacade)]
  * [OnDisable()]
  * [OnEnable()]
  * [RegisterInteractableEvents(InteractableFacade)]
  * [ResetInteractableMaterialsFromCache()]
  * [SetupInteractable()]
  * [SetUpRule()]
  * [TearDownInteractable()]
  * [UnregisterInteractableEvents(InteractableFacade)]

## Details

##### Inheritance

* System.Object
* InteractableHighlighterConfigurator

##### Namespace

* [Tilia.Visuals.InteractableHighlighter]

##### Syntax

```
public class InteractableHighlighterConfigurator : MonoBehaviour
```

### Fields

#### cachedMaterials

A cache of existing used materials.

##### Declaration

```
protected Dictionary<Renderer, Material[]> cachedMaterials
```

### Properties

#### Facade

The public interface facade.

##### Declaration

```
public InteractableHighlighterFacade Facade { get; protected set; }
```

#### HighlighterProxyEmitter

The linked InteractorFacadeEventProxyEmitter for highlighting.

##### Declaration

```
public InteractorFacadeEventProxyEmitter HighlighterProxyEmitter { get; protected set; }
```

#### UnhighlighterProxyEmitter

The linked InteractorFacadeEventProxyEmitter for unhighlighting.

##### Declaration

```
public InteractorFacadeEventProxyEmitter UnhighlighterProxyEmitter { get; protected set; }
```

### Methods

#### ApplyMaterialToAllMeshes(InteractableFacade, Material)

Applies the given Material to all of the meshes in the given InteractableFacade.

##### Declaration

```
protected virtual void ApplyMaterialToAllMeshes(InteractableFacade interactable, Material materialToApply)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactable | The target to change the mesh materials on. |
| Material | materialToApply | The material to apply. |

#### AttemptHighlight(InteractorFacade)

Attempts to highlight the Facade.Interactbale meshes.

##### Declaration

```
public virtual void AttemptHighlight(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor initiating the interaction. |

#### AttemptUnhighlight(InteractorFacade)

Attempts to unhighlight the Facade.Interactbale meshes.

##### Declaration

```
public virtual void AttemptUnhighlight(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor initiating the interaction. |

#### CacheInteractableMaterials(InteractableFacade)

Caches all of the materials associated with the given InteractableFacade.

##### Declaration

```
protected virtual void CacheInteractableMaterials(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactable | The source of the materials to cache. |

#### HandleFirstGrabbed(InteractorFacade)

Handles when the InteractableFacade is first grabbed.

##### Declaration

```
protected virtual void HandleFirstGrabbed(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor initiating the event. |

#### HandleFirstTouched(InteractorFacade)

Handles when the InteractableFacade is first touched.

##### Declaration

```
protected virtual void HandleFirstTouched(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor initiating the event. |

#### HandleLastUntouched(InteractorFacade)

Handles when the InteractableFacade is last untouched.

##### Declaration

```
protected virtual void HandleLastUntouched(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor initiating the event. |

#### LastUngrabbed(InteractorFacade)

Handles when the InteractableFacade is last ungrabbed.

##### Declaration

```
protected virtual void LastUngrabbed(InteractorFacade interactor)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractorFacade | interactor | The Interactor initiating the event. |

#### OnDisable()

##### Declaration

```
protected virtual void OnDisable()
```

#### OnEnable()

##### Declaration

```
protected virtual void OnEnable()
```

#### RegisterInteractableEvents(InteractableFacade)

Registers the appropriate events on the given InteractableFacade.

##### Declaration

```
protected virtual void RegisterInteractableEvents(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactable | The source of the interaction events. |

#### ResetInteractableMaterialsFromCache()

Resets all of the materials on the Facade.Interactable to the cached materials.

##### Declaration

```
protected virtual void ResetInteractableMaterialsFromCache()
```

#### SetupInteractable()

Sets up the Interactable for the highlight process.

##### Declaration

```
public virtual void SetupInteractable()
```

#### SetUpRule()

Sets up the Rule for the highlight process.

##### Declaration

```
public virtual void SetUpRule()
```

#### TearDownInteractable()

Tears down the Interactable from the highlight process.

##### Declaration

```
public virtual void TearDownInteractable()
```

#### UnregisterInteractableEvents(InteractableFacade)

Unregisters the appropriate events on the given InteractableFacade.

##### Declaration

```
protected virtual void UnregisterInteractableEvents(InteractableFacade interactable)
```

##### Parameters

| Type | Name | Description |
| --- | --- | --- |
| InteractableFacade | interactable | The source of the interaction events. |

[Tilia.Visuals.InteractableHighlighter]: README.md
[InteractableHighlighterFacade]: InteractableHighlighterFacade.md
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[cachedMaterials]: #cachedMaterials
[Properties]: #Properties
[Facade]: #Facade
[HighlighterProxyEmitter]: #HighlighterProxyEmitter
[UnhighlighterProxyEmitter]: #UnhighlighterProxyEmitter
[Methods]: #Methods
[ApplyMaterialToAllMeshes(InteractableFacade, Material)]: #ApplyMaterialToAllMeshesInteractableFacade-Material
[AttemptHighlight(InteractorFacade)]: #AttemptHighlightInteractorFacade
[AttemptUnhighlight(InteractorFacade)]: #AttemptUnhighlightInteractorFacade
[CacheInteractableMaterials(InteractableFacade)]: #CacheInteractableMaterialsInteractableFacade
[HandleFirstGrabbed(InteractorFacade)]: #HandleFirstGrabbedInteractorFacade
[HandleFirstTouched(InteractorFacade)]: #HandleFirstTouchedInteractorFacade
[HandleLastUntouched(InteractorFacade)]: #HandleLastUntouchedInteractorFacade
[LastUngrabbed(InteractorFacade)]: #LastUngrabbedInteractorFacade
[OnDisable()]: #OnDisable
[OnEnable()]: #OnEnable
[RegisterInteractableEvents(InteractableFacade)]: #RegisterInteractableEventsInteractableFacade
[ResetInteractableMaterialsFromCache()]: #ResetInteractableMaterialsFromCache
[SetupInteractable()]: #SetupInteractable
[SetUpRule()]: #SetUpRule
[TearDownInteractable()]: #TearDownInteractable
[UnregisterInteractableEvents(InteractableFacade)]: #UnregisterInteractableEventsInteractableFacade
