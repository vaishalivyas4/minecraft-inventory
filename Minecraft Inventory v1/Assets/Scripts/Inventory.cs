using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject invObj;

    Dictionary<string, int> invDictionary;

    public static Inventory instance;

    [SerializeField]
    GameObject invItem;

    [SerializeField]
    Transform invParent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        invDictionary = new Dictionary<string, int>();
    }

    public void AddToInventory(BlockType bType)
    {
        string k = bType.ToString();
        if (!invDictionary.ContainsKey(k))
        {
            invDictionary.Add(k, 1);
        }
        else
        {
            invDictionary[k]++;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        foreach (Transform child in invParent)
        {
            Destroy(child.gameObject);
        }

        foreach (KeyValuePair<string,int> pair in invDictionary)
        {
            GameObject go = Instantiate(invItem, invParent);
            go.GetComponentsInChildren<Text>()[0].text = pair.Key;
            go.GetComponentsInChildren<Text>()[1].text = pair.Value.ToString();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            invObj.SetActive(!invObj.activeInHierarchy);
        }
    }
}
