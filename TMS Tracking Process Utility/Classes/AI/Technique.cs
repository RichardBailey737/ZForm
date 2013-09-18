using UnityEngine;
using System.Collections;
using BBDS.Classes.AI;


public class Technique {
	
	/// <summary>
	/// Gets or sets the name of this technique to be seen by the user
	/// </summary>
	/// <value>
	/// The name.
	/// </value>
	public string Name {
		get;  set; 
	}
	
	/// <summary>
	/// Gets or sets the rollover description of this technique
	/// </summary>
	/// <value>
	/// The description.
	/// </value>
	public string Description { get;  set;  }
	
	/// <summary>
	/// Gets or sets the name of the action to invoke
	/// </summary>
	/// <value>
	/// The name of the action.
	/// </value>
	public string ActionName { get; set; }
	
	
}