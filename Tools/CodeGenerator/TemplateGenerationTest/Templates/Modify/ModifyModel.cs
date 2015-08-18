

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemplateGenerationTest.Models
{
	public class ModifyModel
	{
		[Display(Name="Input Column 1")]
		public System.String InputColumn1 { get; set; }

		[Display(Name="Input Column 2")]
		public System.String InputColumn2 { get; set; }

		[Display(Name="Input Column 12")]
		public System.String InputColumn3 { get; set; }

	}
}