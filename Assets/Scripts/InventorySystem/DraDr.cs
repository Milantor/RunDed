using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DraDr : MonoBehaviour
{
    private InventoryCell obj;
    public static DraDr _instance;

    private void Start()
    {
        _instance = this;
    }

    public void Click(InventoryCell cell)
    {
        if (!obj)
        {
            obj = cell;
            obj.GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f, 1f);
        }
        else
        {
            Inventory._instance.SwapCells(obj, cell);
            Debug.Log("Swapped! " + obj.ID + "&" + cell.ID);
            cell.GetComponent<Image>().color = new Color(0.75f, 0.75f, 0.75f, 1f);
            StartCoroutine(revertColor(cell));
            obj.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            obj = null;
        }
    }

    IEnumerator revertColor(InventoryCell _cell)
    {
        yield return new WaitForSeconds(0.1f);
        _cell.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
    }
}