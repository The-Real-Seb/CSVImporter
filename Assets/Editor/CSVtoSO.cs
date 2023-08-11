using UnityEditor;
using UnityEngine;
using System.IO;

public class CSVtoSO
{
    private static string CSVPath = "/Editor/CSV/Data.csv"; //Chemin d'acces au fichier csv

    [MenuItem("Generation/Generate Data")]
    public static void Generate()
    {
        string[] lines = File.ReadAllLines(Application.dataPath + CSVPath); //recupere tout les lines du fichier
        
        //Recupere tous les material du dossier ressources
        Material[] materials = Resources.LoadAll<Material>("Skin");

        foreach (string s in lines)
        {
            string[] splitData = s.Split(',');
            SO_Skin skin = ScriptableObject.CreateInstance<SO_Skin>();

            skin.skinName = splitData[0]; //Set du nom 
            skin.price = int.Parse(splitData[1]); //Set du prix

            //Conversion Hex to color
            Color col;
            if (ColorUtility.TryParseHtmlString(splitData[2], out col))
                skin.color = col; //Set la couleur;

            if (materials != null)
            {
                if (int.Parse(splitData[3]) < materials.Length)
                {
                    skin.material = materials[int.Parse(splitData[3])]; //Set le material
                }
                else
                {
                    skin.material = materials[0]; //Set le material par default
                }
            }
            AssetDatabase.CreateAsset(skin, $"Assets/Resources/SO_Skin/{splitData[3]}_{skin.skinName}.asset");
        }
        AssetDatabase.SaveAssets();
    }
}
