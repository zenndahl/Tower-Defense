using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    private  Node target;
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    public void SetTarget(Node _target){
        target = _target;

        transform.position = target.GetBuildPosition();

        if(!target.isUpgraded){
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
            
        else{ 
            upgradeCost.text = "Upgraded!";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        

        ui.SetActive(true);
    }

    public void Hide(){
        ui.SetActive(false);
    }

    public void Upgrade(){
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
        //not using the function Hide because the node would still be selected
    }

    public void Sell(){
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}