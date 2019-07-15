using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ButtonBehaviors : ScriptableObject
{
    public void TurnOffPanel(GameObject PanelToDeactivate)
    {
        PanelToDeactivate.SetActive(false);
    }
}
