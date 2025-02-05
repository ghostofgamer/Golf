using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal _portal;
    
    public Portal PortalObject => _portal;
}
