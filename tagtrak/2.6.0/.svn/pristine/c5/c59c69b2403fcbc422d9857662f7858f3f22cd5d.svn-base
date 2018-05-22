using System ;
using System.IO ;
using System.Drawing;
using System.Collections;

public class buttonSpecRecordClass 
{ 
	public bool visible; 
	public System.Drawing.Point location; 
	public System.Drawing.Size size; 
	public string text; 
	public string buttonName; 

	public void reset() 
	{ 
		visible = false; 
		location = new System.Drawing.Point(-1, -1); 
		size = new System.Drawing.Size(-1, -1); 
		text = ""; 
		buttonName = ""; 
	} 

	public buttonSpecRecordClass(string inputButtonName, bool inputVisible, System.Drawing.Point inputLocation, System.Drawing.Size inputSize, string inputText) 
	{ 
		buttonName = inputButtonName ; 
		visible    = inputVisible    ; 
		location   = new System.Drawing.Point(inputLocation.X, inputLocation.Y) ; 
		size       = new System.Drawing.Size(inputSize.Width, inputSize.Height) ; 
		text       = inputText ; 
	} 

	public buttonSpecRecordClass(ref buttonSpecRecordClass inputButtonSpecRecord) 
	{ 
		buttonName = inputButtonSpecRecord.buttonName; 
		visible = inputButtonSpecRecord.visible; 
		location = new System.Drawing.Point(inputButtonSpecRecord.location.X, inputButtonSpecRecord.location.Y); 
		size = new System.Drawing.Size(inputButtonSpecRecord.size.Width, inputButtonSpecRecord.size.Height); 
		text = inputButtonSpecRecord.text; 
	} 

	public void setEqualTo(ref buttonSpecRecordClass inputButtonSpecRecord) 
	{ 
		buttonName = inputButtonSpecRecord.buttonName; 
		visible = inputButtonSpecRecord.visible; 
		location = new System.Drawing.Point(inputButtonSpecRecord.location.X, inputButtonSpecRecord.location.Y); 
		size = new System.Drawing.Size(inputButtonSpecRecord.size.Width, inputButtonSpecRecord.size.Height); 
		text = inputButtonSpecRecord.text; 
	} 

	public string parseIntegerPair(string parmString, ref int x, ref int y) 
	{ 
		if (diagnosticLevel >= 2) 
		{ 
			verify(!parmString == null, 601); 
		} 
		string[] tokenSet = parmString.Split(','); 
		if (tokenSet.Length != 2) 
		{ 
			return "Invalid integer pair"; 
		} 
		x = System.Convert.ToInt32(Trim(tokenSet(0))); 
		y = System.Convert.ToInt32(Trim(tokenSet(1))); 
		return "OK"; 
	} 

	public string parseParm(string parmString) 
	{ 
		if (diagnosticLevel >= 2) 
		{ 
			verify(!parmString == null, 602); 
		} 
		string parmSubstring; 
		int x; 
		int y; 
		string result; 
		if (parmString.StartsWith("Location=(")) 
		{ 
			if (!parmString.EndsWith(")")) 
			{ 
				return "Invalid parameter"; 
			} 
			result = parseIntegerPair(Substring(parmString, 10, Length(parmString) - 11), x, y); 
			if (result != "OK") 
			{ 
				return "Invalid parameter"; 
			} 
			location = new System.Drawing.Point(x, y); 
			return "OK"; 
		} 
		else if (parmString.StartsWith("Size=(")) 
		{ 
			if (!parmString.EndsWith(")")) 
			{ 
				return "Invalid parameter"; 
			} 
			result = parseIntegerPair(Substring(parmString, 6, Length(parmString) - 7), x, y); 
			if (result != "OK") 
			{ 
				return "Invalid parameter"; 
			} 
			size = new System.Drawing.Size(x, y); 
			return "OK"; 
		} 
		else if (parmString.StartsWith("Text=")) 
		{ 
			text = Substring(parmString, 5); 
			return "OK"; 
		} 
		else 
		{ 
			return "Invalid parameter"; 
		} 
		return "OK"; 
	} 

	public void parse(string parmString) 
	{ 
		if (diagnosticLevel >= 2) 
		{ 
			verify(!parmString == null, 604); 
		} 
		string parmSubstring; 
		string result; 
		int separatorLocation; 
		visible = true; 
		do 
		{ 
			separatorLocation = parmString.IndexOf(",Location"); 
			if (separatorLocation < 0) 
			{ 
				separatorLocation = parmString.IndexOf(",Size"); 
			} 
			if (separatorLocation < 0) 
			{ 
				separatorLocation = parmString.IndexOf(",Text"); 
			} 
			if (separatorLocation > 0) 
			{ 
				parmSubstring = Substring(parmString, 0, separatorLocation); 
				parmString = Substring(parmString, separatorLocation + 1); 
				result = parseParm(parmSubstring); 
				if (result != "OK") 
				{ 
					reset(); 
					goto exitMethodDeclaration0; 
				} 
			} 
		} while (separatorLocation > 0); 
		if (isNonNullString(parmString)) 
		{ 
			result = parseParm(parmString); 
			if (result != "OK") 
			{ 
				reset(); 
				goto exitMethodDeclaration1; 
			} 
		} 
		exitMethodDeclaration1: ; 
	} 

	public void parse(string locationString, string sizeString, string textString) 
	{ 
		if (diagnosticLevel >= 2) 
		{ 
			verify(!locationString == null, 7500); 
			verify(!sizeString == null, 7501); 
			verify(!textString == null, 7502); 
		} 
		locationString = Trim(locationString); 
		sizeString = Trim(sizeString); 
		textString = Trim(textString); 
		if (!(isNonNullString(locationString) & isNonNullString(sizeString) & isNonNullString(textString))) 
		{ 
			this.visible = false; 
			goto exitMethodDeclaration2; 
		} 
		string[] tokenSet; 
		string xString; 
		string yString; 
		tokenSet = locationString.Split(","); 
		if (tokenSet.Length != 2) 
		{ 
			this.visible = false; 
			goto exitMethodDeclaration3; 
		} 
		xString = Trim(tokenSet(0)); 
		yString = Trim(tokenSet(1)); 
		if (!(IsInteger(xString) & IsInteger(yString))) 
		{ 
			this.visible = false; 
			goto exitMethodDeclaration4; 
		} 
		try 
		{ 
			this.location.X = System.Convert.ToInt32(xString); 
			this.location.Y = System.Convert.ToInt32(yString); 
		} 
		catch (Exception ex) 
		{ 
			this.visible = false; 
			goto exitMethodDeclaration5; 
		} 
		tokenSet = sizeString.Split(","); 
		if (tokenSet.Length != 2) 
		{ 
			this.visible = false; 
			goto exitMethodDeclaration6; 
		} 
		xString = Trim(tokenSet(0)); 
		yString = Trim(tokenSet(1)); 
		if (!(IsInteger(xString) & IsInteger(yString))) 
		{ 
			this.visible = false; 
			goto exitMethodDeclaration7; 
		} 
		try 
		{ 
			this.size.Width = System.Convert.ToInt32(xString); 
			this.size.Height = System.Convert.ToInt32(yString); 
		} 
		catch (Exception ex) 
		{ 
			this.visible = false; 
			goto exitMethodDeclaration8; 
		} 
		this.text = Trim(textString); 
		this.visible = true; 
		exitMethodDeclaration8: ; 
	} 
}