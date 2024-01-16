using UnityEngine;
using UnityEngine.UI;

public class SpinButtonController : MonoBehaviour
{
    [SerializeField] private Button _spinButton;
    
    public void ChangeButtonInteractivity(bool interactivity)
    {
        _spinButton.interactable = interactivity;
    }
}
