using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{

    //Detection Point
    public Transform detectionPoint;

    //Detection Radius
    private const float detectionRadius= 0.2f;

    //Detection Layer
    public LayerMask detectionLayer;

    public Animator playerAnim;

    public Animator alertAnim;

    GameObject plotAlert;
    public SpriteRenderer alertRender;

    public BarInventory inventory;

    public Sprite defaultDug;

    public GameObject[] critter;

    public List<GameObject> openMenus;

    private void Awake()
    {
        
    }


    // Update is called once per frame
    void Update()
    {


        if (ObjectOverlap())
        {
            GameObject overlappedObject;
            string tag = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer).tag;

            if(tag == "Plot")
            {
                overlappedObject = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer).gameObject;
                Plot data = overlappedObject.GetComponent<Plot>();

                //dig
                if (data.getStatus()==false)
                {
                    data.GetComponent<SpriteRenderer>().sprite = defaultDug;

                    alertRender.enabled = true;
                    alertRender.color = new Color(1, 1, 1, 1);
                    alertAnim.SetBool("canDig?", true);

                    if (InteractInput())
                    {
                        Transform obj = overlappedObject.transform.GetChild(0);
                        plotAlert = obj.gameObject;

                        if (plotAlert.GetComponent<Animator>().enabled == true)
                        {
                            plotAlert.GetComponent<Animator>().enabled = false;
                            plotAlert.SetActive(false);
                        }


                        GetComponent<Audio>().PlayAudio(0, 0);
                        

                        //set player animation states
                        alertAnim.SetBool("canDig?", false);
                        alertAnim.SetBool("canPlant?", true);

                        
                        data.setStatus();


                        plotAlert.SetActive(true);
                        plotAlert.GetComponent<Animator>().enabled = true;

                        playerAnim.SetBool("dig", true);


                        StartCoroutine(waitOne("Dig Action"));
                        StartCoroutine(waitOne("Dig"));

                        
                        overlappedObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

                    }
                }

                //add plant to the plot
                else if (data.getStatus() == true && data.GetPlant()==null)
                {
                    alertRender.color = new Color(1, 1, 1, 1);
                    alertAnim.SetBool("canPlant?", true);

                    
                    if (InteractInput())
                    {
                        int invIndex = inventory.getSelectedIndex();

                        Item toPlant = inventory.itemsList[invIndex];
                        if (toPlant.getItemType() == "Plant")
                        {
                            Plant setPlotPlant = overlappedObject.GetComponent<Plant>();
                            
                            //plant pumpkitty
                            if (toPlant.getName() == "Pumpkitty")
                            {
                                GameObject plotObj = overlappedObject;

                                Plant plant = plotObj.AddComponent<Plant>() as Plant;

                                plant.item = toPlant;
                                plant.plantAge = 0;
                                plant.plantName = "Pumpkitty";
                                plant.ageToSapling = 30;
                                plant.ageToHarvest = 60;

                                data.planted = plant;


                                //update plot UI
                                overlappedObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                Animator anim = plotObj.AddComponent<Animator>() as Animator;

                                data.animator = anim;

                                data.animator.runtimeAnimatorController = plant.item.getAnim().runtimeAnimatorController;

                                GetComponent<Audio>().PlayRandomAudio(4, 6, 1);

                                data.animator.SetBool("isSprout", true);

                                //update UI
                                alertRender.color = new Color(1, 1, 1, 0);
                                alertAnim.SetBool("canPlant?", false);

                            }

                            //plant batberry 
                            else if (toPlant.getName() == "Batberry")
                            {
                                
                                GameObject plotObj = overlappedObject;

                                Plant plant = plotObj.AddComponent<Plant>() as Plant;

                                plant.item = toPlant;
                                plant.plantAge = 0;
                                plant.plantName = "Batberry";
                                plant.ageToSapling = 5;
                                plant.ageToHarvest = 10;

                                data.planted = plant;

                                Debug.Log("Planted: " + plant.plantName);


                                //update plot UI
                                overlappedObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                Animator anim = plotObj.AddComponent<Animator>() as Animator;

                                data.animator = anim;

                                data.animator.runtimeAnimatorController = plant.item.getAnim().runtimeAnimatorController;

                                GetComponent<Audio>().PlayRandomAudio(4, 6, 1);

                                data.animator.SetBool("isSprout", true);

                                //update UI
                                alertRender.color = new Color(1, 1, 1, 0);
                                alertAnim.SetBool("canPlant?", false);

                            }

                            //plant ghoulic
                            else if (toPlant.getName() == "Ghoulic")
                            {
                                GameObject plotObj = overlappedObject;

                                Plant plant = plotObj.AddComponent<Plant>() as Plant;

                                plant.item = toPlant;
                                plant.plantAge = 0;
                                plant.plantName = "Ghoulic";
                                plant.ageToSapling = 30;
                                plant.ageToHarvest = 60;

                                data.planted = plant;


                                //update plot UI
                                overlappedObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                Animator anim = plotObj.AddComponent<Animator>() as Animator;

                                data.animator = anim;

                                data.animator.runtimeAnimatorController = plant.item.getAnim().runtimeAnimatorController;

                                GetComponent<Audio>().PlayRandomAudio(4, 6, 1);

                                data.animator.SetBool("isSprout", true);

                                //update UI
                                alertRender.color = new Color(1, 1, 1, 0);
                                alertAnim.SetBool("canPlant?", false);

                            }

                            //plant Mumshroom
                            else if (toPlant.getName() == "Mumshroom")
                            {
                                GameObject plotObj = overlappedObject;

                                Plant plant = plotObj.AddComponent<Plant>() as Plant;

                                plant.item = toPlant;
                                plant.plantAge = 0;
                                plant.plantName = "Mumshroom";
                                plant.ageToSapling = 30;
                                plant.ageToHarvest = 60;

                                data.planted = plant;


                                //update plot UI
                                overlappedObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                Animator anim = plotObj.AddComponent<Animator>() as Animator;

                                data.animator = anim;

                                data.animator.runtimeAnimatorController = plant.item.getAnim().runtimeAnimatorController;

                                GetComponent<Audio>().PlayRandomAudio(4, 6, 1);

                                data.animator.SetBool("isSprout", true);

                                //update UI
                                alertRender.color = new Color(1, 1, 1, 0);
                                alertAnim.SetBool("canPlant?", false);

                            }

                            //plant Strawboory
                            else if (toPlant.getName() == "Strawboory")
                            {
                                GameObject plotObj = overlappedObject;

                                Plant plant = plotObj.AddComponent<Plant>() as Plant;

                                plant.item = toPlant;
                                plant.plantAge = 0;
                                plant.plantName = "Strawboory";
                                plant.ageToSapling = 30;
                                plant.ageToHarvest = 60;

                                data.planted = plant;


                                //update plot UI
                                overlappedObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                Animator anim = plotObj.AddComponent<Animator>() as Animator;

                                data.animator = anim;

                                data.animator.runtimeAnimatorController = plant.item.getAnim().runtimeAnimatorController;

                                GetComponent<Audio>().PlayRandomAudio(4, 6, 1);

                                data.animator.SetBool("isSprout", true);

                                //update UI
                                alertRender.color = new Color(1, 1, 1, 0);
                                alertAnim.SetBool("canPlant?", false);

                            }

                            //plant Weretermelon
                            else if (toPlant.getName() == "Weretermelon")
                            {
                                GameObject plotObj = overlappedObject;

                                Plant plant = plotObj.AddComponent<Plant>() as Plant;

                                plant.item = toPlant;
                                plant.plantAge = 0;
                                plant.plantName = "Weretermelon";
                                plant.ageToSapling = 30;
                                plant.ageToHarvest = 60;

                                data.planted = plant;


                                //update plot UI
                                overlappedObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                                Animator anim = plotObj.AddComponent<Animator>() as Animator;

                                data.animator = anim;

                                data.animator.runtimeAnimatorController = plant.item.getAnim().runtimeAnimatorController;

                                GetComponent<Audio>().PlayRandomAudio(4, 6, 1);

                                data.animator.SetBool("isSprout", true);

                                //update UI
                                alertRender.color = new Color(1, 1, 1, 0);
                                alertAnim.SetBool("canPlant?", false);

                            }

                        }
                        inventory.useItem(invIndex);



                    }

                }

                //set harvest state available
                else if (data.GetPlant().plantAge >= data.GetPlant().ageToHarvest)
                {
                    alertRender.color = new Color(1, 1, 1, 1);
                    alertAnim.SetBool("canPlant?", false);
                    alertAnim.SetBool("canDig?", false);
                    alertAnim.SetBool("canHarvest", true);

                    //harvest
                    if (InteractInput())
                    {
                        int critterSpawnIndex;

                        critterSpawnIndex = getCritterIndex(overlappedObject);

                        Transform obj = overlappedObject.transform.GetChild(0);
                        plotAlert = obj.gameObject;
                        plotAlert.SetActive(true);
                        plotAlert.GetComponent<Animator>().enabled = true;
                        plotAlert.GetComponent<Animator>().SetBool("canHarvest", true);

                        alertRender.enabled = false;
                        alertRender.color = new Color(1, 1, 1, 0);
                        alertAnim.SetBool("canPlant?", false);
                        alertAnim.SetBool("canDig?", false);
                        alertAnim.SetBool("canHarvest", false);

                        //Functionality to spawn the plant!!!!!!!!!!!
                        SpawnCritter(overlappedObject.transform.position,critterSpawnIndex);


                        data.setStatus();
                        data.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
                        data.GetComponent<Animator>().enabled = false;

                        

                        Destroy(data.GetComponent<Animator>());
                        Destroy(data.GetComponent<Plant>());



                    }


                }


            }
            else if(tag == "Item")
            {
                
                overlappedObject = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer).gameObject;
                Item itemToAdd= overlappedObject.GetComponent<Item>();
                if (InteractInput())
                {

                    Debug.Log("-------------------Interacting with element!!!----------------------\nelement data: \n" + "Item Name:" +itemToAdd.itemName
+ "\nType:" + itemToAdd.itemType
+ "\nImage:" + itemToAdd.itemImage.ToString()
+ "\nAnim:" + itemToAdd.itemAnim.ToString()
+ "\nQTY:" + itemToAdd.qty);
                    GetComponent<Audio>().PlayAudio(7, 1);
                    inventory.addItem(overlappedObject);
                    inventory.updateItemsBar();
                    
                   
                }
               
            }
            else if(tag == "Shop")
            {
                if (InteractInput())
                {
                    inventory.itemCanvas.enabled = false;
                    this.GetComponent<playerMovement>().setMove(false);
                    overlappedObject = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer).gameObject;
                    overlappedObject.GetComponent<Shop_Controller>().openMenu();

                    openMenus.Add(overlappedObject);
                }
                else if (InteractEsc())
                {

                    closeMenus();
                }

            }


        }

        else if (!ObjectOverlap())
        {
            
            alertAnim.SetBool("canDig?", false);
            alertAnim.SetBool("canPlant?", false);
            alertRender.color = new Color(1, 1, 1, 0);

             if (InteractEsc())
            {
                closeMenus();
            }
        }



    }


    private void FixedUpdate()
    {
       
    }

    public void closeMenus()
    {
        Debug.Log("entering closing menus method...");
        if ( openMenus.Count >=1)
        {
            
            Debug.Log("looping open menus...");
            for (int i = 0; i < openMenus.Count; i++)
            {
                if(openMenus[i].name == "Shop")
                {
                    openMenus[i].GetComponent<Shop_Controller>().closeMenu();
                    Debug.Log("closing open menu at index: " + i);


                    this.inventory.itemCanvas.enabled = true;
                    this.GetComponent<playerMovement>().setMove(true);
                }
                else if(openMenus[i].name == "Backpack")
                {
                    this.GetComponent<Backpack>().closeMenu();
                    
                    this.GetComponent<playerMovement>().setMove(true);
                }

                
            }
            
        }

    }

    bool InteractEsc()
    {
        return Input.GetKeyDown(KeyCode.Escape);
    }

    //check if button clicked
    bool InteractInput()
    {
       return Input.GetKeyDown(KeyCode.E);
    }

    //check if intersecting with object
    bool ObjectOverlap()
    {
        bool isOverlapping = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        
        return isOverlapping;
    }

    IEnumerator waitOne(string action)
    {
        if(action == "Dig Action")
        {


            yield return new WaitForSeconds(1.0f);
            playerAnim.SetBool("dig", false);
        }
        else if(action == "Dig")
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<Audio>().PlayRandomAudio(1, 3, 1);
            yield return new WaitForSeconds(1.25f);
            plotAlert.GetComponent<Animator>().enabled = false;
            plotAlert.SetActive(false);
        }

        else if (action == "Harvest")
        {

            yield return new WaitForSeconds(1.0f);

            plotAlert.GetComponent<Animator>().enabled = false;
            plotAlert.SetActive(false);



        }


    }



    public void SpawnCritter(Vector3 location, int critterToSpawn)
    {
        GameObject newCritter = Instantiate(critter[critterToSpawn], location, Quaternion.identity) as GameObject;

        newCritter = randomizeAiPath(newCritter);

        

        newCritter.GetComponent<AIDestinationSetter>().target = this.transform;
    }

    public GameObject randomizeAiPath(GameObject critter)
    {
        critter.GetComponent<AIPath>().radius = Random.Range(9, 15);
        critter.GetComponent<AIPath>().slowdownDistance = Random.Range(9,15);
        critter.GetComponent<AIPath>().endReachedDistance = Random.Range(3, 8);

        return critter;

    }

    public int getCritterIndex(GameObject overlappedObject)
    {
        string name = overlappedObject.GetComponent<Plant>().plantName;

        if(name == "Batberry")
        {
            return 0;
        }
        else if(name == "Ghoulic")
        {
            return 1;
        }
        else if (name == "Mumshroom")
        {
            return 2;
        }
        else if (name == "Pumpkitty")
        {
            return 3;
        }
        else if (name == "Strawboory")
        {
            return 4;
        }
        else
        {
            return 5;
        }

    }

}
