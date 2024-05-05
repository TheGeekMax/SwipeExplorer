using System.Collections; 
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdManager : MonoBehaviour{
    public static ItemIdManager instance;
    private Dictionary<string, Type> itemIdToTypeMap;

    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    private IEnumerable<Type> FindDerivedTypes(Assembly assembly, Type baseType){
        return assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t));
    }

    public void initialise(){
        //initialise manager
        itemIdToTypeMap = new Dictionary<string, Type>();
        foreach(Type item in FindDerivedTypes(Assembly.GetExecutingAssembly(), typeof(Item))){
            //instanciate item and print its name
            Item itemInstance = (Item)Activator.CreateInstance(item);
            itemIdToTypeMap.Add(itemInstance.GetId(), item);
        }
    }

    public Item InstantiateItem(string id){
        if(itemIdToTypeMap.ContainsKey(id)){
            return (Item)Activator.CreateInstance(itemIdToTypeMap[id]);
        }
        return null;
    }
}
