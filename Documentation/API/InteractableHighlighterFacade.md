# Class InteractableHighlighterFacade

The public interface into the InteractableHighlighter Prefab.

## Contents

* [Inheritance]
* [Namespace]
* [Syntax]
* [Fields]
  * [Highlighted]
  * [Unhighlighted]
* [Properties]
  * [Configuration]
  * [HighlightMaterial]
  * [HighlightValidity]
  * [Interactable]
  * [IsEnabled]
  * [UnhighlightMaterial]
* [Methods]
  * [ClearHighlightMaterial()]
  * [ClearHighlightValidity()]
  * [ClearInteractable()]
  * [ClearUnhighlightMaterial()]
  * [OnAfterHighlightValidityChange()]
  * [OnAfterInteractableChange()]
  * [OnBeforeInteractableChange()]

## Details

##### Inheritance

* System.Object
* InteractableHighlighterFacade

##### Namespace

* [Tilia.Visuals.InteractableHighlighter]

##### Syntax

```
public class InteractableHighlighterFacade : MonoBehaviour
```

### Fields

#### Highlighted

Emitted when the Interactable is highlighted.

##### Declaration

```
public InteractableHighlighterFacade.UnityEvent Highlighted
```

#### Unhighlighted

Emitted when the Interactable is unhighlighted.

##### Declaration

```
public InteractableHighlighterFacade.UnityEvent Unhighlighted
```

### Properties

#### Configuration

The linked [InteractableHighlighterConfigurator].

##### Declaration

```
public InteractableHighlighterConfigurator Configuration { get; protected set; }
```

#### HighlightMaterial

An optional Material to apply to all [Interactable] meshes when Highlight occurs.

##### Declaration

```
public Material HighlightMaterial { get; set; }
```

#### HighlightValidity

An optional rule to determine if the Interactor initiating the Interactable events is allowed to initiate the highlight.

##### Declaration

```
public RuleContainer HighlightValidity { get; set; }
```

#### Interactable

The InteractableFacade that is linked to the highlighter.

##### Declaration

```
public InteractableFacade Interactable { get; set; }
```

#### IsEnabled

Whether the highlighter is enabled and will process highlighting actions.

##### Declaration

```
public bool IsEnabled { get; set; }
```

#### UnhighlightMaterial

An optional Material to apply to all [Interactable] meshes when Unhighlight occurs.

##### Declaration

```
public Material UnhighlightMaterial { get; set; }
```

### Methods

#### ClearHighlightMaterial()

Clears [HighlightMaterial].

##### Declaration

```
public virtual void ClearHighlightMaterial()
```

#### ClearHighlightValidity()

Clears [HighlightValidity].

##### Declaration

```
public virtual void ClearHighlightValidity()
```

#### ClearInteractable()

Clears [Interactable].

##### Declaration

```
public virtual void ClearInteractable()
```

#### ClearUnhighlightMaterial()

Clears [UnhighlightMaterial].

##### Declaration

```
public virtual void ClearUnhighlightMaterial()
```

#### OnAfterHighlightValidityChange()

Called after [HighlightValidity] has been changed.

##### Declaration

```
protected virtual void OnAfterHighlightValidityChange()
```

#### OnAfterInteractableChange()

Called after [Interactable] has been changed.

##### Declaration

```
protected virtual void OnAfterInteractableChange()
```

#### OnBeforeInteractableChange()

Called before [Interactable] has been changed.

##### Declaration

```
protected virtual void OnBeforeInteractableChange()
```

[Tilia.Visuals.InteractableHighlighter]: README.md
[InteractableHighlighterFacade.UnityEvent]: InteractableHighlighterFacade.UnityEvent.md
[InteractableHighlighterConfigurator]: InteractableHighlighterConfigurator.md
[Interactable]: InteractableHighlighterFacade.md#Interactable
[Interactable]: InteractableHighlighterFacade.md#Interactable
[HighlightMaterial]: InteractableHighlighterFacade.md#HighlightMaterial
[HighlightValidity]: InteractableHighlighterFacade.md#HighlightValidity
[Interactable]: InteractableHighlighterFacade.md#Interactable
[UnhighlightMaterial]: InteractableHighlighterFacade.md#UnhighlightMaterial
[HighlightValidity]: InteractableHighlighterFacade.md#HighlightValidity
[Interactable]: InteractableHighlighterFacade.md#Interactable
[Interactable]: InteractableHighlighterFacade.md#Interactable
[Inheritance]: #Inheritance
[Namespace]: #Namespace
[Syntax]: #Syntax
[Fields]: #Fields
[Highlighted]: #Highlighted
[Unhighlighted]: #Unhighlighted
[Properties]: #Properties
[Configuration]: #Configuration
[HighlightMaterial]: #HighlightMaterial
[HighlightValidity]: #HighlightValidity
[Interactable]: #Interactable
[IsEnabled]: #IsEnabled
[UnhighlightMaterial]: #UnhighlightMaterial
[Methods]: #Methods
[ClearHighlightMaterial()]: #ClearHighlightMaterial
[ClearHighlightValidity()]: #ClearHighlightValidity
[ClearInteractable()]: #ClearInteractable
[ClearUnhighlightMaterial()]: #ClearUnhighlightMaterial
[OnAfterHighlightValidityChange()]: #OnAfterHighlightValidityChange
[OnAfterInteractableChange()]: #OnAfterInteractableChange
[OnBeforeInteractableChange()]: #OnBeforeInteractableChange
