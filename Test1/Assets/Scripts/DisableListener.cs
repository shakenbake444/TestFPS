
using UnityEngine;
using UnityEngine.Networking;

public class DisableListener : NetworkBehaviour
{
    
    void Start ()
    {
        if(!isLocalPlayer)
        {
            GetComponent<AudioListener>().enabled = false;
        }
    }
}
