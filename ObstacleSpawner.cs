using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public PhysicsMaterial2D[] materials2D;
    public UnityEngine.U2D.SpriteAtlas spriteAtlas;
    public int timeToSpawn;
    public Camera mainCamera;
    public GameObject toClone;

    [Range(0, 1)]
    public float[] probabilityOfSpawn;

    Sprite[] finalSprites;
    float nextExecution;
    EdgeCollider2D myCollider;
    Vector2[] finalColliderPoints;
    
    Dictionary<string, Vector2[]> pointsToCollide;
    Dictionary<string, Vector3> positionToShow;
    Vector3 currentPosition;

    private void Start()
    {
        finalSprites = new Sprite[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites(finalSprites);
        nextExecution = timeToSpawn;

        myCollider = gameObject.GetComponent<EdgeCollider2D>();

        pointsToCollide = new Dictionary<string, Vector2[]>();
        positionToShow = new Dictionary<string, Vector3>();

        pointsToCollide.Add("cabinet2(Clone)", new Vector2[5] {
            new Vector2(-2.517573f, -0.6635575f),
            new Vector2(2.531395f,-0.5578122f),
            new Vector2(2.374064f,1.272957f),
            new Vector2(-2.188486f,1.095625f),
            new Vector2(-2.526322f,-0.6579328f)});
        positionToShow.Add("cabinet2(Clone)", new Vector3(transform.position.x, -4.1f ,1));

        pointsToCollide.Add("cabinet(Clone)", new Vector2[5] {
            new Vector2(-2.345938f, -0.2201681f),
            new Vector2(2.016492f,-0.1716342f),
            new Vector2(2.474184f,1.158534f),
            new Vector2(-2.517452f,1.252957f),
            new Vector2(-2.340384f,-0.2145433f)});
        positionToShow.Add("cabinet(Clone)", new Vector3(transform.position.x, -4.1f, 1));

        pointsToCollide.Add("cabinet_big(Clone)", new Vector2[6] {
            new Vector2(-2.215099f, -2.549115f),
            new Vector2(2.513684f,-2.422078f),
            new Vector2(2.578856f,2.205252f),
            new Vector2(-2.517452f,2.561354f),
            new Vector2(-2.261881f,-2.543491f),
            new Vector2(-2.340384f,-0.2145433f)});
        positionToShow.Add("cabinet_big(Clone)", new Vector3(transform.position.x, -2.69f, 1));

        pointsToCollide.Add("cabinet_big 1(Clone)", new Vector2[5] {
            new Vector2(-2.497558f, -1.764077f),
            new Vector2(2.513684f,-1.741711f),
            new Vector2(2.474185f,2.519267f),
            new Vector2(-2.517452f,2.011827f),
            new Vector2(-2.497392f,-1.758453f)});
        positionToShow.Add("cabinet_big 1(Clone)", new Vector3(transform.position.x, -2.8f, 1));

        pointsToCollide.Add("cabinet_tall(Clone)", new Vector2[5] {
            new Vector2(-1.084749f, -2.114578f),
            new Vector2(1.160438f,-2.302513f),
            new Vector2(1.151341f,2.484217f),
            new Vector2(-1.149299f,2.187078f),
            new Vector2(-1.074047f,-2.144004f)});
        positionToShow.Add("cabinet_tall(Clone)", new Vector3(transform.position.x, -3.24f, 1));

        pointsToCollide.Add("chair(Clone)", new Vector2[9] {
            new Vector2(-1.084749f, -1.308425f),
            new Vector2(1.230538f,-1.25101f),
            new Vector2(0.7612214f,-0.01369047f),
            new Vector2(1.243234f,1.106856f),
            new Vector2(1.136293f,1.266263f),
            new Vector2(0.757843f,0.6457057f),
            new Vector2(0.06478763f,0.4162598f),
            new Vector2(-1.114249f,0.609823f),
            new Vector2(-1.074047f,-1.267751f)});
        positionToShow.Add("chair(Clone)", new Vector3(transform.position.x, -4.15f, 1));
                     
        pointsToCollide.Add("lamp_tall(Clone)", new Vector2[9] {
            new Vector2(-0.79f, -2.27f),
            new Vector2(0.9481573f,-2.535179f),
            new Vector2(0.1439843f,1.517949f),
            new Vector2(0.6580358f,1.552961f),
            new Vector2(0.6911197f,2.580018f),
            new Vector2(-0.8535876f,2.386652f),
            new Vector2(-0.8436117f,1.468312f),
            new Vector2(-0.4044523f,1.496461f),
            new Vector2(-0.7896729f,-2.257955f)});
        positionToShow.Add("lamp_tall(Clone)", new Vector3(transform.position.x, -2.29f, 1));

        pointsToCollide.Add("plant1(Clone)", new Vector2[0] {});
        positionToShow.Add("plant1(Clone)", new Vector3(transform.position.x, -2.61f, 0.5f));

        pointsToCollide.Add("plant2(Clone)", new Vector2[0] {});
        positionToShow.Add("plant2(Clone)", new Vector3(transform.position.x, -2.61f, 0.5f));

        pointsToCollide.Add("plant3(Clone)", new Vector2[0] {});
        positionToShow.Add("plant3(Clone)", new Vector3(transform.position.x, -3.87f, 0.5f));

        pointsToCollide.Add("table(Clone)", new Vector2[5] {
            new Vector2(-1.210602f, 0.5690596f),
            new Vector2(-0.952599f,-0.6529374f),
            new Vector2(0.9264551f,-0.6665258f),
            new Vector2(1.218837f,0.571557f),
            new Vector2(-1.253861f,0.5625882f)});
        positionToShow.Add("table(Clone)", new Vector3(transform.position.x, -4.26f, 1));

        pointsToCollide.Add("chair_tall(Clone)", new Vector2[5] {
            new Vector2(-0.4823133f, 1.055371f),
            new Vector2(-0.5449641f,-1.226485f),
            new Vector2(0.5133069f,-1.210472f),
            new Vector2(0.4714562f,1.217745f),
            new Vector2(-0.4874284f,0.5625882f)});
        positionToShow.Add("chair_tall(Clone)", new Vector3(transform.position.x, -4.2f, 1));

        currentPosition = new Vector2();

        //Debug.Log("positionToShow " + positionToShow.Count);
        //Debug.Log("pointsToCollide " + pointsToCollide.Count);
                
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup < nextExecution)
            return;

        nextExecution += timeToSpawn;
        //Debug.Log("Next Execution " + nextExecution + " Time "+ Time.realtimeSinceStartup);
        //Debug.Break();
        StartCoroutine("SpawnNow");
    }

    private void SpawnNow()
    {
        Debug.Log("Enters in coroutine");

        float distance = Random.Range(25.0f, 60.0f);
        float rand = Random.value;
        //Debug.Log("toClone.name " + toClone.name);

        for (int index = 0; index < finalSprites.Length; index++)
        {
            //Debug.Log("In for " + index + " loop random value " + rand + " probability " + probabilityOfSpawn[index]);
            //Debug.Break();
            if (rand >= probabilityOfSpawn[index]) // rand = 0.21 and value = 0.2 (meaning 80% probs) it will be spawn this type of object
            {
                toClone.GetComponent<SpriteRenderer>().sprite = finalSprites[index];
                //Debug.Log("Sprite name " + toClone.GetComponent<SpriteRenderer>().sprite.name);
                pointsToCollide.TryGetValue(toClone.GetComponent<SpriteRenderer>().sprite.name, out finalColliderPoints);
                toClone.GetComponent<EdgeCollider2D>().points = finalColliderPoints;
                //Debug.Log("points " + finalColliderPoints.ToString());
                toClone.GetComponent<EdgeCollider2D>().points = finalColliderPoints;
                positionToShow.TryGetValue(toClone.GetComponent<SpriteRenderer>().sprite.name, out currentPosition);
                currentPosition.x = mainCamera.transform.localPosition.x + distance;
                Destroy(Object.Instantiate(toClone, currentPosition, transform.rotation), 600.0f);
                break;
            }
        }
        //Debug.Log("End of it");
        //Debug.Break();
    }
}
