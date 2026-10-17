# HoloAirMenu recovery, cloud workspace, and scaling audit

## Scope and verification
Static review of the main-branch repository tree, package manifest, build settings, Addressables remote group/schema, and full source of HomePage, BurgersPg1, ItemRedo, NextPrev, UI Panel, TableView, and UIMovement. No Unity Editor, runtime profiling, video decoding, or container execution was available. Findings below distinguish observed code from runtime risks.

## Start the cloud workspace
Visit https://github.com/codespaces/new?repo=QuestionsBrown%2FHoloAirMenuPleaseQ&ref=audit%2Fcloud-workspace
Confirm the repository and audit/cloud-workspace branch, then create a Codespace. Account allowances and billing apply. The devcontainer provides an Ubuntu source-review shell and C# editor extension, not Unity, an AR simulator, or a working Unity compilation environment. The extension is not a replacement for the Unity Editor or its assemblies. No project scripts run automatically. JSON was parsed before committing; the container has not been launched or tested.

The Codespace clones this existing repository; no fresh product repository is needed. Use a new working branch for experiments. Stop the Codespace when finished. Run Unity on the Mac, locally or through remote desktop. Keep the original main branch as recovery evidence.

Creating a Codespace does not enable video attachments in ChatGPT or provide this conversation access to that Codespace. A ChatGPT/Codex cloud environment is a separate product environment that must be selected through its own interface. Screenshots of the upload error will clarify which environment the message means. Screenshots of the demo can be reviewed here; repository binary-video URLs cannot be decoded through the current GitHub text connector. Avoid committing large demo videos to this source repository.

## Findings, in priority order

### 1. Recovery blockers: import locations and missing build scenes
Most application code is under root Scripts/, not Assets/Scripts/. Root Plugins/, UI Images/, and other content folders likewise are outside Unity's import root. ArtScene.unity is at root, while enabled build settings expect Assets/AR Scenes/ArtScene.unity. The enabled Assets/UI/UI Scenes/Splahscreen.unity is absent. The AR Remote local package dependency expects Assets/Plugins/... but the archive is under root Plugins/.
Restore deliberately with paired .meta files and check GUID references; do not bulk move every root folder into Assets. Generated iOS outputs must remain outside imported content. Recover with the recorded Unity 2020.3.29f1 in an isolated copy before deciding migration steps.

### 2. Invalid MonoBehaviour construction
ItemRedo.cs declares ItemRedo : MonoBehaviour but defines a parameterized constructor; HomePage.cs:219 and BurgersPg1.cs:201 construct it with new ItemRedo(...). This is not a supported way to create Unity components. UI Panel.cs and its construction sites should be checked for the same pattern before restoration.
Use a plain C# controller when Unity lifecycle/component identity is unnecessary, or attach a MonoBehaviour and initialize it explicitly. Do not mechanically convert it without checking scene references.

### 3. Content-specific controller duplication prevents catalog growth
HomePage.cs is 1,236 lines including comments; BurgersPg1.cs is 752. Category scripts repeat item fields, touch routing, selection, reset, and navigation. BurgersPg1.cs:381 accepts five explicit item controllers, and :397-400 resets the other four individually. Touch handling dispatches through food-specific tag strings (:243, :335 onward).
Replace with stable item IDs, catalog records, generic selectable views, and one selection controller. Reset the previously selected item rather than maintaining a parameter for every other item. Adding item 1,000 must be a data operation.

### 4. Fragile interaction state
ItemRedo.cs:191 compares exact world-space z coordinates to determine viewing state. :199 uses z inequality to infer that the item is away from its origin. A moving camera, rotated menu, and tween timing make position an unreliable state indicator.
Use explicit Idle, MovingToView, Inspecting, and Returning states. Use tween completion for transitions and cancellation that restores interaction availability. Separate menu presentation mode (AR / blackout) from item-selection state. Test interrupted animations, rapid taps, and mode switches.

