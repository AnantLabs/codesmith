﻿using System;
using System.ComponentModel;
using CodeSmith.Engine;
using CodeSmith.SchemaHelper;
using Configuration = CodeSmith.SchemaHelper.Configuration;

namespace Generator.CSLA.CodeTemplates
{
    public class EntitiesBaseCodeTemplate : CSLABaseTemplate
    {
        private string _solutionName;
        private DataAccessMethod _dataAccessImplementation;

        public EntitiesBaseCodeTemplate()
        {
            DataAccessImplementation = DataAccessMethod.ParameterizedSQL;
            UseLazyLoading = true;
        }

        #region 2. Solution

        [Editor(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Optional, NotChecked]
        [Category("2. Solution")]
        [Description("The path to the Solution location.")]
        [DefaultValue("")]
        public string Location { get; set; }

        [Category("2. Solution")]
        [Description("Name of the project to be generated.")]
        [DefaultValue("")]
        public string SolutionName
        {
            get { return _solutionName; }
            set
            {
                if (value != null)
                {
                    _solutionName = value;
                    OnSolutionNameChanged();
                }
            }
        }

        [Optional]
        [Category("2. Solution")]
        [Description("The .NET Framework Version. If you use v40 then CSLA 4.0 will be used. If you use v35 then CSLA 3.8 will be used.")]
        public FrameworkVersion FrameworkVersion
        {
            get
            {
                return Configuration.Instance.FrameworkVersion;
            }
            set
            {
                Configuration.Instance.FrameworkVersion = value;
            }
        }

        #endregion

        #region 3. Business Project

        [Category("3. Business Project")]
        [Description("The namespace for the business project.")]
        public string BusinessProjectName { get; set; }

        [Category("3. Business Project")]
        [Description("Uses private property backing variables for properties.")]
        [DefaultValue(false)]
        public bool UseMemberVariables { get; set; }

        [Category("3. Business Project")]
        [Description("If enabled Silverlight support will be added to the project..")]
        [DefaultValue(false)]
        public bool IncludeSilverlightSupport
        {
            get
            {
                return Configuration.Instance.IncludeSilverlightSupport;
            }
            set
            {
                if (!IsLatestCSLA)
                    Console.WriteLine("In order to include Silverlight support you must target CSLA 4.0.");

                Configuration.Instance.IncludeSilverlightSupport = value;
            }
        }

        #endregion

        #region 4. Data Project

        [Category("4. Data Project")]
        [Description("Changes how the Business Data Access Methods and Data Access Layer are implemented.")]
        public DataAccessMethod DataAccessImplementation
        {
            get { return _dataAccessImplementation; }
            set
            {
                _dataAccessImplementation = value;
                OnDataAccessImplementationChanged();
            }
        }
        [Category("4. Data Project")]
        [Description("The Name Space for the Data Project.")]
        public string DataProjectName { get; set; }

        [Category("4. Data Project")]
        [Description("The value all sql parameters should be prefixed with.")]
        [DefaultValue("@p_")]
        public string ParameterPrefix
        {
            get { return Configuration.Instance.ParameterPrefix; }
            set { Configuration.Instance.ParameterPrefix = value; }
        }

        [Category("4. Data Project")]
        [Description("Changes how the business layer and data acces layer is implemented.")]
        [DefaultValue(true)]
        public bool UseLazyLoading { get; set; }

        [Category("4. Data Project")]
        [Description("Prefix to use for all generated procedure names.")]
        public string ProcedurePrefix { get; set; }

        [Category("4. Data Project")]
        [Description("Whether or not to immediately execute the script on the target database.")]
        [DefaultValue(false)]
        public bool AutoExecuteStoredProcedures { get; set; }

        [Category("4. Data Project")]
        [Description("Isolation level to use in the generated procedures.")]
        [DefaultValue(0)] //ReadCommitted
        public TransactionIsolationLevelEnum IsolationLevel { get; set; }

        #endregion

        #region 5. Interface Project

        [Category("5. Interface Project")]
        [Description("The namespace for the interface project.")]
        public string InterfaceProjectName { get; set; }

        #endregion

        #region 7. LinqToSQL Data Access Layer
        [Category("7. LinqToSQL Data Access Layer")]
        [Description("The data acces layer namespace to be used.  This should match with the data context used by LinqToSQL.")]
        [DefaultValue(false)]
        [Optional]
        public string LinqToSQLContextNamespace { get; set; }

        [Category("7. LinqToSQL Data Access Layer")]
        [Description("The data context name to be used.  This should match with the data context used by LinqToSQL.")]
        [DefaultValue(false)]
        [Optional]
        public string LinqToSQLDataContextName { get; set; }

        #endregion

        public virtual void Generate()
        {
        }

        public virtual void OnSolutionNameChanged()
        {
            if (string.IsNullOrEmpty(SolutionName))
            {
                return;
            }

            if (string.IsNullOrEmpty(BusinessProjectName))
            {
                BusinessProjectName = String.Format("{0}.Business", SolutionName);
            }

            if (string.IsNullOrEmpty(DataProjectName))
            {
                DataProjectName = String.Format("{0}.Data", SolutionName);
            }

            if (string.IsNullOrEmpty(InterfaceProjectName))
            {
                InterfaceProjectName = String.Format("{0}.UI", SolutionName);
            }
        }

        public virtual void OnDataAccessImplementationChanged()
        {
        }
    }
}
