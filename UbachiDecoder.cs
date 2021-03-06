//This code decrypts messages using by Germans in WWI! 
//Inputs: A coded message and a key. 
    //The keyword must be english alphabetic. 
    //The keyword is not case sensitive.
    //The message length must be a multiple of the keyword's length.
    //I've capped the message length as a percaution.
//Outputs: The decoded messsage.
//Note: This can be run multiple times.
//Comming soon: An encrypertor to compliment this.

double[] AlphaToNumArr(string inStr, double repeatAdjuster){
    string alphbet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    alphbet = alphbet.ToUpper();
    string inStrAsUpper = inStr.ToUpper();
    double[] asNumeric = new double[inStr.Length];
    
    for(int i = 0; i < inStr.Length; i++)
    {
        //Pull alphabetic number (base zero)
        asNumeric[i] = System.Convert.ToDouble(alphbet.IndexOf(inStrAsUpper[i]));
        //Test
        //Console.Write ("(" + keyAsNumeric[i] + ")");
                    
        //Mark any repeated letters in the keyword
        for(int j = 0; j < i; j++)
        {
            if (asNumeric[i] == asNumeric[j])
            {
                asNumeric[i] += repeatAdjuster;
            }
        }
    }
    return asNumeric;
}

//Main Method
string Ubachi(string message, string keyword) {
    string decodedMsg = "";
    int maxMessageLength = 120;
    string workingMessage = message;
    
    if (message.Length <= maxMessageLength)
    {
        if (keyword.Length <= message.Length)
        {
            if(message.Length % keyword.Length == 0)
            {
                
                //Step 1: Decode the keyword into numbers
                double[] keyAsNumeric = new double[keyword.Length];
                double repeatAdjuster = 1.0/message.Length; //Dividing ensures repetitive messages won't create errors
                keyAsNumeric = AlphaToNumArr(keyword, repeatAdjuster);
                
                //Order the key's elements according to numeric value
                double[] orderedNumeric = new double[keyword.Length];         
                keyAsNumeric.CopyTo(orderedNumeric, 0);
                Array.Sort(orderedNumeric);
                
                int repititions = 2;
                string sectionData = "";
                int packageSize = message.Length / keyword.Length;
                Dictionary<double, string> keyNumAndData =  new Dictionary<double, string>();
                //Assign sections of the message to each element
                for(int ii = 0; ii < repititions; ii++)
                {
                    //Break the message into sections
                    for(int ij = 0; ij < keyword.Length; ij++)
                    {
                        //If the data was arrayed in columns and rows this would package each column
                        sectionData = workingMessage.Substring(ij * packageSize,  packageSize);
                        //Test
                        //Console.Write ("(" +sectionData + ")");
                        
                        //Assign to dictionary
                        if (!keyNumAndData.ContainsKey(orderedNumeric[ij]))
                        {
                            keyNumAndData.Add(orderedNumeric[ij], sectionData);
                            //Test
                            //Console.Write(keyNumAndData[orderedNumeric[ij]] + ", ");
                        }
                        else
                        {
                            //Console.Write (orderedNumeric[ij] + " is already a key in this dictionary.");
                        }
                        //Clear Memory
                        sectionData = "";
                    }
                    //Clear Memory
                    workingMessage = "";
                    
                    //Reorder according to the keyword and copy into a new message
                    string workingSet = "";
                    for (int ik = 0; ik < packageSize; ik ++)
                    {
                        //When making the new message read the data as if each package was a column
                        for(int iki = 0; iki < keyword.Length; iki++)
                        {
                            //Get Column
                            workingSet = keyNumAndData[keyAsNumeric[iki]];
                            //Take one entry from the same row of each column
                            workingMessage += workingSet[ik];
                        }
                    }                    
                    decodedMsg = workingMessage;
                    //Test
                    //Console.Write (decodedMsg);
                    
                    //Clear Memory
                    workingSet = "";
                    keyNumAndData.Clear();
                }
            }
            else
            {
                Console.Write ("Process Failure: Message is not a multiple of the keyword.\n" );
                Console.Write ("The remainder of message/keyword is: " + (message.Length % keyword.Length));
            } 
        }
        else
        {
            Console.Write ("Process Failure: Keyword length exceeded the message length.");
        }
    }
    else
    {
        Console.Write ("Process Failure: Message length exceeded the 120 character limit.");
    }
    
    return decodedMsg;
}
