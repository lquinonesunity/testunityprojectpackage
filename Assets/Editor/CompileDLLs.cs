using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEditor;
using Debug = UnityEngine.Debug;

public class CompileDLLs : Editor
{
    [MenuItem("Tools/CompileTool")]
    private static void CompileScripts()
    {
        Debug.Log("Compiling scripts to dll");
        
        
        // start the child process
        Process process = new Process();
 
        // redirect the output stream of the child process.
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.FileName = @"CompileScripts.bat";
        process.StartInfo.Arguments = "";
 
        /*if (!string.IsNullOrEmpty(workingDirectory)) {
            process.StartInfo.WorkingDirectory = workingDirectory;
        } else {
            process.StartInfo.WorkingDirectory = Application.temporaryCachePath; // nb. can only be called on the main thread
        }*/
 
        int exitCode = -1;
        string output = null;
 
        try {
            process.Start();
 
            // do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // process.WaitForExit();
 
            // read the output stream first and then wait.
            output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
        }
        catch (Exception e) {
            Debug.LogError("Run error" + e.ToString()); // or throw new Exception
        }
        finally {
            exitCode = process.ExitCode;
 
            process.Dispose();
            process = null;
        }
    }
}
