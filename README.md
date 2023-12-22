This is a Blazor App using Principles as Repository Pattern, Use Case Deliberation, Clean Architecture and sits in layers with Plugins to reconcile services and sessions, as well as Banking Services. 

Initially I thought of a separate layer of services like in layered architecture, but realised that the Plugins Layer which is in the outer layers that would normally link to physical db layers (physical devices) at the 
outter most layer of Clean Architecture.

Using LocalStorage, I used a library that allows an abstraction of browser local storage to act as Session Storage to allow login/logout effectively.

Use Cases initially defined allowed me to walk through the implementation.
