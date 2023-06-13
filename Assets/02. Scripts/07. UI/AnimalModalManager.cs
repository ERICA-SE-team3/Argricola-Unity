using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimalModalManager : MonoBehaviour
{
    Block block;
    List<Block> nearBlocks = new List<Block>();

    GameObject setterObj, leftObj;

    GameObject sheepSetter, sheepBlocker;
    Button sheepUp, sheepDown;
    TMPro.TMP_Text sheepCount;
    int sheep = 0;

    GameObject pigSetter, pigBlocker;
    Button pigUp, pigDown;
    TMPro.TMP_Text pigCount;
    int pig = 0;

    GameObject cowSetter, cowBlocker;
    Button cowUp, cowDown;
    TMPro.TMP_Text cowCount;
    int cow = 0;

    TMPro.TMP_Text sheepLeft, pigLeft, cowLeft;
    public static int leftSheep = 0, leftPig = 0, leftCow = 0;

    public int maxAnimal = 0;
    AnimalType animalType = AnimalType.NONE;

    static int[] dx = {-1, 1, 0, 0};
    static int[] dy = {0, 0, -1, 1};

    static int[] dfence = {1,0,3,2};


    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    private void OnEnable() {
        Init();
    }

    public void Init()
    {
        setterObj = this.transform.Find("Setter").gameObject;
        leftObj = this.transform.Find("Left").gameObject;

        sheepSetter = setterObj.transform.Find("Sheep").gameObject;
        sheepBlocker = sheepSetter.transform.Find("Blocker").gameObject;
        sheepUp = sheepSetter.transform.Find("Up").GetComponent<Button>();
        sheepDown = sheepSetter.transform.Find("Down").GetComponent<Button>();
        sheepCount = sheepSetter.transform.Find("Image").Find("Text").GetComponent<TMPro.TMP_Text>();

        pigSetter = setterObj.transform.Find("Pig").gameObject;
        pigBlocker = pigSetter.transform.Find("Blocker").gameObject;
        pigUp = pigSetter.transform.Find("Up").GetComponent<Button>();
        pigDown = pigSetter.transform.Find("Down").GetComponent<Button>();
        pigCount = pigSetter.transform.Find("Image").Find("Text").GetComponent<TMPro.TMP_Text>();

        cowSetter = setterObj.transform.Find("Cow").gameObject;
        cowBlocker = cowSetter.transform.Find("Blocker").gameObject;
        cowUp = cowSetter.transform.Find("Up").GetComponent<Button>();
        cowDown = cowSetter.transform.Find("Down").GetComponent<Button>();
        cowCount = cowSetter.transform.Find("Image").Find("Text").GetComponent<TMPro.TMP_Text>();

        sheepLeft = leftObj.transform.Find("Sheep").Find("Text").GetComponent<TMPro.TMP_Text>();
        pigLeft = leftObj.transform.Find("Pig").Find("Text").GetComponent<TMPro.TMP_Text>();
        cowLeft = leftObj.transform.Find("Cow").Find("Text").GetComponent<TMPro.TMP_Text>();
    }

    public void SetModal(Block block)
    {
        sheep = block.sheep;
        pig = block.pig;
        cow = block.cow;

        this.block = block;
        nearBlocks = GetNearFences(block);

        this.animalType = CalculateType();
        this.maxAnimal = CalculateMaxAnimal();
        SetBlocker();
    }

    AnimalType CalculateType()
    {
        int nbSheep = 0, nbPig = 0, nbCow = 0;
        foreach(Block nb in nearBlocks)
        {
            nbSheep += nb.sheep;
            nbPig += nb.pig;
            nbCow += nb.cow;
        }

        if(nbSheep > 0)
        {
            if(nbCow > 0 || nbPig > 0) { throw new System.Exception("양, 돼지, 소가 같이 있을 수 없습니다."); }
            else return AnimalType.SHEEP;
        }

        if(nbPig > 0)
        {
            if(nbCow > 0) { throw new System.Exception("돼지, 소가 같이 있을 수 없습니다."); }
            else return AnimalType.PIG;
        }

        if(nbCow > 0) return AnimalType.COW;

        return AnimalType.NONE;
    }

    public int CalculateMaxAnimal()
    {
        int max = 0;
        if(block.type == BlockType.FARM) return 0;

        if(block.type == BlockType.HOUSE)
        {
            max = 1;
            return max;
        }

        if(block.type == BlockType.FENCE)
        {
            foreach(Block b in nearBlocks)
            {
                int totalShed = 0;
                int totalAnimal = 0;
                foreach(Block nb in nearBlocks)
                {
                    if(nb.hasShed) totalShed++;
                    totalAnimal += nb.sheep + nb.pig + nb.cow;
                }
                max = nearBlocks.Count * 2 * ((int)Mathf.Pow(2, totalShed));
                max -= totalAnimal;
                max += block.sheep + block.pig + block.cow;
            }
        }

        if(block.type == BlockType.EMPTY)
        {
            if(block.hasShed) max = 1;
            else max = 0;
        }
        return max;
    }


    public static int CalculateMaxAnimal(Block block)
    {
        List<Block> nearBlocks = GetNearFences(block);

        int max = 0;
        if(block.type == BlockType.FARM) return 0;

        if(block.type == BlockType.HOUSE)
        {
            max = 1;
            return max;
        }

        if(block.type == BlockType.FENCE)
        {
            foreach(Block b in nearBlocks)
            {
                int totalShed = 0;
                int totalAnimal = 0;
                foreach(Block nb in nearBlocks)
                {
                    if(nb.hasShed) totalShed++;
                    totalAnimal += nb.sheep + nb.pig + nb.cow;
                }
                max = nearBlocks.Count * 2 * ((int)Mathf.Pow(2, totalShed));
                max -= totalAnimal;
                max += block.sheep + block.pig + block.cow;
            }
        }

        if(block.type == BlockType.EMPTY)
        {
            if(block.hasShed) max = 1;
            else max = 0;
        }
        return max;
    }

    static List<Block> GetNearFences(Block block)
    {
        List<Block> NearBlocks = new List<Block>();
        Queue<Block> q = new Queue<Block>();
        q.Enqueue(block);
        NearBlocks.Add(block);
        while(q.Count != 0)
        {
            Block current = q.Dequeue();
            NearBlocks.Add(current);
            for(int i = 0; i < 4; i++)
            {
                int nx = current.row + dx[i];
                int ny = current.col + dy[i];

                if(nx < 0 || nx >= block.board.row || ny < 0 || ny >= block.board.col) continue;

                if(current.fence[i]) continue;

                if(current.board.blocks[nx, ny].type == BlockType.FENCE)
                {
                    if(current.board.blocks[nx, ny].fence[dfence[i]]) continue;
                    else
                    {
                        if(!NearBlocks.Contains(current.board.blocks[nx, ny]))
                            q.Enqueue(current.board.blocks[nx, ny]);
                    }
                }
            }
        }
        return NearBlocks;
    }

    public void SetBlocker()
    {
        RenewLeftAnimal(); 

        sheepBlocker.SetActive(false);
        pigBlocker.SetActive(false);
        cowBlocker.SetActive(false);

        if ((animalType != AnimalType.NONE && animalType != AnimalType.SHEEP))
            sheepBlocker.SetActive(true);

        if ((animalType != AnimalType.NONE && animalType != AnimalType.PIG)) 
            pigBlocker.SetActive(true);

        if ((animalType != AnimalType.NONE && animalType != AnimalType.COW))
            cowBlocker.SetActive(true);
    }

    public void SetTemporaryBlocker()
    {
        // 본인 블럭의 개수가 0이 되었다고 치고 다시 AnimalType을 계산한다.
        block.SetAnimal(sheep, pig, cow);
        this.animalType = CalculateType();
        
        // SetBlocker 호출한다.
        SetBlocker();
    }

    public void SheepUp()
    {
        if (leftSheep == 0) return;
        if (sheep == maxAnimal) return;
        if (this.animalType != AnimalType.NONE && this.animalType != AnimalType.SHEEP) return;
        if (pig + cow > 0) return;
        leftSheep--;
        sheep++;
        SetBlocker();
    }

    public void SheepDown()
    {
        if (sheep == 0) return;
        leftSheep++;
        if(sheep > 0) { sheep--; }
        if(sheep == 0) { sheepCount.text = "0"; this.animalType = CalculateType(); SetTemporaryBlocker();}
        SetBlocker();
    }

    public void PigUp()
    {
        if (leftPig == 0) return;
        if (pig == maxAnimal) return;
        if (animalType != AnimalType.NONE && animalType != AnimalType.PIG) return;
        if (sheep + cow > 0) return;
        leftPig--;
        pig++;
        pigCount.text = pig.ToString();
        SetBlocker();
    }

    public void PigDown()
    {
        if (pig == 0) return;
        leftPig++;
        if (pig > 0) { pig--; }
        if (pig == 0) { pigCount.text = "0"; animalType = CalculateType(); SetTemporaryBlocker(); }

        SetBlocker();
    }

    public void CowUp()
    {
        if (leftCow == 0) return;
        if (cow == maxAnimal) return;
        if (animalType != AnimalType.NONE && animalType != AnimalType.COW) return;
        if (sheep + pig > 0 ) return;
        leftCow--;
        cow++; 
        SetBlocker();
    }

    public void CowDown()
    {
        if (cow == 0) return;
        leftCow++;
        if (cow > 0) { cow--; }
        if (cow == 0) { cowCount.text = "0"; animalType = CalculateType(); SetTemporaryBlocker(); }
        SetBlocker();
    }

    void RenewLeftAnimal()
    {
        sheepLeft.text = leftSheep.ToString();
        pigLeft.text = leftPig.ToString();
        cowLeft.text = leftCow.ToString();
    }

    public void Confirm()
    {
        block.board.leftSheep -= sheep;
        block.board.leftPig -= pig;
        block.board.leftCow -= cow;

        block.SetAnimal(sheep, pig, cow);
        this.gameObject.SetActive(false);
    }

    private void Update() {
        sheepCount.text = sheep.ToString();
        pigCount.text = pig.ToString();
        cowCount.text = cow.ToString();
    }
}
