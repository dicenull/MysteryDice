using System.Collections;
using System.Collections.Generic;
using Unity.XR.PXR;
using UnityEngine;

public class Pico4Settings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PXR_Boundary.EnableSeeThroughManual(true);

        Debug.Log(PXR_HandTracking.GetSettingState());
    }

	private void OnApplicationPause(bool pause)
	{
		if(!pause)
        {
            PXR_Boundary.EnableSeeThroughManual(true);
        }
	}
}
