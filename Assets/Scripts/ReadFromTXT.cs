using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
public class ReadFromTXT : MonoBehaviour
{

    private static ReadFromTXT _instance;
    public static ReadFromTXT Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<ReadFromTXT>();
                if(_instance == null)
                {
                    _instance = new GameObject().AddComponent<ReadFromTXT>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null) Destroy(this);
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    [SerializeField]
    private Dictionary<string, List<string>> AnimalTable = new Dictionary<string, List<string>>();
    void Start()
    {
        string filePath = Application.streamingAssetsPath + "/Text/" + "A" + ".txt";
        if(!File.Exists(filePath))
        {
            Debug.Log("no exist");
            return;
        }
        List<string> fileLines = File.ReadAllLines(filePath).ToList();
        foreach(string line in fileLines)
        {
            //whole line
            var name = line.Split(",");
            //each word in a line
            foreach (var item in name)
            {
                //first char from each list
                //checking if we have the char in the map
                string firstChar = item.Substring(0, 1);
                if(AnimalTable.ContainsKey(firstChar))
                {
                    AnimalTable[firstChar].Add(item); // adding words to a single letter
                }
                else
                {
                    //first encounter of a new alphabet letter
                    //adding it to our dictionary
                    List<string> newList = new List<string>();
                    newList.Add(item);
                    AnimalTable.Add(firstChar, newList);
                }
            }
        }




        foreach(var kvp in AnimalTable)
        {
            //Debug.Log("Key = " + kvp.Key);
            Debug.Log("Key = " + kvp.Key + " THE ARRAY HAS SIZE " + kvp.Value.Count);
            //foreach(var val in kvp.Value.ToArray())
            //{
            //    Debug.Log(" Value = " + val);
            //}
        }
    }

}
