# Mac + iPhone development setup

## Tonight's acceptance checks
1. Edit a HAM source file in Codespaces and open the private forwarded web preview.
2. Access the Mac from iPhone over cellular, not just home Wi-Fi.
3. Run Unity on the Mac and manipulate a cube through remote desktop.
These checks establish tooling access; the legacy HAM build is not yet recovered.

## Web coding
Use prototype/whitebox-foundation in Codespaces. The devcontainer now uses the Microsoft Python 3.12 devcontainer image and starts a static preview on 8080. A new container should forward it and open the browser. For an existing Codespace use Command Palette → Codespaces: Rebuild Container. In Ports, keep visibility private and open port 8080. Terminal → Run Task → HAM: Start web preview is a command-free fallback if no server is running. If startup fails inspect /tmp/ham-preview.log. Stop the Codespace when done; commit/push changes before switching devices.
Container JSON and task JSON were parsed during preparation; image pull, startup and browser behavior have not been tested in this session.

## Remote Unity
A Codespace does not run Unity's graphical editor. Run it on the Mac and use an authenticated remote desktop service from the iPhone. Jump Desktop with its Mac Connect companion is one option; verify current pricing, macOS compatibility and vendor installation instructions before purchasing.
Install the Mac companion and iPhone client, sign in through the provider, and grant required macOS Screen Recording and Accessibility permissions only to the chosen trusted software. Confirm the Mac appears on the iPhone. Connect while on Wi-Fi first, then turn iPhone Wi-Fi off and test through cellular. No manual public VNC port forwarding is needed for this suggested workflow.
Keep the Mac connected to power and configured to prevent automatic sleep when its display is off. The display may sleep. Keep a laptop lid open unless supported closed-display operation has been verified. A restart can require local login before remote access works.

## Unity bootstrap
Install Unity Hub from unity.com/download if absent. Identify Mac model, processor (Apple silicon vs Intel), macOS version and free storage before choosing the editor.
For a clean tooling check use a supported Unity LTS available in Hub for the Mac. Create a separate basic 3D project named HAM-Unity-Sandbox outside the legacy checkout. Add a cube, save the scene, and press Play. Verify you can select/move the cube and enter/exit Play from iPhone remote access.
Do not install AR, renderer upgrades, third-party plugins, Android SDK/NDK, or iOS build support just for this tooling check. iOS modules/Xcode become necessary for native device builds, not remote scene editing.
Legacy recovery is a separate isolated copy using its recorded editor (2020.3.29f1) if compatible with the Mac, or a deliberate migration after inspecting errors. Do not assume that old editor supports the current macOS/processor or that the original project opens cleanly in new LTS.

## Git synchronization
Use GitHub Desktop on the Mac to clone QuestionsBrown/HoloAirMenuPleaseQ and select prototype/whitebox-foundation. Fetch/pull before working on Mac after cloud edits; commit/push before switching back. Do not edit the same files on both simultaneously.
The Unity sandbox is only a tooling check until a proper Unity .gitignore and visible meta/force text serialization are configured. Do not commit Library, Temp, builds, credentials or signing material. Keep the original legacy project separate from this empty sandbox.
