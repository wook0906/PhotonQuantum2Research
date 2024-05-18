using System;
using Photon.Deterministic;
using Quantum;
using UnityEngine;

public class LocalInput : MonoBehaviour
{
    Quantum.Input input = new Quantum.Input();
    private void OnEnable()
    {
        QuantumCallback.Subscribe(this, (CallbackPollInput callback) => PollInput(callback));
    }

    public void PollInput(CallbackPollInput callback)
    {
        // Note: Use GetButton not GetButtonDown/Up Quantum calculates up/down itself.
        input.Jump = UnityEngine.Input.GetButton("Jump");

        var x = UnityEngine.Input.GetAxis("Horizontal");
        var y = UnityEngine.Input.GetAxis("Vertical");

        // Input that is passed into the simulation needs to be deterministic that's why it's converted to FPVector2.
        input.Direction = new Vector2(x, y).ToFPVector2();

        callback.SetInput(input, DeterministicInputFlags.Repeatable);
    }
}
