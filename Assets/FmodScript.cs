using FMOD;
using UnityEngine;

public class FmodScript : MonoBehaviour {
    public Camera camera;
    public Transform target;

    private ATTRIBUTES_3D attributes = new ATTRIBUTES_3D();

    private void Update() {
        attributes.position = FMODUnity.RuntimeUtils.ToFMODVector(target.position);
        attributes.forward = FMODUnity.RuntimeUtils.ToFMODVector(camera.transform.forward);
        attributes.up = FMODUnity.RuntimeUtils.ToFMODVector(camera.transform.up);
        FMODUnity.RuntimeManager.StudioSystem.setListenerAttributes(0, attributes);
    }
}
