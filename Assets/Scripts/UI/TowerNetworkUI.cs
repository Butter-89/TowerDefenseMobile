using UnityEngine;

public class TowerNetworkUI : MonoBehaviour
{
    public TowerNetworkManager tnm;

    public TowerSwap swap;

    public Camera_gyro cameraController;

    public void TNMGoToNext()
    {
        tnm.GoToNext();
    }

    public void TNMGoToPrevious()
    {
        tnm.GoToPrevious();
    }

    public void GoToTower(string direction, GameObject target)
    {
        swap.SwapTower(target.transform.localPosition);

        cameraController.isBackToMenu = false;
        Transform turret = target.transform.Find("Turret Low");
        Debug.Log(turret);
        cameraController.towerTransform = turret;
        cameraController.tagName = target.transform.parent.tag;
    }
}
