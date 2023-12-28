using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//22.适配器模式
public class DM12Adapter : MonoBehaviour {

	void Start () {
		Adapter adapter = new Adapter(new NewPlugin());
		StandardInterface si = adapter;
		si.Request();
	}
	
	void Update () {
		
	}
}

interface StandardInterface {
	void Request();
}
class StandardImplementA : StandardInterface
{
    public void Request()
    {
        Debug.Log("使用标准方法实现请求");
    }
}

class Adapter : StandardInterface
{
	private NewPlugin plugin;
	public Adapter(NewPlugin p) {
		plugin = p;
	}
	public void Request()
    {
		plugin.SpecificRequest();
    }
}

class NewPlugin {
	public void SpecificRequest() {
		Debug.Log("使用特殊插件方法实现请求");
	}
}