### 5. Navigation can diverge from its displayed state
NextPrev.cs:50 calls selectPage(1) without setting currentPage, initially zero. selectPage mixes its argument with currentPage. :97-102 calls slidePageHolder once per child, potentially starting repeated transitions; changePage has no explicit bounds check.
Use a single validated navigation state and issue one animation per transition. Preserve any deliberate return-to-main sentinel behavior rather than simply clamping it away.

### 6. Input handling is scattered
HomePage processes touch in Update; BurgersPg1.cs:233 processes it in FixedUpdate. Both raycast and dispatch independently. Input sampled on physics ticks risks inconsistent responsiveness. Whether multiple handlers are simultaneously active requires scene/runtime verification.
Route pointer input through one active interaction layer, filter UI touches, resolve the selectable component/ID, and apply an explicit background-tap rule. Preserve the intended transparent-box behavior with tested layer/raycast priority.

### 7. Remote content lifecycle is not demonstrated
The inspected Remote Assets group has no serialized entries. ItemRedo's example Addressables loading and release code is commented out. This does not prove all remote loading is absent, but the reviewed path does not establish a working download/cache/release pipeline.
Define loading, failure fallback, cancellation, ownership of handles, and release/eviction before catalog expansion. Existing Addressables package installation alone does not establish scalable asset streaming.

### 8. Large content dominates performance risk
The tree reports approximately 1.27 GB of blob sizes (not compressed clone size, runtime RAM, or full Git history). Some OBJ models are 30-77 MB; textures and HDRs also reach tens of MB. No explicit LFS rules were present in the inspected .gitattributes.
Measure converted runtime assets on devices. Optimize mesh density, texture resolution, materials, colliders, and draw calls. Choose runtime formats after choosing viewers: web GLB/glTF is not automatically a Unity runtime importer. Do not rewrite Git history as part of recovery.

### 9. Platform coupling
Menu controllers import ARKit and AR Foundation alongside UI, navigation, and item content. The manifest includes ARKit but no ARCore package.
Isolate tracking/camera integration from reusable menu behavior. Android support requires an actual platform provider, configuration, and device tests. Browser support must be proven separately; React alone does not supply tracking.

## Scale target: 1,000 catalog items, bounded active content
Store metadata for 1,000 items while loading only the current restaurant/category page and a small number of nearby models. Do not instantiate 1,000 high-detail food objects at once.
Start with a single application service, menu records, and object storage/CDN; no microservices are justified by a few local customers.
Suggested records: restaurantId, itemId, categoryId, name, description, priceMinor, currency, availability, imageUrl, modelVersion, modelLocation, scale/orientation/view defaults, optional posItemId. Scope all owner edits to the restaurant; draft/publish changes and validate uploads.
Use 2D cards as the browse surface and reserve 3D for featured/selected items. Reuse a bounded set of item views. Asset caching needs explicit memory/disk budgets and eviction.
POS integration should use one adapter/provider initially. Decide the authoritative source of price and availability; retain model mapping independently.

## Plugins: candidates, not deletion instructions
Keep AR Foundation + ARKit for the recovered iPhone AR path, uGUI/TMP if existing screens use them, and the rendering pipeline required by existing materials.
AR Remote is optional development tooling. ARKit face tracking is a removal candidate if no feature or scene references it. FBX exporter, device simulator, Collab Proxy, and unused IDE integrations are optional depending on workflow.
Both DOTween and LeanTween exist; reviewed interactions use LeanTween. Inventory active usages before consolidating to one. Do not delete either blindly. Post-processing and URP compatibility needs scene/material inspection.
Do not install WebAR SDKs, runtime importers, or additional hosting services before testing the required interaction and platform support.

## Decision and next experiment
Preserve/clone this repository. Rebuild the shared content/selection core incrementally rather than duplicating every category script or discarding the proven experience.
Run a one-dish comparison: place/view menu, lower and raise phone, select/rotate/return food, background tap, blackout mode, replace model from external content. Compare recovered Unity AR against a browser prototype on actual iPhone and Android devices. Measure loading, memory, frame pacing, visual behavior, and distribution friction.
Confidence is high in the static refactoring findings; performance, full tracking behavior, and final platform choice remain unverified until device testing and demo review.
