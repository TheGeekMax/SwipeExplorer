using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalManager : MonoBehaviour{
    public static SignalManager instance;

    [System.Serializable]
    public class Signal{
        public string signalName;
        public System.Action callback;

        public Signal(string signalName){
            this.signalName = signalName;
        }
    }

    public List<Signal> signals;

    void Awake(){
        if(instance == null){
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
    }

    public void initialise(){
        signals = new List<Signal>();
    }

    public void Subscribe(string signalName, System.Action callback){
        Signal signal = signals.Find(s => s.signalName == signalName);
        if(signal == null){
            signal = new Signal(signalName);
            signals.Add(signal);
        }
        signal.callback += callback;
    }

    public void SendSignal(string signalName){
        Signal signal = signals.Find(s => s.signalName == signalName);
        if(signal != null){
            signal.callback?.Invoke();
            signals.Remove(signal);
        }
    }

}
