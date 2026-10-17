# White-box delivery and integration plan

## Decision for today
Keep the legacy Unity project as evidence and recovery material. Develop the white-box browser experience in whitebox/ with zero third-party runtime packages. Do not install or upgrade every old plugin. The canvas box establishes screen flow only; it does not determine the eventual XR renderer.

The native app remains an architectural boundary, not an implementation in this branch. A one-dish device experiment must choose Unity AR Foundation versus another native stack. Do not promise browser AR parity with the original iPhone experience before measuring it.

## Components
Guest web menu / future native AR app -> menu API -> published restaurant catalog.
Restaurant studio -> authenticated API -> private photo storage -> asynchronous mesh-generation worker -> review/optimization -> versioned published model storage/CDN.
POS adapter -> provider menu/prices/availability and, later, accepted orders.
Start as one backend plus a worker and object storage, not microservices.

## Minimal records
Restaurant, Membership (user/restaurant/role), MenuItem, AssetVersion, ReconstructionJob, Order, ProviderEvent.
All server reads and writes must enforce restaurant membership/scope where appropriate; public guests read only published content.
MenuItem needs stable item and optional provider IDs, integer minor-unit money plus currency, price/modifier mappings, availability, and model-version reference.
The prototype uses USD with two-decimal formatting; production money formatting must respect currency-specific minor units.
AssetVersion includes storage key, type, byte size, checksum, processing state, scale/orientation and review approval.
ReconstructionJob references private source photos and owns queued/processing/review/failed/published transitions. Uploading photos never means a model is ready.

## Photos to meshes
1. Authenticate restaurant staff or accept an operator-managed request.
2. Issue bounded signed uploads; validate image bytes, limits and ownership on the server.
3. Enqueue a durable job through a ReconstructionProvider interface. Select the actual provider only after evaluating the user's proposed repository, license, GPU needs, quality, deployment and cost.
4. Store an unpublished output. Review food fidelity, texture, size, holes and scale. One-photo generation may invent unseen geometry; multiple photos can improve evidence but need a capture guide.
5. Optimize per viewer: web GLB/glTF and native delivery requirements may differ. Do not assume Unity loads GLB at runtime without a chosen importer.
6. Publish a version pointer atomically; retain rollback and image fallback. Staff can approve replacement without rebuilding the app.
This queue allows manual model creation first and automation later without changing customer workflows.

## Ordering, POS and preparation
Phase A: QR links identify a restaurant and optionally a signed/validated table context. Guests browse and follow that restaurant's existing hosted ordering flow. This does not constitute integrated kitchen delivery.
Phase B: choose one provider with suitable API access and sandbox support. Import prices/availability and map stable provider IDs.
Phase C: server reprices items, validates modifiers/taxes/availability and creates an idempotent order. Use the payment provider's supported hosted checkout/tokenization. Verify webhook signatures and deduplicate events. Coordinate payment authorization/capture with provider order submission according to that provider's supported lifecycle.
Track payment state separately from fulfillment state. A failed POS submission after payment needs retry/reconciliation/refund handling, not a false acceptance screen.
The guest sees received/accepted/preparing only when backed by the restaurant/POS workflow. Test duplicate callbacks, unavailable items, price changes, declined payments, rejected orders and outages.
A QR code alone does not integrate a POS or send a kitchen ticket. The QR must open the correct URL; the backend handles the integration.

## Plugin policy
- Recovery baseline: recorded Unity 2020.3.29f1 in an isolated copy, then compile inventory and controlled migration to a supported editor selected for the target platforms.
- Keep required AR Foundation/ARKit, rendering and UI dependencies for reproduction; old package versions are historical pins, not compatibility promises for a new editor.
- Audit face tracking, AR Remote, FBX exporter, preview simulator, Collab Proxy and unused IDE packages as removal candidates after checking code/assets.
- Both tween libraries exist. Retain the one actually needed per recovered feature; remove the other only after a reference/build check.
- Never upgrade editor, render pipeline, AR packages and all plugins at once.
- Web prototype deliberately adds no XR SDK, model importer, hosted generation vendor or payment SDK yet.

## Scale
1,000 catalog records is reasonable; 1,000 simultaneously loaded high-detail meshes is a separate and costly target. Bound visible cards/models, lazy-load and cancel downloads, cache by model version, evict by budget and release assets. Measure low-end target devices. Do not use legacy raw model sizes as runtime download budgets.
The app architecture should stay constant from 5 to 1,000 items. Verify with synthetic metadata independently of mesh and device performance tests.

## Indicative effort, not delivery guarantees
Assume one focused developer with AI assistance, available accounts/hardware, usable source assets and daily feedback.
- White-box source scaffold: included now; environment launch/device smoke testing still required.
- Setup and one-dish feasibility: roughly 1-3 focused days, potentially longer for legacy recovery.
- Local restaurant pilot with QR menu, a few optimized models, owner edits and hosted-ordering handoff: roughly 1-3 weeks after stack choice.
- Managed photo submission and manually reviewed model publication: another 1-2 weeks; automatic generation depends on provider/repository feasibility and asset quality.
- One real POS/payment/kitchen integration: roughly 2-6 additional weeks after provider/API access; approval and sandbox availability can extend this.
- Faithful native AR, app distribution and broader self-service: a separate milestone after the device experiment.
A seven-day target should be a demonstrable menu and validated workflow, not a promise of fully automated modeling plus cross-platform native AR and reliable restaurant checkout.
