using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard 
{
    Dictionary<string,object>blackBoardData=new Dictionary<string, object>();
    public event EventHandler<BlackBoardEventArgs> OnBlackBoardValueChange;
    public class BlackBoardEventArgs : EventArgs{
        public string key;
        public object val;
    }
    public void SetOrAddData(string key,object val){
        if(!blackBoardData.ContainsKey(key)){
            blackBoardData.Add(key,val);
        }
        else {
            blackBoardData[key]=val;
        }
        OnBlackBoardValueChange?.Invoke(this, new BlackBoardEventArgs{
            key=key,
            val=val
        });
   }
   public void RemoveData(string key){
        if(blackBoardData.ContainsKey(key)){
            blackBoardData.Remove(key);
        OnBlackBoardValueChange?.Invoke(this, new BlackBoardEventArgs{
            key=key,
            val=null
        });
    }    
   }
   public bool GetBlackBoardData<T>(string key,out T val){
        val=default(T);
        if(blackBoardData.ContainsKey(key)){
            val=(T)blackBoardData[key];
            return true;
        }
        return false;
   }
   public bool HasKey(string key){
        return blackBoardData.ContainsKey(key);
   }
}
