//-------------------------------------------------------------------------------------------------
// <copyright file="DependencyExtension.cs" company="Microsoft">
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
// The Windows Installer XML toolset dependency extension.
// </summary>
//-------------------------------------------------------------------------------------------------

namespace Microsoft.Tools.WindowsInstallerXml.Extensions
{
    using System;
    using System.Reflection;

    /// <summary>
    /// The Windows Installer XML toolset dependency extension.
    /// </summary>
    public sealed class DependencyExtension : WixExtension
    {
        private DependencyBinder binderExtension;
        private DependencyCompiler compilerExtension;
        private DependencyDecompiler decompilerExtension;
        private TableDefinitionCollection tableDefinitions;
        private Library library;

        /// <summary>
        /// Gets the binder extension.
        /// </summary>
        /// <value>The binder extension.</value>
        public override BinderExtension BinderExtension
        {
            get
            {
                if (null == this.binderExtension)
                {
                    this.binderExtension = new DependencyBinder();
                }

                return this.binderExtension;
            }
        }

        /// <summary>
        /// Gets the compiler extension.
        /// </summary>
        /// <value>The compiler extension.</value>
        public override CompilerExtension CompilerExtension
        {
            get
            {
                if (null == this.compilerExtension)
                {
                    this.compilerExtension = new DependencyCompiler();
                }

                return this.compilerExtension;
            }
        }

        /// <summary>
        /// Gets the decompiler extension.
        /// </summary>
        /// <value>The decompiler extension.</value>
        public override DecompilerExtension DecompilerExtension
        {
            get
            {
                if (null == this.decompilerExtension)
                {
                    this.decompilerExtension = new DependencyDecompiler();
                }

                return this.decompilerExtension;
            }
        }

        /// <summary>
        /// Gets the optional table definitions for this extension.
        /// </summary>
        /// <value>The optional table definitions for this extension.</value>
        public override TableDefinitionCollection TableDefinitions
        {
            get
            {
                if (null == this.tableDefinitions)
                {
                    this.tableDefinitions = LoadTableDefinitionHelper(Assembly.GetExecutingAssembly(), "Microsoft.Tools.WindowsInstallerXml.Extensions.Data.tables.xml");
                }

                return this.tableDefinitions;
            }
        }

        /// <summary>
        /// Gets the library associated with this extension.
        /// </summary>
        /// <param name="tableDefinitions">The table definitions to use while loading the library.</param>
        /// <returns>The library for this extension.</returns>
        public override Library GetLibrary(TableDefinitionCollection tableDefinitions)
        {
            if (null == this.library)
            {
                this.library = LoadLibraryHelper(Assembly.GetExecutingAssembly(), "Microsoft.Tools.WindowsInstallerXml.Extensions.Data.Dependency.wixlib", tableDefinitions);
            }

            return this.library;
        }

        /// <summary>
        /// Gets the default culture.
        /// </summary>
        /// <value>The default culture.</value>
        public override string DefaultCulture
        {
            get { return "en-us"; }
        }
    }
}
