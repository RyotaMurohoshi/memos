PlayerPrefsを消すEditor拡張

```csharp
using UnityEditor;
using UnityEngine;

public class PlayerPrefsMenuItem
{
	[MenuItem ("PlayerPrefs/DeleteAll")]
	public static void DeleteAll ()
	{
		PlayerPrefs.DeleteAll ();
	}
}
```