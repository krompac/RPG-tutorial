using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    private bool _isFocused = false;
    private bool _hasInteracted = false;
    private Transform _player;
    
    public virtual void Interact()
    {
        Debug.Log("interact " + transform.name);
    }

    void Update()
    {
        if (_isFocused && !_hasInteracted)
        {
            float distance = Vector3.Distance(_player.position, interactionTransform.position);

            if (distance <= radius)
            {
                Interact();
                _hasInteracted = true;
            }
        }    
    }

    public void OnFocused(Transform playerTransform)
    {
        _isFocused = true;
        _player = playerTransform;
        _hasInteracted = false;
    }

    public void OnDeFocused()
    {
        _isFocused = false;
        _player = null;
        _hasInteracted = false;
    }
    

    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
