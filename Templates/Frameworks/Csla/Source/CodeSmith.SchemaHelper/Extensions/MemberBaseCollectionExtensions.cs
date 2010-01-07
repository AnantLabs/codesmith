﻿using System;
using System.Collections.Generic;
using System.Linq;

using CodeSmith.SchemaHelper.Util;

namespace CodeSmith.SchemaHelper
{
    /// <summary>
    /// Extension Methods for MemberBaseCollectionExtensions
    /// </summary>
    public static class MemberBaseCollectionExtensions
    {
        public static List<SearchCriteria> ListSearchCriteria(this List<MemberBase> members)
        {
            List<SearchCriteria> searchCriterias = new List<SearchCriteria>();

            foreach (var member in members)
            {
                string memberName = member.Name;
                searchCriterias.AddRange(member.SearchCriteria.Where(sc => !sc.IsUniqueResult && sc.MethodName.Contains(memberName)));
            }

            return searchCriterias;
        }

        public static string BuildInsertDataBaseColumns(this List<MemberBase> members)
        {
            string columnNames = string.Empty;

            foreach (MemberBase member in members)
            {
                if (!member.IsIdentity)
                    columnNames += string.Format(", [{0}]", member.ColumnName);
            }

            return columnNames.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildInsertParametersVariables(this List<MemberBase> members)
        {
            return members.BuildInsertParametersVariables(true);
        }

        public static string BuildInsertParametersVariables(this List<MemberBase> members, bool isNullable)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                if ( !member.IsIdentity )
                {
                    string systemType = isNullable ? member.SystemType : member.SystemType.TrimEnd( new[] {'?'} );

                    if (Configuration.Instance.TargetLanguage == LanguageEnum.VB)
                        parameters += string.Format(", ByVal {0} As {1}", member.VariableName, systemType);
                    else
                        parameters += string.Format(", {0} {1}", systemType, member.VariableName);
                }
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildInsertReadPropertyParametersVariables(this List<MemberBase> members)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                if (!member.IsIdentity)
                {
                    string name = member.Entity.ResolveCriteriaPrivateMemberVariableName(member.ColumnName);
                    if (name == NamingConventions.PrivateMemberVariableName(member.ColumnName))
                    {
                        foreach (AssociationMember association in member.Entity.OneToMany)
                        {

                            if (association.ColumnName == member.ColumnName)
                            {
                                name = NamingConventions.PrivateMemberVariableName(association.ColumnName);
                                break;
                            }
                        }
                    }
                    parameters += string.Format(", ReadProperty({0}Property)", name);
                }
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildInsertPrivateMemberVariableParameters(this List<MemberBase> members)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                if (!member.IsIdentity)
                {
                    string name = member.Entity.ResolveCriteriaPrivateMemberVariableName(member.ColumnName);
                    if (name == NamingConventions.PrivateMemberVariableName(member.ColumnName))
                    {
                        foreach (AssociationMember association in member.Entity.OneToMany)
                        {
                            if (association.ColumnName == member.ColumnName)
                            {
                                name = NamingConventions.PrivateMemberVariableName(association.LocalColumn.Name);
                                break;
                            }
                        }
                    }

                    parameters += string.Format(", {0}", name);
                }
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildInsertDataBaseParameters(this List<MemberBase> members)
        {
            string columnNames = string.Empty;

            foreach (MemberBase member in members)
            {
                if (!member.IsIdentity)
                    columnNames += string.Format(", {0}{1}", Configuration.Instance.ParameterPrefix, member.ColumnName);
            }

            return columnNames.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildInsertCommandParameters(this List<MemberBase> members)
        {
            string commandParameters = string.Empty;

            foreach (MemberBase member in members)
            {
                if (!member.IsIdentity)
                {

                    string cast = string.Empty;
                    if (member.SystemType.Contains("SmartDate"))
                    {
                        if (Configuration.Instance.TargetLanguage == LanguageEnum.VB)
                            cast = member.IsNullable
                                       ? string.Format("IIf({0}.HasValue, DirectCast({0}.Value.Date, DateTime), System.DBNull.Value))", member.VariableName)
                                       : string.Format("DirectCast({0}.Date, DateTime))", member.PropertyName);
                        else 
                            cast = member.IsNullable
                                       ? string.Format("(DateTime?){0});", member.PropertyName)
                                       : string.Format("(DateTime){0});", member.PropertyName);
                    }
                    else
                        cast = Configuration.Instance.TargetLanguage == LanguageEnum.VB
                                   ? string.Format("{0})", member.PropertyName)
                                   : string.Format("{0});", member.PropertyName);

                    commandParameters += string.Format("\n\t\t\t\t\t\tcommand.Parameters.AddWithValue(\"{0}{1}\", {2}", Configuration.Instance.ParameterPrefix, member.ColumnName, cast);
                }
            }

            return commandParameters.TrimStart(new[] { '\t', '\n' });
        }


        public static string BuildParametersVariables(this List<MemberBase> members)
        {
            return members.BuildParametersVariables(true);
        }

        public static string BuildParametersVariables(this List<MemberBase> members, bool isNullable)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                string systemType = isNullable ? member.SystemType : member.SystemType.TrimEnd(new[] { '?' });

                if (Configuration.Instance.TargetLanguage == LanguageEnum.VB)
                    parameters += string.Format(", ByVal {0} As {1}", member.VariableName, systemType);
                else
                    parameters += string.Format(", {0} {1}", systemType, member.VariableName);
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildParametersVariablesCriteria(this List<MemberBase> members)
        {
            return members.BuildParametersVariablesCriteria(true);
        }

        public static string BuildParametersVariablesCriteria(this List<MemberBase> members, bool isNullable)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                string systemType = isNullable ? member.SystemType : member.SystemType.TrimEnd(new[] { '?' });

                if (Configuration.Instance.TargetLanguage == LanguageEnum.VB)
                    parameters += string.Format(", ByVal {0} As {1}", member.Entity.ResolveCriteriaVariableName(member.ColumnName), systemType);
                else
                    parameters += string.Format(", {0} {1}", systemType, member.Entity.ResolveCriteriaVariableName(member.ColumnName));
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildObjectInitializer(this List<MemberBase> members)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                parameters += string.Format(", {0} = {1}", member.PropertyName, member.VariableName);
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildCriteriaObjectInitializer(this List<MemberBase> members, string className)
        {
            return BuildCriteriaObjectInitializer(members, className, false);
        }

        public static string BuildCriteriaObjectInitializer(this List<MemberBase> members, string className, bool isObjectFactory)
        {
            string parameters = string.Empty;
            
            foreach (MemberBase member in members)
            {
                string name = isObjectFactory ? string.Format("item.{0}", member.Entity.ResolveCriteriaPropertyName(member.ColumnName)) : member.Entity.ResolveCriteriaVariableName(member.ColumnName);

                parameters += string.Format(", {0} = {1}", member.Entity.ResolveCriteriaPropertyName(member.ColumnName, className), name);
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildVariableArguments(this List<MemberBase> members)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                parameters += string.Format(", {0}", member.VariableName);
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildPropertyVariableArguments(this List<MemberBase> members)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                parameters += string.Format(", {0}", member.PropertyName);
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildCriteriaParametersVariables(this List<MemberBase> members)
        {
            return BuildCriteriaParametersVariables(members, "criteria");
        }

        public static string BuildCriteriaParametersVariables(this List<MemberBase> members, string criteria)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                parameters += string.Format(", {0}.{1}", criteria, member.PropertyName);
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildReadPropertyParametersVariables(this List<MemberBase> members)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                parameters += string.Format(", ReadProperty({0}Property)", member.Entity.ResolveCriteriaPrivateMemberVariableName(member.ColumnName));
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildPrivateMemberBaseVariableParameters(this List<MemberBase> members)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                parameters += string.Format(", {0}", member.PrivateMemberVariableName);
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildDataBaseColumns(this List<MemberBase> members)
        {
            string columnNames = string.Empty;

            foreach (MemberBase member in members)
            {
                columnNames += string.Format(", [{0}]", member.ColumnName);
            }

            return columnNames.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildDataBaseParameters(this List<MemberBase> members)
        {
            string columnNames = string.Empty;

            foreach (MemberBase member in members)
            {
                columnNames += string.Format(", {0}{1}",  Configuration.Instance.ParameterPrefix, member.Name);
            }

            return columnNames.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildCommandParameters(this List<MemberBase> members)
        {
            string commandParameters = string.Empty;

            foreach (MemberBase member in members)
            {
                string cast;
                if (member.SystemType.Contains("SmartDate"))
                {
                    if (Configuration.Instance.TargetLanguage == LanguageEnum.VB)
                        cast = member.IsNullable ? string.Format("IIf({0}.HasValue, DirectCast({0}.Value.Date, DateTime), System.DBNull.Value))", member.PropertyName)
                                                 : string.Format("DirectCast({0}.Date, DateTime))", member.PropertyName);
                    else
                        cast = member.IsNullable ? string.Format("(DateTime?){0});", member.PropertyName)
                                                 : string.Format("(DateTime){0});", member.PropertyName);
                }
                else
                    cast = Configuration.Instance.TargetLanguage == LanguageEnum.VB ? string.Format("{0})", member.PropertyName) : string.Format("{0});", member.PropertyName);

                commandParameters += string.Format("\n\t\t\t\t\t\tcommand.Parameters.AddWithValue(\"{0}{1}\", {2}", Configuration.Instance.ParameterPrefix, member.ColumnName, cast);
            }

            return commandParameters.TrimStart(new[] { '\t', '\n' });
        }

        public static string BuildSetStatements(this List<MemberBase> members)
        {
            string setStatements = "\t\t\t\t\t\t SET";

            foreach (MemberBase member in members)
            {
                setStatements += string.Format(" [{0}] = {1}{2},", member.Name, Configuration.Instance.ParameterPrefix, member.VariableName);
            }

            return setStatements.TrimStart(new[] { '\t', '\n' }).TrimEnd(new[] { ',' });
        }

        public static string BuildWhereStatements(this List<MemberBase> members)
        {
            string columnNames = string.Empty;

            foreach (MemberBase member in members)
            {
                columnNames += string.Format("[{0}] = {1} AND ", member.ColumnName, member.BuildParameterVariableName());
            }

            return string.Format("WHERE {0}", columnNames.Remove(columnNames.Length - 5, 5));
        }

        public static string BuildPrivateMemberVariableParameters(this List<MemberBase> members)
        {
            string parameters = string.Empty;

            foreach (MemberBase member in members)
            {
                parameters += string.Format(", {0}", member.Entity.ResolveCriteriaPrivateMemberVariableName(member.ColumnName));
            }

            return parameters.TrimStart(new[] { ',', ' ' });
        }

        public static string BuildReaderStatements(this List<MemberBase> members)
        {
            string columnNames = string.Empty;

            foreach (MemberBase member in members)
            {
                columnNames += string.Format(", reader.{0}(\"{1}\")", member.GetReaderMethod(), member.Name);
            }

            return columnNames.TrimStart(new[] { ',', ' ' });
        }

        public static bool HasByteArrayColumn(this List<MemberBase> members)
        {
            foreach (MemberBase member in members)
            {
                if (member.HasByteArrayColumn())
                    return true;
            }

            return false;
        }
    }
}
