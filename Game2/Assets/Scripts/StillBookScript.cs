using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillBookScript : MonoBehaviour {

    public GameObject[] stillBooks;
    public Vector3 spawnValuesP; //13, 3, 12
    public Vector3 spawnValuesN; //4, 2, 6
    public float spawnWait;
    public int startWait;
    public bool stop;
    public float minWait;
    public float maxWait;
    public int booksSpawned = 0;
    public int maxBooks =10;

    int randBook;

    public void Construct(GameObject book)
    {
        stillBooks[0] = book;
        spawnValuesP = new Vector3(13,3,12);
        spawnValuesN = new Vector3(4, 2, 6);
        startWait = 1;
        minWait = 2;
        maxWait = 5;
        stop = false;
    }

    void Start () {
        StartCoroutine(BookSpawner());
	}


	void Update () {
        if (maxBooks <= booksSpawned)
        {
            stop = true;
        }
        else
        {
            stop = false;
        }
        //ksiazki beda sie pojawiac co losową liczbę sekund z zakresu
        spawnWait = Random.Range(minWait, maxWait);
	}

    IEnumerator BookSpawner()
    {
        //czekaj iles sekund zanim zacznie sie spawnowanie
        yield return new WaitForSeconds(startWait);

        while(!stop)
        {
            //wybierze jeden z trzech rodzajow ksiazek
            randBook = Random.Range(0, 2);
            //losowa pozycja ksiazki
            Vector3 position = new Vector3(Random.Range(-spawnValuesN.x, spawnValuesP.x), Random.Range(-spawnValuesN.y, spawnValuesP.y), Random.Range(-spawnValuesN.z, spawnValuesP.z));
            //inicjalizacja
            Instantiate(stillBooks[randBook], position + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            //ustala co ile mają się pojawiać książki
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
