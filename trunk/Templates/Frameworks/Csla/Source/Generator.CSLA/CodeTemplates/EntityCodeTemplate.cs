﻿//------------------------------------------------------------------------------
//
// Copyright (c) 2002-2012 CodeSmith Tools, LLC.  All rights reserved.
// 
// The terms of use for this software are contained in the file
// named sourcelicense.txt, which can be found in the root of this distribution.
// By using this software in any fashion, you are agreeing to be bound by the
// terms of this license.
// 
// You must not remove this notice, or any other, from this software.
//
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CodeSmith.CustomProperties;
using CodeSmith.Engine;
using CodeSmith.SchemaHelper;

using SchemaExplorer;

using Configuration=CodeSmith.SchemaHelper.Configuration;

namespace Generator.CSLA
{
    public class EntityCodeTemplate : CSLABaseTemplate
    {
        #region Private Member(s)

        private IEntity _entity;
        private StringCollection _ignoreExpressions;
        private StringCollection _cleanExpressions;
        private bool _silverlightSupport;

        private string _criteriaClassName = String.Empty;
        private string _childBusinessClassName = String.Empty;
        

        #endregion

        #region Constructor(s)

        public EntityCodeTemplate()
        {
            DataAccessImplementation = DataAccessMethod.ParameterizedSQL;
            UseLazyLoading = true;

            CleanExpressions = new StringCollection();
            IgnoreExpressions = new StringCollection();
        }

        #endregion

        #region Public Properties

        #region 1. DataSource

        /// <summary>
        /// This is needed for legacy purposes..
        /// </summary>
        [Optional]
        [Category("1. DataSource")]
        public TableSchema SourceTable
        {
            get
            {
                if (Entity is TableEntity)
                    return ((TableEntity)Entity).EntitySource as TableSchema;

                return null;
            }
            set
            {
                if (value != null)
                {
                    var provider = new SchemaExplorerEntityProvider(new TableSchemaCollection {value}, null, null);
                    IEntity entity = new EntityManager(provider).Entities.FirstOrDefault();
                    Entity = entity ?? new TableEntity(value);
                }
            }
        }

        /// <summary>
        /// This is needed for legacy purposes..
        /// </summary>
        [Optional]
        [Category("1. DataSource")]
        public ViewSchema SourceView
        {
            get
            {
                if (Entity is ViewEntity)
                    return ((ViewEntity)Entity).EntitySource as ViewSchema;

                return null;
            }
            set
            {
                if (value != null)
                {
                    var provider = new SchemaExplorerEntityProvider(null, new ViewSchemaCollection { value }, null);
                    IEntity entity = new EntityManager(provider).Entities.FirstOrDefault();
                    Entity = entity ?? new ViewEntity(value);
                }
            }
        }

        /// <summary>
        /// This is needed for legacy purposes..
        /// </summary>
        [Optional]
        [Category("1. DataSource")]
        public CommandSchema SourceCommand
        {
            get
            {
                if (Entity is CommandEntity)
                    return ((CommandEntity)Entity).EntitySource as CommandSchema;

                return null;
            }
            set
            {
                if (value != null)
                {
                    var provider = new SchemaExplorerEntityProvider(null, null, new CommandSchemaCollection { value });
                    IEntity entity = new EntityManager(provider).Entities.FirstOrDefault();
                    Entity = entity ?? new CommandEntity(value);
                }
            }
        }

        /// <summary>
        /// The Generic Entity Object that gets generated.
        /// </summary>
        [Browsable(false)]
        public IEntity Entity
        {
            get { return _entity; }
            set
            {
                if (value != null && _entity != value)
                {
                    _entity = value;
                    OnEntityChanged();
                }
            }
        }

