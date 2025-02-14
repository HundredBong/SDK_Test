using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassthroughManager : MonoBehaviour
{
    public OVRPassthroughLayer passthrough;
    public OVRInput.Button button;

    private void Update()
    {
        if (OVRInput.Get(button))
        {
            passthrough.hidden = !passthrough.hidden;
        }
    }
}
