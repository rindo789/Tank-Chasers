using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Resume : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    if(!SaveExists()){
      gameObject.SetActive(false);
    }
  }
  
  public bool SaveExists()
  {
    string path = Application.persistentDataPath + "/savegame.save";
    if (File.Exists(path))
    {
      return true;
    }
    else
    {
      return false;
    }
  }
}
