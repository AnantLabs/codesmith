//------------------------------------------------------------------------------
//
// Copyright (c) 2002-2006 CodeSmith Tools, LLC.  All rights reserved.
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
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace CodeSmith.Samples
{
	public class ModalEditorPropertyEditor : UITypeEditor
	{
		private IWindowsFormsEditorService editorService = null;
		private ModalEditorPropertyEditorForm _modalEditorPropertyEditorForm = null;
		
		public ModalEditorPropertyEditor(): base()
		{
		}
		
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) 
		{
			if (provider != null) 
			{
				editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
				if (editorService != null) 
				{
					if (_modalEditorPropertyEditorForm == null) _modalEditorPropertyEditorForm = new ModalEditorPropertyEditorForm();
					_modalEditorPropertyEditorForm.Start(editorService, value);
					editorService.ShowDialog(_modalEditorPropertyEditorForm);
					if (_modalEditorPropertyEditorForm.DialogResult == DialogResult.OK)
					{
						value = new ModalEditorProperty(_modalEditorPropertyEditorForm.SampleStringTextBox.Text, _modalEditorPropertyEditorForm.SampleBooleanCheckBox.Checked);
					}
					else
					{
						value = null;
					}
				}
			}
			
			return value;
		}
		
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) 
		{
			return UITypeEditorEditStyle.Modal;
		}
	}
}
