using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    //singleton pattern
    public static BuildManager instance;

    //there will be only one instance of the build manager
    private void Awake() {
        instance = this;
    }

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public TurretUI turretUI;

    public GameObject buildEffect;

    public void SelectNode(Node node){

        if(selectedNode == node){
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        turretUI.SetTarget(selectedNode);
    }

    public void SelectTurretToBuild(TurretBlueprint turret){
        turretToBuild = turret;
        selectedNode = null;
        turretUI.Hide();
    }

    public void DeselectNode(){
        selectedNode = null;
        turretUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild(){
        return turretToBuild;
    }

    //check if there is a turret selected to build
    public bool CanBuild{get{return turretToBuild != null;}}

    //check if there is enough money to purschase selected turret
    public bool HasMoney{get{return PlayerStats.Money >= turretToBuild.cost;}}
}
