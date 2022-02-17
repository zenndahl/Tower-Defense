using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    private void Start() {
        buildManager = BuildManager.instance;    
    }

    //call the BuildManager to assign the standard turret type
    public void SelectStandardTurret(){
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    //call the BuildManager to assign the missile turret type
    public void SelectMissileLauncher(){
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    //call the BuildManager to assign the missile turret type
    public void SelectLaserBeamer(){
        Debug.Log("Laser Beamer Selected");
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}