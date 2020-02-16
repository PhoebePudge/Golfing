using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Clubs : MonoBehaviour{
    private int CURRENT = 0;
    private List<Club> inventory;
    [SerializeField] Sprite[] IconDatabase = new Sprite[13];
    [SerializeField] Sprite defaultBackground;
    private Display d;
    void Start(){
        if (CheckForException()){
            inventory.Add(new Club("Driver", 200, 240, IconDatabase[0]));
            inventory.Add(new Club("3 - Wood", 200, 240, IconDatabase[1]));
            inventory.Add(new Club("5 - Wood", 200, 240, IconDatabase[2]));
            inventory.Add(new Club("2 - Iron", 200, 240, IconDatabase[3]));
            inventory.Add(new Club("3 - Iron", 200, 240, IconDatabase[4]));
            inventory.Add(new Club("4 - Iron", 200, 240, IconDatabase[5]));
            inventory.Add(new Club("5 - Iron", 200, 240, IconDatabase[6]));
            inventory.Add(new Club("6 - Iron", 200, 240, IconDatabase[7]));
            inventory.Add(new Club("7 - Iron", 200, 240, IconDatabase[8]));
            inventory.Add(new Club("8 - Iron", 200, 240, IconDatabase[9]));
            inventory.Add(new Club("9 - Iron", 200, 240, IconDatabase[10]));
            inventory.Add(new Club("PW", 200, 240, IconDatabase[11]));
            inventory.Add(new Club("SW", 200, 240, IconDatabase[12]));
            StartIcons();
        }

    }
    private void StartIcons(){
        d = new Display();
        Vector3 pos = new Vector2(100, 100);

        d.Background = new GameObject();
        d.Icon = new GameObject();
        d.TextMesh = new GameObject();

        d.Background.AddComponent<Image>().sprite = defaultBackground;
        d.Icon.AddComponent<Image>().sprite = inventory[CURRENT].Icon;
        d.Icon.transform.localScale = new Vector3(0.6f,0.6f,0.6f);
        d.TextMesh.AddComponent<TextMeshProUGUI>().text = inventory[CURRENT].name;

        d.Background.name = "Background Image";
        d.Icon.name = "Icon Image";
        d.TextMesh.name = "Inventory Text";

        d.Background.GetComponent<RectTransform>().position = pos;
        d.Icon.GetComponent<RectTransform>().position = pos;
        d.TextMesh.GetComponent<RectTransform>().position = pos - new Vector3(0,60,0);
        d.TextMesh.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.CenterGeoAligned;
        d.TextMesh.GetComponent<TextMeshProUGUI>().fontSize = 20;
        GameObject c = GameObject.Find("Canvas");
        d.Background.transform.parent = c.transform;
        d.Icon.transform.parent = c.transform;
        d.TextMesh.transform.parent = c.transform;
    }
    void Update(){
 
        if (IncreaseInput()) ChangeSelectedClub(CURRENT - 1);
        if (DecreaseInput()) ChangeSelectedClub(CURRENT + 1);
        
    }
    private bool IncreaseInput(){
        if (Input.GetKeyDown(KeyCode.A))return true;
        return false;
    }
    private bool DecreaseInput(){
        if (Input.GetKeyDown(KeyCode.D))return true;
        return false;
    }
    public void ChangeSelectedClub(int newIndex){
        if (CheckInRange(newIndex)){
            CURRENT = newIndex;
            d.Icon.GetComponent<Image>().sprite = inventory[CURRENT].Icon;
            d.TextMesh.GetComponent<TextMeshProUGUI>().text = inventory[CURRENT].name;
        }
    }
    private bool CheckForException()
    {
        for (int i = 0; i < IconDatabase.Length; i++)
        {
            if (IconDatabase[i] == null)
            {
                Debug.LogWarning("Icon Database at index " + i + " was not found, Try Checking the Editor. Setting a temp sprite now... ");
                IconDatabase[i] = Sprite.Create(Texture2D.whiteTexture, new Rect(0,0,1,1), Vector2.right);
                return true;
            }
        }
        return true;
    }

    private bool CheckInRange(int newIndex){
        if (newIndex < 0){
            return false;
        }
        if (newIndex >= inventory.Count){
            return false;
        }
        return true;
    }
}
struct Display{
    public GameObject Icon;
    public GameObject Background;
    public GameObject TextMesh;
}
[System.Serializable]
public class Club{
    public string name;
    private int minDistance;
    private int maxDistance;
    public Sprite Icon;
    public Club(string n, int min, int max, Sprite icon){name = n; minDistance = min; maxDistance = max; Icon = icon;}
    public void CalculateDistance(int inputStrength){

    }
}
