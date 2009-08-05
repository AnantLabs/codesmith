
'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated Imports CSLA 3.7.X CodeSmith Templates.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'ProfileList.vb.
'
'     Template: EditableRootList.DataAccess.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Data

Imports PetShop.Data

Public Partial Class ProfileList

	#Region "Data Access"
	
    '<RunLocal()> _
	'Protected Sub DataPortal_Create()
    'End Sub
    
    Private Shadows Sub DataPortal_Fetch(ByVal criteria As ProfileCriteria)
	    RaiseListChangedEvents = False
        
        Using reader As SafeDataReader = DataAccessLayer.Instance.ProfileFetch(criteria.StateBag)
            While reader.Read()
	            Me.Add(New PetShop.Business.Profile(reader))
			End While
        End Using
        
        RaiseListChangedEvents = True
    End Sub

	#End Region
    
End Class