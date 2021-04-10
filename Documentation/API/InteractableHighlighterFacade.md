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
  * [UnhighlightMaterial]
* [Methods]
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

#### UnhighlightMaterial

An optional Material to apply to all [Interactable] meshes when Unhighlight occurs.

##### Declaration

```
public Material UnhighlightMaterial { get; set; }
```

### Methods

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
[UnhighlightMaterial]: #UnhighlightMaterial
[Methods]: #Methods
[OnAfterHighlightValidityChange()]: #OnAfterHighlightValidityChange
[OnAfterInteractableChange()]: #OnAfterInteractableChange
[OnBeforeInteractableChange()]: #OnBeforeInteractableChange
