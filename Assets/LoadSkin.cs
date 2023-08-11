using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadSkin : MonoBehaviour
{
    public GameObject prefab;
    private SO_Skin[] skins;
    
    void Start()
    {
        skins = Resources.LoadAll<SO_Skin>("SO_Skin");

        foreach (SO_Skin skin in skins)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.GetComponent<Image>().color = skin.color;
            obj.transform.GetChild(0).GetComponent<MeshRenderer>().material = skin.material;
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = skin.skinName;
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = skin.price.ToString();
        }
    }
}
