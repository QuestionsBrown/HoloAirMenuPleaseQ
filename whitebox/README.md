# HoloAirMenu white-box foundation

## Run
Open https://github.com/codespaces/new?repo=QuestionsBrown%2FHoloAirMenuPleaseQ&ref=prototype%2Fwhitebox-foundation and create a Codespace on this branch. GitHub billing/allowances apply. In its terminal:

```sh
python3 -m http.server 8080 --directory whitebox
```

Open the forwarded port 8080 URL in Safari. Keep the port private while testing. The same command works from the repository root on a Mac with Python 3 installed. Opening index.html as file:// does not support the menu fetch.

The included devcontainer is for source editing. It has not been launched here; Python availability must be verified in the selected environment. No Unity Editor or native simulator is installed by this change.

## Working prototype scope
- Restaurant/menu records in data/menu.json; reusable category and item details.
- Rotatable canvas wire-box geometry, button and pointer controls, blackout styling and reset.
- Local image previews, type/count/size checks and an explicitly local reconstruction-request preview.
- HTTPS ordering handoff when restaurant.orderingUrl is configured; unset by default.
- An explanatory system map.

No food meshes, AR tracking, persistent uploads, accounts, server API, reconstruction provider, checkout, POS or kitchen integration are connected. This is a structure prototype, not a finished application or a performance benchmark. Client-side file checks are usability checks, not server security validation.

## Manual smoke check
1. Serve over HTTP and open on iPhone Safari.
2. Switch categories; item titles and prices should update.
3. Rotate with buttons and drag; reset; toggle blackout.
4. Switch tabs and return; viewer should redraw.
5. Select supported photos; verify previews and the local-only request message.
6. Select more than 12 photos or an oversized file; request preview must remain disabled.
7. Confirm no purchase/paid/restaurant-accepted status appears.
8. Rename menu.json temporarily in a local copy; an understandable loading error should appear.

## Validation completed
JavaScript parses with new Function; menu JSON parses. Static ID binding check confirms all literal app.js element references exist in index.html. No browser, container, Unity, network-service integration, or device test could run in the current session.

## Product/backend boundaries
See ../docs/whitebox-delivery-plan.md. Existing Unity content and packages are untouched.
