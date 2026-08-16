# Service Locator

Minimal interface-based Service Locator for Unity projects.

## Installation

Add the package via the Unity Package Manager using the git URL:

```
https://github.com/WendellLeao/service-locator.git
```

To pin a specific version, append `#v1.0.0` (or any tag) to the URL.

## Usage

```csharp
using WendellLeao.ServiceLocator;

// Registration
Locator.Register<IInputService>(new InputService());

// Resolution
IInputService inputService = Locator.Get<IInputService>();

// Cleanup
Locator.Unregister<IInputService>();
```

Only interfaces can be registered or resolved. Registering a concrete type throws `ArgumentException`. Resolving a type that hasn't been registered throws `InvalidOperationException`.
