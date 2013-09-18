using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.IO;
using System.Collections.ObjectModel;
using System.Text;

namespace Runspaces
{
    public partial class RunspaceDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void BtnExecuteScript_Click(object sender, EventArgs e)
        {
            BtnExecuteScript.Enabled = false;

            Stream str = fileUpload.FileContent;
            StreamReader sr = new StreamReader(str);
            string script = sr.ReadToEnd();

            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();

            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
            scriptInvoker.Invoke("Set-ExecutionPolicy -Scope Process -ExecutionPolicy RemoteSigned");

            Pipeline pipe = runspace.CreatePipeline();
            runspace.SessionStateProxy.SetVariable("firstValue", firstValue.Text);
            runspace.SessionStateProxy.SetVariable("secondValue", secondValue.Text);

            pipe.Commands.AddScript(script);
            pipe.Commands.Add("Out-String");
            Collection<PSObject> results = pipe.Invoke();

            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();

            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            String output = stringBuilder.ToString();
            TxtOutput.Text = output;
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            firstValue.Text = "";
            secondValue.Text = "";
            TxtOutput.Text = "";
            if (!BtnExecuteScript.Enabled)
            {
                BtnExecuteScript.Enabled = true;
            }
        }
    }
}