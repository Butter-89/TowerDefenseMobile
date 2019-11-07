using UnityEngine;

public class TowerNetworkManager : MonoBehaviour
{
    TrackedLinkedList<GameObject> towers = new TrackedLinkedList<GameObject>();

    private void Start()
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

    void GoToNext()
    {
        towers.CurrentValue.SetActive(false);
        towers.GoToNext();
        towers.CurrentValue.SetActive(true);
    }

    void GoToPrevious()
    {
        towers.CurrentValue.SetActive(false);
        towers.GoToPrevious();
        towers.CurrentValue.SetActive(true);
    }
    
    /// <summary>
    /// Adds a tower to this network manager. If the added tower's parent is 
    /// not this network, it will set it to this network.
    /// </summary>
    /// <param name="tower">The tower to add to this network.</param>
    void CreateTower(GameObject tower)
    {
        if (tower.transform.parent != transform)
            tower.transform.parent = transform;
        towers.Add(tower);
    }
}
