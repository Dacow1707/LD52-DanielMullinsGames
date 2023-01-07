using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliciesArea : ManagedBehaviour
{
    [SerializeField]
    private GameObject policyPanelPrefab = default;

    [SerializeField]
    private float panelsSpacing = default;

    [SerializeField]
    private Transform panelsAnchor = default;

    public List<PolicyPanel> Panels => panels;
    private List<PolicyPanel> panels = new List<PolicyPanel>();

    public void TickCooldowns(float timeStep)
    {
        panels.ForEach(x => x.TickCooldown(timeStep));
    }

    public PolicyPanel AddPolicyPanel(PolicyData data)
    {
        var panelObj = Instantiate(policyPanelPrefab);
        panelObj.transform.position = panelsAnchor.position + Vector3.right * panelsSpacing * panels.Count;

        var panel = panelObj.GetComponent<PolicyPanel>();
        panel.Initialize(data);

        panels.Add(panel);
        return panel;
    }
}
