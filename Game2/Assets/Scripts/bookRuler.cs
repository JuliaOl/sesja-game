using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookRuler : MonoBehaviour {

    public GameObject[] flyingBooks;
    public int[] index;

	// Use this for initialization
	void Start () {

        foreach (GameObject book in flyingBooks)
        {
            book.SetActive(false);
        }

        StartCoroutine(bookActivator());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator bookActivator()
    {
        yield return new WaitForSeconds(1);

        while(true)
        {
            for (int i=0; i < index.Length; i++)
            {
                index[i] = Random.Range(0, flyingBooks.Length);
            }
            for (int i = 0; i < index.Length; i++)
            {
                int r = index[i];
                if (!flyingBooks[r].activeSelf)
                {
                    flyingBooks[r].SetActive(true);
                }
            }
            yield return new WaitForSeconds(5);
        }
    }
}
