using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComboNode = System.Collections.Generic.Dictionary<uint, uint>;

public class ComboDetector : MonoBehaviour
{
    enum BUTTONS
    {
        UP = 0x01,
        DOWN = 0x02,
        LEFT = 0x04,
        RIGHT = 0x08,
        Z = 0x10,
        X = 0x20,
        COMBO_END = 0xFFFFFFF,
    };
    public TextMesh tm;
    uint buttons = 0;
    uint preButtons = 0;
    uint comboIndex = 0;
    uint[] combo;
    string[] messages;
    List<ComboNode> nodes = new List<ComboNode>();
    List<uint[]> combos = new List<uint[]>();
    // Start is called before the first frame update
    void Start()
    {
        combo = new uint[] {(uint)BUTTONS.RIGHT,0, (uint)BUTTONS.RIGHT, 0, (uint)BUTTONS.RIGHT, 0, (uint)BUTTONS.COMBO_END};
        tm.text = "Hit that combo";
        combos.Add(new uint[] {(uint)BUTTONS.DOWN,0,
                               (uint)BUTTONS.RIGHT,0,
                               (uint)BUTTONS.Z,0,(uint)BUTTONS.COMBO_END});
        combos.Add(new uint[] {(uint)BUTTONS.RIGHT,0,
                               (uint)BUTTONS.LEFT,0,
                               (uint)BUTTONS.RIGHT,0,
                               (uint)BUTTONS.Z,0,(uint)BUTTONS.COMBO_END+1});
        combos.Add(new uint[] {(uint)BUTTONS.DOWN,0,
                               (uint)BUTTONS.LEFT,0,
                               (uint)BUTTONS.X,0,(uint)BUTTONS.COMBO_END+2});
        combos.Add(new uint[] {(uint)BUTTONS.DOWN,0,
                               (uint)BUTTONS.RIGHT,0,
                               (uint)BUTTONS.X,0,(uint)BUTTONS.COMBO_END+3});
        combos.Add(new uint[] {(uint)BUTTONS.DOWN,0,
                               (uint)BUTTONS.RIGHT,0,
                               (uint)BUTTONS.DOWN,0,
                               (uint)BUTTONS.RIGHT,0,
                               (uint)BUTTONS.X,0,(uint)BUTTONS.COMBO_END+4});
        combos.Add(new uint[] {(uint)BUTTONS.UP,0,
                               (uint)BUTTONS.UP,0,
                               (uint)BUTTONS.DOWN,0,
                               (uint)BUTTONS.DOWN,0,
                               (uint)BUTTONS.LEFT,0,
                               (uint)BUTTONS.RIGHT,0,
                               (uint)BUTTONS.LEFT,0,
                               (uint)BUTTONS.RIGHT,0,
                               (uint)BUTTONS.Z,0,
                               (uint)BUTTONS.X,0,(uint)BUTTONS.COMBO_END+5});
        messages = new string[] {"Hadoken","Shoryuken", "Tatsumaki Zankukyayu", "Spiral Arrow", "Spin Drive Smasher","Konami Cheat Code", };
        BuildNodes();
    }
    void UpdateButtons()
    {
        preButtons = buttons;
        buttons = 0;
        buttons |= Input.GetKey(KeyCode.UpArrow) == true ? (uint)(BUTTONS.UP) : 0;
        buttons |= Input.GetKey(KeyCode.DownArrow) == true ? (uint)(BUTTONS.DOWN) : 0;
        buttons |= Input.GetKey(KeyCode.LeftArrow) == true ? (uint)(BUTTONS.LEFT) : 0;
        buttons |= Input.GetKey(KeyCode.RightArrow) == true ? (uint)(BUTTONS.RIGHT) : 0;
        buttons |= Input.GetKey(KeyCode.Z) == true ? (uint)(BUTTONS.Z) : 0;
        buttons |= Input.GetKey(KeyCode.X) == true ? (uint)(BUTTONS.X) : 0;

        //tm.text = System.Convert.ToString(buttons, 2).PadLeft(6, '0');
    }
    // Update is called once per frame
    void Update()
    {
        UpdateButtons();
        DetectCombo();
    }
    bool DidButtonsChange()
    {
        if (preButtons != buttons)
        {
            return true;
        }
        return false;
    }
    void DetectCombo()
    {
        if (DidButtonsChange())
        {
            if (nodes[(int)comboIndex].ContainsKey(buttons))
            {
                comboIndex = nodes[(int)comboIndex][buttons];
                if (comboIndex>=(uint)BUTTONS.COMBO_END)
                {
                    Debug.Log(messages[comboIndex - (uint)BUTTONS.COMBO_END]);
                    tm.text = messages[comboIndex - (uint)BUTTONS.COMBO_END];
                    Invoke("ClearComoboMessage", 1);
                    comboIndex = 0;
                    ResetButtons();
                }
            }
            else
            {
                Debug.Log("????");
                Invoke("ClearComoboMessage", 1);
                comboIndex = 0;
                ResetButtons();
            }
            

        }

    }
    void ClearComboMessage()
    {
        tm.text = "Hit that combo";
    }
    void BuildNodes()
    {
        uint nodeCounter = 0;
        nodes.Add(new ComboNode());
        for (int  row = 0;  row < combos.Count;  row++)
        {
            nodeCounter = 0;
            uint[] currentCombo = combos[row];
            for (int i = 0; i < currentCombo.Length-1; i++)
            {
                if (!nodes[(int)nodeCounter].ContainsKey(currentCombo[i]))
                {
                    if (i<currentCombo.Length-2)
                    {
                        nodes[(int)nodeCounter].Add(currentCombo[i],(uint)nodes.Count);
                        nodeCounter = (uint)nodes.Count;
                        nodes.Add(new ComboNode());
                    }
                    else
                    {
                        nodes[(int)nodeCounter].Add(currentCombo[i], currentCombo[i +1]);
                    }
                }
                else
                {
                    nodeCounter = nodes[(int)nodeCounter][currentCombo[i]];
                }
            }
        }
    }
    void ResetButtons()
    {
        preButtons = 0;
        buttons = 0;
    }
}
