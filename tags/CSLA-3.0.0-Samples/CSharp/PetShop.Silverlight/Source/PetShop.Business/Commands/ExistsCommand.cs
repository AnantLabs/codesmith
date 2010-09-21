﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v3.0.0.0, CSLA Framework: v4.0.0.
//     Changes to this file will be lost after each regeneration.
//
//     Template: ExistsCommand.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

#if SILVERLIGHT
using Csla;
using Csla.Serialization;
#else
using System.Data.SqlClient;

using Csla;
using Csla.Data;
#endif

#endregion

namespace PetShop.Business
{
    [Serializable]
    public class ExistsCommand : CommandBase<ExistsCommand>
    {
        #region Constructor(s)

        private ExistsCommand()
        {
        }
        
        #endregion

        #region Authorization Methods

        public static bool CanExecuteCommand()
        {
            return true;
        }

        #endregion

        #region Synchronous Factory Methods 

#if !SILVERLIGHT
        public static bool Execute<T>(T criteria) where T : PetShop.Business.IGeneratedCriteria
        {
            if (!CanExecuteCommand())
                throw new System.Security.SecurityException("Not authorized to execute command");

            var cmd = new ExistsCommand();
            cmd.BeforeServer(criteria);
            cmd = DataPortal.Execute(cmd);
            cmd.AfterServer();

            return cmd.Result;
        }
#endif  

        #endregion

        #region Asynchronous Factory Methods

#if SILVERLIGHT
        public static bool Execute<T>(T criteria) where T : PetShop.Business.IGeneratedCriteria
        {
            if (!CanExecuteCommand())
                throw new System.Security.SecurityException("Not authorized to execute command");

            var cmd = new ExistsCommand();
            cmd.BeforeServer(criteria);

            var waitHandle = new System.Threading.ManualResetEvent(false);
            DataPortal.BeginExecute(cmd, (o, e) =>
                    {
                        if (e.Error != null) 
                            throw e.Error;
                        
                        cmd.Result = e.Object.Result;

                        waitHandle.Set();
                    });
                
            cmd.AfterServer();

            bool result = waitHandle.WaitOne(30000);
            if (result)
                return cmd.Result;
            
            throw new Exception("Exists timed out.");
        }
#endif  
        
        #endregion

        #region Client-side Code

        private PetShop.Business.IGeneratedCriteria Criteria { get; set; }
        private bool Result { get; set; }

        private void BeforeServer(PetShop.Business.IGeneratedCriteria criteria)
        {
            Criteria = criteria;
            Result = false;
        }

        private void AfterServer()
        {
        }

        #endregion

        #region Data Access

#if !SILVERLIGHT
        protected override void DataPortal_Execute()
        {
            string commandText = string.Format("SELECT COUNT(1) FROM {0} {1}", Criteria.TableFullName, ADOHelper.BuildWhereStatement(Criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(Criteria.StateBag));
                    Result = (int)command.ExecuteScalar() > 0;
                }
            }
        }
#endif

        #endregion
    }
}