        [Category("1. DataSource")]
        [Description("List of regular expressions to clean table, view and column names.")]
        [Optional]
        [DefaultValue("^(sp|tbl|udf|vw)_")]
        public StringCollection CleanExpressions
        {
            get
            {
                return _cleanExpressions;
            }
            set
            {
                _cleanExpressions = value;

                Configuration.Instance.CleanExpressions = new List<Regex>();
                foreach (string clean in _cleanExpressions)
                {
                    if (!string.IsNullOrEmpty(clean))
                    {
                        Configuration.Instance.CleanExpressions.Add(new Regex(clean, RegexOptions.IgnoreCase));
                    }
                }

                //if (SourceTable != null)
                //    Entity = new TableEntity(SourceTable);
            }
        }

        [Category("1. DataSource")]
        [Description("List of regular expressions to ignore tables when generating.")]
        [Optional]
        [DefaultValue("sysdiagrams$")]
        public StringCollection IgnoreExpressions
        {
            get
            {
                return _ignoreExpressions;
            }
            set
            {
                _ignoreExpressions = value;

                Configuration.Instance.IgnoreExpressions = new List<Regex>();
                foreach (string ignore in _ignoreExpressions)
                {
                    if (!string.IsNullOrEmpty(ignore))
                    {
                        Configuration.Instance.IgnoreExpressions.Add(new Regex(ignore, RegexOptions.IgnoreCase));
                    }
                }

                //if (SourceTable != null)
                //    Entity = new TableEntity(SourceTable);
            }
        }

        #endregion

        #region 2. Solution

        [Editor(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Optional, NotChecked]
        [Category("2. Solution")]
        [Description("The path to the Solution location.")]
        [DefaultValue(".\\")]
        public string Location { get; set; }

        #endregion

        #region 3. Business Project

        [Category("3. Business Project")]
        [Description("The namespace for the business project.")]
        public string BusinessProjectName { get; set; }

        [Category("3. Business Project")]
        [Description("The name of the business class.")]
        public string BusinessClassName { get; set; }

        [Category("3. Business Project")]
        [Description("The name of the child business class.")]
        public string ChildBusinessClassName
        {
            get
            {
                if (string.IsNullOrEmpty(_childBusinessClassName))
                    _childBusinessClassName = ResolveChildBusinessClassName();

                return _childBusinessClassName;
            }
            set
            {
                _childBusinessClassName = value;
            }
        }

        [Category("3. Business Project")]
        [Description("The name of the criteria business class.")]
        public string CriteriaClassName
        {
            get
            {
                if(string.IsNullOrEmpty(_criteriaClassName))
                    _criteriaClassName = ResolveTargetClassName(ChildBusinessClassName, "Criteria");

                return _criteriaClassName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.EndsWith("Criteria", StringComparison.InvariantCultureIgnoreCase)) 
                    _criteriaClassName = value;
            }
        }

        /// <summary>
        /// Attempts to resolve the best canidate for the child class name.
        /// </summary>
        /// <returns></returns>
        private string ResolveChildBusinessClassName()
        {
            if (string.IsNullOrEmpty(BusinessClassName))
                return BusinessClassName;

            if (BusinessClassName.Equals(Entity.Name, StringComparison.InvariantCultureIgnoreCase))
                return BusinessClassName;

            if (BusinessClassNameExists("ListList", 4))
                return BusinessClassName.Substring(0, BusinessClassName.Length - 4);

            if (BusinessClassNameExists("InfoList", 8))
                return BusinessClassName.Substring(0, BusinessClassName.Length - 8);

            if (BusinessClassNameExists("NameValueList", 13))
                return BusinessClassName.Substring(0, BusinessClassName.Length - 13);

            if (BusinessClassNameExists("List", 4))
                return BusinessClassName.Substring(0, BusinessClassName.Length - 4);

            if (BusinessClassNameExists("Info", 4))
                return BusinessClassName.Substring(0, BusinessClassName.Length - 4);

            if (BusinessClassNameExists("Criteria", 8))
                return BusinessClassName.Substring(0, BusinessClassName.Length - 8);

            return ResolveTargetClassName(BusinessClassName, String.Empty);
        }


