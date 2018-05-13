using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGame1Test
{


    [UnityTest]
    public IEnumerator MenuGame1TestWithEnumeratorPasses()
    {

        SceneManager.LoadScene("Menu");
        yield return new WaitForSeconds(2);
        Button play1 = GameObject.Find("Play1").GetComponent<Button>();
        play1.onClick.Invoke();
        yield return new WaitForSeconds(2);
        Assert.AreEqual(SceneManager.GetActiveScene().buildIndex, SceneManager.GetSceneByName("VR1").buildIndex);

    }
}
