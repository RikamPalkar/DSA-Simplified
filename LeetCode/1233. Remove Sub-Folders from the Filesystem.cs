//Time: O(n log n), Space: O(n)

    public IList<string> RemoveSubfolders(string[] folder) 
    {
        Array.Sort(folder); 
        List<string> result = [];
        
        string parentFolder = folder[0];
        
        foreach (string currFolder in folder) 
        {
            // Check if the current folder is a subfolder of the previous one
            if (!currFolder.StartsWith(parentFolder + "/")) 
            {
                result.Add(currFolder);
                parentFolder = currFolder;  // Update the previous folder to the current one
            }
        }
        
        return result;
    }
