using UnityEngine;
using UnityEngine.Events;

public class TowerNetworkManager : MonoBehaviour
{
    TrackedLinkedList<GameObject> towers = new TrackedLinkedList<GameObject>();

    [System.Serializable]
    public class TowerChangedEvent : UnityEvent<string> { }

    /// <summary>
    /// Fires whenever the selected tower is changed. The string sent is either
    /// "next" or "previous", depending on the direction moved.
    /// </summary>
    public TowerChangedEvent OnTowerChange;

    /// <summary>
    /// Retrieves the currently selected tower.
    /// </summary>
    public GameObject CurrentTower
    {
        get => towers.CurrentValue;
    }

    public void Start()
    {
        foreach (Transform child in transform)
        {
            towers.Add(child.gameObject);
        }
        // If we have towers already, set the first to be active
        towers.CurrentValue?.SetActive(true);
#if UNITY_EDITOR
        Debug.Log($"Current tower is {towers.CurrentValue}");
#endif
    }

    public void GoToNext()
    {
       // towers.CurrentValue.SetActive(false);
        towers.GoToNext();
       // towers.CurrentValue.SetActive(true);
        OnTowerChange.Invoke("next");
    }

    public void GoToPrevious()
    {
        //towers.CurrentValue.SetActive(false);
        towers.GoToPrevious();
       // towers.CurrentValue.SetActive(true);
        OnTowerChange.Invoke("previous");
    }
    
    /// <summary>
    /// Adds a tower to this network manager. If the added tower's parent is 
    /// not this network, it will set it to this network.
    /// </summary>
    /// <param name="tower">The tower to add to this network.</param>
    public void CreateTower(GameObject tower)
    {
        if (tower.transform.parent != transform)
            tower.transform.parent = transform;
        towers.Add(tower);
    }
}
