//-------------------------------------------------------------------------------------------------
// <copyright file="HeatDirectory.cs" company="Microsoft">
//    Copyright (c) Microsoft Corporation.  All rights reserved.
//    
//    The use and distribution terms for this software are covered by the
//    Common Public License 1.0 (http://opensource.org/licenses/cpl1.0.php)
//    which can be found in the file CPL.TXT at the root of this distribution.
//    By using this software in any fashion, you are agreeing to be bound by
//    the terms of this license.
//    
//    You must not remove this notice, or any other, from this software.
// </copyright>
// 
// <summary>
// Build task to execute the directory harvester extension of the Windows Installer Xml toolset.
// </summary>
//-------------------------------------------------------------------------------------------------

namespace Microsoft.Tools.WindowsInstallerXml.Build.Tasks
{
    using Microsoft.Build.Framework;

    public sealed class HeatDirectory : HeatTask
    {
        private string directory;
        private bool keepEmptyDirectories;
        private bool suppressCom;
        private bool suppressRootDirectory;
        private bool suppressRegistry;
        private string template;
        private string componentGroupName;
        private string directoryRefId;
        private string preprocessorVariable;

        public string ComponentGroupName
        {
            get { return this.componentGroupName; }
            set { this.componentGroupName = value; }
        }

        [Required]
        public string Directory
        {
            get { return this.directory; }
            set { this.directory = value; }
        }

        public string DirectoryRefId
        {
            get { return this.directoryRefId; }
            set { this.directoryRefId = value; }
        }

        public bool KeepEmptyDirectories
        {
            get { return this.keepEmptyDirectories; }
            set { this.keepEmptyDirectories = value; }
        }

        public string PreprocessorVariable
        {
            get { return this.preprocessorVariable; }
            set { this.preprocessorVariable = value; }
        }

        public bool SuppressCom
        {
            get { return this.suppressCom; }
            set { this.suppressCom = value; }
        }

        public bool SuppressRootDirectory
        {
            get { return this.suppressRootDirectory; }
            set { this.suppressRootDirectory = value; }
        }

        public bool SuppressRegistry
        {
            get { return this.suppressRegistry; }
            set { this.suppressRegistry = value; }
        }

        public string Template
        {
            get { return this.template; }
            set { this.template = value; }
        }

        protected override string OperationName
        {
            get { return "dir"; }
        }

        /// <summary>
        /// Generate the command line arguments to write to the response file from the properties.
        /// </summary>
        /// <returns>Command line string.</returns>
        protected override string GenerateResponseFileCommands()
        {
            WixCommandLineBuilder commandLineBuilder = new WixCommandLineBuilder();

            commandLineBuilder.AppendSwitch(this.OperationName);
            commandLineBuilder.AppendFileNameIfNotNull(this.Directory);

            commandLineBuilder.AppendSwitchIfNotNull("-cg ", this.ComponentGroupName);
            commandLineBuilder.AppendSwitchIfNotNull("-dr ", this.DirectoryRefId);
            commandLineBuilder.AppendIfTrue("-ke", this.KeepEmptyDirectories);
            commandLineBuilder.AppendIfTrue("-scom", this.SuppressCom);
            commandLineBuilder.AppendIfTrue("-sreg", this.SuppressRegistry);
            commandLineBuilder.AppendIfTrue("-srd", this.SuppressRootDirectory);
            commandLineBuilder.AppendSwitchIfNotNull("-template ", this.Template);
            commandLineBuilder.AppendSwitchIfNotNull("-var ", this.PreprocessorVariable);

            base.BuildCommandLine(commandLineBuilder);
            return commandLineBuilder.ToString();
        }
    }
}
