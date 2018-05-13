using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnTest {


	[UnityTest]
	public IEnumerator SpawnTestWithEnumeratorPasses() {
        yield return null;

        /*var bookPrefab = Resources.Load("Tests/enemyBook");
        var bookSpawner = new GameObject().AddComponent<StillBookScript>();
        bookSpawner.Construct((GameObject) bookPrefab);

        yield return null;

        var spawnedBook = GameObject.FindWithTag("Enemy");
        var prefabOfTheSpawnedBook = UnityEditor.PrefabUtility.GetPrefabParent(spawnedBook);

        Assert.Equals(bookPrefab, prefabOfTheSpawnedBook);*/
    }
}