        /// <summary>
        /// Gets the Root BusinessName + the suffix.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        [Browsable(false)]
        public string ResolveTargetClassName(string className, string suffix)
        {
            return ResolveTargetClassName(className, suffix, true);
        }

        /// <summary>
        /// Gets the Root BusinessName + the suffix.
        /// </summary>
        /// <param name="className"></param>
        /// <param name="suffix"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        [Browsable(false)]
        public string ResolveTargetClassName(string className, string suffix, bool expression)
        {
            // We will use these eventually..
            //bool isReadOnly;
            bool searchingForCriteriaObject = suffix.Equals("criteria", StringComparison.InvariantCultureIgnoreCase);
         
            if(string.IsNullOrEmpty(className))
                className = Entity != null ? Entity.Name : String.Empty;

            if (Entity != null)
            {
                var temp = className.Replace(Entity.Name, String.Empty);
                if (temp.Equals("criteria", StringComparison.InvariantCultureIgnoreCase) ||
                    temp.Equals("list", StringComparison.InvariantCultureIgnoreCase))
                {
                    className = Entity.Name;
                }

                // Try to detect if we are generating a read only object..
                if (temp.Equals("info", StringComparison.InvariantCultureIgnoreCase) || temp.Equals("infolist", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (searchingForCriteriaObject && expression)
                        return string.Concat(Entity.Name, suffix.Trim());

                    // Try to detect double endings.
                    if (suffix.Equals("info", StringComparison.InvariantCultureIgnoreCase)) 
                        return String.Format("{0}Info", Entity.Name);

                    //isReadOnly = true;
                    className = String.Format("{0}Info", Entity.Name);
                }
            }

            // If the keys are 0 then that means they are not generating from the entities.csp.
            if ((BusinessObjectExists(suffix) && expression) || ContextData.Keys.Count == 0 && expression)
                return string.Concat(className, suffix);

            return expression ? string.Concat(className, suffix.Trim()) : className;
        }

        [Category("3. Business Project")]
        [Description("Uses private property backing variables for properties.")]
        [DefaultValue(false)]
        public bool UseMemberVariables { get; set; }

        [Category("3. Business Project")]
        [Description("Changes how the Business Objects are deleted, defaults to immediate deletion.")]
        [DefaultValue(false)]
        public bool UseDeferredDeletion { get; set; }

        [Category("3. Business Project")]
        [Description("If enabled Silverlight support will be added to the project..")]
        [DefaultValue(false)]
        public bool IncludeSilverlightSupport
        {
            get
            {
                return _silverlightSupport;
            }
            set
            {
                if (!IsLatestCSLA)
                    Console.WriteLine("In order to include Silverlight support you must target CSLA 4.0.");

                _silverlightSupport = value;
                Configuration.Instance.IncludeSilverlightSupport = value;
            }
        }

        #endregion
        
        #region 4. Data Project

        [Category("4. Data Project")]
        [Description("Changes how the Business Data Access Methods and Data Access Layer are implemented.")]
        public DataAccessMethod DataAccessImplementation { get; set; }

        [Category("4. Data Project")]
        [Description("The value all sql parameters should be prefixed with.")]
        [DefaultValue("@p_")]
        public string ParameterPrefix
        {
            get
            {
                return Configuration.Instance.ParameterPrefix;
            }
            set
            {
                Configuration.Instance.ParameterPrefix = value;
            }
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

        #region 7. LinqToSQL Data Access Layer
 
        [Category("7. LinqToSQL Data Access Layer")]
        [Description("LinqToSQL context name space.")]
        [DefaultValue(false)]
        [Optional]
        public string LinqToSQLContextNamespace { get; set; }

        [Category("7. LinqToSQL Data Access Layer")]
        [Description("LinqToSQL data context name.")]
        [DefaultValue(false)]
        [Optional]
        public string LinqToSQLDataContextName { get; set; }

        #endregion

        #region public virtual properties

        [Browsable(false)]
        public bool RenderOptionalContent { get; set; }

        #endregion

        #endregion

        #region Public Virtual Methods

        /// <summary>
        /// This method fires anytime a datasource changes.
        /// </summary>
        public virtual void OnEntityChanged()
        {
            if (OnEntityChanging()) return;

            if (string.IsNullOrEmpty(BusinessClassName))
                BusinessClassName = Entity.Name;

            if (string.IsNullOrEmpty(CriteriaClassName) ||
                CriteriaClassName.Equals("Criteria", StringComparison.InvariantCultureIgnoreCase))
                CriteriaClassName = String.Concat(Entity.Name, "Criteria");

            if (string.IsNullOrEmpty(BusinessProjectName))
                BusinessProjectName = String.Concat(Entity.Namespace, ".Business");

            if (string.IsNullOrEmpty(Location))
                Location = ".\\";

            if (string.IsNullOrEmpty(ProcedurePrefix))
                ProcedurePrefix = "CSLA_";
        }

        public virtual string GetTableOwner()
        {
            return GetTableOwner(true);
        }

        public virtual string GetTableOwner(bool includeDot)
        {
            if (Entity != null && !String.IsNullOrEmpty(Entity.SchemaName) && Entity.SchemaName.Length > 0)
                return includeDot
                           ? String.Format("[{0}].", Entity.SchemaName)
                           : String.Format("[{0}]", Entity.SchemaName);

            return String.Empty;
        }

        /// <summary>
        /// This method is used if you don't want to overwrite the whole OnEntityChanged() method, you just want to modify a property in the pipeline..
        /// I only created this becuase I didn't want to duplicated a lot of code across templates or new up a new entity twice..
        /// </summary>
        /// <returns></returns>
        public virtual bool OnEntityChanging()
        {
            return false;
        }

        #endregion

        #region Public Method(s)

        public bool IsReadOnlyBusinessObject(string suffix)
        {
            string key = String.Format("{0}{1}", Entity.EntityKeyName, suffix);
            if (ContextData.Get(key) == null) return false;

            var value = ContextData[key];
            switch (value)
            {
                case Constants.ReadOnlyChild:
                case Constants.ReadOnlyRoot:
                case Constants.ReadOnlyChildList:
                case Constants.ReadOnlyList:
                    return true;
            }

            return false;
        }

        public bool IsReadOnlyBusinessObject(Association association, string suffix)
        {
            if (association.Properties.Count <= 0)
                return false;

            string key = String.Format("{0}{1}", association.ForeignEntity.EntityKeyName, suffix);
            if (ContextData.Get(key) == null) 
                return false;

            var value = ContextData[key];
            switch (value)
            {
                case Constants.ReadOnlyChild:
                case Constants.ReadOnlyRoot:
                case Constants.ReadOnlyChildList:
                case Constants.ReadOnlyList:
                    return true;
            }

            return false;
        }

        public bool IsChildBusinessObject(string suffix)
        {
            string key = String.Format("{0}{1}", Entity.EntityKeyName, suffix);
            if (ContextData.Get(key) == null) 
                return false;

            var value = ContextData[key];
            switch (value)
            {
                case Constants.EditableChild:
                case Constants.ReadOnlyChild:
                case Constants.EditableChildList:
                case Constants.ReadOnlyChildList:
                    return true;
            }

            return false;
        }

        public bool IsChildBusinessObject(Association association)
        {
            return IsChildBusinessObject(association, String.Empty); 
        }

        public bool IsChildBusinessObject(Association association, string suffix)
        {
            if (association.Properties.Count <= 0)
                return false;

            string key = String.Format("{0}{1}", association.ForeignEntity.EntityKeyName, suffix);
            if (ContextData.Get(key) == null) 
                return false;

            var value = ContextData[key];
            switch (value)
            {
                case Constants.EditableChild:
                case Constants.ReadOnlyChild:
                case Constants.EditableChildList:
                case Constants.ReadOnlyChildList:
                    return true;
            }

            return false;
        }

        public bool IsSwitchableObject()
        {
            return IsSwitchableObject(String.Empty);
        }

        public bool IsSwitchableObject(string suffix)
        {
            string key = String.Format("{0}{1}", Entity.EntityKeyName, suffix);
            if (ContextData.Get(key) == null) return false;

            var value = ContextData[key];
            switch (value)
            {
                case Constants.SwitchableObject:
                    return true;
            }

            return false;
        }

        public bool IsSwitchableObject(Association association)
        {
            return IsSwitchableObject(association, String.Empty);
        }

        public bool IsSwitchableObject(Association association, string suffix)
        {
            if (association.Properties.Count <= 0)
                return false;

            string key = String.Format("{0}{1}", association.ForeignEntity.EntityKeyName, suffix);
            if (ContextData.Get(key) == null) 
                return false;

            var value = ContextData[key];
            switch (value)
            {
                case Constants.SwitchableObject:
                    return true;
            }

            return false;
        }

        public bool IsNameValueListBusinessObject(Association association)
        {
            return IsNameValueListBusinessObject(association, String.Empty);
        }

        public bool IsNameValueListBusinessObject(Association association, string suffix)
        {
            if (association.Properties.Count <= 0)
                return false;

            string key = String.Format("{0}{1}", association.ForeignEntity.EntityKeyName, suffix);
            if (ContextData.Get(key) == null) 
                return false;

            var value = ContextData[key];
            switch (value)
            {
                case Constants.NameValueList:
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Checks to see if a Business Object exists without a suffix.
        /// </summary>
        /// <param name="suffix">The Suffix</param>
        /// <param name="length"></param>
        /// <returns></returns>
        public bool BusinessClassNameExists(string suffix, int length)
        {
            if(!BusinessClassName.EndsWith(suffix, true, CultureInfo.InvariantCulture))
                return false;

            if (Entity.Name == BusinessClassName.Substring(0, BusinessClassName.Length - length))
                return BusinessObjectExists(String.Empty);

            return BusinessObjectExists(BusinessClassName.Substring(BusinessClassName.Length - length, length));
        }

        /// <summary>
        /// This is used to detect to see if the context data contains a class. It is used in the case where we want to see if a read-write class exists before a read only..
        /// </summary>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public bool BusinessObjectExists(string suffix)
        {
            if (Entity == null)
                return false;

            string key = String.Format("{0}{1}", Entity.EntityKeyName, suffix);

            return ContextData.Get(key) != null;
        }

        /// <summary>
        /// This is used to detect to see if the context data contains a class. It is used in the case where we want to see if a read-write class exists before a read only..
        /// </summary>
        /// <param name="association"></param>
        /// <returns></returns>
        public bool BusinessObjectExists(Association association)
        {
            return BusinessObjectExists(association, String.Empty);
        }

        /// <summary>
        /// This is used to detect to see if the context data contains a class. It is used in the case where we want to see if a read-write class exists before a read only..
        /// </summary>
        /// <param name="association"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        public bool BusinessObjectExists(Association association, string suffix)
        {
            if (association.Properties.Count <= 0)
                return false;

            string key = String.Format("{0}{1}", association.Entity.EntityKeyName, suffix);

            return ContextData.Get(key) != null;
        }

        #endregion

        #region Procedure Naming

        public virtual string GetInsertStoredProcedureName()
        {
            return String.Format("{0}[{1}{2}_Insert]", GetTableOwner(), ProcedurePrefix, Entity.Name);
        }

        public virtual string GetInsertStoredProcedureShortName()
        {
            return String.Format("{0}{1}_Insert", ProcedurePrefix, Entity.Name);
        }

        public virtual string GetUpdateStoredProcedureName()
        {
            return String.Format("{0}[{1}{2}_Update]", GetTableOwner(), ProcedurePrefix, Entity.Name);
        }

        public virtual string GetUpdateStoredProcedureShortName()
        {
            return String.Format("{0}{1}_Update", ProcedurePrefix, Entity.Name);
        }

        public virtual string GetDeleteStoredProcedureName()
        {
            return String.Format("{0}[{1}{2}_Delete]", GetTableOwner(), ProcedurePrefix, Entity.Name);
        }

        public virtual string GetDeleteStoredProcedureShortName()
        {
            return String.Format("{0}{1}_Delete", ProcedurePrefix, Entity.Name);
        }

        public virtual string GetSelectStoredProcedureName()
        {
            if (Entity is CommandEntity)
                return String.Format("[{0}].[{01}]", Entity.SchemaName, Entity.EntityKeyName);

            return String.Format("{0}[{1}{2}_Select]", GetTableOwner(), ProcedurePrefix, Entity.Name);
        }

        public virtual string GetSelectStoredProcedureShortName()
        {
            return String.Format("{0}{1}_Select", ProcedurePrefix, Entity.Name);
        }

        #endregion

        #region Render Helpers

        public void RenderToFileHelper<T>(string filePath, IMergeStrategy strategy) where T : EntityCodeTemplate, new()
        {
            var template = this.Create<T>();
            CopyPropertiesTo(template, true, PropertyIgnoreList);
            
            template.RenderToFile(filePath, strategy);
        }

        public void RenderToFileHelper<T>(string filePath) where T : EntityCodeTemplate, new()
        {
            RenderToFileHelper<T>(filePath, true);
        }

        public void RenderToFileHelper<T>(string filePath, bool overwrite) where T : EntityCodeTemplate, new()
        {
            var template = this.Create<T>();
            CopyPropertiesTo(template, true, PropertyIgnoreList);

            if (!overwrite)
            {
                if (!File.Exists(filePath))
                    template.RenderToFile(filePath, false);
            }
            else
                template.RenderToFile(filePath, true);
        }

        public void RenderToFileHelper<T>(string filePath, string dependentUpon) where T : EntityCodeTemplate, new()
        {
            RenderToFileHelper<T>(filePath, dependentUpon, true);
        }

        public void RenderToFileHelper<T>(string filePath, string dependentUpon, bool overwrite) where T : EntityCodeTemplate, new()
        {
            var template = this.Create<T>();
            CopyPropertiesTo(template, true, PropertyIgnoreList);

            if (!overwrite)
            {
                if (!File.Exists(filePath))
                    template.RenderToFile(filePath, dependentUpon, false);
            }
            else
                template.RenderToFile(filePath, dependentUpon, true);
        }

        public void RenderProceduresToFileHelper<T>(string filePath, string dependentUpon, bool overwrite) where T : DataCodeTemplate, new()
        {
            RenderProceduresToFileHelper<T>(filePath, dependentUpon, overwrite, false, false);
        }

        public void RenderProceduresToFileHelper<T>(string filePath, string dependentUpon, bool overwrite, bool readOnly, bool collection) where T : DataCodeTemplate, new()
        {
            if (!Entity.HasKey)
                return;

            if(Entity is CommandEntity || Entity is ViewEntity)
                return;

            var template = this.Create<T>();
            CopyPropertiesTo(template, true, PropertyIgnoreList);
            template.DataProjectName = "Not needed for sql stored procedures.";
            template.SetProperty("IncludeInsert", Entity.CanInsert && !readOnly && !collection);
            template.SetProperty("IncludeUpdate", Entity.CanUpdate && !readOnly && !collection);
            template.SetProperty("IncludeDelete", Entity.CanDelete && !readOnly && !collection);

            if (!overwrite)
            {
                if (!File.Exists(filePath))
                    template.RenderToFile(filePath, dependentUpon, false);
            }
            else
                template.RenderToFile(filePath, dependentUpon, true);
        }
        #endregion
    }
}
