using Raylib_cs;
using System;
using System.Numerics;

/// <summary>
///     Access player input functions.
/// </summary>
/// <remarks>
///     A static wrapper to standardize raylib's gamepad API.
/// </remarks>
public static class Input
{
    // Keyboard
    public static bool IsKeyboardKeyPressed(KeyboardKey key) => Raylib.IsKeyPressed(key);
    public static bool IsKeyboardKeyReleased(KeyboardKey key) =>  Raylib.IsKeyReleased(key);
    public static bool IsKeyboardKeyUp(KeyboardKey key) =>  Raylib.IsKeyUp(key);
    public static bool IsKeyboardKeyDown(KeyboardKey key) => Raylib.IsKeyDown(key);

    // Mouse
    public static bool IsMouseButtonPressed(MouseButton button) => Raylib.IsMouseButtonPressed(button);
    public static bool IsMouseButtonReleased(MouseButton button) => Raylib.IsMouseButtonReleased(button);
    public static bool IsMouseButtonUp(MouseButton button) => Raylib.IsMouseButtonUp(button);
    public static bool IsMouseButtonDown(MouseButton button) => Raylib.IsMouseButtonDown(button);
    public static Vector2 MouseDeltaPosition => Raylib.GetMouseDelta();
    public static Vector2 MousePosition => Raylib.GetMousePosition();
    public static float MouseX => Raylib.GetMouseX();
    public static float MouseY => Raylib.GetMouseY();
    public static Vector2 MouseWheel => Raylib.GetMouseWheelMoveV();
    public static float MouseWheelX => Raylib.GetMouseWheelMoveV().X;
    public static float MouseWheelY => Raylib.GetMouseWheelMoveV().Y;


    // Controller Button
    public static bool IsControllerButtonPressed(int controllerIndex, ControllerButton controllerButton)
        => Raylib.IsGamepadButtonPressed(controllerIndex, (GamepadButton)controllerButton);
    public static bool IsControllerButtonReleased(int controllerIndex, ControllerButton controllerButton)
        => Raylib.IsGamepadButtonReleased(controllerIndex, (GamepadButton)controllerButton);
    public static bool IsControllerButtonUp(int controllerIndex, ControllerButton controllerButton)
        => Raylib.IsGamepadButtonUp(controllerIndex, (GamepadButton)controllerButton);
    public static bool IsControllerButtonDown(int controllerIndex, ControllerButton controllerButton)
        => Raylib.IsGamepadButtonDown(controllerIndex, (GamepadButton)controllerButton);


    private delegate CBool RaylibGamepadButtonFunc(int controllerIndex, GamepadButton controllerButton);
    private static bool IsAnyControllerButtonXXX(ControllerButton controllerButton, RaylibGamepadButtonFunc gamepadFunc)
    {
        int controllerCount = ConnectedControllerCount();
        for (int i = 0; i < controllerCount; i++)
        {
            GamepadButton button = (GamepadButton)controllerButton;
            bool isTriggered = gamepadFunc(i, button);
            if (isTriggered)
                return true;
        }
        return false;
    }
    public static bool IsAnyControllerButtonPressed(ControllerButton controllerButton)
        => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonPressed);
    public static bool IsAnyControllerButtonReleased(ControllerButton controllerButton)
        => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonReleased);
    public static bool IsAnyControllerButtonUp(ControllerButton controllerButton)
        => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonUp);
    public static bool IsAnyControllerButtonDown(ControllerButton controllerButton)
        => IsAnyControllerButtonXXX(controllerButton, Raylib.IsGamepadButtonDown);


    // Controller Axis
    public static float GetControllerAxis(int controllerIndex, ControllerAxis controllerAxis)
    {
        GamepadAxis axis = (GamepadAxis)controllerAxis;
        float value = Raylib.GetGamepadAxisMovement(controllerIndex, axis);
        return value;
    }
    public static float GetAnyControllerAxis(ControllerAxis controllerAxis, float deadzone = 0.05f)
    {
        GamepadAxis axis = (GamepadAxis)controllerAxis;
        float finalValue = 0f;
        int activeControllers = 0;

        int controllerCount = ConnectedControllerCount();
        for (int i = 0; i < controllerCount; i++)
        {
            float value = Raylib.GetGamepadAxisMovement(i, axis);
            bool isActive = Math.Abs(value) > deadzone;
            if (isActive)
            {
                finalValue += value;
                activeControllers++;
            }
        }

        finalValue /= controllerCount;
        return finalValue;
    }
    public static bool IsControllerAvailable(int controllerIndex)
    {
        bool isAvailable = Raylib.IsGamepadAvailable(controllerIndex);
        return isAvailable;
    }
    public static int ConnectedControllerCount()
    {
        int controllerCount = 0;
        int index = 0;
        while (Raylib.IsGamepadAvailable(index++))
            controllerCount++;
        return controllerCount;
    }
}
