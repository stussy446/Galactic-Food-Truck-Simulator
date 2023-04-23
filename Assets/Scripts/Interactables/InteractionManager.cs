using UnityEngine;

public class InteractionManager : MonoBehaviour, IInteractable
{
    public ActionType actionType;
    public Vector3 interactionPosition;

    /// <summary>
    /// Invokes action to switch state based on which object was interacted with
    /// </summary>
    /// <param name="obj"></param>
    public void Interact()
    {
        switch (actionType)
        {
            case ActionType.EnteredButtonPressing:
                ActionList.OnEnteredButtonPressing?.Invoke(ActionType.EnteredButtonPressing);
                break;
            case ActionType.EnteredTranslator:
                ActionList.OnEnteredTranslator?.Invoke(ActionType.EnteredTranslator);
                break;
            case ActionType.EnteredFoodReplicator:
                ActionList.OnEnteredFoodReplicator?.Invoke(ActionType.EnteredFoodReplicator);
                break;
            case ActionType.CustomerOrdered:
                ActionList.OnCustomerOrdered?.Invoke(ActionType.CustomerOrdered);
                break;
        }
    }
}
